using System;
using System.Collections.Generic;
using System.Linq;
using Statos.Model.Blogs;

namespace Statos.Service.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }


        /// <summary>
        /// Create Blog 
        /// </summary>
        /// <param name="blogViewModel"></param>
        /// <returns></returns>
        public Blog CreateBlogPost(BlogViewModel blogViewModel)
        {
            var post = blogViewModel.ConvertToBlogModel();
            post.CreationTime = DateTime.Now;
            _blogRepository.Add(post);
            _blogRepository.SaveChanges();
            return post;
        }

        /// <summary>
        /// returns blog post by Id
        /// </summary>
        /// <returns></returns>
        public BlogViewModel GetBlogPost(int postId)
        {
            var blog = _blogRepository.FindBy(postId);
            var blogView = blog.ConvertToBlogViewModel();
            return blogView;
        }


        /// <summary>
        /// returns all the blog post of the system
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BlogViewModel> GetAllBlogPosts()
        {
            var blog = _blogRepository.GetAll().OrderByDescending(b => b.CreationTime);
            var blogViewModel = blog.ConvertToBlogViewModelList();
            return blogViewModel;
        }


        /// <summary>
        /// Update Blog post View Model
        /// </summary>
        /// <param name="blogViewModel"></param>
        /// <returns></returns>
        public Blog UpdateBlogPost(BlogViewModel blogViewModel)
        {
            var post = blogViewModel.ConvertToBlogModel();
            post.CreationTime = DateTime.Now;
            _blogRepository.Update(post);
            _blogRepository.SaveChanges();
            return post;
        }


        /// <summary>
        /// Remove blog Post ViewModel 
        /// </summary>
        /// <param name="postId"></param>
        public void RemoveBlogPost(int postId)
        {
            var selectedPost = new BlogViewModel { PostId = postId };
            var post = selectedPost.ConvertToBlogModel();
            _blogRepository.Delete(post);
            _blogRepository.SaveChanges();
        }


        /// <summary>
        /// returns the latest 5 post
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BlogViewModel> GetLatestBlogPosts()
        {
            var posts = _blogRepository.FindRecentPost(5);
            var postViewModel = posts.ConvertToBlogViewModelList();
            return postViewModel;
        }
    }
}
