using System;

namespace Projac.Npgsql
{
    /// <summary>
    ///     Represents the size of a <see cref="NpgsqlBinaryValue" />.
    /// </summary>
    public struct NpgsqlBinarySize : IEquatable<NpgsqlBinarySize>
    {
        private readonly int _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NpgsqlBinarySize" /> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     Thrown when the <paramref name="value" /> is not between 0 and
        ///     8000.
        /// </exception>
        public NpgsqlBinarySize(int value)
        {
            if (value < 0 || value > Limits.MaxByteSize)
                throw new ArgumentOutOfRangeException("value", value,
                    string.Format("The value must be between 0 and {0}.", Limits.MaxByteSize));
            _value = value;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     <c>true</c> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(NpgsqlBinarySize other)
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
            return obj is NpgsqlBinarySize && Equals((NpgsqlBinarySize) obj);
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
        ///     Determines whether two specified instances of <see cref="NpgsqlBinarySize" /> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left" /> and <paramref name="right" /> represent the same sql varchar size;
        ///     otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(NpgsqlBinarySize left, NpgsqlBinarySize right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two specified instances of <see cref="NpgsqlBinarySize" /> are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left" /> and <paramref name="right" /> do not represent the same sql varchar
        ///     size; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(NpgsqlBinarySize left, NpgsqlBinarySize right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Converts a <see cref="NpgsqlBinarySize" /> instance to an <see cref="Int32" />.
        /// </summary>
        /// <param name="size">The <see cref="NpgsqlBinarySize" /> instance to convert.</param>
        /// <returns>The <see cref="Int32" /> size value.</returns>
        public static implicit operator int(NpgsqlBinarySize size)
        {
            return size._value;
        }

        /// <summary>
        ///     Converts an <see cref="Int32" /> to a <see cref="NpgsqlBinarySize" /> instance.
        /// </summary>
        /// <param name="value">The <see cref="Int32" /> to convert.</param>
        /// <returns>The <see cref="NpgsqlBinarySize" /> instance.</returns>
        public static implicit operator NpgsqlBinarySize(int value)
        {
            return new NpgsqlBinarySize(value);
        }
    }
}