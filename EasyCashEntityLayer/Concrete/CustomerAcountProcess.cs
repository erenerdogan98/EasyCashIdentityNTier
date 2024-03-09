using EasyCashEntityLayer.Abstract;
using System.ComponentModel.DataAnnotations;

namespace EasyCashEntityLayer.Concrete
{
    public class CustomerAcountProcess : IEntityBase
    {
        // this table will for Account transactions 
        [Key]
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessData { get; set; }
    }
}
