using System.ComponentModel.DataAnnotations;

namespace deila.backend.Entities
{
    public class Basis
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }

        public int Incidents { get; set; } = 0;
    }
}
