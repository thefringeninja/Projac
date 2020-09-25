using System;
using System.Data;
using System.Data.Common;
using Npgsql;
using Projac.Sql;

namespace Projac.Npgsql
{
    /// <summary>
    ///     Represents the T-SQL NVARCHAR NULL parameter value.
    /// </summary>
    public class NpgsqlNVarCharNullValue : IDbParameterValue
    {
        private readonly NpgsqlNVarCharSize _size;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NpgsqlNVarCharNullValue" /> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public NpgsqlNVarCharNullValue(NpgsqlNVarCharSize size)
        {
            _size = size;
        }

        /// <summary>
        ///     Creates a <see cref="DbParameter" /> instance based on this instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>
        ///     A <see cref="DbParameter" />.
        /// </returns>
        public DbParameter ToDbParameter(string parameterName)
        {
            return ToSqlParameter(parameterName);
        }

        /// <summary>
        ///     Creates a <see cref="NpgsqlParameter" /> instance based on this instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>
        ///     A <see cref="NpgsqlParameter" />.
        /// </returns>
        public NpgsqlParameter ToSqlParameter(string parameterName)
        {
#if NET46 || NET452
            return new NpgsqlParameter(
                parameterName,
                SqlDbType.NVarChar,
                _size,
                ParameterDirection.Input,
                true,
                0,
                0,
                "",
                DataRowVersion.Default,
                DBNull.Value);
#else
            return new NpgsqlParameter<string>
                {
                    ParameterName = parameterName,
                    Direction = ParameterDirection.Input,
                    Size = _size,
                    Value = DBNull.Value,
                    SourceColumn = "",
                    IsNullable = true,
                    Precision = 0,
                    Scale = 0,
                    SourceVersion = DataRowVersion.Default
                };
#endif
        }

        private bool Equals(NpgsqlNVarCharNullValue value)
        {
            return value._size == _size;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            return Equals((NpgsqlNVarCharNullValue) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return _size.GetHashCode();
        }
    }
}