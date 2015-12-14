//Copyright (c) Service Stack LLC. All Rights Reserved.
//License: https://raw.github.com/ServiceStack/ServiceStack/master/license.txt

#if !SL5 && !XBOX
using System.Data;

#if NETFX_CORE
using IDbConnection = System.Data.Common.DbConnection;
using IDbCommand = System.Data.Common.DbCommand;
#endif

namespace ServiceStack.Data
{
	public interface IHasDbConnection
	{
		IDbConnection DbConnection { get; }
	}

    public interface IHasDbCommand
    {
        IDbCommand DbCommand { get; }
    }
}
#endif