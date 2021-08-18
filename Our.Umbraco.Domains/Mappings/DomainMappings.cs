using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.Domains.ViewModels;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;

namespace Our.Umbraco.Domains.Mappings
{
    public class DomainMappings : IMapDefinition
    {
        public void DefineMaps(IUmbracoMapper mapper)
        {
            mapper.Define<IDomain, DomainVm>((perm, context) => new DomainVm(), Map);
            mapper.Define<IEnumerable<IDomain>, List<DomainVm>>((perm, context) => new List<DomainVm>(), Map);
        }


        private void Map(IDomain model, DomainVm vm, MapperContext arg3)
        {
            Map(model, vm);
        }

        private void Map(IEnumerable<IDomain> model, List<DomainVm> vm, MapperContext arg3)
        {
            model.ToList().ForEach(src =>
            {
                var target = new DomainVm();
                Map(src, target);
                vm.Add(target);
            });
        }

        private void Map(IDomain src, DomainVm vm)
        {
            vm.Id = src.Id;
            vm.DomainName = src.DomainName;
            vm.RootContentId = src.RootContentId;
            vm.LanguageIsoCode = src.LanguageIsoCode;
        }
    }
}
