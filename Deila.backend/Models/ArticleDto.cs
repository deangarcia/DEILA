using deila.backend.Entities;

namespace deila.backend.Models
{

    public class ArticleBaseDto
    {
        public string? Title { get; set; }
        public int BasisId { get; set; } 
        public string? Origin { get; set; }
        public bool? Sentiment { get; set; }
        public string? Content { get; set; }

    }
    public class ArticleDto : ArticleBaseDto
    {
        public int Id { get; set; }
    }
    public class ArticleCreateDto : ArticleBaseDto { }
    public class ArticleUpdateDto : ArticleBaseDto { }
}
