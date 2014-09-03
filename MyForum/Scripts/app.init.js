//app.init.js
var app = angular.module('myApp', ['ngResource', 'ngRoute']);
var appname = 'myforum';
app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
    .when('/', { templateUrl: appname+'/articles', controller: 'homeCtrl' })
    .when('/login', { templateUrl: appname+'/login', controller: 'LoginCtrl' })
    .when('/logout', { templateUrl: 'admin/login.html', controller: 'LogoutCtrl' })
    .otherwise({ redirectTo: '/' });
}]);
app.controller("homeCtrl", ['$scope',function ($scope) {
    $scope.model = {
        message: "This is my app!!!"
    }
}]);
  
app.controller("LoginCtrl", ['$scope', function ($scope) {
    $scope.model = {
        message: "This is login page"
    }
}]);