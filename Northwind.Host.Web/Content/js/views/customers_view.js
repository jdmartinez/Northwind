/**
`CustomersView` 

@class 		CustomersView
@namespace 	Northwind
@extends 	Northwind.Common.Components.Grid.TableView

*/
Northwind.CustomersView = Northwind.Common.Components.Grid.TableView.extend({

    /**
    Cambiamos las clases para la tabla
    **/
    init: function () {

        this._super();

        var classNames = ['table', 'table-hover', 'customers-list'];

        this.set('classNames', classNames);

    }

});

