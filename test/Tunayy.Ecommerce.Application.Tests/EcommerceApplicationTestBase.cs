using Volo.Abp.Modularity;

namespace Tunayy.Ecommerce;

public abstract class EcommerceApplicationTestBase<TStartupModule> : EcommerceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
