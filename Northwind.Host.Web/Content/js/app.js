;/**
**/
Northwind = Ember.Application.create();

/**
**/
Northwind.store = DS.Store.extend();



;Ember.TEMPLATES["about"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  


  data.buffer.push("<div class=\"about\">\r\n    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. \r\n    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. \r\n    Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per \r\n    conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.</p>\r\n\r\n    <p>Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. \r\n    Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula \r\n    lacinia aliquet. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. \r\n    Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.</p>\r\n\r\n    <p>Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. \r\n    Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. \r\n    Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus.</p>\r\n\r\n    <p>Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. \r\n    Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. \r\n    Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. \r\n    Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. \r\n    Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper.</p>\r\n\r\n    <p>Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. Integer id quam. Morbi mi. \r\n	Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam. \r\n	Aenean laoreet. Vestibulum nisi lectus, commodo ac, facilisis ac, ultricies eu, pede. Ut orci risus, accumsan porttitor, cursus quis, \r\n	aliquet eget, justo.</p>\r\n</div>");
  
});

Ember.TEMPLATES["application"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var buffer = '', stack1, stack2, hashTypes, hashContexts, options, helperMissing=helpers.helperMissing, escapeExpression=this.escapeExpression, self=this;

function program1(depth0,data) {
  
  var buffer = '', stack1, stack2, hashTypes, hashContexts, options;
  data.buffer.push("\r\n		        <li role=\"presentation\">");
  hashTypes = {};
  hashContexts = {};
  options = {hash:{},inverse:self.noop,fn:self.program(2, program2, data),contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  stack2 = ((stack1 = helpers['link-to'] || depth0['link-to']),stack1 ? stack1.call(depth0, "api.path", options) : helperMissing.call(depth0, "link-to", "api.path", options));
  if(stack2 || stack2 === 0) { data.buffer.push(stack2); }
  data.buffer.push("</li>\r\n		    ");
  return buffer;
  }
function program2(depth0,data) {
  
  var buffer = '', stack1, hashContexts, hashTypes, options;
  data.buffer.push("<i ");
  hashContexts = {'class': depth0};
  hashTypes = {'class': "STRING"};
  options = {hash:{
    'class': (":fa api.icon :fa-lg")
  },contexts:[],types:[],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  data.buffer.push(escapeExpression(((stack1 = helpers['bind-attr'] || depth0['bind-attr']),stack1 ? stack1.call(depth0, options) : helperMissing.call(depth0, "bind-attr", options))));
  data.buffer.push("></i><span>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "api.name", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</span>");
  return buffer;
  }

function program4(depth0,data) {
  
  
  data.buffer.push("\r\n		                <i class=\"fa fa-info-circle fa-fw\"></i>\r\n		                <span>About</span>\r\n		            ");
  }

  data.buffer.push("<div class=\"wrapper\">\r\n	<!-- Sidebar -->	\r\n	<aside id=\"sidebar\">\r\n		<nav id=\"services-menu\" class=\"collapse navbar-collapse\" role=\"menu\">\r\n		    <ul class=\"nav nav-stacked\">\r\n		    ");
  hashTypes = {};
  hashContexts = {};
  stack1 = helpers.each.call(depth0, "api", "in", "controller.content", {hash:{},inverse:self.noop,fn:self.program(1, program1, data),contexts:[depth0,depth0,depth0],types:["ID","ID","ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data});
  if(stack1 || stack1 === 0) { data.buffer.push(stack1); }
  data.buffer.push("                   \r\n		        <li class=\"divider\" role=\"presentation\"></li>\r\n		        <li role=\"presentation\">                        \r\n		            ");
  hashTypes = {};
  hashContexts = {};
  options = {hash:{},inverse:self.noop,fn:self.program(4, program4, data),contexts:[depth0],types:["STRING"],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  stack2 = ((stack1 = helpers['link-to'] || depth0['link-to']),stack1 ? stack1.call(depth0, "about", options) : helperMissing.call(depth0, "link-to", "about", options));
  if(stack2 || stack2 === 0) { data.buffer.push(stack2); }
  data.buffer.push("\r\n		        </li>\r\n		    </ul>\r\n		</nav>\r\n	</aside>\r\n	<!-- End sidebar -->	\r\n\r\n	<!-- Content -->	\r\n	<section id=\"content\">\r\n		");
  hashTypes = {};
  hashContexts = {};
  options = {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  data.buffer.push(escapeExpression(((stack1 = helpers.outlet || depth0.outlet),stack1 ? stack1.call(depth0, "content", options) : helperMissing.call(depth0, "outlet", "content", options))));
  data.buffer.push("\r\n	</section>\r\n	<!-- End content -->	\r\n</div>");
  return buffer;
  
});

Ember.TEMPLATES["components/google-map"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var hashTypes, hashContexts, escapeExpression=this.escapeExpression;


  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "yield", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  
});

Ember.TEMPLATES["components/infinite-table-view-header"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var hashTypes, hashContexts, escapeExpression=this.escapeExpression;


  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "yield", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  
});

Ember.TEMPLATES["components/infinite-table-view-item"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var hashTypes, hashContexts, escapeExpression=this.escapeExpression;


  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "yield", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  
});

Ember.TEMPLATES["components/infinite-table-view-items"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var hashTypes, hashContexts, escapeExpression=this.escapeExpression;


  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "yield", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  
});

Ember.TEMPLATES["components/infinite-table-view"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var hashTypes, hashContexts, escapeExpression=this.escapeExpression;


  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "yield", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  
});

Ember.TEMPLATES["customer-list"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var buffer = '', stack1, stack2, hashContexts, hashTypes, options, escapeExpression=this.escapeExpression, self=this, helperMissing=helpers.helperMissing, functionType="function", blockHelperMissing=helpers.blockHelperMissing;

function program1(depth0,data) {
  
  var buffer = '', stack1, options, hashTypes, hashContexts;
  data.buffer.push("\r\n  ");
  options = {hash:{},inverse:self.noop,fn:self.program(2, program2, data),contexts:[],types:[],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  if (stack1 = helpers['infinite-table-view-header']) { stack1 = stack1.call(depth0, options); }
  else { stack1 = depth0['infinite-table-view-header']; stack1 = typeof stack1 === functionType ? stack1.apply(depth0) : stack1; }
  hashTypes = {};
  hashContexts = {};
  if (!helpers['infinite-table-view-header']) { stack1 = blockHelperMissing.call(depth0, stack1, options); }
  if(stack1 || stack1 === 0) { data.buffer.push(stack1); }
  data.buffer.push("\r\n            \r\n  ");
  options = {hash:{},inverse:self.noop,fn:self.program(4, program4, data),contexts:[],types:[],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  if (stack1 = helpers['infinite-table-view-items']) { stack1 = stack1.call(depth0, options); }
  else { stack1 = depth0['infinite-table-view-items']; stack1 = typeof stack1 === functionType ? stack1.apply(depth0) : stack1; }
  hashTypes = {};
  hashContexts = {};
  if (!helpers['infinite-table-view-items']) { stack1 = blockHelperMissing.call(depth0, stack1, options); }
  if(stack1 || stack1 === 0) { data.buffer.push(stack1); }
  data.buffer.push("\r\n  \r\n");
  return buffer;
  }
function program2(depth0,data) {
  
  var buffer = '', hashContexts, hashTypes;
  data.buffer.push("\r\n    <div class=\"form-group input-group\">      \r\n      ");
  hashContexts = {'placeholder': depth0,'class': depth0,'valueBinding': depth0};
  hashTypes = {'placeholder': "STRING",'class': "STRING",'valueBinding': "STRING"};
  data.buffer.push(escapeExpression(helpers.view.call(depth0, "Ember.TextField", {hash:{
    'placeholder': ("Search"),
    'class': ("form-control"),
    'valueBinding': ("controller.searchText")
  },contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("\r\n      <span class=\"input-group-addon\">\r\n        <i class=\"glyphicon glyphicon-search\"></i>\r\n      </span>\r\n    </div>\r\n  ");
  return buffer;
  }

function program4(depth0,data) {
  
  var buffer = '', stack1, hashTypes, hashContexts;
  data.buffer.push("\r\n    ");
  hashTypes = {};
  hashContexts = {};
  stack1 = helpers.each.call(depth0, "item", "in", "items", {hash:{},inverse:self.noop,fn:self.program(5, program5, data),contexts:[depth0,depth0,depth0],types:["ID","ID","ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data});
  if(stack1 || stack1 === 0) { data.buffer.push(stack1); }
  data.buffer.push("\r\n  ");
  return buffer;
  }
function program5(depth0,data) {
  
  var buffer = '', stack1, stack2, hashContexts, hashTypes, options;
  data.buffer.push("\r\n      ");
  hashContexts = {'item': depth0};
  hashTypes = {'item': "ID"};
  options = {hash:{
    'item': ("item")
  },inverse:self.noop,fn:self.program(6, program6, data),contexts:[],types:[],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  stack2 = ((stack1 = helpers['infinite-table-view-item'] || depth0['infinite-table-view-item']),stack1 ? stack1.call(depth0, options) : helperMissing.call(depth0, "infinite-table-view-item", options));
  if(stack2 || stack2 === 0) { data.buffer.push(stack2); }
  data.buffer.push("\r\n    ");
  return buffer;
  }
function program6(depth0,data) {
  
  var buffer = '', stack1, stack2, hashTypes, hashContexts, options;
  data.buffer.push("\r\n        ");
  hashTypes = {};
  hashContexts = {};
  options = {hash:{},inverse:self.noop,fn:self.program(7, program7, data),contexts:[depth0,depth0],types:["STRING","ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  stack2 = ((stack1 = helpers.linkTo || depth0.linkTo),stack1 ? stack1.call(depth0, "customer", "item", options) : helperMissing.call(depth0, "linkTo", "customer", "item", options));
  if(stack2 || stack2 === 0) { data.buffer.push(stack2); }
  data.buffer.push("\r\n      ");
  return buffer;
  }
function program7(depth0,data) {
  
  var buffer = '', hashTypes, hashContexts;
  data.buffer.push("\r\n          <i class=\"fa fa-user img-circle avatar\"></i>\r\n          <h4 class=\"list-group-item-heading\">");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "item.contactName", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</h4>\r\n          <div class=\"list-group-item-text\">");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "item.contactTitle", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</div>\r\n        ");
  return buffer;
  }

  data.buffer.push("\r\n");
  hashContexts = {'controllerBinding': depth0,'class': depth0};
  hashTypes = {'controllerBinding': "STRING",'class': "STRING"};
  options = {hash:{
    'controllerBinding': ("controller"),
    'class': ("customers-list")
  },inverse:self.noop,fn:self.program(1, program1, data),contexts:[],types:[],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  stack2 = ((stack1 = helpers['infinite-table-view'] || depth0['infinite-table-view']),stack1 ? stack1.call(depth0, options) : helperMissing.call(depth0, "infinite-table-view", options));
  if(stack2 || stack2 === 0) { data.buffer.push(stack2); }
  data.buffer.push("      ");
  return buffer;
  
});

Ember.TEMPLATES["customer/customer"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var buffer = '', stack1, stack2, hashTypes, hashContexts, options, escapeExpression=this.escapeExpression, helperMissing=helpers.helperMissing, self=this;

function program1(depth0,data) {
  
  var buffer = '', hashTypes, hashContexts;
  data.buffer.push("\r\n            <dt>Fax</dt>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "fax", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n        ");
  return buffer;
  }

  data.buffer.push("<div id=\"customer-profile\" class=\"customer-profile\">\r\n    <div class=\"row customer-header\">\r\n        <i class=\"fa fa-user avatar img-circle\"></i>\r\n        <h3 class=\"name\">");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "contactName", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</h3>\r\n        <span class=\"title\">");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "contactTitle", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</span>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <dl class=\"profile\">\r\n            <dt>Company Name</dt>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "companyName", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n            <dt class=\"separator\"></dt>\r\n            <dl></dl>\r\n            <dt>Address</dt>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "address", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "city", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "postalCode", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "country", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n            <dd>\r\n                ");
  hashContexts = {'address': depth0,'width': depth0,'height': depth0};
  hashTypes = {'address': "ID",'width': "STRING",'height': "STRING"};
  options = {hash:{
    'address': ("completeAddress"),
    'width': ("100%"),
    'height': ("400px")
  },contexts:[],types:[],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  data.buffer.push(escapeExpression(((stack1 = helpers['google-map'] || depth0['google-map']),stack1 ? stack1.call(depth0, options) : helperMissing.call(depth0, "google-map", options))));
  data.buffer.push("\r\n            </dd>\r\n            <dt class=\"separator\"></dt>\r\n            <dl></dl>\r\n            <dt>Phone</dt>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "phone", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n        ");
  hashTypes = {};
  hashContexts = {};
  stack2 = helpers['if'].call(depth0, "fax", {hash:{},inverse:self.noop,fn:self.program(1, program1, data),contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data});
  if(stack2 || stack2 === 0) { data.buffer.push(stack2); }
  data.buffer.push("\r\n        </dl>        \r\n    </div>    \r\n</div>\r\n");
  return buffer;
  
});

Ember.TEMPLATES["customers"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var buffer = '', stack1, hashTypes, hashContexts, options, helperMissing=helpers.helperMissing, escapeExpression=this.escapeExpression;


  data.buffer.push("<div class=\"leftContent col-md-5\">\r\n	");
  hashTypes = {};
  hashContexts = {};
  options = {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  data.buffer.push(escapeExpression(((stack1 = helpers.outlet || depth0.outlet),stack1 ? stack1.call(depth0, "customerList", options) : helperMissing.call(depth0, "outlet", "customerList", options))));
  data.buffer.push("\r\n</div>\r\n<div class=\"rightContent col-md-7\">\r\n	");
  hashTypes = {};
  hashContexts = {};
  options = {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  data.buffer.push(escapeExpression(((stack1 = helpers.outlet || depth0.outlet),stack1 ? stack1.call(depth0, "customerDetail", options) : helperMissing.call(depth0, "outlet", "customerDetail", options))));
  data.buffer.push("\r\n</div>");
  return buffer;
  
});

Ember.TEMPLATES["order-list"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var buffer = '', hashTypes, hashContexts, escapeExpression=this.escapeExpression;


  data.buffer.push("<h1>Orders</h1>\r\n");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers.view.call(depth0, "Northwind.Common.Components.Grid.GridView", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  return buffer;
  
});

Ember.TEMPLATES["supplier-list"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
this.compilerInfo = [4,'>= 1.0.0'];
helpers = this.merge(helpers, Ember.Handlebars.helpers); data = data || {};
  var buffer = '', hashTypes, hashContexts, escapeExpression=this.escapeExpression;


  data.buffer.push("<h1>Suppliers</h1>\r\n");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers.view.call(depth0, "Northwind.Common.Components.Grid.GridView", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  return buffer;
  
});
;/**
    @extends	Ember.Namespace
    @namespace	Northwind
    @module		@Northwind
**/

Northwind.Common = Ember.Namespace.create({
    Controls: Ember.Namespace.create()
});


;/**
	Funciones relacionadas con Url

	@class		Uri
	@namespace	Northwind
	@module		Northwind
	@extends	Ember.Object
**/
Northwind.Common.Uri = Ember.Object.create({
	
	/**
		Extrae los argumentos de una Url en forma de objeto

		@method	queryParams
		@param  {String} Uri de donde se extraerán sus parámetros
		@see 	https://gist.github.com/simonsmith/5152680
	**/
	queryParams: function (uri) {

		var queryParams = {};

        if (uri) {
            var reg = /\\?([^?=&]+)(=([^&#]*))?/g;

            uri.replace(reg, function ($0, $1, $2, $3) {
                if (typeof $3 == 'string') {
                    queryParams[$1] = decodeURIComponent($3);
                }
            });
        }

        return queryParams;

	}

});
;/**
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

;/**
**/
Northwind.Common.Components = Ember.Namespace.create({
    Grid: Ember.Namespace.create(),
    Avatar: Ember.Namespace.create()
});
;/**
	PaginationMixin
 **/
Northwind.Common.Components.Grid.Pagination = Ember.Mixin.create({
    /**
        totalCount
    **/
    totalCount: 0,    

    /**
        limit
    **/
    limit: 0,

    /**
        page
    **/
    page: 0,    

    /**
        metadata
    **/
    metadata: null,

    /**
        paginableContentBinding
    **/
    paginableContentBinding: 'content',

    /**
        offset
    **/
    offset: function () {

        var page = this.get('page');
        var limit = this.get('limit');

        return (page * limit) + 1;

    }.property('page'),


    /**
        paginatedContent
    **/
    paginatedContent: function () {

        if (this.get('page') >= this.get('pages')) {
            this.set('page', 0);
        }
        
        return this.get('content');

    }.property('@each', 'page', 'limit'),


    /**
        pages
    **/
    pages: function () {        

        return Math.ceil(this.get('totalCount') / this.get('limit'));

    }.property('totalCount', 'limit'),

    /**
        firstPage
    **/
    firstPage: function () {

        this.set('page', 0);        

    },

    /**
        previousPage
    **/
    previousPage: function () {

        this.set('page', Math.max(this.get('page') - 1, 0));

    },

    /**
        nextPage
    **/
    nextPage: function () {

        this.set('page', Math.min(this.get('page') + 1, this.get('pages') - 1));

    },

    /**
        lastPage
    **/
    lastPage: function () {

        this.set('page', this.get('pages') - 1);

    }

});
;/**
    `TableView` 

    @class 		Column
    @namespace 	Northwind.Common.Components.Grid
    @extends 	Ember.Object

*/

Northwind.Common.Components.Grid.Column = Ember.Object.extend({

    property: null,

    display: true,

    formatter: '{{view.content.%@}}',

    /**
        header
    **/
    header: function () {

        if (!this.get('property')) return '';

        return this.get('property').capitalize();

    }.property('property'),

    /**
        visible
    **/
    visible: function () {

        return this.get('display') != false;

    }.property('display'),

    /**
        always
    **/
    always: function () {

        return this.get('display') === 'always';

    }.property('display'),    

    /**
        viewClass
    **/
    viewClass: function () {

        var formatter = this.get('formatter');

        if (Northwind.Common.Components.Grid.CellView.detect(formatter)) {
            return formatter;
        } else {
            Ember.assert('Formatter has to extend CellView or Handlebar template', Ember.typeOf(formatter) === 'string');

            var property = this.get('property');

            if (!property) {
                property = 'constructor';
            }

            var template = this.get('formatter').fmt(property);

            return Northwind.Common.Components.Grid.CellView.extend({
                template: Ember.Handlebars.compile(template)
            });
        };

    }.property()

});

/**
    `TableView` 

    @class      Column
    @namespace  Northwind.Common.Components.Grid
    @extends    Ember.Object

*/

Northwind.Common.Components.Grid.column = function (property, options) {

    if (Ember.typeOf(property) === 'object') {
        options = property;
        property = null;
    }

    var column = Northwind.Common.Components.Grid.Column.create({
        property: property
    });

    if (options) {
        for (var key in options) {
            column.set(key, options[key]);
        };
    }

    return column;
};
;/**
	`GridController` ofrece una manera de listar elementos de una colección de 
  	objetos con la posibilidad de mostrar los datos mediante lista paginada

	@class 		GridController
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.ArrayController
	@uses		Northwind.Common.Components.Grid.PaginationMixin		
 */

Northwind.Common.Components.Grid.GridController = Ember.ArrayController.extend(Northwind.Common.Components.Grid.Pagination, {

    columns: [],

    paginableContentBinding: 'content',

    rowsBinding: 'paginatedContent',

    visibleColumns: function () {

        return this.get('columns').filterProperty('visible', true);

    }.property('columns.@each.visible')

});
;/**
	`TableView` 

	@class 		GridView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.View

 */

Northwind.Common.Components.Grid.GridView = Ember.View.extend({

    classNames: ['grid'],

    defaultTemplate: Ember.Handlebars.compile('{{view Northwind.Common.Components.Grid.TableView}}')

});
;/**
	`PageListView` 

	@class 		PageListView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.ContainerView

 */

Northwind.Common.Components.Grid.PageListView = Ember.ContainerView.extend({

    tagName: 'ul',

    classNames: ['pagination', 'pagination-sm'],

    pages: [],

    visiblePages: 3,

    /**
        firstPageView
    **/
    firstPageView: Ember.View.extend({
        tagName: 'li',
        classNameBindings: ['parentView.hasFirstPage::disabled'],
        template: Ember.Handlebars.compile('<a href="javascript:void(0);" {{action firstPage target="view.parentView"}}>&laquo;</a>')

    }),

    /**
        prevPageView
    **/
    prevPageView: Ember.View.extend({
        tagName: 'li',
        classNameBindings: ['parentView.hasPreviousPage::disabled'],
        template: Ember.Handlebars.compile('<a href="javascript:void(0);" {{action prevPage target="view.parentView"}}>&lsaquo;</a>')
    }),

    /**
        pageView
    **/
    pageView: Ember.View.extend({
        tagName: 'li',
        classNameBindings: ['content.isActive:active'],
        template: Ember.Handlebars.compile('<a href="javascript:void(0);" {{action setPage view.content target="view.parentView"}}>{{view.content.page}}</a>')
    }),

    /**
        nextPageView
    **/
    nextPageView: Ember.View.extend({
        tagName: 'li',
        classNameBindings: ['parentView.hasNextPage::disabled'],
        template: Ember.Handlebars.compile('<a href="javascript:void(0);" {{action nextPage target="view.parentView"}}>&rsaquo;</a>')
    }),

    /**
        nextPageView
    **/
    lastPageView: Ember.View.extend({
        tagName: 'li',
        classNameBindings: ['parentView.hasLastPage::disabled'],
        template: Ember.Handlebars.compile('<a href="javascript:void(0);" {{action lastPage target="view.parentView"}}>&raquo;</a>')
    }),

    /**
        refreshPageListItems
    **/
    refreshPageListItems: function () {

        var pages = this.get('pages');

        if (!pages.get('length')) return;

        this.clear();
        this.pushObject(this.get('firstPageView').create());
        this.pushObject(this.get('prevPageView').create());

        var self = this;


        this.get('pages').forEach(function (page) {            
            var pageView = self.get('pageView').create({
                content: page
            });

            self.pushObject(pageView);
        });

        this.pushObject(this.get('nextPageView').create());
        this.pushObject(this.get('lastPageView').create());
        
    }.observes('pages'),

    /**
        createPages
    **/
    createPages: function () {

        if (!this.get('controller')) return [];

        var currentPage = this.get('controller.page');
        var pages = this.get('controller.pages');
        var pagesFrom = Math.max(0, currentPage - this.visiblePages);
        var pagesTo = Math.min(pages, currentPage + this.visiblePages + 1);
        var limit = this.get('controller.limit');
        
        var pages = [];

        for (var i = pagesFrom; i < pagesTo; i++) {
            pages.push({
                index: i,
                page: i + 1,
                isActive: (i == currentPage)
            });
        }

        this.set('pages', pages);
    },

    /**
        didControllerContentChanged
    **/
    didControllerContentChanged: function () {

        this.createPages();

        var pages = this.get('controller.pages');
        var page = this.get('controller.page');

        this.set('pagesCount', pages);
        this.set('hasNextPage', page + 1 < pages);
        this.set('hasPreviousPage', page > 0);
        this.set('hasFirstPage', page > 0);
        this.set('hasLastPage', page + 1 < pages);

    }.observes('controller.offset', 'controller.pages', 'controller.page').on('init'),

    /**
        actions
    **/
    actions: {
        /**
            setPage
        **/
        setPage: function (context) {

            this.get('controller').set('page', context.index);

        },

        /**
            firstPage
        **/
        firstPage: function () {

            if (!this.get('hasFirstPage')) return;

            this.get('controller').firstPage();

        },

        /**
            lastPage
        **/
        lastPage: function () {

            if (!this.get('hasLastPage')) return;

            this.get('controller').lastPage();

        },

        /**
            lastPage
        **/
        prevPage: function () {

            if (!this.get('hasPreviousPage')) return;

            this.get('controller').previousPage();

        },

        /**
            nextPage
        **/
        nextPage: function () {

            if (!this.get('hasNextPage')) return;

            this.get('controller').nextPage();

        }
    },

    /**
        init
    **/
    init: function () {
        this._super();
        this.refreshPageListItems();
    }

});

;/**
	`PageView` 

	@class 		PageView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.View

 */

Northwind.Common.Components.Grid.PageView = Ember.View.extend({

    classNames: ['pull-left', 'table-page'],

    defaultTemplate: Ember.Handlebars.compile('Showing {{controller.offset}} - {{view.last}} from {{controller.totalCount}}'),

    /**
        didPageChange
    **/
    didPageChange: function () {        

        var limit = this.get('controller.limit');
        var length = this.get('controller.totalCount');
        var offset = this.get('controller.offset');        

        this.set('first', offset);
        this.set('last', Math.min(length, (offset - 1) + limit));

    }.observes('controller.offset', 'controller.limit', 'controller.totalCount').on('init')

});
;/**
	`PaginationView` 

	@class 		PageListView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.ContainerView

 */

Northwind.Common.Components.Grid.PaginationView = Ember.ContainerView.extend({

	tagName: 'div',

	classNames: ['pull-right', 'table-pagination'],

	childViews: ['pageList'],

	/**
		pageList
	**/
	pageList: Northwind.Common.Components.Grid.PageListView.create()

});
;/**
	`TableView` 

	@class 		TableView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.View

 */

Northwind.Common.Components.Grid.TableView = Ember.View.extend({

    tagName: 'table',

    classNames: ['table', 'table-bordered', 'table-striped', 'table-condensed'],

    defaultTemplate: function () {        

        var headerView = '<thead>{{view Northwind.Common.Components.Grid.HeaderView}}</thead>';
        var bodyView = '{{view Northwind.Common.Components.Grid.BodyView}}';
        var footerView = '{{view Northwind.Common.Components.Grid.FooterView}}';

        return Ember.Handlebars.compile(headerView + bodyView + footerView);

    }.property()

});

;/**
	`HeaderView` 

	@class 		HeaderView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.CollectionView

 */

Northwind.Common.Components.Grid.HeaderView = Ember.CollectionView.extend({

 	tagName: 'tr',

    contentBinding: 'controller.visibleColumns',

 	itemViewClass: Ember.View.extend({
 	    tagName: 'th',
        classNames: ['table-header-cell'],
 		template: Ember.Handlebars.compile('{{view.content.header}}')        
 	})

 });
;/**
	`BodyView` 

	@class 		BodyView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.CollectionView

 */

Northwind.Common.Components.Grid.BodyView = Ember.CollectionView.extend({

 	tagName: 'tbody',

 	contentBinding: 'controller.rows',

 	classNames: ['table-body'],

 	itemViewClass: 'Northwind.Common.Components.Grid.RowView',

 	/**
        emptyView
 	**/
 	emptyView: Ember.View.extend({
 		tagName: 'tr',
 		template: Ember.Handlebars.compile('<td {{bindAttr colspan="controller.columns.length"}} class="muted">No hay elementos</td>')
 	})

 });
;/**
	`RowView` 

	@class 		RowView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.View

 */

Northwind.Common.Components.Grid.RowView = Ember.ContainerView.extend({

    tagName: 'tr',

    classNames: ['table-row'],

    rowBinding: 'content',

    columnsBinding: 'controller.visibleColumns',

    /**
        columnsDidChange
    **/
    columnsDidChange: function () {

        if (this.get('columns')) {
            this.clear();
            this.get('columns').forEach(function (column) {
                var cell = column.get('viewClass').create({
                    column: column,
                    content: this.get('row')
                });

                this.pushObject(cell);

            }, this);
        }

    }.observes('columns.@each'),

    /**
    init
    **/
    init: function () {
        this._super();
        this.columnsDidChange();
    }

});
;/**
	`TableView` 

	@class 		CellView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.View

 */

Northwind.Common.Components.Grid.CellView = Ember.View.extend({

 	tagName: 'td'

 });
;/**
	`FooterView` 

	@class 		FooterView
	@namespace 	Northwind.Common.Components.Grid
	@extends 	Ember.CollectionView

 */

Northwind.Common.Components.Grid.FooterView = Ember.ContainerView.extend({

    tagName: 'tfoot',

    classNames: ['table-footer', 'text-muted'],

    childViews: ['gridFooter'],

    gridFooter: Ember.View.create({

        tagName: 'tr',

        template: Ember.Handlebars.compile(
            '<td {{bindAttr colspan="controller.columns.length"}}>' + 
                '{{view Northwind.Common.Components.Grid.PageView}}' + 
                '{{view Northwind.Common.Components.Grid.PaginationView}}' + 
            '</td>'
        )

    })

});
;var precompileTemplate = Ember.Handlebars.compile;

/**
	`AvatarView` 

	@class 		GridView
	@namespace 	Northwind.Common.Components.Avatar
	@extends 	Ember.View

 */

Northwind.Common.Components.Avatar.AvatarView = Northwind.Common.Components.Grid.CellView.extend({
	
	image: null,

	title: null,

	subtitle: null,
	
	template: function () {

		var image = this.get('image');
		var title = this.get('title');
		var subtitle = this.get('subtitle');
		var avatarClasses = ['img-circle', 'avatar'];
		var templateStr = '';		

		if (image) {
			templateStr += '<img src="' + image + '" class="img-circle avatar">';
		} else {
			templateStr += '<i class="fa fa-user ' + avatarClasses.join(' ') + '"></i>';
		}
	
		if (title) {
			templateStr += '{{#link-to \'' + this.get('controller.itemController') +'\' view.content class="title"}}{{' + title + '}}{{/link-to}}';
		}

		if (subtitle) {
			templateStr += '<span class="subtitle">{{' + subtitle + '}}</span>';
		}

		return precompileTemplate(templateStr);

	}.property('image', 'title', 'subtitle')
	
});
;/** 
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
;/** 
	`MapComponent`
	  
	Componente que utiliza Google Maps para la generación de mapas.
	  
	El modo mas facil de crear un `MapComponent` es mediante una plantilla,
	como por ejemplo:
	  
	```html
	{{map address="1 Infinite Loop"}}
	```	  
	  
	@class        GoogleMapComponent
	@namespace    Northwind
	@extends      Ember.Component    
  
**/
Northwind.GoogleMapComponent = Ember.Component.extend({

	latitude: 0,

	longitude: 0,

	address: 0,

	marker: null,

	map: null,

	draggable: false,

	isDragging: false,

	width: 0,

	height: 0,

	/**
		Método que se dispara cuando el valor de `address` cambia

		@method		addressChanged
	**/
	addressChanged: function () {

		var address = this.get("address");
  
	    if ( !address ) return;
	  
	    var geocoder = new google.maps.Geocoder();        
	    var self = this;
	  
	    geocoder.geocode({ 'address': address }, function (results, status) {
	      
	      // Obtenemos la latitud y longitud de la dirección indicada
	      self.setProperties({
	        latitude: results[0].geometry.location.lat(),
	        longitude: results[0].geometry.location.lng()
	      });          
	      
	    });

	}.observes('address'),

	/**
		Método que se dispara cuando el valor de `latitude` o `longitude` cambia

		@method		coordinatesChanged
	**/
	coordinatesChanged: function () {

		var latitude = this.get('latitude');
		var longitude = this.get('longitude');
		var position = new google.maps.LatLng(latitude, longitude);		

		// Centramos el mapa a la nueva posición
		this.get('map').setCenter(position);
		// Actualizamos el marcador
		this.get('marker').setPosition(position);

	}.observes('latitude', 'longitude'),

	/**
		Método que se ejecuta cuando se va a añadir el elemento al DOM
	**/
	didInsertElement: function() {

		var self = this;

		// Necesario para renderizar el mapa
    	this.$().css({ 
    		width: self.get('width'), 
    		height: self.get('height')
    	});

		var latitude = this.get('latitude');
		var longitude = this.get('longitude');
		var draggable = this.get('draggable');

		// Objeto que se encargará de centrar el mapa y el marcador
		var center = new google.maps.LatLng(latitude, longitude);

		// Opciones
		var options = {
			disableDefaultUI: true,
			center: center,
			zoom: 15,
			mapTypeId: google.maps.MapTypeId.ROADMAP
		};

		// Creación del mapa
		var map = new google.maps.Map(this.$()[0], options);

		// Creación del marcador
		var marker = new google.maps.Marker({ 
			position: center, 
			map: map, 
			draggable: false 
		});

		this.set('map', map);
		this.set('marker', marker);		

		// Creamos los listeners si se permite arrastrar el marcador
		if (draggable) {
			google.maps.event.addListener(marker, "drag", function () {

				// Posición actual del marcador
				var position = marker.getPosition();

				// Actualizamos la latitud y la longitud
				self.setProperties({
					latitude: position.lat(),
					longitude: position.lng()
				});
			});

			google.maps.event.addListener(marker, "dragstart", function () {

				self.set('isDragging', true);

			});

			google.maps.event.addListener(marker, "dragend", function () {

				self.set('isDragging', false);

			});
		}

	},

	/**
		Método que se ejecuta cuando se va a destruir el elemento del DOM
	**/
	willDestroyElement: function() {
		// Eliminamos los listeners
    	google.maps.event.clearInstanceListeners(this.get("marker"));
	}

});
;/**
    `ApplicationAdapter` 

    @class 		ApplicationAdapter
    @namespace 	Northwind
    @extends 	DS.RESTAdapter
    @see 		http://stackoverflow.com/questions/16037175/ember-data-serializer-data-mapping/16042261#16042261

*/
Northwind.ApplicationAdapter = DS.RESTAdapter.extend({

	/**
		host
	**/
    host: 'http://localhost:2828',

    /**
    	serializer
    **/
    serializer: Northwind.ApplicationSerializer


});
;/**
    `ApplicationSerializer` 

    @class      ApplicationSerializer
    @namespace  Northwind
    @extends    DS.RESTSerializer

*/

Northwind.ApplicationSerializer = DS.RESTSerializer.extend({

    /**
        `extractArray`

        Eliminamos del JSON aquellos elementos que no son compatibles con un JSON de Ember.
        En este caso, `count` no es necesario ya que tenemos el mismo valor en los metadatos
    **/
    extractArray: function (store, primaryType, payload) {
        
        delete payload.count;
        
        this.extractMeta(store, primaryType, payload);

        return this._super(store, primaryType, payload);

    },    

    /**
        `extractMeta`

        Extraemos los metadatos. Ember busca los metadatos en un objeto `meta`, pero Northwind
        los envía en el objeto `metadata`
    **/
    extractMeta: function (store, type, payload) {

        if (payload && payload.metadata) {
            store.metaForType(type, payload.metadata);
            delete payload.metadata;
        }

    },

    /**
        `serializeIntoHash`

        El JSON que necesita Northwind en las operaciones POST/PUT no tiene
        elemento raíz, así que sobreescribimos este método para eliminarlo
    **/
    serializeIntoHash: function(hash, type, record, options) {

        Ember.merge(hash, this.serialize(record, options));

    }

});


;/**
	Router mapping
**/
Northwind.Router.map(function () {

	// Customers
    this.resource('customers', function () {
        this.resource('customer', { path: ':customer_id' }, function () {
        	this.route('orders');
        });
    });

    // Orders
    this.resource('orders', function () {
    	this.resource('order', { path: ':order_id' });
    });

    // Suppliers
    this.resource('suppliers', function () {
    	this.resource('supplier', { path: ':supplier_id' });
    });

    // About
    this.resource('about');

});

/**
    `ApplicationRoute` 

    @class 		ApplicationRoute
    @namespace 	Northwind
    @extends 	Ember.Route

*/
Northwind.ApplicationRoute = Ember.Route.extend({

	/**
		model
	**/    
	model: function () {
		
		return Ember.$.getJSON('/resources').then(function (data) {
			var apis = data.apis;
			var resources = [];

			apis.forEach(function (api) {
				var path = api.path.substring(api.path.lastIndexOf('/') + 1);

				var res = Ember.Object.create({
					name: path.camelize(),
					icon: '',
					path: path,
					description: api.description
				});

				var icon = '';

				switch (res.name) {
					case 'customers':
					    icon = 'fa-group';
						break;
					case 'orders':
						icon = 'fa-folder';
						break;
					case 'suppliers':
						icon = 'fa-truck';
						break;
				}

				res.set('icon', icon);

				resources.pushObject(res);
			});

			return resources;
		});

	},

	/**
		setupController
	**/
	setupController: function (controller, model) {

		controller.set('content', model);

	}	

});
;/**
    CustomersRoute
**/
Northwind.CustomersRoute = Ember.Route.extend({   

    controller: null,

    /**
        model
    **/
    model: function () {

        var controller = this.controllerFor('customers');

        if (controller) {
            return this.get('store').findQuery('customer', { offset: controller.offset, limit: controller.limit });
        }        

    },   

    /**
        setupController
    **/
    setupController: function (controller, model) {        
        controller.set('content', model);
        controller.set('contentLoaded', true);

        this.set('controller', controller);
    },

    /**
        renderTemplate
    **/
    renderTemplate: function () {

        this.render('customers', {
            into: 'application',
            outlet: 'content'
        });

        this.render('customer-list', {
            into: 'customers',
            outlet: 'customerList'
        });

    }

});
;/**
    CustomersRoute
**/
Northwind.CustomerRoute = Ember.Route.extend({

	/**
		model
	**/
    model: function (params) {

        return this.get('store').find('customer', params.customer_id);

    },

    /**
    renderTemplate
    **/
    renderTemplate: function () {

        this.render('customer', {
            into: 'customers',
            outlet: 'customerDetail'
        });

    }    

});
;/**
    OrdersRoute
**/
Northwind.OrdersRoute = Ember.Route.extend({    

    /**
        model
    **/
    model: function () {

        var controller = this.controllerFor('order');
        
        return this.get('store').findQuery('order', { offset: controller.offset, limit: controller.limit });

    },   

    /**
        setupController
    **/
    setupController: function (controller, model) {
        controller.set('content', model);
        controller.set('contentLoaded', true);
    },

    /**
        renderTemplate
    **/
    renderTemplate: function () {

        this.render('order-list', {
            into: 'application',
            outlet: 'content'
        });

    }

});
;/**
	OrderRoute
**/
Northwind.OrderRoute = Ember.Route.extend({

    model: function (params) {

        return this.get('store').find('order', params.order_id);

    }
});
;/**
    SuppliersRoute
**/
Northwind.SuppliersRoute = Ember.Route.extend({    

    /**
        model
    **/
    model: function () {

        var controller = this.controllerFor('supplier');

        return this.get('store').findQuery('supplier', { offset: controller.offset, limit: controller.limit });

    },   

    /**
        setupController
    **/
    setupController: function (controller, model) {
        controller.set('content', model);
        controller.set('contentLoaded', true);
    },

    /**
    renderTemplate
    **/
    renderTemplate: function () {

        this.render('supplier-list', {
            into: 'application',
            outlet: 'content'
        });

    }

});
;/**
	OrderRoute
**/
Northwind.SupplierRoute = Ember.Route.extend({

    model: function (params) {

        return this.get('store').find('supplier', params.supplier_id);

    }
});
;/**
    `ObjectController` 

    @class 		ObjectController
    @namespace 	Northwind
    @extends 	Ember.ObjectController

*/
Northwind.ObjectController = Ember.ObjectController.extend({

	/**
		Indica si se está editando un registro

		@property	isEditing
		@type		{Boolean}

	**/
	isEditing: false,

	actions: {

		/**
			Modificación de un registro

			@action 	edit
		**/
		edit: function () {

			this.set('isEditing', true);

		},

		/**
			Se guardan los datos del registro

			@action 	acceptChanges
		**/
		acceptChanges: function () {

			this.set('isEditing', false);

			// Comprobamos que los campos obligatorios tienen datos
			if (this.get('model.isSaveable'))
			{
				this.send('save');
			} else {
				this.send('remove');
			}

		},

		/**
			Se guardan los datos del registro en la base de datos

			@action 	save
		**/
		save: function () {

			this.get('model').save();

		},

		/**
			Se elimina el registro

			@action 	remove
		**/
		remove: function () {

			this.get('model').deleteRecord();
			this.send('save');

		}

	}

});
;/**
    @class      ArrayController
    @namespace  Northwind
    @extends    Northwind.Common.Components.Grid.GridController
**/
Northwind.ArrayController = Ember.ArrayController.extend(Northwind.Common.Components.Grid.Pagination, {
    
    contentLoaded: false,

    modelType: Ember.computed(function () {

        var model = this.get('model');

        return model.type;

    }),
    
    /**
        @method loadMetadata

        Carga los metadatos.

        Este método se ejecuta una vez que todos los datos se han cargado.
    **/
    loadMetadata: function () { 

        if (!this.get('contentLoaded')) return;

        var model = this.get('model');
        var meta = this.get('store').metadataFor(model.type);

        if (meta) {
            // Creamos el objeto de metadatos
            var metadata = Ember.Object.create({
                offset: meta.offset,
                limit: meta.limit,
                totalCount: meta.totalCount,
                links: Ember.makeArray()
            });

            // Se añaden los enlaces de paginación
            if (meta.links) {
                for (var link in meta.links) {
                    var lnkObj = Ember.Object.create(Northwind.Common.Uri.queryParams(meta.links[link]));
                    lnkObj.set('rel', link);
                    metadata.links.pushObject(lnkObj);
                }
            }

            this.set('metadata', metadata);
            this.set('limit', metadata.limit);
            this.set('totalCount', metadata.totalCount);
        }

    }.observes('contentLoaded'),

    /**
        @method refresh

        Actualiza la información del controlador a partir de los datos de paginación actuales.

        Este método se dispara cuando se cambia de página de resultados
    **/
    refresh: function () {

        var offset = this.get('offset');
        var limit = this.get('limit');
        var modelType = this.get('modelType');
        var self = this;

        self.set('contentLoaded', false);

        this.get('store').findQuery(modelType, { offset: offset, limit: limit }).then(function (result) {          
            self.set('model', result);
            self.set('contentLoaded', true);
        });

    }.observes('page')

});
;/**
    `CustomerController` 

    @class 		CustomerController
    @namespace 	Northwind
    @extends 	Northwind.ObjectController

*/
Northwind.CustomerController = Northwind.ObjectController.extend({
		

});
;/**
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


;/**
    `OrderController` 

    @class 		OrderController
    @namespace 	Northwind
    @extends 	Northwind.ObjectController

*/
Northwind.OrderController = Northwind.ObjectController.extend({
		

});
;/**
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
;/**
    `SupplierController` 

    @class 		SupplierController
    @namespace 	Northwind
    @extends 	Northwind.ObjectController

*/
Northwind.SupplierController = Northwind.ObjectController.extend({
		

});
;/**
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
;/**
    `TextEditView` 

    @class 		TextEditView
    @namespace 	Northwind
    @extends 	Ember.TextField

*/
Northwind.TextEditView = Ember.TextField.extend({

	didInsertElement: function () {

		this.$().focus();
		
	}

});

Ember.Handlebars.helper('text-edit', Northwind.TextEditView);

;/** 
	Vista que se encarga de renderizar los datos de un customer

	@class		CustomerView
	@extends	Ember.View
	@namespace	Northwind	
**/
Northwind.CustomerView = Ember.View.extend({

	templateName: 'customer/customer',

	customerBinding: 'controller.content',

	updateTitle: function () {

	}.observes('customer.loaded', 'customer.id')	

});
;/**
	Clase base para todos los modelos definidos en Northwind

	@class		Model
	@extends	DS.Model
	@namespace	Northwind
	@module		@Northwind
**/

Northwind.Model = DS.Model.extend({

	required: [],

	/**
		Comprueba si todas las propiedades obligatorias del modelo tienen valor

		@property	isSaveable
		@type		{Boolean}
	**/
	isSaveable: function () {

		var required = this.get('required');
		var self = this;
		
		required.forEach(function (value) {			
			if(!self.get(value)) {
				return false;
			}
		});

		return true;

	}.property('required')

});

;/**
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

;/**
	@class		Order
	@extends	DS.Model
	@namespace	Northwind
	@module		@Northwind
**/

Northwind.Order = Northwind.Model.extend({
	employeeId: DS.attr('number'),
	orderDate: DS.attr('string'),
	requiredDate: DS.attr('string'),
	shippedDate: DS.attr('string'),
	freight: DS.attr('number'),
	shipName: DS.attr('string'),
	shipAddress: DS.attr('string'),
	shipCity: DS.attr('string'),
	shipRegion: DS.attr('string'),
	shipPostalCode: DS.attr('string'),
	shipCountry: DS.attr('string'),
	
    customer: DS.belongsTo('customer')

});

;/**
	@class		OrderDetail
	@extends	DS.Model
	@namespace	Northwind
	@module		@Northwind
**/

Northwind.OrderDetail = Northwind.Model.extend({
	productId: DS.attr('long'),
	unitPrice: DS.attr('decimal'),
	quantity: DS.attr('long'),
	discount: DS.attr('double'),

    order: DS.belongsTo('order')
	
});

;/**
	@class		Supplier
	@extends	DS.Model
	@namespace	Northwind
	@module		@Northwind
**/

Northwind.Supplier = DS.Model.extend({
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
	homePage: DS.attr('string')
	
});

