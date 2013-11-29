/**
    @class      CustomersController
    @namespace  Northwind
    @extends    Northwind.ArrayController
**/
Northwind.CustomersController = Northwind.ArrayController.extend({		

	itemController: 'customer',

	/**
		columns
	**/
    columns: [
		Northwind.Common.Components.Grid.column('contactName', { 
			header: 'Contact Name',
			formatter: Northwind.Common.Components.Avatar.AvatarView.extend({
				title: 'view.content.contactName',
				subtitle: 'view.content.contactTitle'
			})
		}),
		Northwind.Common.Components.Grid.column('companyName', { header: 'Company Name' }),
		Northwind.Common.Components.Grid.column('contactTitle', { header: 'Contact Title' })
	]	

});