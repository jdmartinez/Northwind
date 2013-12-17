/** 
  `InfiniteTableViewComponent`
  
  Lista de elementos que se asemejan a UITableView de iOS.
  La lista puede tener una cabecera y un pie que realizan acciones sobre la misma.
  
  El modo mas facil de crear un `InfiniteTableViewComponent` es mediante una plantilla,
  como por ejemplo:
  
  ```html
  {{infinite-table-view items=model}}
  ```
  
  Tambien se puede decidir que elementos mostrar:
  
  ```html
  {{#infinite-table-view items=model}}
    {{infinite-table-view-header}}    
    
    {{#infinite-table-view-items}}          
      {{#each item in items}}
        {{infinite-table-view-item}}
      {{/each}}
    {{/infinite-table-view-items}}
    
    {{infinite-table-view-footer}}
  {{/infinite-table-view items=model}}
  ```    
  
  @class        InfiniteTableViewComponent
  @namespace    Northwind
  @extends      Ember.Component    
  
**/

Northwind.InfiniteTableViewComponent = Ember.Component.extend({
  
  tagName: 'section',
  
  classNames: ['ui-table-view'],
    
  itemsBinding: 'filteredContent'
  
});

/** 
  `InfiniteTableViewItemsComponent`
  
  Lista de elementos que se asemejan a UITableView de iOS.
  
  @class        InfiniteTableViewItemsComponent
  @namespace    Northwind
  @extends      Ember.Component
  
**/
Northwind.InfiniteTableViewItemsComponent = Ember.Component.extend({
  
  tagName: 'ul',
  
  classNames: ['list-group'],
  
  itemViewClass: Northwind.InfiniteTableViewComponent.extend()
  
});

/** 
  `InfiniteTableViewItemComponent`
  
  Elemento de un `InfiniteTableViewItemsComponent`
  
  @class        InfiniteTableViewItemComponent
  @namespace    Northwind
  @extends      Ember.Component
  
**/
Northwind.InfiniteTableViewItemComponent = Ember.Component.extend({
  
  tagName: 'li',
  
  classNames: ['list-group-item'],
  
  classNameBindings: ['isSelected:active'],
  
  isSelected: false,
      
  click: function() {    
    
    this.send('selectItem');
    
  },
  
  actions: {
    
    selectItem: function () {      
      
      this.toggleProperty('isSelected');                  
      
    }
    
  }
  
});

/** 
  `InfiniteTableViewHeaderComponent`
  
  Cabecera de una `InfiniteTableViewComponent`
  
  @class        InfiniteTableViewHeaderComponent
  @namespace    Northwind
  @extends      Ember.Component
  
**/
Northwind.InfiniteTableViewHeaderComponent = Ember.Component.extend({
  
  tagName: 'header',
  
  classNames: ['list-group-header']
  
});

/** 
  `InfiniteTableViewFooterComponent`
  
  Pie de una `InfiniteTableViewComponent`
  
  @class        InfiniteTableViewFooterComponent
  @namespace    Northwind
  @extends      Ember.Component
  
**/
Northwind.InfiniteTableViewFooterComponent = Ember.Component.extend({
  
  tagName: 'footer',
  
  classNames: ['list-group-footer']
  
});