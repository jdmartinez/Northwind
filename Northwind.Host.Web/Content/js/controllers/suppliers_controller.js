/**
    @class      OrdersController
    @namespace  Northwind
    @extends    Northwind.ArrayController
**/
Northwind.SuppliersController = Northwind.ArrayController.extend({		

	itemController: 'supplier',

	/**
		columns
	**/
    columns: [
		Northwind.Common.Components.Grid.column('id', { formatter: '{{#link-to \'supplier\' view.content}}{{view.content.id}}{{/link-to}}' }),
		Northwind.Common.Components.Grid.column('contactName'),
		Northwind.Common.Components.Grid.column('companyName'),
		Northwind.Common.Components.Grid.column('contactTitle')
	]	

});