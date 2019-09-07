using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Models
{
    public class AppUser : IdentityUser
    {
        [DefaultValue(false)]
        public bool isBlock { get; set; }

        [DefaultValue(false)]
        public bool isDelete { get; set; }

        //public ICollection<Test> Tests { get; set; }

        //public ApplicationUser()
        //{
        //   Tests = new List<Test>();
        //}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}