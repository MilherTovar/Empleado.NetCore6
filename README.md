# Empleado.NetCore6
Prueba realizada en .net Core 6

Para la realización de las pruebas de los diferentes servicios se uso Insomnia
Se encuentran dos entidades:
Company
	CompanyName
	LegalRepresentCompany
	Activo
Empleado
	Nombres
	Apellidos
	Identificacion
	email
	Activo
	Company

En base de datos, dado el mapeo se crearon las tablas de forma automática con EntityFramework, las siguientes tablas

Company
	Id	Llave primaria
	CompanyName
	LegalRepresentCompany
	Activo
Empleado
	Id	Llave primaria
	Nombres
	Apellidos
	Identificacion
	email
	Activo
	idCompany	Llave foranea

Se puede incluir más tablas, entre esas el tipo de documento y crear una tabla adicional, de tal manera se puede ir creciendo la base de datos de una de esta formas

Company			Empleado			TipoIdentificación
Id (Primaria)		Id (Primaria)			Id (Primaria)
			idCompany (Foranea)
			idTipoDocumentacion (Foranea)

Al instalar la base de datos en otra máquina diferente a la del BackEnd, se debe tener en cuenta que se debe realizar la modificación en el fichero denominado "appsettings.json" la sección de "ConnectionStrings" ubicar el Data Source correspondiente

Si en el futuro se piensa migrar se debe tener en cuenta que se debe cambiar en las opciones de los servicios de "program", en la adición del contexto que se va a usar MySql en vez de usar sql Server, esto también conlleva a que debe cambiar la cadena de conexión; después de haber realizado estos ajustes deberá ejecutar comandos de dotnet ef migrations add "(Mensajes propios de la migración)" y actualizar la base de datos mediante el comando: dotnet ef database update, esta serie de comando junto con las configuraciones anteriores permitirá con facilidad migrar de Sql Server a MySql.

El proceso de migración (incluyendo la generación inicial de la base de datos), genera una 
tabla inicial que se denomina __EFMigrationsHistory

En el momento de realizar esta prueba se generaron tres migraciones
20220528175033_Migración Inicial	6.0.5
20220528191240_Inclusión de tabla de Empleado y de campos de Activo en tabla de Company	6.0.5
20220528222143_Se agrega Identity	6.0.5

Para la parte de la seguridad de los servicios se uso JWT e Identity, la implementación de esta estrategia definió en base de datos las siguientes tablas:

AspNetRolesClaims
AspNetRoles
AspNetUserClaims
AspNetUserLogins
AspNetUserRoles
AspNetUsers
AspNetUserTokens

De tal manera que para el consumo de cualquier servicio se requiere de un token generado.

Sobre el proyecto, se realizó un proyecto de capas usando como patrón de diseño Repository

Las capas fueron las siguientes

DataAccess
Entities
Repository
Application
Abstractions

Los EndPoints fueron creados a través de un proyecto WebApi para .net core 6; para l transferencia de datos se usaron diferentes DTO que se encuentran en el proyecto de WebApi.

La capa de servicio se uso para el proceso de autenticación