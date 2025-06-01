using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class QuestionDBRepo : GenRepo<QuestionDB>,IQuestionDBRepo
    {
        ExamContext ec;
        public QuestionDBRepo(ExamContext ec) : base(ec)
        {
            this.ec = ec;
        }
    }
}
