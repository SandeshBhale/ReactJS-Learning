using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("ScheduledExamTable")]
    public class ScheduledExam
    {
        [Key]
        public Int64 ScheduledExamId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime ExamDate { get; set; }
        public string StartTime { get; set; }
        public int TimeInMinutes { get; set; }
        public int TotalNumberOfQuestions { get; set; }
        public bool isNegetive { get; set; }
        public int MarksPerQuestion { get; set; }
    }
}
