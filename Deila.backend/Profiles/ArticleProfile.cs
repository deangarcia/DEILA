using AutoMapper;
using deila.backend.Entities;
using deila.backend.Models;

namespace deila.backend.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleCreateDto, Article>();
            CreateMap<ArticleUpdateDto, Article>(); // Two-way mapping
        }
    }
}
