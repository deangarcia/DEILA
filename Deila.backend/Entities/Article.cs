using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deila.backend.Entities
{
    public class Article
    {
        [Required]
        public int Id { get; set; }

        public string? Title { get; set; }

        public int BasisId { get; set; }

        public string? Origin { get; set; }

        public bool? Sentiment { get; set; }

        public string? Content { get; set; }

    }
}
