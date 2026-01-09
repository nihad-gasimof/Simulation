using ProniaSimulaiton.Models.Common;

namespace ProniaSimulaiton.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string? ImgUrl { get; set; }
        public double Price { get; set; }
        public int Rate { get; set; }
        public int CategoryId { get; set; } 
        public Category? Category { get; set; }
    }
}
