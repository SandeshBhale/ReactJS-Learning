using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("SubjectTable")]
    public class Subject
    {
        public Int64  SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<Topic> Topics { get; set; }
        public List<ScheduledExamSubject> ScheduledExamSubjects { get; set; }
    }
}
