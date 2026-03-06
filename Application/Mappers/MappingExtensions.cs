using FoodCampus.Domain;
using FoodCampus.Infrastructure.Models;
using FoodCampus.Application.DTOs;

namespace FoodCampus.Application.Mappers;

public static class MappingExtensions
{
    // Infrastructure Model -> Domain Entity
    public static Restaurante ToDomain(this RestauranteModel model) =>
        new(model.Id, model.Nombre, model.Especialidad, model.HorarioApertura, model.HorarioCierre);

    public static Pedido ToDomain(this PedidoModel model) =>
        new(model.Id, model.Usuario, model.Fecha, model.CostoEnvio);

    public static DetallePedido ToDomain(this DetallePedidoModel model) =>
        new(model.Id, model.PedidoId, model.RestauranteId, model.Cantidad, model.PrecioUnitario);

    // Domain Entity -> Presentation DTO
    public static RestauranteDTO ToDTO(this Restaurante restaurante) =>
        new(
            restaurante.Id,
            restaurante.Nombre,
            restaurante.Especialidad,
            restaurante.HorarioApertura.ToString(@"hh\:mm"),
            restaurante.HorarioCierre.ToString(@"hh\:mm"),
            restaurante.EstaAbierto()
        );

    public static PedidoDTO ToDTO(this Pedido pedido, decimal totalCalculado) =>
        new(pedido.Id, pedido.Usuario, pedido.Fecha, pedido.CostoEnvio, totalCalculado);

    public static DetallePedidoDTO ToDTO(this DetallePedido detalle, string restauranteNombre) =>
        new(
            detalle.Id,
            detalle.RestauranteId,
            restauranteNombre,
            detalle.Cantidad,
            detalle.PrecioUnitario,
            detalle.Cantidad * detalle.PrecioUnitario
        );
}
