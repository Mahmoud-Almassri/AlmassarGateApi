﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.DTO
{
    public class UserProfileRequestDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
