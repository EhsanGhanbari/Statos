using System;
using System.Collections.Generic;
using Statos.Model.Contents;

namespace Statos.Service.Contents
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;

        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        /// <summary>
        /// Create Content 
        /// </summary>
        /// <param name="contentViewModel"></param>
        /// <returns></returns>
        public void CreateContent(ContentViewModel contentViewModel)
        {
            var content = contentViewModel.ConvertToContentModel();
            content.CreationTime = DateTime.Now;
            _contentRepository.Add(content);
            _contentRepository.SaveChanges();
        }


        /// <summary>
        /// Get Latest Content of the Content!
        /// </summary>
        /// <returns></returns>
        public ContentViewModel GetLatestContent()
        {
            var content = _contentRepository.GetLatestContentQuery();
            var contentViewModel = content.ConvertToContentViewModel();
            return contentViewModel;
        }


        /// <summary>
        /// Update the Content of Content
        /// </summary>
        /// <param name="contentViewModel"></param>
        /// <returns></returns>
        public Content UpdateContent(ContentViewModel contentViewModel)
        {
            var content = contentViewModel.ConvertToContentModel();
            content.CreationTime = DateTime.Now;
            _contentRepository.Update(content);
            _contentRepository.SaveChanges();
            return content;
        }



        /// <summary>
        /// Get All content of the content
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContentViewModel> GetAllContent()
        {
            var contents = _contentRepository.GetAll();
            var contentViewModel = contents.ConvertTContentViewModelList();
            return contentViewModel;
        }

        /// <summary>
        /// Remove Conten
        /// </summary>
        /// <param name="contentViewModel"></param>
        public void RemoveContent(ContentViewModel contentViewModel)
        {
            var content = contentViewModel.ConvertToContentModel();
            _contentRepository.Delete(content);
            _contentRepository.SaveChanges();
        }
    }
}
