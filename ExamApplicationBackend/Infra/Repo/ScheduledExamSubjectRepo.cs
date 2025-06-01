using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class ScheduledExamSubjectRepo : GenRepo<ScheduledExamSubject>,IScheduledExamSubjectRepo
    {
        ExamContext ec;
        public ScheduledExamSubjectRepo(ExamContext ec):base(ec)
        {
            this.ec = ec;
        }
    }
}
