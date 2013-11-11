/**
    @class      OrdersController
    @namespace  Northwind
    @extends    Northwind.ArrayController
**/
Northwind.OrdersController = Northwind.ArrayController.extend({		

	itemController: 'order',

	/**
		columns
	**/
    columns: [
		Northwind.Common.Components.Grid.column('id', { formatter: '{{#link-to \'order\' view.content}}{{view.content.id}}{{/link-to}}' }),
		Northwind.Common.Components.Grid.column('employeeId'),
		Northwind.Common.Components.Grid.column('shipName'),
		Northwind.Common.Components.Grid.column('shipAddress'),
		Northwind.Common.Components.Grid.column('shipCity')
	]	

});