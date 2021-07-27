namespace NewsCenter.Web.ViewModels.ViewModels.Admin.Articles.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditArticleInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
