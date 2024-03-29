using AltOxite.Core.Config;
using AltOxite.Core.Domain;
using AltOxite.Core.Domain.Persistence;
using AltOxite.Core.Persistence;
using AltOxite.Core.Security;
using AltOxite.Core.Services;
using AltOxite.Core.Web.Controllers;
using AltOxite.Core.Web.FeedConvertors;
using FluentNHibernate.Framework;
using FubuMVC.Core.Controller;
using FubuMVC.Core.Security;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;
using IRepository = AltOxite.Core.Persistence.IRepository;

namespace AltOxite.Web
{
    public class AltOxiteWebRegistry : Registry
    {
        public AltOxiteWebRegistry()
        {
            ForRequestedType<ISessionSourceConfiguration>().AsSingletons()
                .TheDefault.Is.OfConcreteType<SQLiteSessionSourceConfiguration>()
                .WithCtorArg("db_file_name")
                    .EqualToAppSetting("AltOxite.sql_lite_db_file_name");

            ForRequestedType<ICookieHandler>().AsSingletons()
                .TheDefault.Is.OfConcreteType<CookieHandler>()
                .WithCtorArg("cookie_path")
                    .EqualToAppSetting("AltOxite.cookie_path_for_user_id");

            ForRequestedType<ISessionSource>().AsSingletons()
                .TheDefault.Is.ConstructedBy(ctx => 
                    ctx.GetInstance<ISessionSourceConfiguration>()
                    .CreateSessionSource(new AltOxitePersistenceModel()));

            ForRequestedType<IUnitOfWork>().TheDefault.Is.ConstructedBy(ctx => ctx.GetInstance<INHibernateUnitOfWork>());

            ForRequestedType<INHibernateUnitOfWork>().CacheBy(InstanceScope.Hybrid)
                .TheDefault.Is.OfConcreteType<NHibernateUnitOfWork>();

            ForRequestedType<IRepository>().TheDefault.Is.OfConcreteType<NHibernateRepository>();

            ForRequestedType<ISecurityDataService>().TheDefault.Is.OfConcreteType<SecurityDataService>();
            ForRequestedType<IPrincipalFactory>().TheDefault.Is.OfConcreteType<AltOxitePrincipalFactory>();
            ForRequestedType<IBlogPostCommentService>().TheDefault.Is.OfConcreteType<BlogPostCommentService>();
            ForRequestedType<IUserService>().TheDefault.Is.OfConcreteType<UserService>();
            ForRequestedType<IPostService>().TheDefault.Is.OfConcreteType<PostService>();
            ForRequestedType<ITagService>().TheDefault.Is.OfConcreteType<TagService>();

            ForRequestedType<IApplicationFirstRunHandler>()
                .TheDefault.Is.OfConcreteType<DefaultApplicationFirstRunHandler>();

            ForRequestedType<SiteConfiguration>()
                .AsSingletons()
                .TheDefault.Is.ConstructedBy(() =>
                    new SiteConfiguration()
                    .FromAppSetting("AltOxite.SiteConfiguration"));

            ForRequestedType<IFeedConverterFor<IndexViewModel>>()
                .TheDefault.Is.OfConcreteType<IndexViewModelFeedConvertor>();
        }
    }
}