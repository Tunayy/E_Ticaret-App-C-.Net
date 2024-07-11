using Volo.Abp.Modularity;

namespace Tunayy.Ecommerce;

/* Inherit from this class for your domain layer tests. */
public abstract class EcommerceDomainTestBase<TStartupModule> : EcommerceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
