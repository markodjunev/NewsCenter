using NewsCenter.Data.Common.Repositories;
using NewsCenter.Data.Models;
using NewsCenter.Services.Data.Interfaces;
using NewsCenter.Web.ViewModels.ViewModels.Admin.Articles.InputModels;
using NewsCenter.Web.ViewModels.ViewModels.Categories.OutputViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCenter.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        private IQueryable<Category> All()
        {
            return this.categoriesRepository.All().Where(x => x.IsDeleted == false);
        }

        public bool Any()
        {
            return this.All().Any();
        }

        public async Task CreateAsync(string name, string imageUrl)
        {
            var category = new Category
            {
                Name = name,
                ImageUrl = imageUrl,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = this.All().OrderBy(c => c.Name).Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
            });

            return categories;
        }

        public Category GetById(int id)
        {
            var category = this.All().FirstOrDefault(x => x.Id == id);

            return category;
        }

        public IEnumerable<CategoryDropDownModel> GetDropDownModels()
        {
            var categories = this.All().Select(x => new CategoryDropDownModel
            {
                Id = x.Id,
                Name = x.Name,
            });

            return categories;
        }
    }
}
