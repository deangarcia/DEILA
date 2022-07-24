using deila.backend.Contexts;
using deila.backend.Entities;

namespace deila.backend.Services
{
    public class BasisRepo : GenericRepo<Basis, DeilaDbContext>, IBasisRepo
    {
        private readonly DeilaDbContext _context;
        public BasisRepo(DeilaDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

    }
}
