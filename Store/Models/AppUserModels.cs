using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Models
{
    public class AppUser : IdentityUser
    {
        /*new public string Email { get; set; }

        public string Password { get; set; }*/

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}