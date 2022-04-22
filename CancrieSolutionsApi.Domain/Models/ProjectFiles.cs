using AlmassarGate.Domain.Models.Common;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.Models
{
    public class ProjectFiles: BaseModel
    {
        public int ProjectId { get; set; }
        public int FileCategory { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        
    }
}
