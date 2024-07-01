using System.ComponentModel.DataAnnotations;

namespace Core_Blog.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Girin.")]
        public string username { get; set; }


        [Required(ErrorMessage = "Lütfen Şifrenizi Girin.")]
        public string password { get; set; }
    }
}
