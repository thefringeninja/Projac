using System.Data;
using System.Data.Common;
using Npgsql;
using Projac.Sql;

namespace Projac.Npgsql
{
    /// <summary>
    ///     Represents a T-SQL BIT parameter value.
    /// </summary>
    public class NpgsqlBitValue : IDbParameterValue
    {
        private readonly bool _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NpgsqlBitValue" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public NpgsqlBitValue(bool value)
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
                SqlDbType.Bit,
                1,
                ParameterDirection.Input,
                false,
                0,
                0,
                "",
                DataRowVersion.Default,
                _value);
#else
            return new NpgsqlParameter<bool>
                {
                    ParameterName = parameterName,
                    Direction = ParameterDirection.Input,
                    Size = 1,
                    Value = _value,
                    SourceColumn = "",
                    IsNullable = false,
                    Precision = 0,
                    Scale = 0,
                    SourceVersion = DataRowVersion.Default
                };
#endif
        }

        private bool Equals(NpgsqlBitValue other)
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
            return Equals((NpgsqlBitValue) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return _value ? 1 : 0;
        }
    }
}