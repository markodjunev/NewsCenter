namespace NewsCenter.Data.Models
{
    using NewsCenter.Data.Common.Models;
    using System.Collections.Generic;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
