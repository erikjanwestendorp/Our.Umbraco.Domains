(function () {
    'use strict';

    function domainResource($http, $q, umbRequestHelper ) {
        var service = {
            getAll: getAll,
            deleteById: deleteById
        };

        return service;

        function getAll() {
            var url = umbRequestHelper.getApiUrl("domainsOverview", "GetDomains");
            return $http.get(url)
                .then(success, error);

            function success(result) {
                return result.data;
            }

            function error(result) {
                return $q.reject(result);
            }
        }

        function deleteById(id) {
            var url = umbRequestHelper.getApiUrl("domainsOverview", "DeleteById", "id=" + id);
            return $http.get(url).then(success, error);

            function success(result) {
                return result.data;
            }

            function error(result) {
                return $q.reject(result);
            }
        }


    }

    angular.module('umbraco.services').factory('domainResource', domainResource);
})();