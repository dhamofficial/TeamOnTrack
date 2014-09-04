//app.init.js
var app = angular.module('myApp', ['ngResource', 'ngRoute', 'angular-loading-bar', 'ngAnimate']);
var appname = 'myforum';
app.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = true;
    cfpLoadingBarProvider.includeBar = true;
}])
app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
    .when('/', { templateUrl: appname+'/articles', controller: 'homeCtrl' })
    .when('/favorites', { templateUrl: appname + '/articles/favorites', controller: 'FavoritesCtrl' })
    .when('/newpost', { templateUrl: appname + '/articles/newpost', controller: 'FavoritesCtrl' })
    .when('/login', { templateUrl: appname + '/login', controller: 'LoginCtrl' })
    .when('/logout', { templateUrl: 'admin/login.html', controller: 'LogoutCtrl' })
    .otherwise({ redirectTo: '/' });
}]);

app.controller("homeCtrl", ['$scope',function ($scope) {
    $scope.model = {
        message: "This is my app!!!"
    }
}]);

app.controller("FavoritesCtrl", ['$scope', function ($scope) {
    $scope.model = {
        message: "This is my FavoritesCtrl app!!!"
    }
}]);
  
app.controller("LoginCtrl", ['$scope', function ($scope) {
    $scope.model = {
        message: "This is login page"
    }
}]);