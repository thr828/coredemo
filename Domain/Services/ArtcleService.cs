using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ArtcleService : BaseService<Article, ArticleDTO>, IArtcleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArtcleService(IArticleRepository articleRepository):base(articleRepository) 
        {
            _articleRepository = articleRepository;
        }

        public IEnumerable<ArticleDTO> GetAllActive()
        {
            return _articleRepository.GetAllActive();
        }


    }
}
