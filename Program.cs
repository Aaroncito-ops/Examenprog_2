using Microsoft.Extensions.DependencyInjection;
using FoodCampus.Application.Interfaces;
using FoodCampus.Application.Services;
using FoodCampus.Infrastructure.Repositories;
using FoodCampus.Infrastructure.Logging;
using FoodCampus.Domain;
using System.Globalization;
using Microsoft.Data.SqlClient;
using FoodCampus.Application.Exceptions;

// Configuración de la cadena de conexión
const string connectionString = "Server=test_utm_ACM.mssql.somee.com;Initial Catalog=test_utm_ACM;Persist Security Info=False;User ID=Aaroncito_SQLLogin_1;Password=o9s2vr4q6l;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

// Inyección de Dependencias
var services = new ServiceCollection();

// Unbound Generics registration: nameof(AppLogger<>)
services.AddSingleton(typeof(IAppLogger<>), typeof(AppLogger<>));

services.AddSingleton<IRestauranteRepository>(_ => new RestauranteRepository(connectionString));
services.AddSingleton<IPedidoRepository>(_ => new PedidoRepository(connectionString));
services.AddSingleton<ServicioCatalogo>();
services.AddSingleton<ServicioPedidos>();

var serviceProvider = services.BuildServiceProvider();

// Logger principal para Program
var logger = serviceProvider.GetRequiredService<IAppLogger<Program>>();
var catalogo = serviceProvider.GetRequiredService<ServicioCatalogo>();
var pedidosServicio = serviceProvider.GetRequiredService<ServicioPedidos>();
var restauranteRepo = serviceProvider.GetRequiredService<IRestauranteRepository>();

bool salir = false;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA FOODCAMPUS ===");
    Console.WriteLine("1. Consultar Catálogo de Restaurantes");
    Console.WriteLine("2. Registrar Nuevo Restaurante");
    Console.WriteLine("3. Crear Nuevo Pedido (Maestro-Detalle)");
    Console.WriteLine("4. Consultar Pedidos por Usuario");
    Console.WriteLine("5. Salir");
    Console.Write("\nSeleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out int opcion)) continue;

    try
    {
        switch (opcion)
        {
            case 1:
                await MostrarCatalogo(catalogo);
                break;
            case 2:
                await RegistrarRestaurante(restauranteRepo, logger);
                break;
            case 3:
                await CrearPedido(pedidosServicio, catalogo, logger);
                break;
            case 4:
                await ConsultarPedidosPorUsuario(pedidosServicio);
                break;
            case 5:
                salir = true;
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
    catch (SqlException ex)
    {
        logger.LogError("Error de base de datos (Somee/SQL Server). Puede ser un timeout o red.", ex);
    }
    catch (ReglaNegocioException ex)
    {
        logger.LogError("Inconsistencia en regla de negocio.", ex);
    }
    catch (Exception ex)
    {
        logger.LogError("Ocurrió un error inesperado.", ex);
    }

    if (!salir)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

async Task MostrarCatalogo(ServicioCatalogo service)
{
    var restaurantes = await service.ObtenerRestaurantesAsync();
    Console.WriteLine("\n--- Catálogo de Restaurantes ---");
    foreach (var r in restaurantes)
    {
        var estado = r.EstaAbierto ? "[ABIERTO]" : "[CERRADO]";
        Console.WriteLine($"{r.Id}. {r.Nombre} - {r.Especialidad} ({r.HorarioApertura}-{r.HorarioCierre}) {estado}");
    }
}

async Task RegistrarRestaurante(IRestauranteRepository repo, IAppLogger<Program> log)
{
    Console.WriteLine("\n--- Registro de Restaurante ---");
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine() ?? "";
    Console.Write("Especialidad: ");
    string especialidad = Console.ReadLine() ?? "";
    Console.Write("Horario Apertura (HH:mm): ");
    if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan apertura)) return;
    Console.Write("Horario Cierre (HH:mm): ");
    if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan cierre)) return;

    var nuevo = new Restaurante(0, nombre, especialidad, apertura, cierre);
    int id = await repo.CreateAsync(nuevo);
    log.LogInfo($"Restaurante registrado con éxito. ID: {id}");
}

async Task CrearPedido(ServicioPedidos serv, ServicioCatalogo cat, IAppLogger<Program> log)
{
    Console.WriteLine("\n--- Creación de Pedido Maestro-Detalle ---");
    
    Console.Write("Nombre del Usuario: ");
    string usuario = Console.ReadLine() ?? "Anonimo";

    await MostrarCatalogo(cat);
    
    Console.Write("\nID del Restaurante para el pedido: ");
    if (!int.TryParse(Console.ReadLine(), out int restId)) return;
    
    Console.Write("Cantidad: ");
    if (!int.TryParse(Console.ReadLine(), out int cant)) return;
    
    Console.Write("Precio Unitario: ");
    if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio)) return;

    var pedido = new Pedido(0, usuario, DateTime.Now, 15.00m); // Costo envío fijo para prueba
    var detalle = new DetallePedido(0, 0, restId, cant, precio);
    
    int pedidoId = await serv.RegistrarPedidoAsync(pedido, new[] { detalle });
    log.LogInfo($"Pedido #{pedidoId} registrado correctamente para el usuario {usuario}.");
}

async Task ConsultarPedidosPorUsuario(ServicioPedidos serv)
{
    Console.WriteLine("\n--- Consulta de Pedidos por Usuario ---");
    Console.Write("Ingrese el nombre del usuario: ");
    string usuario = Console.ReadLine() ?? "";

    var pedidos = await serv.ObtenerPedidosPorUsuarioAsync(usuario);
    
    if (!pedidos.Any())
    {
        Console.WriteLine($"No se encontraron pedidos para el usuario: {usuario}");
        return;
    }

    Console.WriteLine($"\nPedidos de {usuario}:");
    foreach (var p in pedidos)
    {
        Console.WriteLine($"- ID: {p.Id}, Fecha: {p.Fecha:dd/MM/yyyy HH:mm}, Total: {p.Total:C}");
        var detalles = await serv.ObtenerDetallesPedidoAsync(p.Id);
        foreach (var d in detalles)
        {
            Console.WriteLine($"  * {d.RestauranteNombre}: {d.Cantidad} x {d.PrecioUnitario:C} = {d.Subtotal:C}");
        }
    }
}
