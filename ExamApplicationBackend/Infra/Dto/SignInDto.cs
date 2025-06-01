using System.ComponentModel.DataAnnotations;

namespace Web.Dto
{
    public class SignInDto
    {
        [Required(ErrorMessage = "EmailId Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
