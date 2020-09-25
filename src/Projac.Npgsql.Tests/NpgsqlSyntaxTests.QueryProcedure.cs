using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Projac.Sql;

namespace Projac.Npgsql.Tests
{
    public partial class NpgsqlSyntaxTests
    {
        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryProcedureCases")]
        public void QueryProcedureReturnsExpectedInstance(SqlQueryCommand actual, SqlQueryCommand expected)
        {
            Assert.That(actual.Text, Is.EqualTo(expected.Text));
            Assert.That(actual.Parameters, Is.EquivalentTo(expected.Parameters).Using(new NpgsqlParameterEqualityComparer()));
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryProcedureIfCases")]
        public void QueryProcedureIfReturnsExpectedInstance(IEnumerable<SqlQueryCommand> actual, SqlQueryCommand[] expected)
        {
            var actualArray = actual.ToArray();
            Assert.That(actualArray.Length, Is.EqualTo(expected.Length));
            for (var index = 0; index < actualArray.Length; index++)
            {
                Assert.That(actualArray[index].Text, Is.EqualTo(expected[index].Text));
                Assert.That(actualArray[index].Parameters, Is.EquivalentTo(expected[index].Parameters).Using(new NpgsqlParameterEqualityComparer()));
            }
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryProcedureUnlessCases")]
        public void QueryProcedureUnlessReturnsExpectedInstance(IEnumerable<SqlQueryCommand> actual, SqlQueryCommand[] expected)
        {
            var actualArray = actual.ToArray();
            Assert.That(actualArray.Length, Is.EqualTo(expected.Length));
            for (var index = 0; index < actualArray.Length; index++)
            {
                Assert.That(actualArray[index].Text, Is.EqualTo(expected[index].Text));
                Assert.That(actualArray[index].Parameters, Is.EquivalentTo(expected[index].Parameters).Using(new NpgsqlParameterEqualityComparer()));
            }
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryProcedureFormatCases")]
        public void QueryProcedureFormatReturnsExpectedInstance(SqlQueryCommand actual, SqlQueryCommand expected)
        {
            Assert.That(actual.Text, Is.EqualTo(expected.Text));
            Assert.That(actual.Parameters, Is.EquivalentTo(expected.Parameters).Using(new NpgsqlParameterEqualityComparer()));
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryProcedureFormatIfCases")]
        public void QueryProcedureFormatIfReturnsExpectedInstance(IEnumerable<SqlQueryCommand> actual, SqlQueryCommand[] expected)
        {
            var actualArray = actual.ToArray();
            Assert.That(actualArray.Length, Is.EqualTo(expected.Length));
            for (var index = 0; index < actualArray.Length; index++)
            {
                Assert.That(actualArray[index].Text, Is.EqualTo(expected[index].Text));
                Assert.That(actualArray[index].Parameters, Is.EquivalentTo(expected[index].Parameters).Using(new NpgsqlParameterEqualityComparer()));
            }
        }

        [TestCaseSource(typeof(NpgsqlSyntaxTestCases), "QueryProcedureFormatUnlessCases")]
        public void QueryProcedureFormatUnlessReturnsExpectedInstance(IEnumerable<SqlQueryCommand> actual, SqlQueryCommand[] expected)
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
