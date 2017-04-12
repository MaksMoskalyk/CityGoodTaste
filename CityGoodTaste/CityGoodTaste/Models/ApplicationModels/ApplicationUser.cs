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

        
        [MaxLength(50)]
        public string Name { get; set; }

       
        [MaxLength(50)]
        public string Surname { get; set; }


        public byte[] Photo { get; set; }

        
        public virtual ICollection<Phone> Phones { get; set; }

       
        public virtual ICollection<Cuisine> Cuisines { get; set; }

        
        public virtual ICollection<Order> Orders { get; set; }


        public virtual ICollection<Like> Likes { get; set; }

     
        public virtual ICollection<RestaurantReview> Reviews { get; set; }

       
        public virtual ICollection<TableReservation> TableReservation { get; set; }

        public virtual Administration Administration { get; set; }
        
    }
}