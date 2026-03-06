# Prompt 07: Servicios de Aplicación (Casos de Uso)

Actúa como un arquitecto de software senior. Genera las clases `ServicioCatalogo` y `ServicioPedidos` en `FoodCampus.Application.Services`.
1. `ServicioCatalogo`: ObtenerRestaurantesAsync, ObtenerRestaurantePorIdAsync.
2. `ServicioPedidos`:
   - `RegistrarPedidoAsync`: Recibe `Pedido` y lista de `DetallePedido`, valida que el restaurante esté abierto y registra.
   - `ObtenerPedidoPorIdAsync`: Obtiene el pedido y sus detalles, calculando el total (detalles + costo envío).
   - `ObtenerPedidosPorUsuarioAsync`: Obtiene la lista de pedidos filtrados por usuario, calculando el total acumulado para cada uno.
   - `ObtenerDetallesPedidoAsync`: Obtiene los detalles de un pedido incluyendo el nombre del restaurante.

Utiliza inyección de dependencias para los repositorios. Genera solo el código C#.
