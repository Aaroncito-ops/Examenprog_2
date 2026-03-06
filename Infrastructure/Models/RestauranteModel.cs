using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCampus.Infrastructure.Models;

[Table("Restaurante")]
public class RestauranteModel
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string Especialidad { get; set; } = string.Empty;
    
    public TimeSpan HorarioApertura { get; set; }
    
    public TimeSpan HorarioCierre { get; set; }
}
