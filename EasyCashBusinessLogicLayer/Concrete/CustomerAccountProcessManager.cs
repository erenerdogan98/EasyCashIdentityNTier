using EasyCashBusinessLogicLayer.Abstract;
using EasyCashDatabaseLogicLayer.Abstract;
using EasyCashEntityLayer.Concrete;
using System.Linq.Expressions;

namespace EasyCashBusinessLogicLayer.Concrete
{
    public class CustomerAccountProcessManager(ICustomerAccountProcessDAL customerAccountProcessDAL) : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDAL _customerAccountProcessDAL = customerAccountProcessDAL ?? throw new ArgumentNullException(nameof(customerAccountProcessDAL));
        public async Task TAddAsync(CustomerAccountProcess customerAccountProcess) => await _customerAccountProcessDAL.AddAsync(customerAccountProcess);

        public async Task TDeleteAsync(CustomerAccountProcess customerAccountProcess) => await _customerAccountProcessDAL.DeleteAsync(customerAccountProcess);

        public async Task<IEnumerable<CustomerAccountProcess>> TGetAllAsync() => await _customerAccountProcessDAL.GetAllAsync();

        public async Task<IEnumerable<CustomerAccountProcess>> TGetAllAsync(Expression<Func<CustomerAccountProcess, bool>> filter) => await _customerAccountProcessDAL.GetAllAsync(filter);

        public async Task<CustomerAccountProcess> TGetByIdAsync(int id) => await _customerAccountProcessDAL.GetByIdAsync(id);

        public async Task TUpdateAsync(CustomerAccountProcess entity) => await _customerAccountProcessDAL.UpdateAsync(entity);
    }
}
