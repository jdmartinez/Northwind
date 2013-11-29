/** 
	Vista que se encarga de renderizar los datos de un customer

	@class		CustomerView
	@extends	Ember.View
	@namespace	Northwind	
**/
Northwind.CustomerView = Ember.View.extend({

	templateName: 'customer/customer',

	customerBinding: 'controller.content',

	updateTitle: function () {

	}.observes('customer.loaded', 'customer.id')	

});