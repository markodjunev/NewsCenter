﻿namespace NewsCenterWebAPI.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using NewsCenter.Data.Models;
    using NewsCenterWebAPI.Helpers;
    using NewsCenterWebAPI.ViewModels.Account.InputModels;
    using System.Threading.Tasks;
    using System;
    using NewsCenterWebAPI.ViewModels.Common;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Claims;
    using NewsCenterWebAPI.ViewModels.Account.OutputViewModels;

    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IOptions<AppSettings> appSettings;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appSettings = appSettings;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<object> Login(LoginInputModel input)
        {
            var user = this.userManager.Users.FirstOrDefault(r => r.UserName == input.UserName);

            if (user == null)
            {
                return BadRequest(new BadRequestViewModel
                {
                    Message = "Incorrect username or password."
                });
            }

            var result = await this.signInManager.PasswordSignInAsync(user.UserName, input.Password, false, false);

            if (result.Succeeded)
            {
                return new AuthenticationViewModel
                {
                    Message = "You have successfully logged in.",
                    Token = GenerateJwtToken(user),
                    UserId = user.Id,
                    Username = user.UserName,
                    IsAdmin = await this.userManager.IsInRoleAsync(user, "Administrator"),
                };
            }

            return BadRequest(new BadRequestViewModel
            {
                Message = "Incorrect username or password."
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<ActionResult<object>> Register(RegisterInputModel input)
        {
            if (this.userManager.Users.Any(x => x.Email == input.Email))
            {
                return BadRequest(new BadRequestViewModel
                {
                    Message = "This e-mail is already in use. Please try with another one."
                });
            }

            if (this.userManager.Users.Any(x => x.UserName == input.UserName))
            {
                return BadRequest(new BadRequestViewModel
                {
                    Message = "This username is already in use. Please try with another one."
                });
            }

            var user = new ApplicationUser
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName,
                Email = input.Email,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            var result = await this.userManager.CreateAsync(user, input.Password);
            if (result.Succeeded)
            {
                var addToRoleResult = await userManager.AddToRoleAsync(user, "User");
                if (addToRoleResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    return new AuthenticationViewModel
                    {
                        Message = "You have successfully registered.",
                        Token = GenerateJwtToken(user),
                        UserId = user.Id,
                        Username = user.UserName,
                        IsAdmin = false,
                    };
                }
            }

            return BadRequest(new BadRequestViewModel
            {
                Message = "Something went wrong."
            });
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = appSettings.Value.Secret;
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role,
                            this.userManager.IsInRoleAsync(user, "Administrator")
                                .GetAwaiter()
                                .GetResult() ? "Administrator" : "User")
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
