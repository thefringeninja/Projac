using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Projac.Npgsql.Tests
{
    [TestFixture]
    public class NpgsqlDecimalScaleTests
    {
        [Test]
        public void MaxReturnsExpectedInstance()
        {
            Assert.That(NpgsqlDecimalScale.Max, Is.EqualTo(new NpgsqlDecimalScale(38)));
        }

        [Test]
        public void MinReturnsExpectedInstance()
        {
            Assert.That(NpgsqlDecimalScale.Min, Is.EqualTo(new NpgsqlDecimalScale(0)));
        }

        [Test]
        public void DefaultReturnsExpectedInstance()
        {
            Assert.That(NpgsqlDecimalScale.Default, Is.EqualTo(new NpgsqlDecimalScale(0)));
        }

        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(37, true)]
        [TestCase(38, true)]
        [TestCase(39, false)]
        public void ScaleMustBeWithinRange(byte value, bool withinRange)
        {
            if (!withinRange)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => SutFactory(value));
            }
            else
            {
                Assert.DoesNotThrow(() => SutFactory(value));
            }
        }

        [Test]
        public void DoesEqualItself()
        {
            var sut = SutFactory();
            var instance = sut;
            Assert.That(sut.Equals(instance), Is.True);
        }

        [Test]
        public void DoesNotEqualObjectOfOtherType()
        {
            var sut = SutFactory();
            var instance = new object();
            Assert.That(sut.Equals(instance), Is.False);
        }

        [Test]
        public void DoesNotEqualNull()
        {
            var sut = SutFactory();
            Assert.That(sut.Equals(null), Is.False);
        }

        [Test]
        public void IsEquatable()
        {
            var sut = SutFactory();
            Assert.That(sut, Is.InstanceOf<IEquatable<NpgsqlDecimalScale>>());
        }

        [Test]
        public void TwoInstancesAreEqualIfTheyHaveTheSameValue()
        {
            var sut = SutFactory(4);
            var other = SutFactory(4);
            Assert.That(sut.Equals(other), Is.True);
        }

        [Test]
        public void TwoInstancesAreNotEqualIfTheirValuesDiffer()
        {
            var sut = SutFactory(4);
            var other = SutFactory(5);
            Assert.That(sut.Equals(other), Is.False);
        }

        [Test]
        public void TwoInstancesHaveTheSameHashCodeIfTheyHaveTheSameValue()
        {
            var sut = SutFactory(4);
            var other = SutFactory(4);
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.True);
        }

        [Test]
        public void TwoInstancesDoNotHaveTheSameHashCodeIfTheirValuesDiffer()
        {
            var sut = SutFactory(4);
            var other = SutFactory(5);
            Assert.That(sut.GetHashCode().Equals(other.GetHashCode()), Is.False);
        }

        [Test]
        public void TwoInstancesAreOperatorEqualIfTheyHaveTheSameValue()
        {
            var sut = SutFactory(4);
            var other = SutFactory(4);
            Assert.That(sut == other, Is.True);
            Assert.That(sut != other, Is.False);
        }

        [Test]
        public void TwoInstancesAreNotOperatorEqualIfTheirValuesDiffer()
        {
            var sut = SutFactory(4);
            var other = SutFactory(5);
            Assert.That(sut == other, Is.False);
            Assert.That(sut != other, Is.True);
        }

        [Test]
        public void CanBeImplicitlyConvertedToByte()
        {
            var sut = SutFactory(12);

            byte result = sut;

            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void CanBeExplicitlyConvertedToByte()
        {
            var sut = SutFactory(12);

            var result = (byte)sut;

            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void CanBeImplicitlyConvertedFromByte()
        {
            NpgsqlDecimalScale result = 12;

            Assert.That(result, Is.EqualTo(new NpgsqlDecimalScale(12)));
        }

        [Test]
        public void CanBeExplicitlyConvertedFromByte()
        {
            var result = (NpgsqlDecimalScale)12;

            Assert.That(result, Is.EqualTo(new NpgsqlDecimalScale(12)));
        }

        [Test]
        public void IsComparableToNpgsqlDecimalScale()
        {
            Assert.That(SutFactory(), Is.InstanceOf<IComparable<NpgsqlDecimalScale>>());
        }

        [Test]
        public void IsComparableToNpgsqlDecimalPrecision()
        {
            Assert.That(SutFactory(), Is.InstanceOf<IComparable<NpgsqlDecimalPrecision>>());
        }

        [TestCaseSource("CompareToScaleCases")]
        public void CompareToScaleReturnsExpectedResult(NpgsqlDecimalScale sut, NpgsqlDecimalScale other, int expected)
        {
            var result = sut.CompareTo(other);

            Assert.That(result, Is.EqualTo(expected));
        }

        private static IEnumerable<TestCaseData> CompareToScaleCases()
        {
            yield return new TestCaseData(
                new NpgsqlDecimalScale(1), new NpgsqlDecimalScale(2), -1);
            yield return new TestCaseData(
                new NpgsqlDecimalScale(2), new NpgsqlDecimalScale(1), 1);
            yield return new TestCaseData(
                new NpgsqlDecimalScale(1), new NpgsqlDecimalScale(1), 0);
        }

        [TestCaseSource("CompareToPrecisionCases")]
        public void CompareToPrecisionReturnsExpectedResult(NpgsqlDecimalScale sut, NpgsqlDecimalPrecision other, int expected)
        {
            var result = sut.CompareTo(other);

            Assert.That(result, Is.EqualTo(expected));
        }

        private static IEnumerable<TestCaseData> CompareToPrecisionCases()
        {
            yield return new TestCaseData(
                new NpgsqlDecimalScale(1), new NpgsqlDecimalPrecision(2), -1);
            yield return new TestCaseData(
                new NpgsqlDecimalScale(2), new NpgsqlDecimalPrecision(1), 1);
            yield return new TestCaseData(
                new NpgsqlDecimalScale(1), new NpgsqlDecimalPrecision(1), 0);
        }

        [TestCase(1, 1, true)]
        [TestCase(2, 1, false)]
        [TestCase(0, 1, true)]
        public void LessThanOrEqualToScaleOperatorReturnsExpectedResult(byte left, byte right, bool expected)
        {
            var result = new NpgsqlDecimalScale(left) <= new NpgsqlDecimalScale(right);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 1, false)]
        [TestCase(2, 1, false)]
        [TestCase(0, 1, true)]
        public void LessThanScaleOperatorReturnsExpectedResult(byte left, byte right, bool expected)
        {
            var result = new NpgsqlDecimalScale(left) < new NpgsqlDecimalScale(right);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 1, true)]
        [TestCase(2, 1, true)]
        [TestCase(0, 1, false)]
        public void GreaterThanOrEqualToScaleOperatorReturnsExpectedResult(byte left, byte right, bool expected)
        {
            var result = new NpgsqlDecimalScale(left) >= new NpgsqlDecimalScale(right);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 1, false)]
        [TestCase(2, 1, true)]
        [TestCase(0, 1, false)]
        public void GreaterThanScaleOperatorReturnsExpectedResult(byte left, byte right, bool expected)
        {
            var result = new NpgsqlDecimalScale(left) > new NpgsqlDecimalScale(right);

            Assert.That(result, Is.EqualTo(expected));
        }



        [TestCase(1, 1, true)]
        [TestCase(2, 1, false)]
        [TestCase(0, 1, true)]
        public void LessThanOrEqualToPrecisionOperatorReturnsExpectedResult(byte left, byte right, bool expected)
        {
            var result = new NpgsqlDecimalScale(left) <= new NpgsqlDecimalPrecision(right);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 1, false)]
        [TestCase(2, 1, false)]
        [TestCase(0, 1, true)]
        public void LessThanPrecisionOperatorReturnsExpectedResult(byte left, byte right, bool expected)
        {
            var result = new NpgsqlDecimalScale(left) < new NpgsqlDecimalPrecision(right);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 1, true)]
        [TestCase(2, 1, true)]
        [TestCase(0, 1, false)]
        public void GreaterThanOrEqualToPrecisionOperatorReturnsExpectedResult(byte left, byte right, bool expected)
        {
            var result = new NpgsqlDecimalScale(left) >= new NpgsqlDecimalPrecision(right);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 1, false)]
        [TestCase(2, 1, true)]
        [TestCase(0, 1, false)]
        public void GreaterThanPrecisionOperatorReturnsExpectedResult(byte left, byte right, bool expected)
        {
            var result = new NpgsqlDecimalScale(left) > new NpgsqlDecimalPrecision(right);

            Assert.That(result, Is.EqualTo(expected));
        }

        private static NpgsqlDecimalScale SutFactory()
        {
            var random = new Random();
            return SutFactory((byte)random.Next(0, 38));
        }

        private static NpgsqlDecimalScale SutFactory(byte value)
        {
            return new NpgsqlDecimalScale(value);
        }
    }
}