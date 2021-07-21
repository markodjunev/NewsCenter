namespace NewsCenter.Services.Data.Interfaces
{
    using NewsCenter.Data.Models;
    using NewsCenter.Web.ViewModels.ViewModels.Categories.OutputViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task CreateAsync(string name, string imageUrl);

        bool Any();

        IEnumerable<CategoryViewModel> GetAll();

        Category GetByName(string name);
    }
}
