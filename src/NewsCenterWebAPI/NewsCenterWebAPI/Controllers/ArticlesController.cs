using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsCenter.Data.Models;
using NewsCenter.Services.Data.Interfaces;
using NewsCenter.Web.ViewModels.ViewModels.Articles.OutputViewModels;
using System;
using System.Threading.Tasks;

namespace NewsCenterWebAPI.Controllers
{
    public class ArticlesController : ApiController
    {
        private const int ArticlesPerPage = 5;

        private readonly ICategoriesService categoriesService;
        private readonly IArticlesService articlesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ArticlesController(
            ICategoriesService categoriesService,
            IArticlesService articlesService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.categoriesService = categoriesService;
            this.articlesService = articlesService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(ByCategory) + "/{id}")]
        public ActionResult<ArticlesViewModel> ByCategory(int id, [FromQuery] int page = 1)
        {
            var category = this.categoriesService.GetById(id);

            if (category == null)
            {
                return this.BadRequest("Category with this name doesn't exist.");
            }

            var articles = new ArticlesViewModel
            {
                AllArticlesByCategory = this.articlesService.GetAllArticlesByCategoryId(id, ArticlesPerPage, (page - 1) * ArticlesPerPage),
            };

            var count = this.articlesService.CountByCategoryId(id);

            articles.PagesCount = (int)Math.Ceiling((double)count / ArticlesPerPage);
            if (articles.PagesCount == 0)
            {
                articles.PagesCount = 1;
            }

            articles.CurrentPage = page;
            articles.ArticlesCount = count;

            if (articles.CurrentPage > articles.PagesCount)
            {
                return this.RedirectToAction("ByCategory", new { page = 1});
            }

            return articles;
        }

        [HttpGet]
        [Route(nameof(Details) + "/{id}")]
        public async Task<ActionResult<ArticleDetailsViewModel>> Details(int id)
        {
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var model = this.articlesService.GetArticleDetails(id, user.Id);

            return model;
        }
    }
}
