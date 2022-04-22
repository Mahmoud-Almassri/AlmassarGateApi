using Microsoft.AspNetCore.Identity;
namespace Domains.Models
{
    public partial class UserClaims : IdentityUserClaim<long>
    {


        public virtual ApplicationUser User { get; set; }
    }
}
