var precompileTemplate = Ember.Handlebars.compile;

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