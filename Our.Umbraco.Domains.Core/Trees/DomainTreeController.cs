using System.Net.Http.Formatting;
using System.Web.Http.ModelBinding;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using Umbraco.Web.WebApi.Filters;

namespace Our.Umbraco.Domains.Core.Trees
{
    [Tree(
        sectionAlias:Constants.Applications.Settings,
        treeAlias: Static.Constants.Defaults.DomainsTreeAlias, 
        TreeTitle = Static.Constants.Defaults.DomainsTreeTitle, 
        TreeGroup = Constants.Trees.Groups.Settings)]
    [PluginController(areaName: Static.Constants.Defaults.DomainsAreaName)]
    public class DomainTreeController : TreeController
    {
        protected override TreeNode CreateRootNode(FormDataCollection queryStrings)
        {
            var root = base.CreateRootNode(queryStrings);

            root.RoutePath = $"{Constants.Applications.Settings}{Static.Constants.Defaults.TreeRoutePath}";
            root.Icon = Static.Constants.Icons.Globe;
            root.HasChildren = false;
            root.MenuUrl = null;

            return root;
        }

        protected override MenuItemCollection GetMenuForNode(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormDataCollection queryStrings)
        {
            return null;
        }

        protected override TreeNodeCollection GetTreeNodes(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormDataCollection queryStrings)
        {
            return new TreeNodeCollection();
        }
    }
}
