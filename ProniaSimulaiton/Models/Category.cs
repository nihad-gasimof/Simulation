using ProniaSimulaiton.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ProniaSimulaiton.Models
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage ="Adin olmasi mecburidir")]
        public string  Name{ get; set; }
       public List<Product> Products { get; set; }
    }
}
