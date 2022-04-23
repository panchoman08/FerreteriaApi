using AutoMapper;
using FerreteriaApi.DTOs;
using FerreteriaApi.DTOs.product;
using FerreteriaApi.DTOs.product_category;
using FerreteriaApi.DTOs.product_measure;
using FerreteriaApi.DTOs.product_status;
using FerreteriaApi.DTOs.supplier_category;
using FerreteriaApi.DTOs.user_sys;
using FerreteriaApi.Models;

namespace FerreteriaApi.Utilities
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<ProductCat, ProductCategoryDTO>();
            CreateMap<ProductCategoryDTO, ProductCat>();
            CreateMap<ProductCategoryCreateDTO, ProductCat>();
            CreateMap<ProductCategoryUpdateDTO, ProductCat>();

            CreateMap<UserSy, UserCredential>();
            CreateMap<UserSy, UserModel>();
            CreateMap<UserRegister, UserSy>();
            CreateMap<UserSy, ResponseAuthentication>();

            CreateMap<ProductStum, ProductStatusDTO>();
            CreateMap<ProductStatusDTO, ProductStum>();
            CreateMap<ProductStatusCreateDTO, ProductStum>();


            CreateMap<Measure, ProductMeasureDTO>();
            CreateMap<ProductMeasureCreateDTO, Measure>();

            CreateMap<SupplierCat, SupplierCatDTO>();
            CreateMap<SupplierCatCreateDTO, SupplierCat>();



        }
    }


}
