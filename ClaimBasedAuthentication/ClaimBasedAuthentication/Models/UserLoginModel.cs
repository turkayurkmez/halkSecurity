using System.ComponentModel.DataAnnotations;

namespace ClaimBasedAuthentication.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Boş bırakmayınız")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
