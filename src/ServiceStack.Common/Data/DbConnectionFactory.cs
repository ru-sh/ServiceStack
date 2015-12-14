#if !SL5
using System;
using System.Data;

#if NETFX_CORE
using IDbConnection = System.Data.Common.DbConnection;
#endif

namespace ServiceStack.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly Func<IDbConnection> connectionFactoryFn;

        public DbConnectionFactory(Func<IDbConnection> connectionFactoryFn)
        {
            this.connectionFactoryFn = connectionFactoryFn;
        }

        public IDbConnection OpenDbConnection()
        {
            var dbConn = CreateDbConnection();
            dbConn.Open();
            return dbConn;
        }

        public IDbConnection CreateDbConnection()
        {
            return connectionFactoryFn();
        }
    }
}
#endif