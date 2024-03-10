

using EasyCashEntityLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace EasyCashEntityLayer.Concrete
{
    public class AppUser : IdentityUser<int> , IEntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public int ConfirmCode { get; set; }

        // for relationship between 'CustomerAccount'
        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
    }
}
