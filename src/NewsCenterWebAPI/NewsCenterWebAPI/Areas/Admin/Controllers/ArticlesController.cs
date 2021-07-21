namespace NewsCenterWebAPI.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NewsCenter.Services.Data.Interfaces;
    using NewsCenter.Web.ViewModels.ViewModels.Admin.Articles.InputModels;
    using NewsCenterWebAPI.Controllers;
    using System.Threading.Tasks;

    [Route("admin/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class ArticlesController : ApiController
    {
        private readonly IArticlesService articlesService;
        private readonly ICategoriesService categoriesService;

        public ArticlesController(IArticlesService articlesService, ICategoriesService categoriesService)
        {
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            var category = this.categoriesService.GetByName(input.CategoryName);

            if (category == null)
            {
                return BadRequest("Category with this name doesn't exist!");
            }

            await this.articlesService.CreateAsync(input.Title, input.ImageUrl, input.Content, category.Id);

            return Ok();
        }
    }
}
