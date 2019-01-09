using System;
using System.Web.Mvc;
using Statos.Service.Blogs;
using Statos.Web.UI.Controllers;
using Statos.Web.UI.Helpers;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }


        /// <summary>
        /// List of blog posts
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var posts = _blogService.GetAllBlogPosts();
            return View("List", posts);
        }


        /// <summary>
        /// post details
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public ActionResult Post(int postId)
        {
            var post = _blogService.GetBlogPost(postId);
            return View("Post", post);
        }


        /// <summary>
        /// Create Blog Post action 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(BlogViewModel blogViewModel)
        {
            if (ModelState.IsValid)
            {
                blogViewModel.UrlSlug = blogViewModel.Title.GenerateSlug();
                _blogService.CreateBlogPost(blogViewModel);
                return RedirectToAction("List");
            }
            return View("Create");
        }


        /// <summary>
        /// Remove action 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int postId)
        {
            if (ModelState.IsValid)
            {
                _blogService.RemoveBlogPost(postId);
                RedirectToAction("List");
            }
            return Json("");
        }


        /// <summary>
        /// Return the Edit page for blog Post
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int postId)
        {
            var post = _blogService.GetBlogPost(postId);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(BlogViewModel blogViewModel)
        {
            if (ModelState.IsValid)
            {
                blogViewModel.UrlSlug = blogViewModel.Title.GenerateSlug();
                _blogService.UpdateBlogPost(blogViewModel);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}
