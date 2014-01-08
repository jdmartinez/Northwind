Ember.TEMPLATES["about"] = Ember.Handlebars.template(function anonymous(Handlebars,depth0,helpers,partials,data) {
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
  var buffer = '', stack1, stack2, hashTypes, hashContexts, options, escapeExpression=this.escapeExpression, self=this, helperMissing=helpers.helperMissing;

function program1(depth0,data) {
  
  var buffer = '', hashTypes, hashContexts;
  data.buffer.push("\r\n            <dt>Fax</dt>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "fax", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n        ");
  return buffer;
  }

function program3(depth0,data) {
  
  
  data.buffer.push("\r\n                    <h3>Mapa</h3>\r\n                ");
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
  data.buffer.push("</dd>\r\n            <dt class=\"separator\"></dt>\r\n            <dl></dl>\r\n            <dt>Phone</dt>\r\n            <dd>");
  hashTypes = {};
  hashContexts = {};
  data.buffer.push(escapeExpression(helpers._triageMustache.call(depth0, "phone", {hash:{},contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data})));
  data.buffer.push("</dd>\r\n        ");
  hashTypes = {};
  hashContexts = {};
  stack1 = helpers['if'].call(depth0, "fax", {hash:{},inverse:self.noop,fn:self.program(1, program1, data),contexts:[depth0],types:["ID"],hashContexts:hashContexts,hashTypes:hashTypes,data:data});
  if(stack1 || stack1 === 0) { data.buffer.push(stack1); }
  data.buffer.push("\r\n            <dt class=\"separator\"></dt>\r\n            <dl></dl>\r\n            <dt>Mapa<dt>\r\n            <dd>\r\n                ");
  hashContexts = {'address': depth0,'width': depth0,'height': depth0};
  hashTypes = {'address': "ID",'width': "STRING",'height': "STRING"};
  options = {hash:{
    'address': ("completeAddress"),
    'width': ("100%"),
    'height': ("400px")
  },inverse:self.noop,fn:self.program(3, program3, data),contexts:[],types:[],hashContexts:hashContexts,hashTypes:hashTypes,data:data};
  stack2 = ((stack1 = helpers['google-map'] || depth0['google-map']),stack1 ? stack1.call(depth0, options) : helperMissing.call(depth0, "google-map", options));
  if(stack2 || stack2 === 0) { data.buffer.push(stack2); }
  data.buffer.push("\r\n            </dd>\r\n        </dl>        \r\n    </div>    \r\n</div>\r\n");
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