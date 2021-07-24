namespace NewsCenter.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using NewsCenter.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<LikeComment> LikeComments { get; set; }
    }
}
