namespace NewsCenter.Services.Data
{
    using NewsCenter.Data.Common.Repositories;
    using NewsCenter.Data.Models;
    using NewsCenter.Services.Data.Interfaces;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class LikeCommentsService : ILikeCommentsService
    {
        private readonly IRepository<LikeComment> likeCommentsRepository;

        public LikeCommentsService(IRepository<LikeComment> likeCommentsRepository)
        {
            this.likeCommentsRepository = likeCommentsRepository;
        }

        private IQueryable<LikeComment> All()
        {
            return this.likeCommentsRepository.All().Where(x => x.IsDeleted == false);
        }

        public async Task CreateAsync(int commentId, string userId)
        {
            var likeComment = new LikeComment
            {
                CommentId = commentId,
                UserId = userId,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await this.likeCommentsRepository.AddAsync(likeComment);
            await this.likeCommentsRepository.SaveChangesAsync();
        }

        public bool Exist(int commentId, string userId)
        {
            return this.All().Any(x => x.CommentId == commentId && x.UserId == userId);
        }

        public async Task DeleteAsync(int commentId, string userId)
        {
            var likeComment = this.All()
                .FirstOrDefault(x => x.CommentId == commentId && x.UserId == userId);

            likeComment.IsDeleted = true;
            likeComment.DeletedOn = DateTime.UtcNow;
            likeComment.ModifiedOn = DateTime.UtcNow;

            this.likeCommentsRepository.Update(likeComment);
            await this.likeCommentsRepository.SaveChangesAsync();
        }
    }
}
