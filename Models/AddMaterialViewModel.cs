using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Models;

public class AddMaterialViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Unit Price is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid unit price")]
    public decimal UnitPrice { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid quantity")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Supplier is required")]
    public string Supplier { get; set; }
}
