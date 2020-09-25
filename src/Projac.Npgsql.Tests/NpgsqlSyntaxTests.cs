using NUnit.Framework;

namespace Projac.Npgsql.Tests
{
    [TestFixture]
    public partial class NpgsqlSyntaxTests
    {
        private NpgsqlSyntax _syntax;

        [SetUp]
        public void SetUp()
        {
            _syntax = new NpgsqlSyntax();
        }

        private NpgsqlSyntax Sql { get { return _syntax; } }
    }
}
