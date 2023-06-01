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
    public abstract class BaseService<TEntity, DTO> : IBaseService<DTO> where TEntity : class where DTO : IEntityDTO
    {
        private readonly IBaseRepository<TEntity, DTO> _repository;

        protected BaseService(IBaseRepository<TEntity, DTO> repository)
        {
            _repository = repository;
        }

        public void Add(DTO entity)
        {
            _repository.Add(entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
          return _repository.GetAll();
        }

        public DTO GetById(int id)
        {
            return (DTO)_repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Delete(id);
        }

        public void Update(DTO entity)
        {
            _repository.Update(entity);
        }

        IEnumerable<DTO> IBaseService<DTO>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
