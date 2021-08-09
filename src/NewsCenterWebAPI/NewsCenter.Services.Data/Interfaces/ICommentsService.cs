namespace NewsCenter.Services.Data.Interfaces
{
    using NewsCenter.Data.Models;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        bool Exist(int? id);

        Task CreateAsync(string content, int articleId, int? parentCommentId, string creatorId);

        bool CheckParentCommentArticleId(int? parentCommentId, int articleId);

        Comment GetById(int id);

        Task DeleteAsync(int id);
    }
}
