

using AutoMapper;
using Domain.Entities;
using DTO;

namespace Mapper
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
        }
    }
}