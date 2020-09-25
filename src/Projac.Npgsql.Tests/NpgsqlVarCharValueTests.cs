using System;
using System.Data;
using NpgsqlTypes;
using NUnit.Framework;
using Projac.Sql;

namespace Projac.Npgsql.Tests
{
    [TestFixture]
    public class NpgsqlVarCharValueTests
    {
        [Test]
        public void NullIsNotAnAcceptableValue()
        {
            Assert.Throws<ArgumentNullException>(() => SutFactory(null, new NpgsqlVarCharSize(123)));
        }

        [Test]
        public void IsNpgsqlParameterValue()
        {
            var sut = SutFactory();

            Assert.That(sut, Is.InstanceOf<IDbParameterValue>());
        }

        [Test]
        public void ToDbParameterReturnsExpectedInstance()
        {
            const string parameterName = "name";
            const string value = "value";

            var sut = SutFactory(value, new NpgsqlVarCharSize(123));

            var result = sut.ToDbParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Varchar, value, false, 123);
        }

        [Test]
        public void ToSqlParameterReturnsExpectedInstance()
        {
            const string parameterName = "name";
            const string value = "value";

            var sut = SutFactory(value, new NpgsqlVarCharSize(123));

            var result = sut.ToSqlParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Varchar, value, false, 123);
        }

        [Test]
        public void DoesEqualItself()
        {
            var sut = SutFactory();
            var instance = sut;
            Assert.That(sut.Equals(instance), Is.True);
        }

        [Test]
        public void DoesNotEqualOtherObjectType()
        {
            var sut = SutFactory();
            Assert.That(sut.Equals(new object()), Is.False);
        }

        [Test]
        public void DoesNotEqualNull()
        {
            var sut = SutFactory();
            Assert.That(sut.Equals(null), Is.False);
        }

        [Test]
        public void TwoInstanceAreEqualIfTheyHaveTheSameValueAndSize()
        {
            var sut = SutFactory("value", new NpgsqlVarCharSize(123));
            var other = SutFactory("value", new NpgsqlVarCharSize(123));
            Assert.That(sut.Equals(other), Is.True);
        }

        [Test]
        public void TwoInstanceAreNotEqualIfTheirValueDiffers()
        {
            var sut = SutFactory("value1", new NpgsqlVarCharSize(123));
            var other = SutFactory("value2", new NpgsqlVarCharSize(123));
            Assert.That(sut.Equals(other), Is.False);
        }

        [Test]
        public void TwoInstanceAreNotEqualIfTheirSizeDiffers()
        {
            var sut = SutFactory("value", new NpgsqlVarCharSize(123));
            var other = SutFactory("value", new NpgsqlVarCharSize(456));
            Assert.That(sut.Equals(other), Is.False);
        }

        [Test]
        public void TwoInstanceHaveTheSameHashCodeIfTheyHaveTheSameValueAndSize()
        {
            var sut = SutFactory("value", new NpgsqlVarCharSize(123));
            var other = SutFactory("value", new NpgsqlVarCharSize(123));
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.True);
        }

        [Test]
        public void TwoInstanceDoNotHaveTheSameHashCodeIfTheirValueDiffers()
        {
            var sut = SutFactory("value1", new NpgsqlVarCharSize(123));
            var other = SutFactory("value2", new NpgsqlVarCharSize(123));
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.False);
        }

        [Test]
        public void TwoInstanceDoNotHaveTheSameHashCodeIfTheirSizeDiffers()
        {
            var sut = SutFactory("value", new NpgsqlVarCharSize(123));
            var other = SutFactory("value", new NpgsqlVarCharSize(456));
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.False);
        }

        private static NpgsqlVarCharValue SutFactory()
        {
            return SutFactory("value", new NpgsqlVarCharSize(123));
        }

        private static NpgsqlVarCharValue SutFactory(string value, NpgsqlVarCharSize size)
        {
            return new NpgsqlVarCharValue(value, size);
        }
    }
}