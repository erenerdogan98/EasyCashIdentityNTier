using EasyCashBusinessLogicLayer.Abstract;
using EasyCashDataAccessLayer.Abstract;
using EasyCashEntityLayer.Concrete;
using System.Linq.Expressions;

namespace EasyCashBusinessLogicLayer.Concrete
{
    public class CustomerAccountManager(ICustomerAccountDAL customerAccountDAL) : ICustomerAccountService
    {
        private readonly ICustomerAccountDAL _customerAccountDAL = customerAccountDAL ?? throw new ArgumentNullException(nameof(customerAccountDAL));

        public async Task TAddAsync(CustomerAccount customerAccount) => await _customerAccountDAL.AddAsync(customerAccount);

        public async Task TDeleteAsync(CustomerAccount customerAccount) => await _customerAccountDAL.DeleteAsync(customerAccount);

        public async Task<IEnumerable<CustomerAccount>> TGetAllAsync() => await _customerAccountDAL.GetAllAsync();

        public async Task<IEnumerable<CustomerAccount>> TGetAllAsync(Expression<Func<CustomerAccount, bool>> filter) => await _customerAccountDAL.GetAllAsync(filter);

        public async Task<CustomerAccount> TGetByIdAsync(int id) => await _customerAccountDAL.GetByIdAsync(id);

        public async Task TUpdateAsync(CustomerAccount customerAccount) => await _customerAccountDAL.UpdateAsync(customerAccount);
    }
}
