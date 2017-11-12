using Cellar.Api.DataAccess.Domain;

namespace Cellar.Api.DataAccess.Api.Repository
{
    public interface IActionLogsRepository : IMongoRepositoryBase<BdoActionLog>
    {
    }
}
