//app.init.js
var app = angular.module('myApp', ['ngResource', 'ngRoute', 'angular-loading-bar', 'ngAnimate']);
var appname = 'myforum';
app.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = true;
    cfpLoadingBarProvider.includeBar = true;
}]);
app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
    .when('/', { templateUrl: appname+'/articles', controller: 'homeCtrl',title:'Featured Articles' })
    .when('/favorites', { templateUrl: appname + '/articles/favorites', controller: 'FavoritesCtrl', title: 'Pinned Articles' })
    .when('/myarticles', { templateUrl: appname + '/articles/MyArticles', controller: 'FavoritesCtrl', title: 'My Articles' })
    .when('/newpost', { templateUrl: appname + '/articles/newpost', controller: 'NewPostCtrl', title: 'Create new Post' })
    .when('/category/:categoryId', { templateUrl: function (param) { return appname + '/articles/Category/' + param.categoryId }, controller: 'SearchCtrl', title: 'Articles by Category' })
    .when('/editArticle/:articleId', { templateUrl: function (param) { return appname + '/articles/article/' + param.articleId }, controller: 'SearchCtrl', title: 'Articles by Category' })
    .when('/team/:teamId', { templateUrl: function (param) { return appname + '/articles/team/' + param.teamId }, controller: 'SearchCtrl',title:'My Team Articles' })
    .when('/login', { templateUrl: appname + '/login', controller: 'LoginCtrl' })
    .when('/logout', { templateUrl: 'admin/login.html', controller: 'LogoutCtrl' })
    .otherwise({ redirectTo: '/' });
}]);

app.factory(
"transformRequestAsFormPost",
function () {
    function transformRequest(data, getHeaders) {
        var headers = getHeaders();
        headers["Content-type"] = "application/x-www-form-urlencoded; charset=utf-8";
        return (serializeData(data));
    }
    return (transformRequest);
    function serializeData(data) {
        if (!angular.isObject(data)) {
            return ((data == null) ? "" : data.toString());
        }
        var buffer = [];
        for (var name in data) {
            if (!data.hasOwnProperty(name)) {
                continue;
            }
            var value = data[name];
            buffer.push(encodeURIComponent(name) +"=" +encodeURIComponent((value == null) ? "" : value));
        }
        var source = buffer.join("&").replace(/%20/g, "+");
        return (source);
    }
}
);
app.value("$sanitize",function (html) {return (html);}
);

app.controller("homeCtrl", ['$scope', '$routeParams', function ($scope, $routeParams) {
    
}]);

app.controller("FavoritesCtrl", ['$scope', '$routeParams', function ($scope, $routeParams) {
    $scope.categoryId = $routeParams.categoryId;
}]);

app.controller("NewPostCtrl", ['$scope', '$routeParams', '$http', '$location', function ($scope, $routeParams, $http, $location) {
    $scope.init = function (a) {
        console.log(a); // prints value of name
    }
    $scope.createPost = function () {
        var post = {
            Title: $scope.Title, ShortDescription: $scope.ShortDescription,
            PostContent: $scope.Description,
            CategoryID: 1, CreatedBy: 1
        };
        console.log(post);
        $http.post(appname + "/Articles/NewPost", post).success(function (data, status, headers, config) {
            showMessage(data);
            if(data.MessageType=='success') $('input,textarea').each(function (index, item) {$(item).val(''); });
        }).error(function (data, status, headers, config) {
            showMessage(data);
        });
    }
}]);

app.controller("SearchCtrl", ['$scope', '$routeParams', function ($scope, $routeParams) {
    $scope.categoryId = $routeParams.categoryId;
}]);

app.controller("LoginCtrl", ['$scope', function ($scope) {
    $scope.model = {
        message: "This is login page"
    }
}]);
function showMessage(o) {
    var n = noty({ text: o.Message, type: o.MessageType, timeout: 10000 });
}

$(document).ready(function () {
    $('.nav li a').click(function (e) {
        $('.nav li').removeClass('active');
        var $parent = $(this).parent();
        if (!$parent.hasClass('active')) {$parent.addClass('active');}
    });
});