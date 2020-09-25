using System;
using System.Data;
using System.Data.Common;
using Npgsql;
using NpgsqlTypes;
using Projac.Sql;

namespace Projac.Npgsql
{
    /// <summary>
    /// Represents the T-SQL MONEY NULL parameter value.
    /// </summary>
    public class NpgsqlMoneyNullValue : IDbParameterValue
    {
        /// <summary>
        ///     The single instance of this value.
        /// </summary>
        public static readonly NpgsqlMoneyNullValue Instance = new NpgsqlMoneyNullValue();

        private NpgsqlMoneyNullValue()
        {
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
                SqlDbType.Money,
                8,
                ParameterDirection.Input,
                true,
                0,
                4,
                "",
                DataRowVersion.Default,
                DBNull.Value);
#else
            return new NpgsqlParameter<decimal>
                {
                    ParameterName = parameterName,
                    Direction = ParameterDirection.Input,
                    NpgsqlDbType = NpgsqlDbType.Money,
                    Size = 8,
                    Value = DBNull.Value,
                    SourceColumn = "",
                    IsNullable = true,
                    Precision = 0,
                    Scale = 4,
                    SourceVersion = DataRowVersion.Default
                };
#endif
        }

        private static bool Equals(NpgsqlMoneyNullValue value)
        {
            return ReferenceEquals(value, Instance);
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
            {
                return false;
            }

            return Equals((NpgsqlMoneyNullValue)obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}