(function () {
    'use strict';

    function CreateDomainController($scope, languageResource, contentResource) {

        var vm = this;

        vm.languages = [];

        vm.hostname = null;
        vm.node = null;
        vm.language = null;

        vm.dialogTreeApi = {};

        vm.onTreeInit = function () {
            vm.dialogTreeApi.callbacks.treeNodeSelect(nodeSelectHandler);
        };

        function nodeSelectHandler(args) {
            if (args && args.event) {
                args.event.preventDefault();
                args.event.stopPropagation();
            }

            if (vm.node) {
                //un-select if there's a current one selected
                vm.node.selected = false;
            }

            vm.node = args.node;
            vm.node.selected = true;
        };
        function init() {
            languageResource.getAll()
                .then(function (languages) {
                    vm.languages = languages;
                });
        };

        init();

    }

    angular.module('umbraco')
        .controller('Domains.Overlays.CreateController', CreateDomainController);
})();