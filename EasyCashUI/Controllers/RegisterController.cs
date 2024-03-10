using EasyCashBusinessLogicLayer.ValidationRules.AppUserValidationRules;
using EasyCashDTOLayer.Dtos.AppUserDtos;
using EasyCashEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashUI.Controllers
{
	[Route("{controller}")]
	public class RegisterController(UserManager<AppUser> userManager, AppUserRegisterValidator validationRules) : Controller
	{
		// For now i don't add identity processing to NTier , but while refactoring , I try to add 
		private readonly UserManager<AppUser> _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
		private readonly AppUserRegisterValidator _validationRules = validationRules ?? throw new ArgumentNullException(nameof(validationRules));
		[HttpGet("register")]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost("register")]
		public async Task<IActionResult> Index(AppUserRegisterDto appUserRegister)
		{
			var validationResult = _validationRules.Validate(appUserRegister);
            Random random = new();
            int code;
            code = random.Next(100000, 1000000);
            if (validationResult.IsValid)
			{
				AppUser user = new()
				{
					UserName = appUserRegister.UserName,
					Email = appUserRegister.Email,
					Name = appUserRegister.Name,
					Surname = appUserRegister.Surname,
					PhoneNumber = appUserRegister.Phone,
					City = "Ankara",
					District = "Batikent",
					ImageUrl = "asdasd",
					ConfirmCode = code
				};
				var result = await _userManager.CreateAsync(user, appUserRegister.Password);
				if (result.Succeeded)
				{
					return Ok("Resigration successfully");
				}
				else
				{
					foreach (var error in validationResult.Errors)
					{
						ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					}
				}
			}
			
			return View();

		}
	}
}
