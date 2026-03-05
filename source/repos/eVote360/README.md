# eVote360

Sistema de votación digital con gestión integral de procesos electorales.

##  Descripción

eVote360 es una aplicación web para administrar y ejecutar procesos electorales de forma segura y eficiente. Permite la gestión de candidatos, partidos políticos, ciudadanos y resultados en tiempo real, con soporte para validación de documentos mediante OCR.

##  Arquitectura

Proyecto construido con arquitectura en capas:

- **eVote360.Web** - Presentación (ASP.NET Core MVC)
- **eVote360.Application** - Lógica de negocio y servicios
- **eVote360.Infrastructure** - Implementación de repositorios
- **eVote360.Persistence** - Contexto de base de datos (Entity Framework)
- **eVote360.Domain** - Entidades y contratos
- **eVote360.Shared** - Código compartido

##  Tecnologías

- **.NET 8.0**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server**
- **Identity & Roles**
- **OCR (api.ocr.space)**
- **AutoMapper**

##  Funcionalidades Principales

- Gestión de partidos políticos y candidatos
- Registro y autenticación de ciudadanos
- Sistema de votación con validación
- Reconocimiento de documentos (OCR)
- Panel de control administrativo
- Resultados electorales en tiempo real
- Control de acceso por roles (Administrador, Dirigente, Votante)

##  Instalación

1. Clonar el repositorio
2. Restaurar dependencias: `dotnet restore`
3. Configurar la base de datos en `appsettings.json`
4. Aplicar migraciones: `dotnet ef database update`
5. Ejecutar: `dotnet run`

##  Roles de Usuario

- **Administrador** - Acceso total al sistema
- **Dirigente** - Gestión de partidos y visualización de resultados
- **Votante** - Participación en procesos electorales

##  Licencia

MIT
