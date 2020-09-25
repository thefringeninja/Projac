using System;
using System.Data.Common;
using Npgsql;
using Projac.Sql;

namespace Projac.Npgsql.Tests
{
    internal class NpgsqlParameterValueStub : IDbParameterValue
    {
        public DbParameter ToDbParameter(string parameterName)
        {
            return new NpgsqlParameter { ParameterName = parameterName, Value = DBNull.Value };
        }
    }
}
