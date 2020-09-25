using System;
using System.Data;
using System.Data.Common;
using Npgsql;
using Projac.Sql;

namespace Projac.Npgsql
{
    /// <summary>
    /// Represents the T-SQL DATE NULL parameter value.
    /// </summary>
    public class NpgsqlDateNullValue : IDbParameterValue
    {
        /// <summary>
        ///     The single instance of this value.
        /// </summary>
        public static readonly NpgsqlDateNullValue Instance = new NpgsqlDateNullValue();

        private NpgsqlDateNullValue()
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
            return new NpgsqlParameter<DateTime>
                {
                    ParameterName = parameterName,
                    Direction = ParameterDirection.Input,
                    Size = 0,
                    Value = DBNull.Value,
                    SourceColumn = "",
                    IsNullable = true,
                    Precision = 0,
                    Scale = 0,
                    SourceVersion = DataRowVersion.Default
                };
        }

        private static bool Equals(NpgsqlDateNullValue value)
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

            return Equals((NpgsqlDateNullValue)obj);
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