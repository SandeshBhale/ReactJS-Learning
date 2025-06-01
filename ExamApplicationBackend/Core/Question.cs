using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("QuestionTable")]
    public class Question
    {
        [Key]
        public Int64 QuestionId { get; set; }
        public string QuestionName { get; set; }
        [ForeignKey("Topic")]
        public Int64 TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public string QuestionTitle { get; set; }
        public List<QuestionOption> QuestionOptions { get; set; }

    }
}
