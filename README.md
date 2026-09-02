# API de Registro de Clientes

## Descripción
CRUD en C# con ASP NET CORE

## Tecnologías
- C# / ASP.NET Core
- Entity Framework Core
- SQLite
- Swagger para documentación de la API
- 
## Cómo correr el proyecto
1. Clona el repositorio
2. Abre la solución en Visual Studio
3. Restaura los paquetes NuGet (se hace automático al abrir, o clic derecho en la solución > Restaurar paquetes NuGet)
4. En la Consola del Administrador de Paquetes, ejecuta: `Update-Database`
5. Presiona F5 para correr el proyecto
6. Se abrirá Swagger en el navegador con los endpoints disponibles

## Endpoints
| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/clientes | Lista todos los clientes |
| GET | /api/clientes/{id} | Consulta un cliente por id |
| POST | /api/clientes | Crea un nuevo cliente |
| PUT | /api/clientes/{id} | Actualiza un cliente |
| DELETE | /api/clientes/{id} | Elimina un cliente |

