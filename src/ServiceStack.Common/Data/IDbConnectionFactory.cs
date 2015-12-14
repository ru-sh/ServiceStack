#if !SL5
using System.Data;

#if NETFX_CORE
using IDbConnection = System.Data.Common.DbConnection;
#endif

namespace ServiceStack.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection OpenDbConnection();
        IDbConnection CreateDbConnection();
    }
}
#endif
