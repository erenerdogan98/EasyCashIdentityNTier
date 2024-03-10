using EasyCashDataAccessLayer.Abstract;
using EasyCashDataAccessLayer.Concrete;
using EasyCashDataAccessLayer.Repositories;
using EasyCashEntityLayer.Concrete;

namespace EasyCashDataAccessLayer.EntityFramework
{
    public class EFCustomerAccountRepository(Context context) : GenericRepository<CustomerAccount>(context), ICustomerAccountDAL
    {
    }
}
