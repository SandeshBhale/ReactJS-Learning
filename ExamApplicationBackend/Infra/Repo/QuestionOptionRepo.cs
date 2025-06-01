using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class QuestionOptionRepo : GenRepo<QuestionOption>, IQuestionOptionRepo
    {
        ExamContext ec;
        public QuestionOptionRepo(ExamContext ec):base(ec)
        {
            this.ec = ec;
        }
    }
}
