using EasyCashEntityLayer.Abstract;
using System.ComponentModel.DataAnnotations;

namespace EasyCashEntityLayer.Concrete
{
    public class CustomerAccount : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; } // maybe later , can do table for Currency
        public decimal AccountBalance { get; set; }
        public string BankBranch { get; set; }

        // relationship between AppUser
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
