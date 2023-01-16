namespace VetScheduler.VetScheduler.Shared
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
