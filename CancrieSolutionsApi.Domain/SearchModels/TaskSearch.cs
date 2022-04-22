using Domains.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.SearchModels
{
    public class TaskSearch : BaseSearch
    {
        public string TaskTitle { get; set; }
    }
}
