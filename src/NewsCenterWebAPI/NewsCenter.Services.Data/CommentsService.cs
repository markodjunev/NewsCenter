using NewsCenter.Data.Common.Repositories;
using NewsCenter.Data.Models;
using NewsCenter.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCenter.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> commentsRepository;

        public CommentsService(IRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        private IQueryable<Comment> All()
        {
            return this.commentsRepository.All().Where(x => x.IsDeleted == false);
        }

        public bool Exist(int id)
        {
            return this.All().Any(x => x.Id == id);
        }

        public async Task CreateAsync(string content, int articleId, string creatorId)
        {
            var comment = new Comment
            {
                Content = content,
                ArticleId = articleId,
                CreatorId = creatorId,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public Comment GetById(int id)
        {
            var comment = this.All().FirstOrDefault(x => x.Id == id);
            return comment;
        }

        public async Task DeleteAsync(int id)
        {
            var comment = this.All().FirstOrDefault(x => x.Id == id);

            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;
            comment.ModifiedOn = DateTime.UtcNow;

            this.commentsRepository.Update(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}
