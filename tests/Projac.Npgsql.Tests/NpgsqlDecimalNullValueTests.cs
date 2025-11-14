using System;
using System.Data;
using NpgsqlTypes;
using NUnit.Framework;
using Projac.Sql;

namespace Projac.Npgsql.Tests
{
    [TestFixture]
    public class NpgsqlDecimalNullValueTests
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

            var sut = SutFactory(19, 1);

            var result = sut.ToDbParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Money, DBNull.Value, true, 0, 19, 1);
        }

        [Test]
        public void ToSqlParameterReturnsExpectedInstance()
        {
            const string parameterName = "name";

            var sut = SutFactory(19, 1);

            var result = sut.ToSqlParameter(parameterName);

            result.ExpectNpgsqlParameter(parameterName, NpgsqlDbType.Money, DBNull.Value, true, 0, 19, 1);
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
        public void TwoInstanceAreEqualIfTheyHaveTheSamePrecisionAndScale()
        {
            var sut = SutFactory(5,4);
            var other = SutFactory(5,4);
            Assert.That(sut.Equals(other), Is.True);
        }

        [Test]
        public void TwoInstanceAreNotEqualIfTheirPrecisionDiffers()
        {
            var sut = SutFactory(5,4);
            var other = SutFactory(6,4);
            Assert.That(sut.Equals(other), Is.False);
        }

        [Test]
        public void TwoInstanceAreNotEqualIfTheirScaleDiffers()
        {
            var sut = SutFactory(5, 4);
            var other = SutFactory(5, 3);
            Assert.That(sut.Equals(other), Is.False);
        }

        [Test]
        public void TwoInstanceHaveTheSameHashCodeIfTheyHaveTheSamePrecisionAndScale()
        {
            var sut = SutFactory(5, 4);
            var other = SutFactory(5, 4);
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.True);
        }

        [Test]
        public void TwoInstanceDoNotHaveTheSameHashCodeIfTheirPrecisionDiffers()
        {
            var sut = SutFactory(5, 4);
            var other = SutFactory(6, 4);
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.False);
        }

        [Test]
        public void TwoInstanceDoNotHaveTheSameHashCodeIfTheirScaleDiffers()
        {
            var sut = SutFactory(5, 4);
            var other = SutFactory(5, 3);
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.False);
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(38, true)]
        [TestCase(39, false)]
        public void PrecisionMustBeWithinRange(byte precision, bool withinRange)
        {
            if (!withinRange)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => SutFactory(precision));
            }
            else
            {
                Assert.DoesNotThrow(() => SutFactory(precision));
            }
        }

        [TestCase(0, true)]
        [TestCase(8, true)]
        [TestCase(9, false)]
        public void ScaleMustBeWithinRange(byte scale, bool withinRange)
        {
            if (!withinRange)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => SutFactory(8, scale));
            }
            else
            {
                Assert.DoesNotThrow(() => SutFactory(8, scale));
            }
        }

        private static NpgsqlDecimalNullValue SutFactory(byte precision = 18, byte scale = 0)
        {
            return new NpgsqlDecimalNullValue(precision, scale);
        }
    }
}