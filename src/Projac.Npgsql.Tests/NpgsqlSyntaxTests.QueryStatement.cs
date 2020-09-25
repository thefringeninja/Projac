using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Projac.Sql;

namespace Projac.Npgsql.Tests
{
    public partial class NpgsqlSyntaxTests
    {
        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryStatementCases")]
        public void QueryStatementReturnsExpectedInstance(SqlQueryCommand actual, SqlQueryCommand expected)
        {
            Assert.That(actual.Text, Is.EqualTo(expected.Text));
            Assert.That(actual.Parameters, Is.EquivalentTo(expected.Parameters).Using(new NpgsqlParameterEqualityComparer()));
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryStatementIfCases")]
        public void QueryStatementIfReturnsExpectedInstance(IEnumerable<SqlQueryCommand> actual, SqlQueryCommand[] expected)
        {
            var actualArray = actual.ToArray();
            Assert.That(actualArray.Length, Is.EqualTo(expected.Length));
            for (var index = 0; index < actualArray.Length; index++)
            {
                Assert.That(actualArray[index].Text, Is.EqualTo(expected[index].Text));
                Assert.That(actualArray[index].Parameters, Is.EquivalentTo(expected[index].Parameters).Using(new NpgsqlParameterEqualityComparer()));
            }
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryStatementUnlessCases")]
        public void QueryStatementUnlessReturnsExpectedInstance(IEnumerable<SqlQueryCommand> actual, SqlQueryCommand[] expected)
        {
            var actualArray = actual.ToArray();
            Assert.That(actualArray.Length, Is.EqualTo(expected.Length));
            for (var index = 0; index < actualArray.Length; index++)
            {
                Assert.That(actualArray[index].Text, Is.EqualTo(expected[index].Text));
                Assert.That(actualArray[index].Parameters, Is.EquivalentTo(expected[index].Parameters).Using(new NpgsqlParameterEqualityComparer()));
            }
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryStatementFormatCases")]
        public void QueryStatementFormatReturnsExpectedInstance(SqlQueryCommand actual, SqlQueryCommand expected)
        {
            Assert.That(actual.Text, Is.EqualTo(expected.Text));
            Assert.That(actual.Parameters, Is.EquivalentTo(expected.Parameters).Using(new NpgsqlParameterEqualityComparer()));
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryStatementFormatIfCases")]
        public void QueryStatementFormatIfReturnsExpectedInstance(IEnumerable<SqlQueryCommand> actual, SqlQueryCommand[] expected)
        {
            var actualArray = actual.ToArray();
            Assert.That(actualArray.Length, Is.EqualTo(expected.Length));
            for (var index = 0; index < actualArray.Length; index++)
            {
                Assert.That(actualArray[index].Text, Is.EqualTo(expected[index].Text));
                Assert.That(actualArray[index].Parameters, Is.EquivalentTo(expected[index].Parameters).Using(new NpgsqlParameterEqualityComparer()));
            }
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryStatementFormatUnlessCases")]
        public void QueryStatementFormatUnlessReturnsExpectedInstance(IEnumerable<SqlQueryCommand> actual, SqlQueryCommand[] expected)
        {
            var actualArray = actual.ToArray();
            Assert.That(actualArray.Length, Is.EqualTo(expected.Length));
            for (var index = 0; index < actualArray.Length; index++)
            {
                Assert.That(actualArray[index].Text, Is.EqualTo(expected[index].Text));
                Assert.That(actualArray[index].Parameters, Is.EquivalentTo(expected[index].Parameters).Using(new NpgsqlParameterEqualityComparer()));
            }
        }
    }
}
