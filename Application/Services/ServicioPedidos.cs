using FoodCampus.Application.DTOs;
using FoodCampus.Application.Exceptions;
using FoodCampus.Application.Interfaces;
using FoodCampus.Application.Mappers;
using FoodCampus.Domain;

namespace FoodCampus.Application.Services;

public class ServicioPedidos(
    IPedidoRepository pedidoRepository, 
    IRestauranteRepository restauranteRepository)
{
    public async Task<int> RegistrarPedidoAsync(Pedido pedido, IEnumerable<DetallePedido> detalles)
    {
        // Validación de reglas de negocio
        foreach (var detalle in detalles)
        {
            var restaurante = await restauranteRepository.GetByIdAsync(detalle.RestauranteId)
                ?? throw new ReglaNegocioException($"El restaurante con ID {detalle.RestauranteId} no existe.");

            if (!restaurante.EstaAbierto())
            {
                throw new RestauranteCerradoException(restaurante.Nombre);
            }
        }

        // Persistencia orquestada mediante el repositorio transaccional
        return await pedidoRepository.CreateAsync(pedido, detalles);
    }

    public async Task<PedidoDTO?> ObtenerPedidoPorIdAsync(int id)
    {
        var pedido = await pedidoRepository.GetByIdAsync(id);
        if (pedido == null) return null;

        var detalles = await pedidoRepository.GetDetallesByPedidoIdAsync(id);
        var total = detalles.Sum(d => d.Cantidad * d.PrecioUnitario) + pedido.CostoEnvio;

        return pedido.ToDTO(total);
    }

    public async Task<IEnumerable<PedidoDTO>> ObtenerPedidosPorUsuarioAsync(string usuario)
    {
        var pedidos = await pedidoRepository.GetByUsuarioAsync(usuario);
        var result = new List<PedidoDTO>();

        foreach (var pedido in pedidos)
        {
            var detalles = await pedidoRepository.GetDetallesByPedidoIdAsync(pedido.Id);
            var total = detalles.Sum(d => d.Cantidad * d.PrecioUnitario) + pedido.CostoEnvio;
            result.Add(pedido.ToDTO(total));
        }

        return result;
    }

    public async Task<IEnumerable<DetallePedidoDTO>> ObtenerDetallesPedidoAsync(int pedidoId)
    {
        var detalles = await pedidoRepository.GetDetallesByPedidoIdAsync(pedidoId);
        var listaDetallesDto = new List<DetallePedidoDTO>();

        foreach (var d in detalles)
        {
            var restaurante = await restauranteRepository.GetByIdAsync(d.RestauranteId);
            listaDetallesDto.Add(d.ToDTO(restaurante?.Nombre ?? "Desconocido"));
        }

        return listaDetallesDto;
    }
}
