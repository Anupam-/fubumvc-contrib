using System;
using AltOxite.Core.Domain;
using AltOxite.Core.Persistence;

namespace AltOxite.Core.Config
{
    public class DefaultApplicationFirstRunHandler : IApplicationFirstRunHandler
    {
        private readonly IRepository _repository;
        private readonly ISessionSourceConfiguration _sourceConfig;
        private readonly IUnitOfWork _unitOfWork;
        private static bool _isInitialized;

        public DefaultApplicationFirstRunHandler(ISessionSourceConfiguration sourceConfig, IUnitOfWork unitOfWork, IRepository repository)
        {
            _sourceConfig = sourceConfig;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public bool IsInitialized
        {
            get { return _isInitialized; }
            set { _isInitialized = value; }
        }

        public void InitializeIfNecessary()
        {
            if (!_sourceConfig.IsNewDatabase || IsInitialized) return;

            var user = setup_admin_user();
            setup_sample_post(user);
            _unitOfWork.Commit();

            IsInitialized = true;
        }

        private User setup_admin_user()
        {
            var defaultUser = new User
            {
                Username = "Admin",
                Password = "pa$$w0rd",
                DisplayName = "Oxite Administrator",
                HashedEmail = "01d418308faffa0d07f34ace68b686ad",
                UserRole = UserRoles.SiteUser
            };

            _repository.Save(defaultUser);
            return defaultUser;
        }

        private void setup_sample_post(User user)
        {
            var oxiteTag = new Tag {Name = "Oxite", CreatedDate = DateTime.Parse("12 NOV 2008")};

            var defaultPost = new Post
            {
                Title = "World.Hello()",
                Slug = "World_Hello",
                BodyShort = "Welcome to Oxite! &nbsp;This is a sample application targeting developers built on <a href=\"http://asp.net/mvc\">ASP.NET MVC</a>. &nbsp;Make any changes you like. &nbsp;If you build a feature you think other developers would be interested in and would like to share your code go to the <a href=\"http://www.codeplex.com/oxite\">Oxite Code Plex project</a> to see how you can contribute.<br /><br />To get started, sign in with \"Admin\" and \"pa$$w0rd\" and click on the Admin tab.<br /><br />For more information about <a href=\"http://oxite.net\">Oxite</a> visit the default <a href=\"/About\">About</a> page.",
                Body = "Welcome to Oxite! &nbsp;This is a sample application targeting developers built on <a href=\"http://asp.net/mvc\">ASP.NET MVC</a>. &nbsp;Make any changes you like. &nbsp;If you build a feature you think other developers would be interested in and would like to share your code go to the <a href=\"http://www.codeplex.com/oxite\">Oxite Code Plex project</a> to see how you can contribute.<br /><br />To get started, sign in with \"Admin\" and \"pa$$w0rd\" and click on the Admin tab.<br /><br />For more information about <a href=\"http://oxite.net\">Oxite</a> visit the default <a href=\"/About\">About</a> page.",
                Published = DateTime.Parse("2008-12-05 09:29:03.270"),
                User = user
            };
            defaultPost.AddTag(oxiteTag);

            _repository.Save(defaultPost);

            var defaultPost1 = new Post
            {
                Title = "World.Hello()",
                Slug = "World_Hello2",
                BodyShort = "Welcome to Oxite! &nbsp;This is a sample application targeting developers built on <a href=\"http://asp.net/mvc\">ASP.NET MVC</a>. &nbsp;Make any changes you like. &nbsp;If you build a feature you think other developers would be interested in and would like to share your code go to the <a href=\"http://www.codeplex.com/oxite\">Oxite Code Plex project</a> to see how you can contribute.<br /><br />To get started, sign in with \"Admin\" and \"pa$$w0rd\" and click on the Admin tab.<br /><br />For more information about <a href=\"http://oxite.net\">Oxite</a> visit the default <a href=\"/About\">About</a> page.",
                Body = "Welcome to Oxite! &nbsp;This is a sample application targeting developers built on <a href=\"http://asp.net/mvc\">ASP.NET MVC</a>. &nbsp;Make any changes you like. &nbsp;If you build a feature you think other developers would be interested in and would like to share your code go to the <a href=\"http://www.codeplex.com/oxite\">Oxite Code Plex project</a> to see how you can contribute.<br /><br />To get started, sign in with \"Admin\" and \"pa$$w0rd\" and click on the Admin tab.<br /><br />For more information about <a href=\"http://oxite.net\">Oxite</a> visit the default <a href=\"/About\">About</a> page.",
                Published = DateTime.Parse("2008-12-05 09:29:03.270"),
                User = user
            };
            defaultPost1.AddTag(oxiteTag);
            defaultPost1.AddTag(new Tag { Name = "AltOxite", CreatedDate = DateTime.Parse("30 DEC 2008") });
            defaultPost1.AddComment(new Comment { Post = defaultPost1, User = user, Body = "test comment", Published = DateTime.Parse("31 DEC 2008") });

            _repository.Save(defaultPost1);
        }
    }
}