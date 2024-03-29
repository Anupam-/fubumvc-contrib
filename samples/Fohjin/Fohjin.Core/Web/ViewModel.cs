using Fohjin.Core.Domain;
using Fohjin.Core.Web.DisplayModels;

namespace Fohjin.Core.Web
{
    public class ViewModel
    {
        public string SiteName { get; set; }
        public string LanguageDefault { get; set; }
        public string SEORobots { get; set; }
        public User CurrentUser { get; set; }
        public RecentPostsDisplay RecentPosts { get; set; }
    }
}