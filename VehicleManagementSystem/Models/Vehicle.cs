using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleManagementSystem.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? RegNo { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        [Range(1, 999)]
        public int NumberOfSeats { get; set; }

        public string? Colors { get; set; } // Assuming a single string can contain multiple colors
    }
}