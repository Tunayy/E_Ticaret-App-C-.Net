using System.Threading.Tasks;

namespace Tunayy.Ecommerce.Data;

public interface IEcommerceDbSchemaMigrator
{
    Task MigrateAsync();
}
