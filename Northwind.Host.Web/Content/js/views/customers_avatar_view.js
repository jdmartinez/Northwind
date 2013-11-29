/**
    `CustomersAvatarView` 

    @class 		CustomersAvatarView
    @namespace 	Northwind
    @extends 	Northwind.Common.Components.Grid.CellView
*/
Northwind.CustomersAvatarView = Northwind.Common.Components.Grid.CellView.extend({

	template: Ember.Handlebars.compile(
			//'{{#link-to \'customer\' view.content}}{{view.content.contactName}}{{/link-to}}'
			'{{view Northwind.Common.Controls.ImageView class="img-circle avatar" src="../img/no-profile.png" }}'
		)

});