namespace NewsCenter.Web.ViewModels.ViewModels.Admin.Articles.OutputViewModels
{
    public class UpdateArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
    }
}
