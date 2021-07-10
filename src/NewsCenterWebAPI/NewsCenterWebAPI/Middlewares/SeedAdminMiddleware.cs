namespace NewsCenterWebAPI.Middlewares
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using NewsCenter.Data.Models;

    public class SeedAdminMiddleware
    {
        private readonly RequestDelegate next;

        public SeedAdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var userManager = provider.GetService<UserManager<ApplicationUser>>();

            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "admin.a@abv.bg",
                    UserName = "admin",
                };

                var userResult = await userManager.CreateAsync(user, "123456");
                if (!userResult.Succeeded)
                {
                    throw new InvalidOperationException();
                }

                var roleResult = await userManager.AddToRoleAsync(user, "Administrator");
                if (!roleResult.Succeeded)
                {
                    throw new InvalidOperationException();
                }
            }

            await this.next(context);
        }

    }
}
