using Tunayy.Ecommerce.Samples;
using Xunit;

namespace Tunayy.Ecommerce.EntityFrameworkCore.Applications;

[Collection(EcommerceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<EcommerceEntityFrameworkCoreTestModule>
{

}
