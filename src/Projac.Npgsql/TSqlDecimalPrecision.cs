using System;

namespace Projac.Npgsql
{
    /// <summary>
    ///     Represents the precision of a <see cref="NpgsqlDecimalValue" />. The maximum total number of decimal digits that will be stored, both to the left and to the right of the decimal point. The precision must be a value from 1 through the maximum precision of 38. The default precision is 18.
    /// </summary>
    public struct NpgsqlDecimalPrecision : IEquatable<NpgsqlDecimalPrecision>
    {
        /// <summary>
        ///     Represents the maximum precision value.
        /// </summary>
        public static readonly NpgsqlDecimalPrecision Max = new NpgsqlDecimalPrecision(38);

        /// <summary>
        ///     Represents the minimum precision value.
        /// </summary>
        public static readonly NpgsqlDecimalPrecision Min = new NpgsqlDecimalPrecision(1);

        /// <summary>
        ///     Represents the default precision value.
        /// </summary>
        public static readonly NpgsqlDecimalPrecision Default = new NpgsqlDecimalPrecision(18);

        private readonly byte _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NpgsqlDecimalPrecision" /> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if the value is not between 1 and 38.</exception>
        public NpgsqlDecimalPrecision(byte value)
        {
            if (value < 1 || value > 38)
            {
                throw new ArgumentOutOfRangeException("value", value,
                    string.Format("The value must be between {0} and {1}.", 1, 38));
            }

            _value = value;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     <c>true</c> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(NpgsqlDecimalPrecision other)
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
            return obj is NpgsqlDecimalPrecision && Equals((NpgsqlDecimalPrecision)obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return _value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _value.ToString();
        }

        /// <summary>
        ///     Determines whether two specified instances of <see cref="NpgsqlDecimalPrecision" /> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left" /> and <paramref name="right" /> represent the same sql varchar size;
        ///     otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(NpgsqlDecimalPrecision left, NpgsqlDecimalPrecision right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two specified instances of <see cref="NpgsqlDecimalPrecision" /> are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left" /> and <paramref name="right" /> do not represent the same sql varchar
        ///     size; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(NpgsqlDecimalPrecision left, NpgsqlDecimalPrecision right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Converts a <see cref="NpgsqlDecimalPrecision" /> instance to an <see cref="Byte" />.
        /// </summary>
        /// <param name="precision">The <see cref="NpgsqlDecimalPrecision" /> instance to convert.</param>
        /// <returns>The <see cref="Byte" /> size value.</returns>
        public static implicit operator byte(NpgsqlDecimalPrecision precision)
        {
            return precision._value;
        }

        /// <summary>
        ///     Converts an <see cref="Byte" /> to a <see cref="NpgsqlDecimalPrecision" /> instance.
        /// </summary>
        /// <param name="value">The <see cref="Byte" /> to convert.</param>
        /// <returns>The <see cref="NpgsqlDecimalPrecision" /> instance.</returns>
        public static implicit operator NpgsqlDecimalPrecision(byte value)
        {
            return new NpgsqlDecimalPrecision(value);
        }
    }
}