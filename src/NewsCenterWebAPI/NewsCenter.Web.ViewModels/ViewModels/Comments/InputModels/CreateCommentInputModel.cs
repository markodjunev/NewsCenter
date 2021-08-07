namespace NewsCenter.Web.ViewModels.ViewModels.Comments.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentInputModel
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public int? ParentCommentId { get; set; }
    }
}
