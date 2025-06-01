using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("QuestionOptionTable")]
    public class QuestionOption
    {
        [Key]
        public Int64 QuestionOptionId { get; set; }
        [ForeignKey("Question")]
        public Int64 QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }
}
