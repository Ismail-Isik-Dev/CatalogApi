namespace Catalog.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public enum Status
    {
        Archived = 0,
        Active = 1,
        Deleted = 2
    }
}
