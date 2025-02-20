# **Proyecto Ecommerce Angular + .NET Core**

Este es un sistema de comercio electrónico desarrollado con **Angular** (frontend) y **.NET Core** (backend). Permite a los usuarios registrarse, iniciar sesión, agregar artículos al carrito, realizar compras y ver su historial de compras.


## **Requisitos Previos**

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

- **Node.js** (v16 o superior): Para ejecutar el frontend Angular.
  - Descarga: https://nodejs.org/
- **.NET SDK** (v6 o superior): Para ejecutar el backend.
  - Descarga: https://dotnet.microsoft.com/download
- **SQL Server**: Para la base de datos.
  - Puedes usar SQL Server Express o cualquier otra versión compatible.
- **Angular CLI**: Instala Angular CLI globalmente usando npm:
  ```bash
  npm install -g @angular/cli

## **Configuración del Proyecto**
- Clonar el Repositorio
- Abrirlo con VS
- Restaurar Dependencias
- Configurar la Conexión a la Base de Datos
Abre el archivo appsettings.json y configura la cadena de conexión a tu instancia de SQL Server:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=DB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
- Ejecuta las migraciones para crear la base de datos:
```bash
  Update-Database
```
La base de datos se crea automáticamente al aplicar las migraciones de Entity Framework Core. Sin embargo, se puede verificar la estructura de la base de datos en el archivo ApplicationDbContext.cs
La aplicacion abrira dos ventanas al momento de ejecutar en VS https://localhost:7007/swagger/index.html del backend y CRUD, y https://localhost:49744/login donde esta el aplicativo de Angular.
