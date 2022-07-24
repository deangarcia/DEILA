using AutoMapper;
using deila.backend.Entities;
using deila.backend.Models;

namespace deila.backend.Profiles
{
    public class BasisProfile : Profile
    {
        public BasisProfile()
        {
            CreateMap<Basis, BasisDto>();
            CreateMap<BasisCreateDto, Basis>();
            CreateMap<BasisUpdateDto, Basis>(); // Two-way mapping
        }
    }
}
