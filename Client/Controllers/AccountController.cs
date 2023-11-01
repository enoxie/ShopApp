using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.EmailServices;
using Client.Extensions;
using Client.Identity;
using Client.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Kullanıcı Bulunamadı",
                    Message = "Bu kullanıcı adı ile daha önce hesap oluşturulmamış",
                    AlertType = "warning"

                });
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Hesabınızı onaylayınız",
                    Message = "Giriş yaptığınız hesap onaylı değil",
                    AlertType = "warning"

                });
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Giriş Bilgileri Hatalı",
                Message = "Girilen kullanıcı adı veya şifre hatalı",
                AlertType = "danger"

            });

            return View();

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.UserName,
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "customer");
                //generate token 
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });
                await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız", $"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:5000{url}'>tıklayınız</a>");
                return RedirectToAction("Login", "Account");
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Hay Aksi!",
                Message = "Bilinmeyen bir hata oluştu",
                AlertType = "warning"

            });
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage()
            {
                Title = "Oturum Kapatıldı.",
                Message = "Hesabınızdan çıkış yapıldı.",
                AlertType = "success"

            });
            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Geçersiz token",
                    Message = "Girdiğiniz token geçersizdir.",
                    AlertType = "warning"

                });
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Hesabınız onaylandı!",
                        Message = "Hesabınız başarıyla onaylandı!",
                        AlertType = "success"

                    });
                    return View();
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Hesabınız onaylanmadı!",
                Message = "Hesap onaylama işlemi başarısız!",
                AlertType = "danger"

            });

            return View();

        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (String.IsNullOrEmpty(Email))
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Geçersiz Mail",
                    Message = "Geçerli bir mail adresi giriniz",
                    AlertType = "danger"

                });
                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Geçersiz Kullanıcı",
                    Message = "Kullanıcı bulunamadı!",
                    AlertType = "danger"

                });

                return View();
            }

            //generate token 
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });
            await _emailSender.SendEmailAsync(Email, "Reset Password", $"Şifrenizi sıfırlamak için linke <a href='http://localhost:5000{url}'>tıklayınız</a>");
            TempData.Put("message", new AlertMessage()
            {
                Title = "Bağlantı Gönderildi",
                Message = "Şifre sıfırlama bağlantısı gönderildi!",
                AlertType = "success"

            });
            return View();
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Home", "Index");
            }
            var model = new ResetPasswordModel { Token = token };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("Home", "Index");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Sıfırlama Başarılı",
                    Message = "Şifreniz başarıyla sıfırlandı!",
                    AlertType = "success"

                });
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}