using Microsoft.AspNetCore.Identity;

namespace Domains.Models
{
    public partial class UserLogins : IdentityUserLogin<long>
    {
       

        public virtual ApplicationUser User { get; set; }
    }
}
