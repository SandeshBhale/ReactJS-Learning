using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Core
{
    [Table("AdminTable")]
    public class Admin
    {
        [Key]
        public Int64 AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
    }
}
