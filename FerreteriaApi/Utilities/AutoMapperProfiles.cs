using AutoMapper;
using FerreteriaApi.DTOs;
using FerreteriaApi.DTOs.buy;
using FerreteriaApi.DTOs.buy_details;
using FerreteriaApi.DTOs.cellar;
using FerreteriaApi.DTOs.cellar_transfer;
using FerreteriaApi.DTOs.cellar_transfer_details;
using FerreteriaApi.DTOs.customer;
using FerreteriaApi.DTOs.customer_category;
using FerreteriaApi.DTOs.inventory;
using FerreteriaApi.DTOs.product;
using FerreteriaApi.DTOs.product_category;
using FerreteriaApi.DTOs.product_measure;
using FerreteriaApi.DTOs.product_status;
using FerreteriaApi.DTOs.sale;
using FerreteriaApi.DTOs.supplier;
using FerreteriaApi.DTOs.supplier_category;
using FerreteriaApi.DTOs.transaction_status;
using FerreteriaApi.DTOs.user_sys;
using FerreteriaApi.DTOs.user_sys_category;
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

            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierCreateDTO, Supplier>();

            CreateMap<CustomerCat, CustomerCatDTO>();
            CreateMap<CustomerCatCreateDTO, CustomerCat>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerCreateDTO, Customer>();

            CreateMap<RolUser, UserRolDTO>();
            CreateMap<UserRolCreateDTO, RolUser>();

            CreateMap<Buy, BuyDTO>();
            CreateMap<BuyCreateDTO, Buy>();

            CreateMap<BuyDet, BuyDetailDTO>();
            CreateMap<BuyDetailCreateDTO, BuyDet>();

            CreateMap<TranStatus, TransStatusDTO>();
            CreateMap<TransStatusCreateDTO, TranStatus>();

            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleCreateDTO, Sale>();

            CreateMap<Cellar, CellarDTO>();
            CreateMap<CellarCreateDTO, Cellar>();

            CreateMap<CellarTransfer, CellarTransferDTO>();
            CreateMap<CellarTransferCreateDTO, CellarTransfer>();

            CreateMap<CellarTransferDet, CellarTransferDetDTO>();
            CreateMap<CellarTransDetCreateDTO, CellarTransferDet>();

            CreateMap<Inventory, InventoryDTO>();
            CreateMap<InventoryCreateDTO, Inventory>();

        }
    }


}
