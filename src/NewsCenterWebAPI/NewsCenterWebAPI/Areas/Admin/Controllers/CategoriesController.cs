namespace NewsCenterWebAPI.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NewsCenter.Services.Data.Interfaces;
    using NewsCenter.Web.ViewModels.ViewModels.Admin.Articles.InputModels;
    using NewsCenterWebAPI.Controllers;
    using System.Collections.Generic;

    [Route("admin/[controller]")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        [Route(nameof(DropDown))]
        public IEnumerable<CategoryDropDownModel> DropDown()
        {
            var categories = this.categoriesService.GetDropDownModels();

            return categories;
        }
    }
}
