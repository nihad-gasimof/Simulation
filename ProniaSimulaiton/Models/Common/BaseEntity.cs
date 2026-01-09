namespace ProniaSimulaiton.Models.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
