using System;
using System.Data;
using NpgsqlTypes;
using NUnit.Framework;
using Projac.Sql;

namespace Projac.Npgsql.Tests
{
    [TestFixture]
    public class NpgsqlDateTimeOffsetValueTests
    {
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

            var value = DateTimeOffset.UtcNow;
            var sut = SutFactory(value);

            var result = sut.ToDbParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Date, value, false, 7);
        }

        [Test]
        public void ToSqlParameterReturnsExpectedInstance()
        {
            const string parameterName = "name";

            var value = DateTimeOffset.UtcNow;
            var sut = SutFactory(value);

            var result = sut.ToSqlParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Date, value, false, 7);
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
        public void TwoInstanceAreEqualIfTheyHaveTheSameValue()
        {
            var value = DateTimeOffset.UtcNow;
            var sut = SutFactory(value);
            var other = SutFactory(value);
            Assert.That(sut.Equals(other), Is.True);
        }

        [Test]
        public void TwoInstanceAreNotEqualIfTheirValueDiffers()
        {
            var value1 = new DateTimeOffset(0, TimeSpan.Zero);
            var value2 = new DateTimeOffset(1, TimeSpan.Zero);
            var sut = SutFactory(value1);
            var other = SutFactory(value2);
            Assert.That(sut.Equals(other), Is.False);
        }

        [Test]
        public void TwoInstanceHaveTheSameHashCodeIfTheyHaveTheSameValue()
        {
            var value = DateTimeOffset.UtcNow;
            var sut = SutFactory(value);
            var other = SutFactory(value);
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.True);
        }

        [Test]
        public void TwoInstanceDoNotHaveTheSameHashCodeIfTheirValueDiffers()
        {
            var value1 = new DateTimeOffset(0, TimeSpan.Zero);
            var value2 = new DateTimeOffset(1, TimeSpan.Zero);
            var sut = SutFactory(value1);
            var other = SutFactory(value2);
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.False);
        }

        private static NpgsqlDateTimeOffsetValue SutFactory()
        {
            return SutFactory(DateTimeOffset.UtcNow);
        }

        private static NpgsqlDateTimeOffsetValue SutFactory(DateTimeOffset value)
        {
            return new NpgsqlDateTimeOffsetValue(value);
        }
    }
}