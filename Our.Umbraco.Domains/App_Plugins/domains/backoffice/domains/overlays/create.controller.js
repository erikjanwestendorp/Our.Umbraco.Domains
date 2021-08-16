(function () {
    'use strict';

    function CreateDomainController($scope, languageResource, contentResource) {

        var vm = this;

        vm.languages = [];

        vm.hostname = null;
        vm.node = null;
        vm.language = null;

        vm.save = save;
        vm.close = close;

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

        function save() {
            var data = {
                nodeId: vm.node.id,
                domains: [
                    {
                        name: vm.hostname,
                        lang: vm.language.id
                    }
                ]
            };

            contentResource.saveLanguageAndDomains(data)
                .then(function (response) {
                    if (!response.valid) {
                        alert('Oops!');
                    } else {
                        $scope.model.submit();
                    }
                });
        };

        function close() {
            $scope.model.close();
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