using Domains.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.SearchModels
{
    public class GroupSearch: BaseSearch
    {
        public string UserName { get; set; }
    }
}
