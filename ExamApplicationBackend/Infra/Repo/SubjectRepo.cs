using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class SubjectRepo : GenRepo<Subject>,ISubjectRepo
    {
        ExamContext ec;
        public SubjectRepo(ExamContext ec) : base(ec)
        {
            this.ec = ec;
        }
    }
}
