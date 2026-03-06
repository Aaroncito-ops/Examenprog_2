namespace FoodCampus.Application.Exceptions;

public class ReglaNegocioException(string message) : Exception(message);

public class RestauranteCerradoException(string nombreRestaurante) 
    : ReglaNegocioException($"El restaurante '{nombreRestaurante}' se encuentra cerrado actualmente.");
