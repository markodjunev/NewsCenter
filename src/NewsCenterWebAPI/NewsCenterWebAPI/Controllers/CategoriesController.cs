namespace NewsCenterWebAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NewsCenter.Services.Data.Interfaces;
    using NewsCenter.Web.ViewModels.ViewModels.Categories.OutputViewModels;
    using System.Collections.Generic;

    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(All))]
        public IEnumerable<CategoryViewModel> All()
        {
            var categories = this.categoriesService.GetAll();

            return categories;
        }
    }
}
