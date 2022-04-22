using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlmassarGate.Domain.DTO
{
    public partial class RestPasswordDTO
    {
        public string EmailAddress { get; set; }
        public string Token { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
