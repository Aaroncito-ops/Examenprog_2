using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCampus.Infrastructure.Models;

[Table("DetallePedido")]
public class DetallePedidoModel
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int PedidoId { get; set; }
    
    [Required]
    public int RestauranteId { get; set; }
    
    [Required]
    public int Cantidad { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrecioUnitario { get; set; }
}
