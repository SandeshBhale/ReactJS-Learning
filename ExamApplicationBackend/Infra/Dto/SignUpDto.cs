using System.ComponentModel.DataAnnotations;

namespace Web.Dto
{
    public class SignUpDto
    {
        [Required(ErrorMessage ="First Name Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name Reuired")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="EmailId Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Mobile Number Required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage ="Password Required")]
        public string Password { get; set; }
    }
}
