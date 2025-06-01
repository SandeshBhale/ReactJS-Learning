using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("ScheduledExamResultTable")]
    public class ScheduledExamResult
    {
        [Key]
        public Int64 ScheduledExamResultId { get; set; }
        [ForeignKey("User")]
        public Int64 UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime AppearDateTime { get; set; }
        public int SolvedQuestions { get; set; }
        public int NegetiveMarks { get; set; }
        public int PositiveMarks { get; set; }
        public int ObtainedMarks { get; set; }
    }
}
