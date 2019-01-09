using System;
using System.Collections.Generic;
using Statos.Model.Blogs;

namespace Statos.Service.Blogs
{
    public interface IBlogService
    {
        Blog CreateBlogPost(BlogViewModel blogViewModel);
        BlogViewModel GetBlogPost(int postId);
        IEnumerable<BlogViewModel> GetAllBlogPosts();
        Blog UpdateBlogPost(BlogViewModel blogViewModel);
        void RemoveBlogPost(int postId);
        IEnumerable<BlogViewModel> GetLatestBlogPosts();
    }
}
