namespace NewsCenter.Web.ViewModels.ViewModels.Articles.OutputViewModels
{
    using System;

    public class AllArticlesByCategory
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public string ShortContent => this.Content.Length > 100 ? this.Content.Substring(0, 99) + "..." : this.Content;

        public DateTime CreatedOn { get; set; }
    }
}
