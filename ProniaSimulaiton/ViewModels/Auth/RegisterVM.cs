using System.ComponentModel.DataAnnotations;

namespace ProniaSimulaiton.ViewModels.Auth
{
    public record RegisterVM
    {
        [Required(ErrorMessage = "Ad Mutleq Olmalidir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad Mutleq Olmalidir")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "UserName Mutleq Olmalidir")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Mutleq Olmalidir")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Formatini duzgun daxil edin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Mutleq Olmalidir")]
        [DataType(DataType.Password, ErrorMessage = "Parolda mutleq 1 simvol ve 1 herf olmalidir minimum uzunluq 4")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parol Ile uygunlasmir")]
        public string ResetPassword { get; set; }
    }
}
