namespace NewsCenter.Data.Models
{
    using NewsCenter.Data.Common.Models;

    public class LikeComment : BaseDeletableModel<int>
    {
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
