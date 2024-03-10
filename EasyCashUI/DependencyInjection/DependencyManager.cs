using EasyCashBusinessLogicLayer.Abstract;
using EasyCashBusinessLogicLayer.Concrete;
using EasyCashBusinessLogicLayer.ValidationRules.AppUserValidationRules;
using EasyCashDatabaseLogicLayer.Abstract;
using EasyCashDatabaseLogicLayer.Concrete;
using EasyCashDatabaseLogicLayer.EntityFramework;
using EasyCashDTOLayer.Dtos.AppUserDtos;
using EasyCashEntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace EasyCashUI.DependencyInjection
{
    public static class DependencyManager
    {
        public static void ConfigureMyServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>();

            services.AddScoped<ICustomerAccountDAL, EFCustomerAccountRepository>();
            services.AddScoped<ICustomerAccountProcessDAL, EFCustomerAccountProcessRepository>();
            services.AddScoped<ICustomerAccountService, CustomerAccountManager>();
            services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();

            //identity 
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

            // for validations 
            services.AddScoped<IValidator<AppUserRegisterDto>, AppUserRegisterValidator>();
            services.AddValidatorsFromAssemblyContaining<AppUserRegisterValidator>();
        }
    }
}
