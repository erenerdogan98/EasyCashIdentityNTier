using EasyCashDatabaseLogicLayer.Abstract;
using EasyCashDatabaseLogicLayer.Concrete;
using EasyCashDatabaseLogicLayer.Repositories;
using EasyCashEntityLayer.Concrete;

namespace EasyCashDatabaseLogicLayer.EntityFramework
{
    public class EFCustomerAccountRepository(Context context) : GenericRepository<CustomerAccount>(context), ICustomerAccountDAL
    {
    }
}
