using System.ComponentModel.DataAnnotations;

namespace ProniaSimulaiton.ViewModels.Auth
{
    public class LoginVM
    {
        
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Mutleq Olmalidir")]
        [DataType(DataType.Password,ErrorMessage ="Parolda mutleq 1 simvol ve 1 herf olmalidir minimum uzunluq 4")]
        public string Password { get; set; }
        

    }
}
