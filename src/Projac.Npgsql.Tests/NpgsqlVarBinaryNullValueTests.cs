using System;
using System.Data;
using NpgsqlTypes;
using NUnit.Framework;
using Projac.Sql;

namespace Projac.Npgsql.Tests
{
    [TestFixture]
    public class NpgsqlVarBinaryNullValueTests
    {
        private NpgsqlVarBinaryNullValue _sut;
        private NpgsqlVarBinarySize _size;

        [SetUp]
        public void SetUp()
        {
            _size = new NpgsqlVarBinarySize(100);
            _sut = new NpgsqlVarBinaryNullValue(_size);
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

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Varbit, DBNull.Value, true, 100);
        }

        [Test]
        public void ToSqlParameterReturnsExpectedInstance()
        {
            const string parameterName = "name";

            var result = _sut.ToSqlParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Varbit, DBNull.Value, true, 100);
        }

        [Test]
        public void DoesEqualItself()
        {
            var self = _sut;
            Assert.That(_sut.Equals(self), Is.True);
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

            Assert.That(result, Is.EqualTo(100));
        }
    }
}