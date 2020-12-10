using Our.Umbraco.Domains.Core.Mappings;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Mapping;

namespace Our.Umbraco.Domains.Core.Compose
{
    public class DomainsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<DomainsComponent>();

            composition.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
                .Add<DomainMappings>()
                .Add<ContentMappings>();
        }
    }
}
