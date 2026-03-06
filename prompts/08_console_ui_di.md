# Prompt 8: Interfaz de Consola y Resiliencia

**Rol:** Desarrollador de Aplicaciones Multiplataforma.
**Contexto:** Proyecto `FoodCampus.API` (Consola).
**Tarea:** Crear el menú interactivo y configurar el arranque del sistema.

**Requisitos Técnicos:**
1. **Inyección de Dependencias:** Configurar `ServiceCollection` usando **Unbound Generics** con la sintaxis `nameof(Repository<>)` para el registro de logs o repositorios genéricos.
2. **Robustez:** Implementar un bucle de menú que use `TryParse` para todas las entradas del usuario.
3. **Resiliencia:** Envolver las llamadas a los servicios en bloques `try-catch` específicos para errores de SQL (timeouts de Somee), mostrando mensajes amigables en color **Rojo** sin que la app se cierre.
4. El menú debe permitir: Registrar restaurante, Consultar catálogo y Crear Pedido Maestro-Detalle.