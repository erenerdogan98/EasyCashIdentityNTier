using EasyCashEntityLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace EasyCashEntityLayer.Concrete
{
    public class AppRole : IdentityRole<int>, IEntityBase
    {
    }
}
