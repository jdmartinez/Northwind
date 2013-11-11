/**
    OrdersRoute
**/
Northwind.OrdersRoute = Ember.Route.extend({    

    /**
        model
    **/
    model: function () {

        var controller = this.controllerFor('order');        

        return this.get('store').findQuery('order', { offset: controller.offset, limit: controller.limit });

    },   

    /**
        setupController
    **/
    setupController: function (controller, model) {
        controller.set('content', model);
        controller.set('contentLoaded', true);
    }

});