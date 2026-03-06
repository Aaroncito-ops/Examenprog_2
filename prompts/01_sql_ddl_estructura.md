# Prompt 01: Creación de la Estructura de Base de Datos (DDL)

Actúa como un DBA Senior. Genera un script SQL compatible con SQL Server para el proyecto "FoodCampus". 
El script debe:
1. Usar la base de datos `test_utm_ACM`.
2. Eliminar las tablas si existen (`DetallePedido`, `Pedido`, `Restaurante`).
3. Crear la tabla `Restaurante` con: Id (PK, Identity), Nombre (NVARCHAR 100), Especialidad (NVARCHAR 100), HorarioApertura (TIME), HorarioCierre (TIME).
4. Crear la tabla `Pedido` (Maestro) con: Id (PK, Identity), Usuario (NVARCHAR 100), Fecha (DATETIME, default GETDATE), CostoEnvio (DECIMAL 18,2, default 0.00).
5. Crear la tabla `DetallePedido` con: Id (PK, Identity), PedidoId (FK), RestauranteId (FK), Cantidad (INT), PrecioUnitario (DECIMAL 18,2).
6. Asegurar las relaciones de llave foránea necesarias.

Genera solo el código SQL encapsulado en un bloque de código.
