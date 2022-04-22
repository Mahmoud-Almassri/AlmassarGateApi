using AlmassarGate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.DTO.AddDTO
{
    public class PartAddDTO
    {
        public int Id { get; set; }
        public BaseStatus? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public string ModifiedByName { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public int Available { get; set; }
        public double PriceForUnit { get; set; }
    }
}
