using System.Collections.Generic;
using System.Linq;
using Fohjin.Core.Domain;
using Fohjin.Core.Persistence;
using Fohjin.Core.Services;
using Fohjin.Core.Web.Controllers;
using FubuMVC.Core.Controller.Config;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace Fohjin.Tests.Web.Controllers
{
    [TestFixture]
    public class BlogPostControllerTester
    {
        private IRepository _repository;
        private BlogPostController _controller;
        private IBlogPostCommentService _blogPostCommentService;
        private IUserService _userService;
        private IList<Post> _posts;
        private IUrlResolver _resolver;
        private Post _post;
        private string _testSlug;

        [SetUp]
        public void SetUp()
        {
            _posts = new List<Post>();
            _repository = MockRepository.GenerateStub<IRepository>();
            _resolver = MockRepository.GenerateStub<IUrlResolver>();
            _blogPostCommentService = MockRepository.GenerateStub<IBlogPostCommentService>();
            _userService = MockRepository.GenerateStub<IUserService>();
            _controller = new BlogPostController(_repository, _resolver, _blogPostCommentService, _userService);

            _testSlug = "TESTSLUG";

            _post = new Post { Slug = _testSlug };
            _posts.Add(_post);
        }

        [Test]
        public void index_should_do_nothing_but_just_render_the_view_if_nothing_was_supplied()
        {
            var output = _controller.Index(new BlogPostViewModel());
            
            output.Post.ShouldBeNull();
            _repository.AssertWasNotCalled(r=>r.Query<Post>());
        }

        [Test]
        public void should_do_nothing_repository_returns_no_results_for_query()
        {
            _repository.Stub(r => r.Query<Post>(null)).IgnoreArguments().Return(new Post[0].AsQueryable());

            var output = _controller.Index(new BlogPostViewModel {Slug = "badslug"});
    
            output.Post.ShouldBeNull();
        }
    }

    [TestFixture]
    public class BlogPostController_when_an_anonymous_user_adds_a_comment
    {
        private IRepository _repository;
        private BlogPostController _controller;
        private IBlogPostCommentService _blogPostCommentService;
        private IUserService _userService;
        private string _testSlug;
        private BlogPostCommentViewModel _validInput;
        private BlogPostCommentViewModel _invalidInput;
        private IList<Post> _posts;
        private IList<User> _users;
        private IUrlResolver _resolver;
        private Post _post;

        [SetUp]
        public void SetUp()
        {
            _posts = new List<Post>();
            _users = new List<User>();
            _repository = MockRepository.GenerateStub<IRepository>();
            _resolver = MockRepository.GenerateStub<IUrlResolver>();
            _blogPostCommentService = MockRepository.GenerateStub<IBlogPostCommentService>();
            _userService = MockRepository.GenerateStub<IUserService>();
            _controller = new BlogPostController(_repository, _resolver, _blogPostCommentService, _userService);
            
            _post = new Post { Slug = _testSlug };
            _posts.Add(_post);

            _repository
               .Stub(r => r.Query<Post>(null))
               .IgnoreArguments()
               .Return(_posts.AsQueryable());

            _repository
               .Stub(r => r.Query<User>(null))
               .IgnoreArguments()
               .Return(_users.AsQueryable());

            _testSlug = "TESTSLUG";

            _invalidInput = new BlogPostCommentViewModel {Slug = _testSlug};
            
            _validInput = new BlogPostCommentViewModel
            {
                DisplayName = "username",
                Email = "email",
                Body = "body",
                Subscribed = true,
                Slug = _testSlug
            };
        }

        [Test]
        public void should_load_the_post_by_the_given_slug()
        {
            _controller.Comment(_validInput);

            _repository.AssertWasCalled(
                r=>r.Query<Post>(null),
                o => o.Constraints(Property.Value("Slug", _testSlug)));
        }
    }

    [TestFixture]
    public class UserService_when_creating_a_new_anonymous_user
    {
        private IRepository _repository;
        private User _curUser;
        private IList<User> _users;
        private IUserService _userService;
        private string GivenUserDisplayName;
        private string GivenUserEmail;
        private string GivenUserUrl;
        private string GivenTwitterUserName;

        [SetUp]
        public void SetUp()
        {
            _users = new List<User>();

            _repository = MockRepository.GenerateStub<IRepository>();
            _userService = new UserService(_repository);

            _curUser = null;

            _repository.Stub(r => r.Query<User>(null)).IgnoreArguments().Return(_users.AsQueryable());

            GivenUserDisplayName = "username";
            GivenUserEmail = "email";
            GivenUserUrl = "www";
            GivenTwitterUserName = "name";

            _curUser = _userService.AddOrUpdateUser(GivenUserEmail, GivenUserDisplayName, GivenUserUrl, GivenTwitterUserName);
        }

        public User CreatedUser
        {
            get
            {
                if( _curUser == null )
                {
                    _curUser = _userService.AddOrUpdateUser(GivenUserEmail, GivenUserDisplayName, GivenUserUrl, GivenTwitterUserName);
                }
                return _curUser;
            }
        }

        [Test]
        public void the_user_should_have_been_created()
        {
            CreatedUser.ShouldNotBeNull();
        }

        [Test]
        public void the_user_should_be_anonymous()
        {
            CreatedUser.IsAuthenticated.ShouldBeFalse();
        }

        [Test]
        public void should_have_a_hashed_gravatar_email()
        {
            CreatedUser.HashedEmail.ShouldNotBeNull();
            CreatedUser.HashedEmail.ShouldNotEqual(GivenUserEmail);
        }

        [Test]
        public void should_have_a_url()
        {
            CreatedUser.Url.ShouldNotBeNull();
            CreatedUser.Url.ShouldContain(GivenUserUrl);
        }
    }

    [TestFixture]
    public class BlogPostController_when_updating_an_anonymous_user_for_new_comment
    {
        private IRepository _repository;
        private IList<User> _users;
        private IUserService _userService;
        private string GivenUserDisplayName;
        private string GivenUserEmail;
        private string GivenUserUrl;
        private string GivenTwitterUserName;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _users = new List<User>
            { 
                new User
                {
                    DisplayName = "prev_username",
                    Url = "prev_url"
                }
            };

            _repository = MockRepository.GenerateStub<IRepository>();
            _userService = new UserService(_repository);

            _repository.Stub(r => r.Query<User>(null)).IgnoreArguments().Return(_users.AsQueryable());

            GivenUserDisplayName = "username";
            GivenUserEmail = "email";
            GivenUserUrl = "url";
            GivenTwitterUserName = "name";

            _user = _userService.AddOrUpdateUser(GivenUserEmail, GivenUserDisplayName, GivenUserUrl, GivenTwitterUserName);
        }

        public BlogPostCommentViewModel Given { get; set; }

        [Test]
        public void the_display_name_should_have_been_updated()
        {
            _user.DisplayName.ShouldEqual(GivenUserDisplayName);
        }

        [Test]
        public void the_url_should_have_been_updated()
        {
            _user.Url.ShouldContain(GivenUserUrl);
        }
    }
}