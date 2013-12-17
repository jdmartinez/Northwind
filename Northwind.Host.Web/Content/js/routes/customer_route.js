/**
    CustomersRoute
**/
Northwind.CustomerRoute = Ember.Route.extend({

	/**
		model
	**/
    model: function (params) {

        return this.get('store').find('customer', params.customer_id);

    },

    /**
    renderTemplate
    **/
    renderTemplate: function () {

        this.render('customer', {
            into: 'customers',
            outlet: 'customerDetail'
        });

    }    

});