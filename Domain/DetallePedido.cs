namespace FoodCampus.Domain;

public class DetallePedido(int id, int pedidoId, int restauranteId, int cantidad, decimal precioUnitario)
{
    public int Id { get; } = id;
    public int PedidoId { get; } = pedidoId;
    public int RestauranteId { get; } = restauranteId;
    public decimal PrecioUnitario { get; } = precioUnitario;

    public int Cantidad
    {
        get => field;
        set => field = value > 0 ? value : throw new ArgumentException("La cantidad debe ser mayor a cero.");
    } = cantidad;
}
