namespace Biblioteca.Domain.Commons
{
    public abstract class BaseModel
    {
        public string Id { get; set; } = string.Empty;
        public string CreateBy { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime LastModifiedDate { get; set; }
    }
}
