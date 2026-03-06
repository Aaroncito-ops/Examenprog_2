using System.Data;
using Dapper;
using FoodCampus.Application.Interfaces;
using FoodCampus.Application.Mappers;
using FoodCampus.Domain;
using FoodCampus.Infrastructure.Models;
using Microsoft.Data.SqlClient;

namespace FoodCampus.Infrastructure.Repositories;

public class PedidoRepository(string connectionString) : IPedidoRepository
{
    public async Task<int> CreateAsync(Pedido pedido, IEnumerable<DetallePedido> detalles)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        using var transaction = connection.BeginTransaction();

        try
        {
            const string sqlPedido = @"
                INSERT INTO Pedido (Usuario, Fecha, CostoEnvio) 
                VALUES (@Usuario, @Fecha, @CostoEnvio);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            var pedidoId = await connection.QuerySingleAsync<int>(sqlPedido, new 
            { 
                pedido.Usuario,
                pedido.Fecha, 
                pedido.CostoEnvio 
            }, transaction);

            const string sqlDetalle = @"
                INSERT INTO DetallePedido (PedidoId, RestauranteId, Cantidad, PrecioUnitario)
                VALUES (@PedidoId, @RestauranteId, @Cantidad, @PrecioUnitario);";

            foreach (var detalle in detalles)
            {
                await connection.ExecuteAsync(sqlDetalle, new 
                { 
                    PedidoId = pedidoId,
                    detalle.RestauranteId,
                    detalle.Cantidad,
                    detalle.PrecioUnitario
                }, transaction);
            }

            transaction.Commit();
            return pedidoId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<Pedido?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(connectionString);
        var model = await connection.QueryFirstOrDefaultAsync<PedidoModel>(
            "SELECT * FROM Pedido WHERE Id = @Id", new { Id = id });
        return model?.ToDomain();
    }

    public async Task<IEnumerable<Pedido>> GetByUsuarioAsync(string usuario)
    {
        using var connection = new SqlConnection(connectionString);
        var models = await connection.QueryAsync<PedidoModel>(
            "SELECT * FROM Pedido WHERE Usuario = @Usuario", new { Usuario = usuario });
        return models.Select(m => m.ToDomain());
    }

    public async Task<IEnumerable<DetallePedido>> GetDetallesByPedidoIdAsync(int pedidoId)
    {
        using var connection = new SqlConnection(connectionString);
        var models = await connection.QueryAsync<DetallePedidoModel>(
            "SELECT * FROM DetallePedido WHERE PedidoId = @PedidoId", new { PedidoId = pedidoId });
        return models.Select(m => m.ToDomain());
    }
}
