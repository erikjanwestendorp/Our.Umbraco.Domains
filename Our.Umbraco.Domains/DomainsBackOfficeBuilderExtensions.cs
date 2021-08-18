using System.Linq;
using Our.Umbraco.Domains.Mappings;
using Our.Umbraco.Domains.Notifications;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Infrastructure.Persistence.Mappers;

namespace Our.Umbraco.Domains
{
    public static class DomainsBackOfficeBuilderExtensions
    {
        public static IUmbracoBuilder AddDomains(this IUmbracoBuilder builder)
        {
            // Add Notifications
            builder.AddNotificationHandler<ServerVariablesParsingNotification, VariablesHandler>();
            
            // Add Mappings
            builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
                .Add<DomainMappings>()
                .Add<ContentMappings>();

            return builder;
        }
    }
}
