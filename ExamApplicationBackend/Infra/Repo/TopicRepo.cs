using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class TopicRepo:GenRepo<Topic>,ITopicRepo
    {
        ExamContext ec;
        public TopicRepo(ExamContext ec) : base(ec)
        {
            this.ec = ec;
        }
    }
}
