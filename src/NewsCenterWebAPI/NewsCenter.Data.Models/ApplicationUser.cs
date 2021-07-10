namespace NewsCenter.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using NewsCenter.Data.Common.Models;
    using System;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
            this.LikeComments = new HashSet<LikeComment>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<LikeComment> LikeComments { get; set; }
    }
}
