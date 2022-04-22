using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO
{
    public class ForgetPasswordDTO
    {
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Language { get; set; }
    }
}
