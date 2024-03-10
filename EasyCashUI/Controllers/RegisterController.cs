using EasyCashBusinessLogicLayer.ValidationRules.AppUserValidationRules;
using EasyCashDTOLayer.Dtos.AppUserDtos;
using EasyCashEntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
					// I'll explain with hotmail too , and also after refactoring , will add model class for email processings..
                    MimeMessage mimeMessage = new();
                    MailboxAddress mailboxAddressFrom = new("Easy Cash", "ornekdeneme_123@hotmail.com");
                    MailboxAddress mailboxAddressTo = new("User", user.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder
                    {
                        TextBody = $"Your confirmation code to complete the registration process: {code}"
                    };
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Confirm Code";

                    SmtpClient client = new();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("fenerli458@gmail.com", "fffvozozqrxtybzb");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    TempData["Mail"] = appUserRegister.Email;

                    return RedirectToAction("Index", "ConfirmMail");
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
