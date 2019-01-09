using System;
using System.Web.Mvc;
using PagedList;
using Statos.Service.Blogs;

namespace Statos.Web.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }


        /// <summary>
        /// returns the  
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int? page)
        {
            var posts = _blogService.GetAllBlogPosts();
            var pageNumber = page ?? 1;
            var onePageOfPosts = posts.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfPosts = onePageOfPosts;
            return View(posts);
        }




        /// <summary>
        /// return the blog post by Identity 
        /// </summary>
        /// <returns></returns>
        public ActionResult Post(int postId, string urlSlug)
        {
            var post = _blogService.GetBlogPost(postId);
            return View(post);
        }


        /// <summary>
        /// returns the 5 recent post to show in the side bar
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult PostSideBar()
        {
            var posts = _blogService.GetLatestBlogPosts();
            return PartialView(posts);
        }
      
    }
}
