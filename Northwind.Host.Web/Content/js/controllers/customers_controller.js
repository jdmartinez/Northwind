/**
    @class      CustomersController
    @namespace  Northwind
    @extends    Northwind.ArrayController
**/
Northwind.CustomersController = Northwind.ArrayController.extend(Northwind.SearchingSupport, {		

	limit: 50,

	itemController: 'customer',

	searchProperties: Ember.A(['contactName', 'contactTitle']),

	filterableContentBinding: 'paginableContent',

  	itemsBinding: 'filteredContent'

});

