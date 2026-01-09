using _34_Front_To_BackSqlConnection.Controllers;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Enums;
using _35_ServiceLifeTimeAppSettingProduct.ViewModels;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace _35_ServiceLifeTimeAppSettingProduct.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
           _roleManager = roleManager;
        }


        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser appUser = new()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email,
            };

            IdentityResult result =  await _userManager.CreateAsync(appUser,registerVM.Password);

            if (!result.Succeeded) 
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            //await _userManager.AddToRoleAsync(appUser,UserRole.Member.ToString());

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string link = Url.Action(nameof(ConfirmEmail),"Account",new {userId = appUser.Id,token},Request.Scheme,Request.Host.ToString());





            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ilhamshh-bpa203@code.edu.az"));
            email.To.Add(MailboxAddress.Parse(appUser.Email));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html)
            { Text = $@"<a href='{link}'  style=display:inline-block;padding:12px 24px;background-color:#0d6efd;color:#ffffff;text-decoration:none;font-size:16px;font-weight:600;border-radius:6px;> Click here </a>\" };


            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ilhamshh-bpa203@code.edu.az", "bbjcjghktnkfbesh");
            smtp.Send(email);
            smtp.Disconnect(true);



            return RedirectToAction(nameof(VerifyEmail));
        }

        public IActionResult VerifyEmail()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (userId is null || token is null) return BadRequest();
            
            AppUser user = await _userManager.FindByIdAsync(userId);
            if(user is null) return NotFound();

            await _userManager.ConfirmEmailAsync(user, token);


            return RedirectToAction(nameof(Login));
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM,string? returnUrl)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u=>u.Name==loginVM.UsernameOrEmail || u.Email==loginVM.UsernameOrEmail);
            if (appUser is null)
            {
                ModelState.AddModelError(string.Empty, "Username,Email or Password is incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.IsPersistent, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Account is locked,try later");
                return View();
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username,Email or Password is incorrect!");
                return View();
            }

            if (returnUrl is null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");


            }
            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }

        public async Task<IActionResult> CreateRols()
        {

            foreach (var role in Enum.GetValues(typeof(UserRole)))
            {
                if (await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }

    }
}
