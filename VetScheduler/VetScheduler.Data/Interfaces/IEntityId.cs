namespace VetScheduler.Data.Interfaces
{
    public interface IEntityId<TId>
    {
        public TId Id { get; set; }
    }
}
