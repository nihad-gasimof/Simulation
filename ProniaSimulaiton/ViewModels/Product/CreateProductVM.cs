using ProniaSimulaiton.Models;
using System.ComponentModel.DataAnnotations;

namespace ProniaSimulaiton.ViewModels.Product
{
    public class CreateProductVM
    {
        [Required(ErrorMessage ="Ad mutleq olmalidir")]
        [MinLength(4,ErrorMessage ="Minimum uzunlug 4 olmalidir")]
        public string Name { get; set; }

        public string ImgUrl { get; set; }
        [Range(0,9999999,ErrorMessage ="Minimum 0 olmalidir")]
        public double Price { get; set; }
        [Range(0,5,ErrorMessage ="Rate 0-5 araliginda olmalidir")]
        public int Rate { get; set; }
        [Required(ErrorMessage ="Mutleq Category Secin")]
        public int CategoryId { get; set; }
    }
}
