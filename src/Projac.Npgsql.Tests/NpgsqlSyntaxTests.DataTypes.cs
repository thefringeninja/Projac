using System;
using NUnit.Framework;

namespace Projac.Npgsql.Tests
{
    public partial class NpgsqlSyntaxTests
    {
        [Test]
        public void VarCharReturnsExpectedInstance()
        {
            Assert.That(Sql.VarChar("value", 123), Is.EqualTo(new NpgsqlVarCharValue("value", new NpgsqlVarCharSize(123))));
        }

        [Test]
        public void VarCharNullReturnsExpectedInstance()
        {
            Assert.That(Sql.VarChar(null, 123), Is.EqualTo(new NpgsqlVarCharNullValue(new NpgsqlVarCharSize(123))));
        }

        [Test]
        public void CharReturnsExpectedInstance()
        {
            Assert.That(Sql.Char("value", 123), Is.EqualTo(new NpgsqlCharValue("value", new NpgsqlCharSize(123))));
        }

        [Test]
        public void CharNullReturnsExpectedInstance()
        {
            Assert.That(Sql.Char(null, 123), Is.EqualTo(new NpgsqlCharNullValue(new NpgsqlCharSize(123))));
        }

        [Test]
        public void VarCharMaxReturnsExpectedInstance()
        {
            Assert.That(Sql.VarCharMax("value"), Is.EqualTo(new NpgsqlVarCharValue("value", NpgsqlVarCharSize.Max)));
        }

        [Test]
        public void VarCharMaxNullReturnsExpectedInstance()
        {
            Assert.That(Sql.VarCharMax(null), Is.EqualTo(new NpgsqlVarCharNullValue(NpgsqlVarCharSize.Max)));
        }

        [Test]
        public void NVarCharReturnsExpectedInstance()
        {
            Assert.That(Sql.NVarChar("value", 123), Is.EqualTo(new NpgsqlNVarCharValue("value", new NpgsqlNVarCharSize(123))));
        }

        [Test]
        public void NVarCharNullReturnsExpectedInstance()
        {
            Assert.That(Sql.NVarChar(null, 123), Is.EqualTo(new NpgsqlNVarCharNullValue(new NpgsqlNVarCharSize(123))));
        }

        [Test]
        public void NCharReturnsExpectedInstance()
        {
            Assert.That(Sql.NChar("value", 123), Is.EqualTo(new NpgsqlNCharValue("value", new NpgsqlNCharSize(123))));
        }

        [Test]
        public void NCharNullReturnsExpectedInstance()
        {
            Assert.That(Sql.NChar(null, 123), Is.EqualTo(new NpgsqlNCharNullValue(new NpgsqlNCharSize(123))));
        }

        [Test]
        public void NVarCharMaxReturnsExpectedInstance()
        {
            Assert.That(Sql.NVarCharMax("value"), Is.EqualTo(new NpgsqlNVarCharValue("value", NpgsqlNVarCharSize.Max)));
        }

        [Test]
        public void NVarCharMaxNullReturnsExpectedInstance()
        {
            Assert.That(Sql.NVarCharMax(null), Is.EqualTo(new NpgsqlNVarCharNullValue(NpgsqlNVarCharSize.Max)));
        }

        [Test]
        public void BinaryReturnsExpectedInstance()
        {
            Assert.That(Sql.Binary(new byte[] { 1, 2, 3 }, 123), Is.EqualTo(new NpgsqlBinaryValue(new byte[] { 1, 2, 3 }, new NpgsqlBinarySize(123))));
        }

        [Test]
        public void BinaryNullReturnsExpectedInstance()
        {
            Assert.That(Sql.Binary(null, 123), Is.EqualTo(new NpgsqlBinaryNullValue(new NpgsqlBinarySize(123))));
        }

        [Test]
        public void VarBinaryReturnsExpectedInstance()
        {
            Assert.That(Sql.VarBinary(new byte[] { 1, 2, 3 }, 123), Is.EqualTo(new NpgsqlVarBinaryValue(new byte[] { 1, 2, 3 }, new NpgsqlVarBinarySize(123))));
        }

        [Test]
        public void VarBinaryNullReturnsExpectedInstance()
        {
            Assert.That(Sql.VarBinary(null, 123), Is.EqualTo(new NpgsqlVarBinaryNullValue(new NpgsqlVarBinarySize(123))));
        }

        [Test]
        public void VarBinaryMaxReturnsExpectedInstance()
        {
            Assert.That(Sql.VarBinaryMax(new byte[] { 1, 2, 3 }), Is.EqualTo(new NpgsqlVarBinaryValue(new byte[] { 1, 2, 3 }, NpgsqlVarBinarySize.Max)));
        }

        [Test]
        public void VarBinaryMaxNullReturnsExpectedInstance()
        {
            Assert.That(Sql.VarBinaryMax(null), Is.EqualTo(new NpgsqlVarBinaryNullValue(NpgsqlVarBinarySize.Max)));
        }

        [Test]
        public void BigIntReturnsExpectedInstance()
        {
            Assert.That(Sql.BigInt(123), Is.EqualTo(new NpgsqlBigIntValue(123)));
        }

        [Test]
        public void BigIntNullReturnsExpectedInstance()
        {
            Assert.That(Sql.BigInt(null), Is.EqualTo(NpgsqlBigIntNullValue.Instance));
        }

        [Test]
        public void IntReturnsExpectedInstance()
        {
            Assert.That(Sql.Int(123), Is.EqualTo(new NpgsqlIntValue(123)));
        }

        [Test]
        public void IntNullReturnsExpectedInstance()
        {
            Assert.That(Sql.Int(null), Is.EqualTo(NpgsqlIntNullValue.Instance));
        }

        [Test]
        public void BitReturnsExpectedInstance()
        {
            Assert.That(Sql.Bit(true), Is.EqualTo(new NpgsqlBitValue(true)));
        }

        [Test]
        public void BitNullReturnsExpectedInstance()
        {
            Assert.That(Sql.Bit(null), Is.EqualTo(NpgsqlBitNullValue.Instance));
        }

        [Test]
        public void UniqueIdentifierReturnsExpectedInstance()
        {
            Assert.That(Sql.UniqueIdentifier(Guid.Empty), Is.EqualTo(new NpgsqlUniqueIdentifierValue(Guid.Empty)));
        }

        [Test]
        public void UniqueIdentifierNullReturnsExpectedInstance()
        {
            Assert.That(Sql.UniqueIdentifier(null), Is.EqualTo(NpgsqlUniqueIdentifierNullValue.Instance));
        }

        [Test]
        public void DateReturnsExpectedInstance()
        {
            var value = DateTime.UtcNow;
            Assert.That(Sql.Date(value), Is.EqualTo(new NpgsqlDateValue(value)));
        }

        [Test]
        public void DateNullReturnsExpectedInstance()
        {
            Assert.That(Sql.Date(null), Is.EqualTo(NpgsqlDateNullValue.Instance));
        }

        [Test]
        public void DateTimeReturnsExpectedInstance()
        {
            var value = DateTime.UtcNow;
            //Assert.That(Sql.DateTime(value), Is.EqualTo(new NpgsqlDateTimeValue(value)));
        }

  /*      [Test]
        public void DateTimeNullReturnsExpectedInstance()
        {
            Assert.That(Sql.DateTime(null), Is.EqualTo(NpgsqlDateTimeNullValue.Instance));
        }

        [Test]
        public void DateTime2WithoutPrecisionReturnsExpectedInstance()
        {
            var value = DateTime.UtcNow;
            Assert.That(Sql.DateTime2(value), Is.EqualTo(new NpgsqlDateTime2Value(value, 7)));
        }

        [Test]
        public void DateTime2ReturnsExpectedInstance()
        {
            var value = DateTime.UtcNow;
            Assert.That(Sql.DateTime2(value, 3), Is.EqualTo(new NpgsqlDateTime2Value(value, 3)));
        }

        [Test]
        public void DateTime2NullReturnsExpectedInstance()
        {
            Assert.That(Sql.DateTime2(null, 3), Is.EqualTo(new NpgsqlDateTime2NullValue(new NpgsqlDateTime2Precision(3))));
        }

        [Test]
        public void DateTime2NullWithoutPrecisionReturnsExpectedInstance()
        {
            Assert.That(Sql.DateTime2(null), Is.EqualTo(new NpgsqlDateTime2NullValue(NpgsqlDateTime2Precision.Default)));
        }
*/
        [Test]
        public void DateTimeOffsetReturnsExpectedInstance()
        {
            var value = DateTimeOffset.UtcNow;
            Assert.That(Sql.DateTimeOffset(value), Is.EqualTo(new NpgsqlDateTimeOffsetValue(value)));
        }

        [Test]
        public void DateTimeOffsetNullReturnsExpectedInstance()
        {
            Assert.That(Sql.DateTimeOffset(null), Is.EqualTo(NpgsqlDateTimeOffsetNullValue.Instance));
        }

        [Test]
        public void MoneyReturnsExpectedInstance()
        {
            Assert.That(Sql.Money(123.45M), Is.EqualTo(new NpgsqlMoneyValue(123.45M)));
        }

        [Test]
        public void MoneyNullReturnsExpectedInstance()
        {
            Assert.That(Sql.Money(null), Is.EqualTo(NpgsqlMoneyNullValue.Instance));
        }

        [Test]
        public void DecimalWithoutPrecisionNorScaleReturnsExpectedInstance()
        {
            var value = 5;
            Assert.That(Sql.Decimal(value), Is.EqualTo(new NpgsqlDecimalValue(value, 18, 0)));
        }

        [Test]
        public void DecimalWithoutScaleReturnsExpectedInstance()
        {
            var value = 5;
            Assert.That(Sql.Decimal(value, NpgsqlDecimalPrecision.Max), Is.EqualTo(new NpgsqlDecimalValue(value, NpgsqlDecimalPrecision.Max, NpgsqlDecimalScale.Default)));
        }

        [Test]
        public void DecimalReturnsExpectedInstance()
        {
            var value = 5;
            Assert.That(Sql.Decimal(value, 3, 1), Is.EqualTo(new NpgsqlDecimalValue(value, 3, 1)));
        }

        [Test]
        public void DecimalNullReturnsExpectedInstance()
        {
            Assert.That(Sql.Decimal(null, 3, 1), Is.EqualTo(new NpgsqlDecimalNullValue(3, 1)));
        }

        [Test]
        public void DecimalNullWithoutScaleReturnsExpectedInstance()
        {
            Assert.That(Sql.Decimal(null, NpgsqlDecimalPrecision.Max), Is.EqualTo(new NpgsqlDecimalNullValue(NpgsqlDecimalPrecision.Max, NpgsqlDecimalScale.Default)));
        }

        [Test]
        public void DecimalNullWithoutPrecisionNorScaleReturnsExpectedInstance()
        {
            Assert.That(Sql.Decimal(null), Is.EqualTo(new NpgsqlDecimalNullValue(NpgsqlDecimalPrecision.Default, NpgsqlDecimalScale.Default)));
        }
    }
}
