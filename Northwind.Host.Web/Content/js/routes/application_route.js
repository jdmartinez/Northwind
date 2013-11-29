/**
	Router mapping
**/
Northwind.Router.map(function () {

	// Customers
    this.resource('customers', function () {
        this.resource('customer', { path: ':customer_id' }, function () {
        	this.route('orders');
        });
    });

    // Orders
    this.resource('orders', function () {
    	this.resource('order', { path: ':order_id' });
    });

    // Suppliers
    this.resource('suppliers', function () {
    	this.resource('supplier', { path: ':supplier_id' });
    });

    // About
    this.resource('about');

});

/**
    `ApplicationRoute` 

    @class 		ApplicationRoute
    @namespace 	Northwind
    @extends 	Ember.Route

*/
Northwind.ApplicationRoute = Ember.Route.extend({

	/**
		model
	**/    
	model: function () {
		
		return Ember.$.getJSON('/resources').then(function (data) {
			var apis = data.apis;
			var resources = [];

			apis.forEach(function (api) {
				var path = api.path.substring(api.path.lastIndexOf('/') + 1);

				var res = Ember.Object.create({
					name: path.camelize(),
					icon: '',
					path: path,
					description: api.description
				});

				var icon = '';

				switch (res.name) {
					case 'customers':
					    icon = 'fa-group';
						break;
					case 'orders':
						icon = 'fa-folder';
						break;
					case 'suppliers':
						icon = 'fa-truck';
						break;
				}

				res.set('icon', icon);

				resources.pushObject(res);
			});

			return resources;
		});

	},

	/**
		setupController
	**/
	setupController: function (controller, model) {

		controller.set('content', model);

	}	

});