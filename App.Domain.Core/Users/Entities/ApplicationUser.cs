using App.Domain.Core.Products.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Users.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
      
        #region Navigation properties
       public Buyer? Buyer { get; set; }
       public Seller? Seller { get; set; }

        #endregion Navigation properties
    }
}
