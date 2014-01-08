/** 
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