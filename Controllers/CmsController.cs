using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using Piranha.Models;
using TAU.Website.Models;
using TAU.Website.Models.Pages;

namespace TAU.Website.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CmsController : Controller
    {
        private readonly IApi _api;
        private readonly IModelLoader _loader;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public CmsController(IApi api, IModelLoader loader)
        {
            _api = api;
            _loader = loader;
        }

        /// <summary>
        /// Gets the blog archive with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="year">The optional year</param>
        /// <param name="month">The optional month</param>
        /// <param name="page">The optional page</param>
        /// <param name="category">The optional category</param>
        /// <param name="tag">The optional tag</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("archive")]
        public async Task<IActionResult> Archive(Guid id, int? year = null, int? month = null, int? page = null,
            Guid? category = null, Guid? tag = null, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<StandardArchive>(id, HttpContext.User, draft);
                model.Archive = await _api.Archives.GetByIdAsync<PostInfo>(id, page, category, tag, year, month);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("page")]
        public async Task<IActionResult> Page(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<StandardPage>(id, HttpContext.User, draft);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
        
        /// <summary>
        /// Gets the home page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("/homepage")]
        public async Task<IActionResult> HomePage(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<HomePage>(id, HttpContext.User, draft);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
        
        /// <summary>
        /// Gets the service page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("/servicepage")]
        public async Task<IActionResult> ServicePage(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<ServicePage>(id, HttpContext.User, draft);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
        
        /// <summary>
        /// Gets the managed service page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("/managedservicespage")]
        public async Task<IActionResult> ManagedServicesPage(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<ManagedServicesPage>(id, HttpContext.User, draft);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
        
        /// <summary>
        /// Gets the contacts page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("/contactpage")]
        public async Task<IActionResult> ContactPage(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<ContactPage>(id, HttpContext.User, draft);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
        
        /// <summary>
        /// Gets the products page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("/productspage")]
        public async Task<IActionResult> ProductsPage(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<ProductsPage>(id, HttpContext.User, draft);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
        
        /// <summary>
        /// Gets the post with the given id.
        /// </summary>
        /// <param name="id">The unique post id</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("post")]
        public async Task<IActionResult> Post(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPostAsync<StandardPost>(id, HttpContext.User, draft);

                if (model.IsCommentsOpen)
                {
                    model.Comments = await _api.Posts.GetAllCommentsAsync(model.Id, true);
                }
                return View(model);
            }
            catch
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Saves the given comment and then redirects to the post.
        /// </summary>
        /// <param name="id">The unique post id</param>
        /// <param name="commentModel">The comment model</param>
        [HttpPost]
        [Route("post/comment")]
        public async Task<IActionResult> SavePostComment(SaveCommentModel commentModel)
        {
            try
            {
                var model = await _loader.GetPostAsync<StandardPost>(commentModel.Id, HttpContext.User);

                // Create the comment
                if (Request.HttpContext.Connection.RemoteIpAddress != null)
                {
                    var comment = new PostComment
                    {
                        IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        UserAgent = Request.Headers.ContainsKey("User-Agent") ? Request.Headers["User-Agent"].ToString() : "",
                        Author = commentModel.CommentAuthor,
                        Email = commentModel.CommentEmail,
                        Url = commentModel.CommentUrl,
                        Body = commentModel.CommentBody
                    };
                    await _api.Posts.SaveCommentAndVerifyAsync(commentModel.Id, comment);
                }

                return Redirect(model.Permalink + "#comments");
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}
