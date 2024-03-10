using EasyCashDatabaseLogicLayer.Abstract;
using EasyCashDatabaseLogicLayer.Concrete;
using EasyCashDatabaseLogicLayer.Repositories;
using EasyCashEntityLayer.Concrete;

namespace EasyCashDatabaseLogicLayer.EntityFramework
{
    public class EFCustomerAccountProcessRepository(Context context) : GenericRepository<CustomerAccountProcess>(context), ICustomerAccountProcessDAL 
    {
    }
}
