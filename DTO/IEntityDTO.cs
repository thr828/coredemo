namespace DTO
{
    public interface IEntityDTO
    {
        DateTime CreatedAt { get; set; }
        bool Active { get; set; }
    }
}