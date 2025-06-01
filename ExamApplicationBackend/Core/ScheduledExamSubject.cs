using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("ScheduledExamSubjectTable")]
    public class ScheduledExamSubject
    {
        [Key]
        public Int64 SchedulesExamSubjectId { get; set; }
        [ForeignKey("Subject")]
        public Int64 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int NoOfQuestions { get; set; }
    }
}
