using System.Linq;
using System.Web.Security;
using Fohjin.Core.Domain;
using Fohjin.Core.Persistence;
using FubuMVC.Core;

namespace Fohjin.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public User AddOrUpdateUser(string userEmail, string userDisplayName, string userUrl, string twitterUserName)
        {
            var user = _repository.Query(new UserByEmail(userEmail)).SingleOrDefault() 
                ?? new User
                {
                    Username = userDisplayName,
                    IsAuthenticated = false,
                    UserRole = UserRoles.NotAuthenticated,
                    Email = userEmail,
                    HashedEmail = GenerateGravatarHash(userEmail),
                    TwitterUserName = twitterUserName,
                };

            if (!user.IsAuthenticated)
            {
                user.DisplayName = userDisplayName;
                user.Url = !string.IsNullOrEmpty(userUrl) 
                    ? (userUrl.StartsWith("http://") || userUrl.StartsWith("https://")) 
                        ? userUrl 
                        : "http://{0}".ToFormat(userUrl)
                    : "";
            }

            _repository.Save(user);
            return user;
        }

        private static string GenerateGravatarHash(string emailAddress)
        {
            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(emailAddress.Trim().ToLower(), "MD5");
            return (hash != null) ? hash.Trim().ToLower() : "";
        }
    }
}