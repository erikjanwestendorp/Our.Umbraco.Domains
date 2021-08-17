using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.Domains
{
    public class DomainsComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddDomains();
        }
    }
}
