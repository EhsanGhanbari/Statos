using System;
using System.Collections.Generic;
using Statos.Model.Stores;

namespace Statos.Service.Stores
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        /// <summary>
        /// Add Stuff To Store
        /// </summary>
        /// <param name="storeViewModel"></param>
        /// <returns></returns>
        public Store AddStoreContent(StoreViewModel storeViewModel)
        {
            var store = storeViewModel.ConvertToStoreModel();
            _storeRepository.Add(store);
            _storeRepository.SaveChanges();
            return store;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeViewModel"></param>
        /// <returns></returns>
        public Store EditStoreContent(StoreViewModel  storeViewModel)
        {
            var storeView = new StoreViewModel {StoreId = storeViewModel.StoreId};
            var store = storeView.ConvertToStoreModel();
            _storeRepository.Update(store);
            _storeRepository.SaveChanges();
            return store;
        }

        /// <summary>
        /// Remove Store Content
        /// </summary>
        /// <param name="storeViewModel"></param>
        public void RemoveStoreContent(StoreViewModel storeViewModel)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeViewModel"></param>
        /// <returns></returns>
        public StoreViewModel GetStoreContentBy(StoreViewModel storeViewModel)
        {
            var storeView = new StoreViewModel {StoreId = storeViewModel.StoreId};
            var store = _storeRepository.FindBy(storeViewModel);
           //var storeViewModel = store.ConvertToStoreViewModel();
            return storeViewModel;
        }


        /// <summary>
        /// Get All Store Content
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StoreViewModel> GetAllStoreContent()
        {
            var store = _storeRepository.GetAll();
            var storeView = store.ConvertToStoreViewModelList();
            return storeView;
        }
    }
}
