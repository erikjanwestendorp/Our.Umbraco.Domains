namespace Our.Umbraco.Domains.Core.Static
{
    public static class Constants
    {
        public static class Defaults
        {
            public const string DomainsTreeAlias = "domains";
            public const string DomainsTreeTitle = "Domains";
            public const string DomainsAreaName = "domains";
            public const string TreeRoutePath = "/domains/dashboard";
        }

        public static class Icons
        {
            public const string Globe = "icon-globe-alt";
        }

        public static class Exceptions
        {
            public const string MissingUmbracoUrls = "Missing umbracoUrls.";
            public const string NullUmbracoUrls = "Null umbracoUrls";
            public const string InvalidUmbracoUrls = "Invalid umbracoUrls";
            public const string HttpContextIsNull = "HttpContext is null";
        }

        public static class Keys
        {
            public const string UmbracoUrls = "umbracoUrls";
            public const string DomainsOverview = "domainsOverview";
        }
    }
}
