using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using Npgsql;
using Projac.Sql;

namespace Projac.Npgsql
{
    /// <summary>
    ///     Represents a T-SQL BINARY parameter value.
    /// </summary>
    public class NpgsqlBinaryValue : IDbParameterValue
    {
        private readonly int _size;
        private readonly byte[] _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NpgsqlBinaryValue" /> class.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="size">The parameter size.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="value" /> is <c>null</c>.</exception>
        public NpgsqlBinaryValue(byte[] value, NpgsqlBinarySize size)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            _value = value;
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
                SqlDbType.Binary,
                _size,
                ParameterDirection.Input,
                false,
                0,
                0,
                "",
                DataRowVersion.Default,
                _value);
#else
            return new NpgsqlParameter<byte[]>
                {
                    ParameterName = parameterName,
                    Direction = ParameterDirection.Input,
                    Size = _size,
                    Value = _value,
                    SourceColumn = "",
                    IsNullable = false,
                    Precision = 0,
                    Scale = 0,
                    SourceVersion = DataRowVersion.Default
                };
#endif
        }

        private bool Equals(NpgsqlBinaryValue other)
        {
            return _value.SequenceEqual(other._value) && _size == other._size;
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
            return Equals((NpgsqlBinaryValue) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return _value.Aggregate(_size, (aggregation, current) => aggregation ^ current);
        }
    }
}