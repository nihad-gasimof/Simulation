using Microsoft.AspNetCore.Identity;

namespace ProniaSimulaiton.Models
{
    public class AppUser:IdentityUser
    {
        public string  Name{ get; set; }
        public string  Surname{ get; set; }
    }
}
