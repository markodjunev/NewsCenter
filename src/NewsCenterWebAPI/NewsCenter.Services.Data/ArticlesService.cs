namespace NewsCenter.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using NewsCenter.Data.Common.Repositories;
    using NewsCenter.Data.Models;
    using NewsCenter.Services.Data.Interfaces;
    using NewsCenter.Web.ViewModels.ViewModels.Admin.Articles.OutputViewModels;

    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> articlesRepository;

        public ArticlesService(IRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        private IQueryable<Article> All()
        {
            return this.articlesRepository.All().Where(x => x.IsDeleted == false);
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

        public bool Exist(int id)
        {
            return this.All().Any(x => x.Id == id);
        }

        public UpdateArticleViewModel GetUpdateArticleViewModel(int id)
        {
            var article = this.All()
                .FirstOrDefault(x => x.Id == id);

            var viewModel = new UpdateArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                ImageUrl = article.ImageUrl,
                Content = article.Content,
                CategoryId = article.CategoryId,
            };

            return viewModel;
        }

        public async Task EditAsync(int id, string title, string imageUrl, string content, int categoryId)
        {
            var article = this.All().FirstOrDefault(x => x.Id == id);

            article.Title = title;
            article.ImageUrl = imageUrl;
            article.Content = content;
            article.CategoryId = categoryId;
            article.ModifiedOn = DateTime.UtcNow;

            this.articlesRepository.Update(article);
            await this.articlesRepository.SaveChangesAsync();
        }
    }
}
