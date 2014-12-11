# Nortwind [![Build status](https://ci.appveyor.com/api/projects/status/swi5h3ncwxfcoaq1?svg=true)](https://ci.appveyor.com/project/jdmartinez/northwind)

Ejemplo de servicio web RESTful con interfaz de usuario HTML5 y CSS3. Este proyecto incluye algunos proyectos de código abierto como: 

- [ServiceStack](http://www.servicestack.net/) - Librería .NET para el desarrollo de servicios web.
  - [Bundler](https://github.com/ServiceStack/Bundler) - Utilizades basadas en node.js para la unión y compresión de archivos CoffeeScript, Less, Sass, js y css. 
- [ASP.NET MVC3](http://www.asp.net/mvc/mvc3) - ASP.NET MVC Web Framework
- [Grunt](http://gruntjs.com/) - Gestor de tareas programadas basado en node.js
  - [grunt-ember-templates](https://github.com/dgeb/grunt-ember-templates) - Precompilador de plantillas Handlebars 
- [Twitter Bootstrap](http://twitter.github.com/bootstrap/) - Librería CSS de diseño web.
- [EmberJS](http://emberjs.com/) - Librería para el desarrollo de aplicaciones web.
  - [Handlebars](http://handlebarsjs.com/) - Librería para la creación de plantillas web.
  - [jQuery](http://jquery.com/) - Librería para la manipulación del DOM.


## Características actuales ##

Actualmente el proyecto soporta una pequeña serie de características. Las que están disponibles actualmente son:

**Servidor**

- Recuperación de elementos y colecciones (sólo *Customers* y *Orders*).
- Paginación.
- Primer intento de resultados parciales.
- Autenticación

## Características planeadas ##

Las características planeadas para este desarrollo son:

**Servidor**

- Relaciones.
- Resultados parciales en entidades relacionadas.
- Filtrado.
- Gestión de errores.
- Agregados (`COUNT`, `MAX`, etc.).

**Web**

El objetivo es implementar una especie de aplicación CRM que utilice todas las características que ofrece el servicio utilizando HTML5 y CSS3.

