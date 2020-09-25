using System.Data;
using System.Data.Common;
using Npgsql;
using NpgsqlTypes;
using Projac.Sql;

namespace Projac.Npgsql
{
    /// <summary>
    /// Represents the T-SQL MONEY parameter value.
    /// </summary>
    public class NpgsqlMoneyValue : IDbParameterValue
    {
        private readonly decimal _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NpgsqlMoneyValue" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public NpgsqlMoneyValue(decimal value)
        {
            _value = value;
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
                false,
                0,
                4,
                "",
                DataRowVersion.Default,
                _value);
#else
            return new NpgsqlParameter<decimal>
                {
                    ParameterName = parameterName,
                    Direction = ParameterDirection.Input,
                    NpgsqlDbType = NpgsqlDbType.Money,
                    Size = 8,
                    Value = _value,
                    SourceColumn = "",
                    IsNullable = false,
                    Precision = 0,
                    Scale = 4,
                    SourceVersion = DataRowVersion.Default
                };
#endif
        }

        private bool Equals(NpgsqlMoneyValue other)
        {
            return _value == other._value;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((NpgsqlMoneyValue)obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}