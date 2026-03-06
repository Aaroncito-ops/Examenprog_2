namespace FoodCampus.Domain;

public class Restaurante(int id, string nombre, string especialidad, TimeSpan horarioApertura, TimeSpan horarioCierre)
{
    public int Id { get; } = id;
    public string Nombre { get; } = nombre;
    public string Especialidad { get; } = especialidad;
    public TimeSpan HorarioApertura { get; } = horarioApertura;
    public TimeSpan HorarioCierre { get; } = horarioCierre;
}

// Extension member for Restaurante
public static class RestauranteExtensions
{
    // C# 14 allows extension members. Here implemented as an extension property.
    public static bool EstaAbierto(this Restaurante restaurante)
    {
        var now = TimeSpan.FromTicks(DateTime.Now.Ticks % TimeSpan.TicksPerDay);
        return now >= restaurante.HorarioApertura && now <= restaurante.HorarioCierre;
    }
}
