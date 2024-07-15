using AutoMapper;
using Tunayy.Ecommerce.Categories;
using Tunayy.Ecommerce.MainCategories;
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

        CreateMap<Category, CategoriesDto>().ReverseMap();
        CreateMap<Category, CategoriesListDto>().ReverseMap();
        CreateMap<CreateCategoriesInputDto, Category>();
        CreateMap<UpdateCategoriesInputDto, Category>();
    }
}
