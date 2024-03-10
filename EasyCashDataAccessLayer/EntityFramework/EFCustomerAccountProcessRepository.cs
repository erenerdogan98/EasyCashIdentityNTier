using EasyCashDataAccessLayer.Abstract;
using EasyCashDataAccessLayer.Concrete;
using EasyCashDataAccessLayer.Repositories;
using EasyCashEntityLayer.Concrete;

namespace EasyCashDataAccessLayer.EntityFramework
{
    public class EFCustomerAccountProcessRepository(Context context) : GenericRepository<CustomerAccountProcess>(context), ICustomerAccountProcessDAL
    {
    }
}
