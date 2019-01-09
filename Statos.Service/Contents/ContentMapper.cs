using System.Collections.Generic;
using AutoMapper;
using Statos.Model.Contents;

namespace Statos.Service.Contents
{
    public static class ContentMapper
    {

        /// <summary>
        /// Convert Content to About View Model
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static ContentViewModel ConvertToContentViewModel(this Content content)
        {
            return Mapper.Map<Content, ContentViewModel>(content);
        }


        /// <summary>
        /// Convert Content Model
        /// </summary>
        /// <param name="contentViewModel"></param>
        /// <returns></returns>
        public static Content ConvertToContentModel(this ContentViewModel contentViewModel)
        {
            return Mapper.Map<ContentViewModel, Content>(contentViewModel);
        }
       

        /// <summary>
        /// Convert to content View model list
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static IEnumerable<ContentViewModel> ConvertTContentViewModelList(this IEnumerable<Content> content)
        {
            return Mapper.Map<IEnumerable<Content>, IEnumerable<ContentViewModel>>(content);
        }
    }
}
