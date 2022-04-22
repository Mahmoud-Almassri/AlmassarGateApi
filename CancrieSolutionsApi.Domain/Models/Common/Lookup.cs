using AlmassarGate.Domain.Enums;
using Domains.Models;
using System;

namespace AlmassarGate.Domain.Models.Common
{
    public class Lookup :BaseModel
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public EntitiesEnum ParentId { get; set; }
    }
}
