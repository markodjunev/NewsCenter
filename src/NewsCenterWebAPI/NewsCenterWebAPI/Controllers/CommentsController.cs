namespace NewsCenterWebAPI.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NewsCenter.Data.Models;
    using NewsCenter.Services.Data.Interfaces;
    using NewsCenter.Web.ViewModels.ViewModels.Comments.InputModels;
    using System.Threading.Tasks;

    public class CommentsController : ApiController
    {
        private readonly IArticlesService articlesService;
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            IArticlesService articlesService,
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.articlesService = articlesService;
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route(nameof(Create))]

        public async Task<IActionResult> Create(CreateCommentInputModel input)
        {
            if (!this.articlesService.Exist(input.ArticleId))
            {
                return BadRequest("Article doesn't exist!");
            }

            if (input.ParentCommentId != null)
            {
                if (!this.commentsService.Exist(input.ParentCommentId))
                {
                    return BadRequest("Parent comment doesn't exist!");
                }

                if (!this.commentsService.CheckParentCommentArticleId(input.ParentCommentId, input.ArticleId)) // check if parent comment articleId is equal to input articleId
                {
                    return BadRequest("Parent comment articleId doesn't match to input articleId!");
                }
            }

            var creator = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            await this.commentsService.CreateAsync(input.Content, input.ArticleId, input.ParentCommentId, creator.Id);

            return this.Ok();
        }

        [HttpDelete]
        [Route(nameof(Delete) + "/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = this.commentsService.GetById(id);

            if (comment == null)
            {
                return BadRequest("Comment doesn't exist");
            }

            var creator = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            if (this.User.IsInRole("Administrator") || creator.Id == comment.CreatorId)
            {
                await this.commentsService.DeleteAsync(id);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
