using Our.Umbraco.Domains.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Mapping;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;
using Umbraco.Web.WebApi.Filters;

namespace Our.Umbraco.Domains.Core.Controllers.Backoffice
{
    [UmbracoApplicationAuthorize(Constants.Applications.Settings)]
    public class DomainController : UmbracoAuthorizedApiController
    {
        private readonly IDomainService _domainService;
        private readonly IContentService _contentService;
        private readonly UmbracoMapper _umbracoMapper;
        public DomainController(UmbracoMapper umbracoMapper)
        {
            _domainService = Services.DomainService;
            _contentService = Services.ContentService;
            _umbracoMapper = umbracoMapper;
        }

        [HttpGet]
        public IEnumerable<DomainVm> GetDomains()
        {
            var domains = _domainService.GetAll(true);
            if (!domains.Any())
                return Enumerable.Empty<DomainVm>();

            try
            {
                var result = _umbracoMapper.Map<IEnumerable<DomainVm>>(domains);
                foreach (var domainVm in result)
                {
                    if (domainVm.RootContentId != null)
                    {
                        var content = _contentService.GetById(domainVm.RootContentId.Value);

                        if (content != null)
                        {
                            domainVm.Content = _umbracoMapper.Map<ContentVm>(content);
                        }
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(typeof(DomainController), ex);
            }

            return Enumerable.Empty<DomainVm>();
        }

        [HttpGet]
        public bool DeleteById(int id)
        {
            var domain = _domainService.GetById(id);
            if (domain == null)
                return false;

            var deleteAttempt = _domainService.Delete(domain);
            return deleteAttempt.Success;
        }
    }
}
