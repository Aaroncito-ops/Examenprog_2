namespace FoodCampus.Application.DTOs;

public record RestauranteDTO(int Id, string Nombre, string Especialidad, string HorarioApertura, string HorarioCierre, bool EstaAbierto);

public record PedidoDTO(int Id, string Usuario, DateTime Fecha, decimal CostoEnvio, decimal Total);

public record DetallePedidoDTO(int Id, int RestauranteId, string RestauranteNombre, int Cantidad, decimal PrecioUnitario, decimal Subtotal);
