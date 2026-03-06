namespace FoodCampus.Domain;

public class Pedido(int id, string usuario, DateTime fecha, decimal costoEnvio)
{
    public int Id { get; } = id;
    public string Usuario { get; } = usuario;
    public DateTime Fecha { get; } = fecha;

    public decimal CostoEnvio
    {
        get => field;
        set => field = value >= 0 ? value : throw new ArgumentException("El costo de envío no puede ser negativo.");
    } = costoEnvio;
}
