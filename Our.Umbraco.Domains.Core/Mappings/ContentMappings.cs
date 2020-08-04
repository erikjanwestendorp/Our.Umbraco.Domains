using Our.Umbraco.Domains.Core.ViewModels;
using Umbraco.Core.Mapping;
using Umbraco.Core.Models;

namespace Our.Umbraco.Domains.Core.Mappings
{
    public class ContentMappings : IMapDefinition
    {
        public void DefineMaps(UmbracoMapper mapper)
        {
            mapper.Define<IContent, ContentVm>((perm, context) => new ContentVm(), Map);
        }
        private void Map(IContent src, ContentVm vm, MapperContext arg3)
        {
            vm.Id = src.Id;
            vm.Name = src.Name;
        }
    }

}
