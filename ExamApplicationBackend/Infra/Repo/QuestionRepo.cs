using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class QuestionRepo : GenRepo<Question>,IQuestionRepo
    {
        ExamContext ec;
        public QuestionRepo(ExamContext ec) : base(ec)
        {
            this.ec = ec;
        }
    }
}
