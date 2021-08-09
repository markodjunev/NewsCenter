namespace NewsCenterWebAPI.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NewsCenter.Data.Models;
    using NewsCenter.Services.Data.Interfaces;
    using System.Threading.Tasks;

    public class LikeCommentsController : ApiController
    {
        private readonly ICommentsService commentsService;
        private readonly ILikeCommentsService likeCommentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public LikeCommentsController(
            ICommentsService commentsService,
            ILikeCommentsService likeCommentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.likeCommentsService = likeCommentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route(nameof(Create) + "/{id}")]
        public async Task<IActionResult> Create(int id)
        {
            var comment = this.commentsService.GetById(id);

            if (comment == null)
            {
                return BadRequest("Comment doesn't exist!");
            }

            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var isAlreadyLiked = this.likeCommentsService.Exist(id, user.Id);

            if (isAlreadyLiked)
            {
                return BadRequest("You've already liked this comment!");
            }

            await this.likeCommentsService.CreateAsync(id, user.Id);

            return Ok();
        }

        [HttpDelete]
        [Route(nameof(Delete) + "/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var isAlreadyLiked = this.likeCommentsService.Exist(id, user.Id);

            if (!isAlreadyLiked)
            {
                return BadRequest("You haven't liked this comment!");
            }

            await this.likeCommentsService.DeleteAsync(id, user.Id);

            return Ok();
        }
    }
}
