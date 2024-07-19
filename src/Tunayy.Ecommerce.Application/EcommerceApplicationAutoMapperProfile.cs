using AutoMapper;
using Tunayy.Ecommerce.Categories;
using Tunayy.Ecommerce.Images;
using Tunayy.Ecommerce.Products;
using Tunayy.Ecommerce.Properties;
using Tunayy.Ecommerce.Tables;
using Tunayy.Ecommerce.Tests;
using Tunayy.Ecommerce.TestTwos;

namespace Tunayy.Ecommerce;

public class EcommerceApplicationAutoMapperProfile : Profile
{
    public EcommerceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */


        CreateMap<Test, TestDto>().ReverseMap();
        CreateMap<Test, TestListDto>().ReverseMap();
        CreateMap<CreateTestInput, Test>();
        CreateMap<UpdateTestInput, Test>();

        CreateMap<TestTwo, TestTwoInTest>();

        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryListDto>().ReverseMap();
        CreateMap<CreateCategoryInputDto, Category>();
        CreateMap<UpdateCategoryInputDto, Category>();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductListDto>().ReverseMap();
        CreateMap<CreateProductInputDto, Product>();
        CreateMap<UpdateProductInputDto, Product>();
        CreateMap<ProductProperty, ProductPropertyDto>().ReverseMap();

        CreateMap<Image, ImageDto>().ReverseMap();
        CreateMap<Image, ImageListDto>().ReverseMap();
        CreateMap<CreateImageInputDto, Image>();
        CreateMap<UpdateImageInputDto, Image>();

        CreateMap<Property, PropertyDto>().ReverseMap();
        CreateMap<Property, PropertyListDto>().ReverseMap();
        CreateMap<CreatePropertyInputDto, Property>();
        CreateMap<UpdatePropertyInputDto, Property>();
    }
}
