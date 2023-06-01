using Domain.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IArticleRepository: IBaseRepository<Article, ArticleDTO>
    {
        IEnumerable<ArticleDTO> GetAllActive();
    }
}
