using FoodCampus.Domain;

namespace FoodCampus.Application.Interfaces;

public interface IRestauranteRepository
{
    Task<IEnumerable<Restaurante>> GetAllAsync();
    Task<Restaurante?> GetByIdAsync(int id);
    Task<int> CreateAsync(Restaurante restaurante);
}

public interface IPedidoRepository
{
    Task<int> CreateAsync(Pedido pedido, IEnumerable<DetallePedido> detalles);
    Task<Pedido?> GetByIdAsync(int id);
    Task<IEnumerable<Pedido>> GetByUsuarioAsync(string usuario);
    Task<IEnumerable<DetallePedido>> GetDetallesByPedidoIdAsync(int pedidoId);
}
