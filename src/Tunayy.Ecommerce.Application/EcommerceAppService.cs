using System;
using System.Collections.Generic;
using System.Text;
using Tunayy.Ecommerce.Localization;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce;

/* Inherit your application services from this class.
 */
public abstract class EcommerceAppService : ApplicationService
{
    protected EcommerceAppService()
    {
        LocalizationResource = typeof(EcommerceResource);
    }
}
