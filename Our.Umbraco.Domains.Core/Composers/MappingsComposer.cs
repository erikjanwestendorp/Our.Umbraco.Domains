using Our.Umbraco.Domains.Core.Mappings;
using Umbraco.Core.Composing;
using Umbraco.Core.Mapping;

namespace Our.Umbraco.Domains.Core.Composers
{
    public class MappingsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
                .Add<DomainMappings>()
                .Add<ContentMappings>();
        }
    }
}
