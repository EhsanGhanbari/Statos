using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Statos.Model.Blogs;

namespace Statos.Service.Blogs
{
    public static class BlogMapper
    {
        /// <summary>
        /// Converts the blog to blogViewModel
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public static BlogViewModel ConvertToBlogViewModel(this Blog blog)
        {
            Mapper.CreateMap<Blog, BlogViewModel>()
                  .ForMember(bl => bl.PostId, src => src.MapFrom(b => b.Id));
            return Mapper.Map<Blog, BlogViewModel>(blog);
        }


        /// <summary>
        /// Converts to Blog Model
        /// </summary>
        /// <param name="blogViewModel"></param>
        /// <returns></returns>
        public static Blog ConvertToBlogModel(this BlogViewModel blogViewModel)
        {
            Mapper.CreateMap<BlogViewModel, Blog>()
                 .ForMember(bl => bl.Id, src => src.MapFrom(b => b.PostId));
            return Mapper.Map<BlogViewModel, Blog>(blogViewModel);
        }


        /// <summary>
        /// Convert to blog View Model list
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public static IEnumerable<BlogViewModel> ConvertToBlogViewModelList(this IEnumerable<Blog> blog)
        {
            Mapper.CreateMap<Blog, BlogViewModel>()
                  .ForMember(bl => bl.PostId, src => src.MapFrom(b => b.Id));
            return Mapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(blog);
        }

    }
}
