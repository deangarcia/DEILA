using deila.backend.Contexts;
using deila.backend.Entities;

namespace deila.backend.Services
{
    public class ArticleRepo : GenericRepo<Article, DeilaDbContext>, IArticleRepo
    {
        private readonly DeilaDbContext _context;
        public ArticleRepo(DeilaDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

    }
}
