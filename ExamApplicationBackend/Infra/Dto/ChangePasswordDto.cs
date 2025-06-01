using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dto
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "EmailId Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        public string OldPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        [Compare(nameof(NewPassword), ErrorMessage = "Email Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
