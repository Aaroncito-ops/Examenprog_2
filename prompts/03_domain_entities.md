# Prompt 03: Entidades del Dominio

Actúa como un desarrollador backend experto en C#. Genera las entidades del dominio para el proyecto "FoodCampus" en el namespace `FoodCampus.Domain`. 
Deben ser clases con lógica de validación interna simple:
1. `Restaurante`: Id (int), Nombre (string), Especialidad (string), HorarioApertura (TimeSpan), HorarioCierre (TimeSpan). Agregar método `EstaAbierto()` que compare con la hora actual.
2. `Pedido`: Id (int), Usuario (string), Fecha (DateTime), CostoEnvio (decimal). Validar que el costo de envío no sea negativo.
3. `DetallePedido`: Id (int), PedidoId (int), RestauranteId (int), Cantidad (int), PrecioUnitario (decimal).

Utiliza constructores para inicializar las propiedades. Genera solo el código C#.
