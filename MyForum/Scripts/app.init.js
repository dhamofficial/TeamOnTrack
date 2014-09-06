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
    .when('/category/:categoryId', { templateUrl: function (param) { return appname + '/articles/Category/' + param.categoryId }, controller: 'SearchCtrl' })
    .when('/login', { templateUrl: appname + '/login', controller: 'LoginCtrl' })
    .when('/logout', { templateUrl: 'admin/login.html', controller: 'LogoutCtrl' })
    .otherwise({ redirectTo: '/' });
}]);

app.controller("homeCtrl", ['$scope', '$routeParams', function ($scope, $routeParams) {
    
}]);

app.controller("FavoritesCtrl", ['$scope', '$routeParams', function ($scope, $routeParams) {
    $scope.categoryId = $routeParams.categoryId;
}]);
  
app.controller("SearchCtrl", ['$scope', '$routeParams', function ($scope, $routeParams) {
    $scope.categoryId = $routeParams.categoryId;
}]);

app.controller("LoginCtrl", ['$scope', function ($scope) {
    $scope.model = {
        message: "This is login page"
    }
}]);
$(document).ready(function () {
    $('.nav li a').click(function (e) {

        $('.nav li').removeClass('active');

        var $parent = $(this).parent();
        if (!$parent.hasClass('active')) {
            $parent.addClass('active');
        }
        e.preventDefault();
    });
});