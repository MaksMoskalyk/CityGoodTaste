using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CityGoodTaste.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Display(Name = "UserName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "UserSurname", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Phones", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Phone> Phones { get; set; }

        [Display(Name = "Cuisines", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Cuisine> Cuisines { get; set; }

        [Display(Name = "Orders", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Order> Orders { get; set; }

        [Display(Name = "Likes", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Like> Likes { get; set; }

        [Display(Name = "Reviews", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<RestaurantReview> Reviews { get; set; }

        [Display(Name = "Reservations", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<TableReservation> TableReservation { get; set; }

    }
}