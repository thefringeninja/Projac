using System;
using Projac.Sql;

namespace Projac.Npgsql
{
    public partial class NpgsqlSyntax
    {
        /// <summary>
        ///     Returns a VARCHAR parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="size">The parameter size.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue VarChar(string value, NpgsqlVarCharSize size)
        {
            if (value == null)
                return new NpgsqlVarCharNullValue(size);
            return new NpgsqlVarCharValue(value, size);
        }

        /// <summary>
        ///     Returns a CHAR parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="size">The parameter size.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Char(string value, NpgsqlCharSize size)
        {
            if (value == null)
                return new NpgsqlCharNullValue(size);
            return new NpgsqlCharValue(value, size);
        }

        /// <summary>
        ///     Returns a VARCHAR(MAX) parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue VarCharMax(string value)
        {
            if (value == null)
                return new NpgsqlVarCharNullValue(NpgsqlVarCharSize.Max);
            return new NpgsqlVarCharValue(value, NpgsqlVarCharSize.Max);
        }

        /// <summary>
        ///     Returns a NVARCHAR parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="size">The parameter size.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue NVarChar(string value, NpgsqlNVarCharSize size)
        {
            if (value == null)
                return new NpgsqlNVarCharNullValue(size);
            return new NpgsqlNVarCharValue(value, size);
        }

        /// <summary>
        ///     Returns a NCHAR parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="size">The parameter size.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue NChar(string value, NpgsqlNCharSize size)
        {
            if (value == null)
                return new NpgsqlNCharNullValue(size);
            return new NpgsqlNCharValue(value, size);
        }

        /// <summary>
        ///     Returns a NVARCHAR(MAX) parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue NVarCharMax(string value)
        {
            if (value == null)
                return new NpgsqlNVarCharNullValue(NpgsqlNVarCharSize.Max);
            return new NpgsqlNVarCharValue(value, NpgsqlNVarCharSize.Max);
        }

        /// <summary>
        ///     Returns a BINARY parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="size">The parameter size.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Binary(byte[] value, NpgsqlBinarySize size)
        {
            if (value == null)
                return new NpgsqlBinaryNullValue(size);
            return new NpgsqlBinaryValue(value, size);
        }

        /// <summary>
        ///     Returns a VARBINARY parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="size">The parameter size.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue VarBinary(byte[] value, NpgsqlVarBinarySize size)
        {
            if (value == null)
                return new NpgsqlVarBinaryNullValue(size);
            return new NpgsqlVarBinaryValue(value, size);
        }

        /// <summary>
        ///     Returns a VARBINARY parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue VarBinaryMax(byte[] value)
        {
            if (value == null)
                return new NpgsqlVarBinaryNullValue(NpgsqlVarBinarySize.Max);
            return new NpgsqlVarBinaryValue(value, NpgsqlVarBinarySize.Max);
        }

        /// <summary>
        ///     Returns a BIGINT parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue BigInt(long? value)
        {
            if (!value.HasValue)
                return NpgsqlBigIntNullValue.Instance;
            return new NpgsqlBigIntValue(value.Value);
        }

        /// <summary>
        ///     Returns a INT parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Int(int? value)
        {
            if (!value.HasValue)
                return NpgsqlIntNullValue.Instance;
            return new NpgsqlIntValue(value.Value);
        }

        /// <summary>
        ///     Returns a BIT parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Bit(bool? value)
        {
            if (!value.HasValue)
                return NpgsqlBitNullValue.Instance;
            return new NpgsqlBitValue(value.Value);
        }

        /// <summary>
        ///     Returns a UNIQUEIDENTIFIER parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue UniqueIdentifier(Guid? value)
        {
            if (!value.HasValue)
                return NpgsqlUniqueIdentifierNullValue.Instance;
            return new NpgsqlUniqueIdentifierValue(value.Value);
        }

        /// <summary>
        ///     Returns a DATE parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Date(DateTime? value)
        {
            if (value == null)
                return NpgsqlDateNullValue.Instance;
            return new NpgsqlDateValue(value.Value);
        }


        /// <summary>
        ///     Returns a DATETIMEOFFSET parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue DateTimeOffset(DateTimeOffset? value)
        {
            if (!value.HasValue)
                return NpgsqlDateTimeOffsetNullValue.Instance;
            return new NpgsqlDateTimeOffsetValue(value.Value);
        }

        /// <summary>
        ///     Returns a DECIMAL parameter value.
        /// </summary>
        /// <param name="value">The parameter value</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Decimal(decimal? value)
        {
            return Decimal(value, NpgsqlDecimalPrecision.Default, NpgsqlDecimalScale.Default);
        }

        /// <summary>
        ///     Returns a DECIMAL parameter value.
        /// </summary>
        /// <param name="value">The parameter value</param>
        /// <param name="precision">The parameter precision.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Decimal(decimal? value, NpgsqlDecimalPrecision precision)
        {
            return Decimal(value, precision, NpgsqlDecimalScale.Default);
        }

        /// <summary>
        ///     Returns a DECIMAL parameter value.
        /// </summary>
        /// <param name="value">The parameter value</param>
        /// <param name="precision">The parameter precision.</param>
        /// <param name="scale">The parameter scale.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Decimal(decimal? value, NpgsqlDecimalPrecision precision, NpgsqlDecimalScale scale)
        {
            if (!value.HasValue)
                return new NpgsqlDecimalNullValue(precision, scale);
            return new NpgsqlDecimalValue(value.Value, precision, scale);
        }

        /// <summary>
        ///     Returns a MONEY parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <returns>A <see cref="IDbParameterValue" />.</returns>
        public IDbParameterValue Money(decimal? value)
        {
            if (!value.HasValue)
                return NpgsqlMoneyNullValue.Instance;
            return new NpgsqlMoneyValue(value.Value);
        }
    }
}