using System.Data;
using Dapper;
using FoodCampus.Application.Interfaces;
using FoodCampus.Application.Mappers;
using FoodCampus.Domain;
using FoodCampus.Infrastructure.Models;
using Microsoft.Data.SqlClient;

namespace FoodCampus.Infrastructure.Repositories;

public class RestauranteRepository(string connectionString) : IRestauranteRepository
{
    public async Task<IEnumerable<Restaurante>> GetAllAsync()
    {
        using var connection = new SqlConnection(connectionString);
        var models = await connection.QueryAsync<RestauranteModel>("SELECT * FROM Restaurante");
        return models.Select(m => m.ToDomain());
    }

    public async Task<Restaurante?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(connectionString);
        var model = await connection.QueryFirstOrDefaultAsync<RestauranteModel>(
            "SELECT * FROM Restaurante WHERE Id = @Id", new { Id = id });
        return model?.ToDomain();
    }

    public async Task<int> CreateAsync(Restaurante restaurante)
    {
        using var connection = new SqlConnection(connectionString);
        const string sql = @"
            INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) 
            VALUES (@Nombre, @Especialidad, @HorarioApertura, @HorarioCierre);
            SELECT CAST(SCOPE_IDENTITY() as int);";

        return await connection.QuerySingleAsync<int>(sql, new 
        { 
            restaurante.Nombre, 
            restaurante.Especialidad, 
            restaurante.HorarioApertura, 
            restaurante.HorarioCierre 
        });
    }
}
