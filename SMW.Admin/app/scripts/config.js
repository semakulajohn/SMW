function configState($stateProvider, $urlRouterProvider, $compileProvider) {

    // Optimize load start with remove binding information inside the DOM element
    $compileProvider.debugInfoEnabled(false);
    
    // Set default state
    $urlRouterProvider

        .otherwise("/dashboard");  

    $stateProvider
          // Dashboard - Main page
        .state('dashboard', {
            url: "/dashboard",
            templateUrl: "/app/views/dashboard.html",
            data: {
                pageTitle: 'Dashboard',
               
            }
        })
   
         .state('login', {
             url: "/login",
             templateUrl: "/app/views/adminAccount/login/login.html",
             data: {
                 //pageTitle: 'Profile'
             }
         })
              // User Profile page
    .state('profile', {
        url: "/profile",
        templateUrl: "/app/views/_common/profile.html",
        data: {
            pageTitle: 'Profile'
        }
    })
     

    

          // Modules section 


   //projects
     .state('projects', {
         abstract: true,
         url: "/projects",
         templateUrl: "/app/views/_common/content_empty.html",
         data: {
             pageTitle: 'Projects'
         }
     })

    .state('projects.list', {
        url: "/projects",
        templateUrl: "/app/views/project/list.html",
        data: {
            pageTitle: 'Projects',
        },
        controller: function ($scope, $stateParams) {

        }
    })

         .state('project-edit', {
             url: "/projects/:action/:projectId/:mediaFolderId",
             templateUrl: "/app/views/project/edit.html",
             data: {
                 pageTitle: 'Project edit',
                 pageDesc: ''
             },
             controller: function ($scope, $stateParams) {
                 $scope.action = $stateParams.action;
                 $scope.projectId = $stateParams.projectId;
                 $scope.mediaFolderId = $stateParams.mediaFolderId;
                 $scope.defaultTab = 'edit';
             }
         })
   
          //.state('estate-house-edit', {
          //    url: "/houses/:action/:estateId/:houseId",
          //    templateUrl: "/app/views/house/edit.html",
          //    data: {
          //        pageTitle: 'Estate House edit',
          //        pageDesc: ''
          //    },
          //    controller: function ($scope, $stateParams) {
          //        $scope.action = $stateParams.action;
          //        $scope.houseId = $stateParams.houseId;
          //        $scope.estateId = $stateParams.estateId;
          //        $scope.defaultTab = 'edit';
          //    }
          //})

          //.state('estate-houses', {
          //    url: "/houses/:estateId",
          //    templateUrl: "/app/views/estate/estate-house.html",
          //    data: {
          //        pageTitle: 'Estate Houses',
          //        pageDesc: ''
          //    },
          //    controller: function ($scope, $stateParams) {
          //        $scope.estateId = $stateParams.estateId;

          //    }
          //})

         //properties
     .state('properties', {
         abstract: true,
         url: "/properties",
         templateUrl: "/app/views/_common/content_empty.html",
         data: {
             pageTitle: 'Properties'
         }
     })

    .state('properties.list', {
        url: "/properties",
        templateUrl: "/app/views/property/list.html",
        data: {
            pageTitle: 'Properties',
        },
        controller: function ($scope, $stateParams) {

        }
    })

          
    .state('property-edit', {
        url: "/properties/:action/:propertyId/:mediaFolderId",
        templateUrl: "/app/views/property/edit.html",
        data: {
            pageTitle: 'Property edit',
            pageDesc: ''
        },
        controller: function ($scope, $stateParams) {
            $scope.action = $stateParams.action;
            $scope.propertyId = $stateParams.propertyId;
            $scope.mediaFolderId = $stateParams.mediaFolderId;
            $scope.defaultTab = 'edit';
        }
    })

         
    //Search
    $stateProvider
    .state('search', {
        url: "/search/:q",
        templateUrl: "/app/views/search/index.html",
        data: {
            pageTitle: 'Search'
        },
        controller: function ($scope, $stateParams) {
            $scope.q = $stateParams.q;
        }
    })

}

angular
    .module('homer')
    .config(configState).run(function ($rootScope, $state) {
        $rootScope.$state = $state;
      
        $rootScope.$on("$locationChangeStart", function (event, next, current) {
            if (next.match("/UsersAdmin/")) {
                var parts = next.split('#');
                if (parts.length > 1) {
                    if (!next.match('#/dashboard')) {
                        window.location = '/#' + parts[1];
                    }
                }
            }
        });

    })
  