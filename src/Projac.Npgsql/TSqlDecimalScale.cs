﻿using System;

namespace Projac.Npgsql
{
    /// <summary>
    ///     Represents the scale of a <see cref="NpgsqlDecimalValue" />. The maximum number of decimal digits that can be stored to the right of the decimal point. Scale must be a value from 0 through the precision of the decimal value. The default scale is 0.
    /// </summary>
    public struct NpgsqlDecimalScale : IEquatable<NpgsqlDecimalScale>, IComparable<NpgsqlDecimalScale>, IComparable<NpgsqlDecimalPrecision>
    {
        /// <summary>
        ///     Represents the maximum precision value.
        /// </summary>
        public static readonly NpgsqlDecimalScale Max = new NpgsqlDecimalScale(38);

        /// <summary>
        ///     Represents the minimum precision value.
        /// </summary>
        public static readonly NpgsqlDecimalScale Min = new NpgsqlDecimalScale(0);

        /// <summary>
        ///     Represents the default value.
        /// </summary>
        public static readonly NpgsqlDecimalScale Default = new NpgsqlDecimalScale(0);

        private readonly byte _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NpgsqlDecimalScale" /> struct.
        /// </summary>
        /// <param name="value">The scale</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is not between 0 and 38.</exception>
        public NpgsqlDecimalScale(byte value)
        {
            if (value > 38)
            {
                throw new ArgumentOutOfRangeException("value", value,
                    string.Format("The value must be between {0} and {1}.", 0, 38));
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
        public bool Equals(NpgsqlDecimalScale other)
        {
            return _value == other._value;
        }

        /// <summary>
        /// Compares this instance to a <see cref="NpgsqlDecimalScale"/>.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other"/> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other"/>. Greater than zero This instance follows <paramref name="other"/> in the sort order.
        /// </returns>
        public int CompareTo(NpgsqlDecimalScale other)
        {
            return _value.CompareTo(other);
        }

        /// <summary>
        /// Compares this instance to a <see cref="NpgsqlDecimalPrecision"/>.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other"/> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other"/>. Greater than zero This instance follows <paramref name="other"/> in the sort order.
        /// </returns>
        public int CompareTo(NpgsqlDecimalPrecision other)
        {
            return _value.CompareTo(other);
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
            return obj is NpgsqlDecimalScale && Equals((NpgsqlDecimalScale)obj);
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
        ///     Determines whether two specified instances of <see cref="NpgsqlDecimalScale" /> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left" /> and <paramref name="right" /> represent the same sql varchar size;
        ///     otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(NpgsqlDecimalScale left, NpgsqlDecimalScale right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two specified instances of <see cref="NpgsqlDecimalScale" /> are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left" /> and <paramref name="right" /> do not represent the same sql varchar
        ///     size; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(NpgsqlDecimalScale left, NpgsqlDecimalScale right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Converts a <see cref="NpgsqlDecimalScale" /> instance to an <see cref="Byte" />.
        /// </summary>
        /// <param name="scale">The <see cref="NpgsqlDecimalScale" /> instance to convert.</param>
        /// <returns>The <see cref="Byte" /> size value.</returns>
        public static implicit operator byte(NpgsqlDecimalScale scale)
        {
            return scale._value;
        }

        /// <summary>
        ///     Converts a <see cref="NpgsqlDecimalScale" /> instance to an <see cref="Byte" />.
        /// </summary>
        /// <param name="value">The <see cref="NpgsqlDecimalScale" /> instance to convert.</param>
        /// <returns>The <see cref="Byte" /> size value.</returns>
        public static implicit operator NpgsqlDecimalScale(byte value)
        {
            return new NpgsqlDecimalScale(value);
        }

        /// <summary>
        /// Compares two instances of <see cref="NpgsqlDecimalScale"/> using the less than or equal to operator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>, otherwise false.
        /// </returns>
        public static bool operator <=(NpgsqlDecimalScale left, NpgsqlDecimalScale right)
        {
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares two instances of <see cref="NpgsqlDecimalScale"/> using the less than operator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>, otherwise false.
        /// </returns>
        public static bool operator <(NpgsqlDecimalScale left, NpgsqlDecimalScale right)
        {
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares two instances of <see cref="NpgsqlDecimalScale"/> using the greater than or equal to operator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>, otherwise false.
        /// </returns>
        public static bool operator >=(NpgsqlDecimalScale left, NpgsqlDecimalScale right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Compares two instances of <see cref="NpgsqlDecimalScale"/> using the greater than operator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>, otherwise false.
        /// </returns>
        public static bool operator >(NpgsqlDecimalScale left, NpgsqlDecimalScale right)
        {
            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Compares a <see cref="NpgsqlDecimalScale"/> to a <see cref="NpgsqlDecimalPrecision"/> using the less than or equal to operator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>, otherwise false.
        /// </returns>
        public static bool operator <=(NpgsqlDecimalScale left, NpgsqlDecimalPrecision right)
        {
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares a <see cref="NpgsqlDecimalScale"/> to a <see cref="NpgsqlDecimalPrecision"/> using the less than operator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>, otherwise false.
        /// </returns>
        public static bool operator <(NpgsqlDecimalScale left, NpgsqlDecimalPrecision right)
        {
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares a <see cref="NpgsqlDecimalScale"/> to a <see cref="NpgsqlDecimalPrecision"/> using the greater than or equal to operator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>, otherwise false.
        /// </returns>
        public static bool operator >=(NpgsqlDecimalScale left, NpgsqlDecimalPrecision right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Compares a <see cref="NpgsqlDecimalScale"/> to a <see cref="NpgsqlDecimalPrecision"/> using the greater than operator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>, otherwise false.
        /// </returns>
        public static bool operator >(NpgsqlDecimalScale left, NpgsqlDecimalPrecision right)
        {
            return left.CompareTo(right) > 0;
        }
    }
}