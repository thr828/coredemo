using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, DTO> where TEntity : class where DTO : IEntityDTO
    {
        void Add(DTO entity);
        DTO GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(DTO entity);
        void Delete(int id);


    }
}
