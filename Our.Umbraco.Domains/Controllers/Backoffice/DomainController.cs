using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Our.Umbraco.Domains.ViewModels;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Our.Umbraco.Domains.Controllers.Backoffice
{

    //TODO Authorize
    //[UmbracoApplicationAuthorize(Constants.Applications.Settings)]
    public class DomainController : UmbracoAuthorizedApiController
    {
        private readonly ILogger<DomainController> _logger;
        private readonly IDomainService _domainService;
        private readonly IContentService _contentService;
        private readonly IUmbracoMapper _umbracoMapper;

        public DomainController(
            ILogger<DomainController> logger,
            IDomainService domainService,
            IContentService contentService,
            IUmbracoMapper umbracoMapper)
        {
            _logger = logger;
            _domainService = domainService;
            _contentService = contentService;
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
                var result = _umbracoMapper.Map<IEnumerable<DomainVm>>(domains).ToList();
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
                _logger.LogError(ex, ex.Message);
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
