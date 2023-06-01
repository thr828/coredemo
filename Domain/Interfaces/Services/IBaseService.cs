using DTO;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<TEntityDTO> where TEntityDTO : IEntityDTO
    {
        void Add(TEntityDTO entity);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO entity);
        void Remove(int id);
        void Dispose();
    }
}
