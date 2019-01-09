using System;
using System.Collections.Generic;
using Statos.Model.Stores;

namespace Statos.Service.Stores
{
    public interface IStoreService
    {
        Store AddStoreContent(StoreViewModel storeViewModel);
        Store EditStoreContent(StoreViewModel storeViewModel);
        void RemoveStoreContent(StoreViewModel storeViewModel);
        StoreViewModel GetStoreContentBy(StoreViewModel storeViewModel);
        IEnumerable<StoreViewModel> GetAllStoreContent();
    }
}
