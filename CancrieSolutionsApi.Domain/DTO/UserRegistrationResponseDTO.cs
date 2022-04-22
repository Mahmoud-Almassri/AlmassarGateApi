using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO
{
    public partial class UserRegistrationResponseDTO
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
