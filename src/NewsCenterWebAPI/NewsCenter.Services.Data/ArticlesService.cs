namespace NewsCenter.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NewsCenter.Data.Common.Repositories;
    using NewsCenter.Data.Models;
    using NewsCenter.Services.Data.Interfaces;
    using NewsCenter.Web.ViewModels.ViewModels.Admin.Articles.OutputViewModels;
    using NewsCenter.Web.ViewModels.ViewModels.Articles.OutputViewModels;
    using NewsCenter.Web.ViewModels.ViewModels.Comments.OutputViewModels;

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

        public int CountByCategoryId(int id)
        {
            return this.All().Where(x => x.CategoryId == id).Count();
        }

        public IEnumerable<AllArticlesByCategory> GetAllArticlesByCategoryId(int categoryId, int? take = null, int skip = 0)
        {
            var articles = this.All()
                .Where(x => x.CategoryId == categoryId)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new AllArticlesByCategory
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content.Length > 100 ? x.Content.Substring(0, 99) + "..." : x.Content,
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn,
                })
                .Skip(skip);

            if (take.HasValue)
            {
                articles = articles.Take(take.Value);
            }

            return articles;
        }

        public ArticleDetailsViewModel GetArticleDetails(int id, string userId)
        {
            var article = this.All().Where(x => x.Id == id)
                .Select(x => new ArticleDetailsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                    Comments = x.Comments.Select(c => new CommentDetailsViewModel
                    {
                        Id = c.Id,
                        ArticleId = c.Id,
                        Content = c.Content,
                        CreatorId = c.CreatorId,
                        CreatorUserName = c.Creator.UserName,
                        CreatedOn = c.CreatedOn,
                        IsLiked = c.LikeComments.Where(lc => lc.IsDeleted == false).Any(lc => lc.CommentId == c.Id && lc.UserId == userId),
                        LikesCount = c.LikeComments.Where(lc => lc.IsDeleted == false && lc.CommentId == c.Id).Count(),
                    })
                    .ToList(),
                }).FirstOrDefault();

            return article;
        }
    }
}
