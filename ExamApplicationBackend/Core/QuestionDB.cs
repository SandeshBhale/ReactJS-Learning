using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    [Table("QuestionDBTable")]
    public class QuestionDB
    {
        [Key]
        public Int64 QuestionDBId { get; set; }
        public string QuesionDBName { get; set; }
    }
}
