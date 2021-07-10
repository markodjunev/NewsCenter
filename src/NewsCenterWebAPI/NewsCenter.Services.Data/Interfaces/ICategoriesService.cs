namespace NewsCenter.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task CreateAsync(string name, string imageUrl);

        bool Any();
    }
}
