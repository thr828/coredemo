
using AutoMapper;
using Domain.Interfaces.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class BaseRepository<TEntity, DTO> : IBaseRepository<TEntity, DTO> 
        where TEntity : class 
        where DTO : IEntityDTO
    {
        private readonly MyContext _myContext;

        private readonly IMapper _mapper;

        protected BaseRepository(MyContext myContext, IMapper mapper = null)
        {
            _myContext = myContext;
            _mapper = mapper;
        }

        public void Add(DTO entity)
        {
            var mapperEntity = _mapper.Map<DTO>(entity);
           _myContext.Add(mapperEntity); //上下文添加数据
            //_myContext.Set<TEntity>().Add(mapperEntity);
            _myContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entities = _myContext.Set<TEntity>().AsQueryable();
            return entities;
        }

        public DTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DTO entity)
        {
            throw new NotImplementedException();
        }
    }

}
