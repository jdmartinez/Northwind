/**
    SuppliersRoute
**/
Northwind.SuppliersRoute = Ember.Route.extend({    

    /**
        model
    **/
    model: function () {

        var controller = this.controllerFor('supplier');

        return this.get('store').findQuery('supplier', { offset: controller.offset, limit: controller.limit });

    },   

    /**
        setupController
    **/
    setupController: function (controller, model) {
        controller.set('content', model);
        controller.set('contentLoaded', true);
    },

    /**
    renderTemplate
    **/
    renderTemplate: function () {

        this.render('supplier-list', {
            into: 'application',
            outlet: 'content'
        });

    }

});