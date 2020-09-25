using System;
using System.Data;
using NpgsqlTypes;
using NUnit.Framework;
using Projac.Sql;

namespace Projac.Npgsql.Tests
{
    [TestFixture]
    public class NpgsqlBitNullValueTests
    {
        private NpgsqlBitNullValue _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = NpgsqlBitNullValue.Instance;
        }

        [Test]
        public void InstanceIsSqlNullValue()
        {
            Assert.That(NpgsqlBitNullValue.Instance, Is.InstanceOf<NpgsqlBitNullValue>());
        }

        [Test]
        public void IsNpgsqlParameterValue()
        {
            Assert.That(_sut, Is.InstanceOf<IDbParameterValue>());
        }

        [Test]
        public void ToDbParameterReturnsExpectedInstance()
        {
            const string parameterName = "name";

            var result = _sut.ToDbParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Bit, DBNull.Value, true, 1);
        }

        [Test]
        public void ToSqlParameterReturnsExpectedInstance()
        {
            const string parameterName = "name";

            var result = _sut.ToSqlParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Bit, DBNull.Value, true, 1);
        }

        [Test]
        public void DoesEqualItself()
        {
            Assert.That(_sut.Equals(NpgsqlBitNullValue.Instance), Is.True);
        }

        [Test]
        public void DoesNotEqualOtherObjectType()
        {
            Assert.That(_sut.Equals(new object()), Is.False);
        }

        [Test]
        public void DoesNotEqualNull()
        {
            Assert.That(_sut.Equals(null), Is.False);
        }

        [Test]
        public void HasExpectedHashCode()
        {
            var result = _sut.GetHashCode();

            Assert.That(result, Is.EqualTo(0));
        }
    }
}