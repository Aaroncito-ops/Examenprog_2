# Prompt 04: Modelos de Infraestructura (Dapper/EF)

Actúa como un desarrollador backend para el proyecto "FoodCampus". 
Genera las clases de modelo para la infraestructura en el namespace `FoodCampus.Infrastructure.Models`:
1. `RestauranteModel`: Refleja las columnas de la tabla `Restaurante`.
2. `PedidoModel`: Refleja las columnas de la tabla `Pedido` (incluyendo `Usuario` NVARCHAR, `Fecha` DATETIME, `CostoEnvio` DECIMAL).
3. `DetallePedidoModel`: Refleja las columnas de la tabla `DetallePedido`.

Asegura que los tipos de datos en C# correspondan con los tipos de SQL Server. Agrega atributos de DataAnnotations como [Table], [Key] y [Required].
Genera solo el código C#.
