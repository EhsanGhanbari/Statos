using System.Collections.Generic;
using AutoMapper;
using Statos.Model.Products;
using Statos.Service.Categories;

namespace Statos.Service.Products
{
    public static class ProductMapper
    {

        #region Products

        /// <summary>
        /// All product list
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static IEnumerable<ProductViewModel> ConvertToProductViewList(this IEnumerable<Product> product)
        {
            Mapper.CreateMap<Product, ProductViewModel>()
                  .ForMember(pro => pro.ProductId, src => src.MapFrom(p => p.Id));
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(product);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductViewModel ConvertToProductViewModel(this Product product)
        {
            Mapper.CreateMap<Product, ProductViewModel>()
                 .ForMember(pro => pro.ProductId, src => src.MapFrom(p => p.Id));
            return Mapper.Map<Product, ProductViewModel>(product);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        public static Product ConvertToProductModel(this ProductViewModel productViewModel)
        {
            Mapper.CreateMap<ProductViewModel, Product>()
                .ForMember(pro => pro.Id, src => src.MapFrom(p => p.ProductId));
            return Mapper.Map<ProductViewModel, Product>(productViewModel);
        }


        #endregion
        
        #region Brand

        /// <summary>
        /// Convert to Brand View Model
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static BrandViewModel ConvertToBrandViewModel(this Brand brand)
        {
            Mapper.CreateMap<Brand, BrandViewModel>()
                  .ForMember(bra => bra.BrandId, br => br.MapFrom(b => b.Id));
            return Mapper.Map<Brand, BrandViewModel>(brand);
        }


        /// <summary>
        /// Convert to Brand View Model List
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static IEnumerable<BrandViewModel> ConvertToBrandViewModelList(this IEnumerable<Brand> brand)
        {
            Mapper.CreateMap<Brand, BrandViewModel>()
                  .ForMember(bra => bra.BrandId, br => br.MapFrom(b => b.Id));
            return Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(brand);
        }

        #endregion 
        
        #region Category
     
        /// <summary>
        /// Convert To Category ViewModel
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static CategoryViewModel ConvertToCategoryViewModel(this Category category)
        {
            Mapper.CreateMap<Category, CategoryViewModel>()
                  .ForMember(cat => cat.CategoryId, opt => opt.MapFrom(src => src.Id));
            return Mapper.Map<Category, CategoryViewModel>(category);
        }

        /// <summary>
        /// Convert To Category ViewModel List
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static IEnumerable<CategoryViewModel> ConvertToCategoryViewModelList(this IEnumerable<Category> category)
        {
            Mapper.CreateMap<Category, CategoryViewModel>()
                 .ForMember(cat => cat.CategoryId, opt => opt.MapFrom(src => src.Id));
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(category);
        }
        #endregion

    }
}
