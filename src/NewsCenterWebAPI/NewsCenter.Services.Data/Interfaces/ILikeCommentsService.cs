namespace NewsCenter.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    public interface ILikeCommentsService
    {
        bool Exist(int commentId, string userId);

        Task CreateAsync(int commentId, string userId);

        Task DeleteAsync(int commentId, string userId);
    }
}
