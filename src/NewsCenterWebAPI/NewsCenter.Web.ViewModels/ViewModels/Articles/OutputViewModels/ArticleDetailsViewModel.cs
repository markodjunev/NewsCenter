namespace NewsCenter.Web.ViewModels.ViewModels.Articles.OutputViewModels
{
    using NewsCenter.Web.ViewModels.ViewModels.Comments.OutputViewModels;
    using System;
    using System.Collections.Generic;

    public class ArticleDetailsViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<CommentDetailsViewModel> Comments { get; set; }
    }
}
