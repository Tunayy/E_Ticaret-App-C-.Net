using Volo.Abp.Modularity;

namespace Tunayy.Ecommerce;

[DependsOn(
    typeof(EcommerceDomainModule),
    typeof(EcommerceTestBaseModule)
)]
public class EcommerceDomainTestModule : AbpModule
{

}
