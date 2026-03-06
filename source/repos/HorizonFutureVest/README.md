# HorizonFutureVest

Proyecto ASP.NET Core para simulaciones financieras por país y generación de reportes en pantalla, PDF y Excel.

Descripción

Aplicación web que permite ejecutar simulaciones por país y año, mostrar resultados detallados y exportarlos a Excel (EPPlus) o PDF (QuestPDF).

Requisitos

- .NET SDK 6.0 o superior
- SQL Server u otro proveedor compatible con Entity Framework Core
- (Opcional) dotnet-ef para migraciones

Dependencias importantes

- EPPlus — exportación a Excel. Asegúrate de configurar LicenseContext según tu uso.
- QuestPDF — generación de PDF. En el código se usa la licencia Community.
- Microsoft.EntityFrameworkCore y proveedor de base de datos correspondiente.

Configuración rápida

1. Ajusta la cadena de conexión en HorizonFutureVest.Web/appsettings.json (sección ConnectionStrings).
2. Restaurar paquetes: dotnet restore
3. (Opcional) Ejecutar migraciones:
   - dotnet tool install --global dotnet-ef
   - dotnet ef database update -p HorizonFutureVest.Persistence -s HorizonFutureVest.Web
4. Ejecutar el proyecto web:
   - dotnet run --project HorizonFutureVest.Web

Exportar y licencias

- EPPlus: si trabajas en entorno no comercial, fija `ExcelPackage.LicenseContext = LicenseContext.NonCommercial;` (o revisa la licencia para uso comercial).
- QuestPDF: en el código se establece `QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;`.

Subir a GitHub (ejemplo)

Si quieres subir el proyecto al repositorio https://github.com/Cristianl12/HorizonFutureVest, desde la carpeta raíz ejecuta:

1. git init (si no está inicializado)
2. git remote add origin https://github.com/Cristianl12/HorizonFutureVest.git
3. git add .
4. git commit -m "Initial commit: HorizonFutureVest"
5. git push -u origin main

Notas finales

- Revisa appsettings.json antes de subir credenciales o cadenas de conexión. Usa variables de entorno o secretos de usuario para información sensible.
- Añade un archivo LICENSE si quieres publicar con una licencia concreta.
