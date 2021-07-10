namespace NewsCenterWebAPI.Middlewares.Extensions
{
    using Microsoft.AspNetCore.Builder;

    public static class SeedRolesExtension
    {
        public static IApplicationBuilder UseSeedRolesMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedRolesMiddleware>();
        }
    }
}
