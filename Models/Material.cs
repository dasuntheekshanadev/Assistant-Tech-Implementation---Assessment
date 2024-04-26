using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Models;

public class Material
{  
    public int Id {  get; set; }

    [StringLength(100)]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }
    [Required]

    public decimal Quantity { get; set; }
    [Required]
    public string Supplier { get; set; }
    public bool IsActive { get; set; } = true;



}
