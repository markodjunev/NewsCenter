namespace NewsCenter.Services.Data.Interfaces
{
    using System.Threading.Tasks;
    using NewsCenter.Web.ViewModels.ViewModels.Admin.Articles.OutputViewModels;

    public interface IArticlesService
    {
        Task CreateAsync(string title, string imageUrl, string content, int categoryId);

        bool Exist(int id);

        UpdateArticleViewModel GetUpdateArticleViewModel(int id);

        Task EditAsync(int id, string title, string imageUrl, string content, int categoryId);
    }
}
