using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO
{
    public class ExternalAuthDTO
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
    }
}
