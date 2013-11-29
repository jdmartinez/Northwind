/**
	OrderRoute
**/
Northwind.OrderRoute = Ember.Route.extend({

    model: function (params) {

        return this.get('store').find('order', params.order_id);

    }
});