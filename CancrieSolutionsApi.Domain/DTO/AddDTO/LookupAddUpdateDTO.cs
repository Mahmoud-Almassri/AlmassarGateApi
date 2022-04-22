using AlmassarGate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO.AddDTO
{
    public partial class LookupDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
        public EntitiesEnum ParentId { get; set; }

    }
}
