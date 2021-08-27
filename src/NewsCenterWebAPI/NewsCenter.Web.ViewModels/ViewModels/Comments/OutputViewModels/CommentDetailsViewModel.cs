namespace NewsCenter.Web.ViewModels.ViewModels.Comments.OutputViewModels
{
    using System;

    public class CommentDetailsViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        public string CreatorId { get; set; }

        public string CreatorUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsLiked { get; set; }

        public int LikesCount { get; set; }

        public bool IsDeleted { get; set; }
    }
}
