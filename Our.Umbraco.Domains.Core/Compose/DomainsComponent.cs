using Our.Umbraco.Domains.Core.Controllers.Backoffice;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.JavaScript;

namespace Our.Umbraco.Domains.Core.Compose
{
    public class DomainsComponent : IComponent
    {
        public void Initialize()
        {
            InstallServerVars();
        }

        public void Terminate() { }

        private void InstallServerVars()
        {
            ServerVariablesParser.Parsing += ServerVariablesParser_Parsing;
        }

        private void ServerVariablesParser_Parsing(object sender, Dictionary<string, object> serverVars)
        {

            if (!serverVars.ContainsKey(Static.Constants.Keys.UmbracoUrls))
                throw new ArgumentException(Static.Constants.Exceptions.MissingUmbracoUrls);

            var umbracoUrlsObject = serverVars[Static.Constants.Keys.UmbracoUrls];
            if (umbracoUrlsObject == null)
                throw new ArgumentException(Static.Constants.Exceptions.NullUmbracoUrls);

            if (!(umbracoUrlsObject is Dictionary<string, object> umbracoUrls))
                throw new ArgumentException(Static.Constants.Exceptions.InvalidUmbracoUrls);

            if (HttpContext.Current == null)
                throw new InvalidOperationException(Static.Constants.Exceptions.HttpContextIsNull);

            var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()));
            umbracoUrls[Static.Constants.Keys.DomainsOverview] = urlHelper.GetUmbracoApiServiceBaseUrl<DomainController>(controller => controller.GetDomains());

        }
    }
}
