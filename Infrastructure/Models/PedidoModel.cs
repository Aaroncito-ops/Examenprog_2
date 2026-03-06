using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCampus.Infrastructure.Models;

[Table("Pedido")]
public class PedidoModel
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Usuario { get; set; } = string.Empty;

    [Required]
    public DateTime Fecha { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal CostoEnvio { get; set; }
}
