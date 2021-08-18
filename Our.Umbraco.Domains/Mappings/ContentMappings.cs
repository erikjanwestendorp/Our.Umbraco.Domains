using Our.Umbraco.Domains.ViewModels;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;

namespace Our.Umbraco.Domains.Mappings
{
    public class ContentMappings : IMapDefinition
    {
        public void DefineMaps(IUmbracoMapper mapper)
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
