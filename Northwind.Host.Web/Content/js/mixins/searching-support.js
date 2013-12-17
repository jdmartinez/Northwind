/**
**/
Northwind.SearchingSupport = Ember.Mixin.create({
  
  searchText: '', 
  
  searchProperties: Ember.A(),
  
  filterableContentBinding: 'content',
  
  filteredContent: function () {    

    var searchText = this.get('searchText');
    var sProps = this.get('searchProperties');
    var regExp = new RegExp(searchText, 'gi');
    
    if (!searchText) return this;
    
    return this.get('filterableContent').filter(function(item) {

      //var props = Ember.Object.create(item).getProperties(sProps);      
      var props = item.getProperties(sProps);      

      for (var p in props) {
        if ( props[p] && props[p].toString().match(regExp)) {
          return true;
        }
      }
      
      return false;

    });

  }.property('searchText', 'searchProperties', 'filterableContent')
  
});
