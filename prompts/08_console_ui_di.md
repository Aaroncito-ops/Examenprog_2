# Prompt 08: Interfaz de Consola y DI

Actúa como un desarrollador backend para el proyecto "FoodCampus". 
Genera la clase `Program` que:
1. Configure `ServiceCollection` para inyección de dependencias (`IAppLogger`, `IRestauranteRepository`, `IPedidoRepository`, `ServicioCatalogo`, `ServicioPedidos`).
2. Utilice la cadena de conexión: `Server=test_utm_ACM.mssql.somee.com;Initial Catalog=test_utm_ACM;Persist Security Info=False;User ID=YourUser;Password=YourPassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;`.
3. Implemente un bucle `while` para mostrar el menú de consola:
   1. Consultar Catálogo de Restaurantes.
   2. Registrar Nuevo Restaurante (solicitar datos).
   3. Crear Nuevo Pedido (Maestro-Detalle), solicitando `Nombre del Usuario` al inicio.
   4. Consultar Pedidos por Usuario (solicitar nombre y mostrar lista de sus pedidos con detalles y totales).
   5. Salir.
4. Implemente el manejo de errores global (SQL, Reglas de Negocio, General).

Asegura que el diseño sea modular y profesional. Genera solo el código C#.
