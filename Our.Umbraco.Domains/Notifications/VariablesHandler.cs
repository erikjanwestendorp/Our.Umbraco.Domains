using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Our.Umbraco.Domains.Controllers.Backoffice;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Our.Umbraco.Domains.Notifications
{
    public class VariablesHandler : INotificationHandler<ServerVariablesParsingNotification>
    {
        private readonly LinkGenerator _linkGenerator;
        public VariablesHandler(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public void Handle(ServerVariablesParsingNotification notification)
        {
            notification.ServerVariables.Add(Static.Constants.Package.Name, new Dictionary<string, object>
            {
                {Static.Constants.Keys.DomainsOverview, _linkGenerator.GetUmbracoApiServiceBaseUrl<DomainController>(controller => controller.GetDomains())}
            });
        }
    }
}
