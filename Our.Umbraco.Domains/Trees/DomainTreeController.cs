using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.Domains.Trees
{
    [Tree(
        sectionAlias: Constants.Applications.Settings,
        treeAlias: Static.Constants.Defaults.DomainsTreeAlias,
        TreeTitle = Static.Constants.Defaults.DomainsTreeTitle,
        TreeGroup = Constants.Trees.Groups.Settings,
        SortOrder = 12)]
    [PluginController(areaName: Static.Constants.Defaults.DomainsAreaName)]
    public class DomainTreeController : TreeController
    {
        public DomainTreeController(ILocalizedTextService localizedTextService, UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection, IEventAggregator eventAggregator) : base(localizedTextService, umbracoApiControllerTypeCollection, eventAggregator)
        {
        }


        protected override ActionResult<TreeNode> CreateRootNode(FormCollection queryStrings)
        {
            var root = base.CreateRootNode(queryStrings);

            root.Value.RoutePath = $"{Constants.Applications.Settings}{Static.Constants.Defaults.TreeRoutePath}";
            root.Value.Icon = Static.Constants.Icons.Globe;
            root.Value.HasChildren = false;
            root.Value.MenuUrl = null;

            return root.Value;

        }

        protected override ActionResult<TreeNodeCollection> GetTreeNodes(string id, FormCollection queryStrings)
        {
            return new TreeNodeCollection();
        }

        protected override ActionResult<MenuItemCollection> GetMenuForNode(string id, FormCollection queryStrings)
        {
            return null;
        }

    }
}
