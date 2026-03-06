# Prompt 06: Implementación de Repositorios (Dapper)

Actúa como un desarrollador backend experto en C#. Genera las interfaces `IRestauranteRepository` e `IPedidoRepository` y sus implementaciones en `FoodCampus.Infrastructure.Repositories` usando Dapper. 
1. `IRestauranteRepository`: GetAllAsync, GetByIdAsync, CreateAsync.
2. `IPedidoRepository`: CreateAsync (transaccional maestro-detalle), GetByIdAsync, GetByUsuarioAsync (que filtre por el nombre de usuario), GetDetallesByPedidoIdAsync.
3. El método `CreateAsync` de `IPedidoRepository` debe guardar el campo `Usuario` en la tabla `Pedido`.

Asegura el uso de `IDbConnection` y la liberación de recursos adecuada. Genera solo el código C#.
