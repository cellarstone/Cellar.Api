using Cellar.Api.DataAccess.Api.Repository;
using Cellar.Api.DataAccess.Domain;
using Cellar.Api.DataAccess.Implementation.Repository;
using System;

namespace Cellar.Api.DataAccess.Implementation.Repository
{
    public class ActionLogsRepository : MongoRepositoryBase<BdoActionLog>, IActionLogsRepository
    {
        public override string CollectionName => "ActionLogs";

        public override bool Update(BdoActionLog item)
        {
            throw new NotImplementedException();
        }
    }
}
