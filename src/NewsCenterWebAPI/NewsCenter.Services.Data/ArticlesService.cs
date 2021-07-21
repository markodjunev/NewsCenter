namespace NewsCenter.Services.Data
{
    using System;
    using System.Threading.Tasks;
    using NewsCenter.Data.Common.Repositories;
    using NewsCenter.Data.Models;
    using NewsCenter.Services.Data.Interfaces;

    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> articlesRepository;

        public ArticlesService(IRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        public async Task CreateAsync(string title, string imageUrl, string content, int categoryId)
        {
            var article = new Article
            {
                Title = title,
                ImageUrl = imageUrl,
                Content = content,
                CategoryId = categoryId,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
        }
    }
}
