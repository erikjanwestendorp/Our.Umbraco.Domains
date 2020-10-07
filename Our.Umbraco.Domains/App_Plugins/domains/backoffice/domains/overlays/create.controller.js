(function () {
    'use strict';

    function CreateDomainController() {

        var vm = this;

        vm.hostname = null;
    }

    angular.module('umbraco')
        .controller('Domains.Overlays.CreateController', CreateDomainController);
})();