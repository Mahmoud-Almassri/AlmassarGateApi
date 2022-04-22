using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO
{
    public partial class UpdateUserRegistrationDTO
    {
        public int ApplicationUserId { get; set; }
        public string Address { get; set; }
    }
}
