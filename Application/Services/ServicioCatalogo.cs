using FoodCampus.Application.DTOs;
using FoodCampus.Application.Interfaces;
using FoodCampus.Application.Mappers;

namespace FoodCampus.Application.Services;

public class ServicioCatalogo(IRestauranteRepository restauranteRepository)
{
    public async Task<IEnumerable<RestauranteDTO>> ObtenerRestaurantesAsync()
    {
        var restaurantes = await restauranteRepository.GetAllAsync();
        return restaurantes.Select(r => r.ToDTO());
    }

    public async Task<RestauranteDTO?> ObtenerRestaurantePorIdAsync(int id)
    {
        var restaurante = await restauranteRepository.GetByIdAsync(id);
        return restaurante?.ToDTO();
    }
}
