(function () {
    'use strict';

    function controller(domainResource, notificationsService, overlayService, localizationService, eventsService) {

        var vm = this;
        vm.page = {};
        vm.domains = [];

        vm.deleteDomain = deleteDomain;
        vm.navigate = navigate;
        
        init();

        function init() {
            vm.loading = true;

            setPageName();
            loadDomains();
        }

        function deleteDomain(domain, event) {
            console.log(domain);

            var dialog = {
                view: "/App_Plugins/domains/backoffice/domains/overlays/delete.html",
                domain: domain,
                submitButtonLabelKey: "contentTypeEditor_yesDelete",
                submitButtonStyle: "danger",
                submit: function (model) {
                    performDelete(model.domain);
                    overlayService.close();
                },
                close: function () {
                    overlayService.close();
                }
            };

            localizationService.localize("general_delete").then(value => {
                dialog.title = value;
                overlayService.open(dialog);
            });

            event.preventDefault();
            event.stopPropagation();
        }

        function performDelete(domain) {
            domain.deleteButtonState = "busy";

            domainResource.deleteById(domain.id).then(function () {

                var args = { domain: domain };
                eventsService.emit("editors.domains.domainDeleted", args);

                var index = vm.domains.indexOf(domain);
                vm.domains.splice(index, 1);

            }, function (err) {
                domain.deleteButtonState = "error";
            });
        }

        function navigate(nodeId) {
            window.location = "/umbraco/#/content/content/edit/" + nodeId;
        }

        function setPageName() {
            localizationService.localize("default_domains").then(value => {
                vm.page.name = value;
            });
        }

        function loadDomains() {
            domainResource.getAll().then(succes, error);

            function succes(result) {
                vm.domains = result;
                vm.items = result;
                vm.loading = false;
            }

            function error(result) {
                notificationsService.error(result.data);
            }
        }
    }

    angular.module('umbraco')
        .controller('Domains.DashboardController', controller);
})();