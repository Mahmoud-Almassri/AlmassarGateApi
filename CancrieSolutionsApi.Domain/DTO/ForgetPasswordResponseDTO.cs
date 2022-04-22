using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO
{
    public partial class ForgetPasswordResponseDTO
    {
        public string EmailAddress { get; set; }
        public string Token { get; set; }
    }
}
