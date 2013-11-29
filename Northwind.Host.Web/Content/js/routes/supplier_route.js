/**
	OrderRoute
**/
Northwind.SupplierRoute = Ember.Route.extend({

    model: function (params) {

        return this.get('store').find('supplier', params.supplier_id);

    }
});