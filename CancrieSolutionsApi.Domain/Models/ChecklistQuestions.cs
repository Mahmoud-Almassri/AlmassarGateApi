using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Models
{
    public class ChecklistQuestion : BaseModel
    {
        public GroupTitle GroupTitleId { get; set; }
        public int QuestionEnumId { get; set; }

        public string QuestionText { get; set; }

        public string QuestionProperties { get; set; }

    }
}
