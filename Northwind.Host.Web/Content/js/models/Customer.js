/**
	Modelo que representa un Customer

	@class		Customer
	@extends	Northwind.Model
	@namespace	Northwind
	@module		@Northwind
**/

Northwind.Customer = Northwind.Model.extend({
	companyName: DS.attr('string'),
	contactName: DS.attr('string'),
	contactTitle: DS.attr('string'),
	address: DS.attr('string'),
	city: DS.attr('string'),
	region: DS.attr('string'),
	postalCode: DS.attr('string'),
	country: DS.attr('string'),
	phone: DS.attr('string'),
	fax: DS.attr('string'),

	completeAddress: function () {

		return this.get('address') + '. ' + this.get('city') + '. ' + this.get('postalCode') + '. ' + this.get('country');

	}.property('address', 'city', 'postalCode', 'country'),
	    
    orders: DS.hasMany('order')
});

Northwind.Customer.reopen({

	required: ['contactName', 'companyName']

});
