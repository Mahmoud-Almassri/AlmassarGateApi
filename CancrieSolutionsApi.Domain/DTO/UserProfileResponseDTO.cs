using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO
{
    public class UserProfileResponseDTO
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
