using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ArtcleRepository : BaseRepository<Article, ArticleDTO>, IArticleRepository
    {
        private readonly MyContext myContext;
        private readonly IMapper mapper;

        public ArtcleRepository(MyContext myContext, IMapper mapper ) : base(myContext, mapper)
        {
            this.myContext = myContext;
            this.mapper = mapper;
        }

        public IEnumerable<ArticleDTO> GetAllActive()
        {
            var list=  GetAll().Where(p=>p.Version==1).ToList();
            return mapper.Map<List<ArticleDTO>>(list);
        }
    }
}
