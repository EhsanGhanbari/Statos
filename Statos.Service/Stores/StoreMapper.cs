using System.Collections.Generic;
using AutoMapper;
using Statos.Model.Stores;

namespace Statos.Service.Stores
{
    public static class StoreMapper
    {

        /// <summary>
        /// Convert to Store View Model
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static StoreViewModel ConvertToStoreViewModel(this Store store)
        {
            return Mapper.Map<Store, StoreViewModel>(store);
        }


        /// <summary>
        /// Convert to Store Model
        /// </summary>
        /// <param name="storeViewModel"></param>
        /// <returns></returns>
        public static Store ConvertToStoreModel(this StoreViewModel storeViewModel)
        {
            Mapper.CreateMap<StoreViewModel, Store>()
                 .ForMember(sto => sto.Id, st => st.MapFrom(s => s.ProductId));
            return Mapper.Map<StoreViewModel, Store>(storeViewModel);
        }


        /// <summary>
        /// Convert to Strore View Model list
        /// </summary>
        /// <param name="storeList"></param>
        /// <returns></returns>
        public static IEnumerable<StoreViewModel> ConvertToStoreViewModelList(this IEnumerable<Store> storeList)
        {
            return Mapper.Map<IEnumerable<Store>, IEnumerable<StoreViewModel>>(storeList);
        }


    }
}
