using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("TopicTable")]
    public class Topic
    {
        [Key]
        public Int64 TopicId { get; set; }
        public string TopicName { get; set; }
        [ForeignKey("Subject")]
        public Int64 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public List<Question> Questions { get; set; }
    }
}
