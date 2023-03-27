namespace ELS.Core.Entities.Base
{
    public class Entity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
