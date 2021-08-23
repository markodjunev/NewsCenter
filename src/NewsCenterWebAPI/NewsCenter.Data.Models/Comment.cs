namespace NewsCenter.Data.Models
{
    using NewsCenter.Data.Common.Models;
    using System.Collections.Generic;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.LikeComments = new HashSet<LikeComment>();
        }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<LikeComment> LikeComments { get; set; }
    }
}
