using AlmassarGate.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.DTO.LookupsDTO
{
    public class PartDTO: BaseModelDTO
    {
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public int Available { get; set; }
        public double PriceForUnit { get; set; }
    }
}
