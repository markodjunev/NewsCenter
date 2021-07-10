namespace NewsCenterWebAPI.Middlewares
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    public class SeedRolesMiddleware
    {
        private readonly RequestDelegate next;

        public SeedRolesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();

            var adminRoleExists = await roleManager.RoleExistsAsync("Administrator");
            if (!adminRoleExists)
            {
                var result = await roleManager.CreateAsync(new IdentityRole("Administrator"));
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException();
                }
            }

            var userRoleExists = await roleManager.RoleExistsAsync("User");
            if (!userRoleExists)
            {
                var result = await roleManager.CreateAsync(new IdentityRole("User"));
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException();
                }
            }

            await this.next(context);
        }
    }
}
