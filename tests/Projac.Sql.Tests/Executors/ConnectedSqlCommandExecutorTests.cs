using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using NUnit.Framework;
using Projac.Sql.Executors;

namespace Projac.Sql.Tests.Executors
{
    [TestFixture]
    public class ConnectedSqlCommandExecutorTests
    {
        [Test]
        public void IsAsynchronousSqlNonQueryCommandExecutor()
        {
            NUnit.Framework.Assert.That((IAsyncSqlNonQueryCommandExecutor)SutFactory(), Is.InstanceOf<IAsyncSqlNonQueryCommandExecutor>());
        }

        [Test]
        public void IsSynchronousSqlNonQueryCommandExecutor()
        {
            NUnit.Framework.Assert.That((ISqlNonQueryCommandExecutor)SutFactory(), Is.InstanceOf<ISqlNonQueryCommandExecutor>());
        }

        [Test]
        public void IsSynchronousSqlQueryCommandExecutor()
        {
            NUnit.Framework.Assert.That((ISqlQueryCommandExecutor)SutFactory(), Is.InstanceOf<ISqlQueryCommandExecutor>());
        }

        [Test]
        public void IsAsynchronousSqlQueryCommandExecutor()
        {
            NUnit.Framework.Assert.That((IAsyncSqlQueryCommandExecutor)SutFactory(), Is.InstanceOf<IAsyncSqlQueryCommandExecutor>());
        }

        [Test]
        public void ConnectionCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => SutFactory(null));
        }

        [Test]
        public void ConnectionMustBeOpen()
        {
            Assert.Throws<ArgumentException>(
                () => SutFactory(new TestDbConnection()));
        }

        [Test]
        public void OpenConnectionIsAccepted()
        {
            var connection = new TestDbConnection();
            connection.Open();
            Assert.DoesNotThrow(() => SutFactory(connection));
        }

        [Test]
        public void ExecuteNonQueryCommandCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.Throws<ArgumentNullException>(
                () => sut.ExecuteNonQuery((SqlNonQueryCommand) null));
        }

        [Test]
        public void ExecuteNonQueryAsyncCommandCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.That(async () =>
                await sut.ExecuteNonQueryAsync((SqlNonQueryCommand)null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ExecuteNonQueryAsyncTokenCommandCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.That(async () =>
                await sut.ExecuteNonQueryAsync((SqlNonQueryCommand)null, CancellationToken.None),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ExecuteNonQueryCommandsCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.Throws<ArgumentNullException>(
                () => sut.ExecuteNonQuery((IEnumerable<SqlNonQueryCommand>) null));
        }

        [Test]
        public void ExecuteReaderCommandCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.Throws<ArgumentNullException>(
                () => sut.ExecuteReader(null));
        }

        [Test]
        public void ExecuteReaderAsyncCommandCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.That(async () =>
                await sut.ExecuteReaderAsync(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ExecuteReaderAsyncTokenCommandsCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.That(async () =>
                await sut.ExecuteReaderAsync(null, CancellationToken.None),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ExecuteScalarCommandCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.Throws<ArgumentNullException>(
                () => sut.ExecuteScalar(null));
        }

        [Test]
        public void ExecuteScalarAsyncCommandCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.That(async () =>
                await sut.ExecuteScalarAsync(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ExecuteScalarAsyncTokenCommandsCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.That(async () =>
                await sut.ExecuteScalarAsync(null, CancellationToken.None),
                Throws.ArgumentNullException);
        }

        private static ConnectedSqlCommandExecutor SutFactory()
        {
            var connection = new TestDbConnection();
            connection.Open();
            return SutFactory(connection);
        }

        private static ConnectedSqlCommandExecutor SutFactory(DbConnection connection)
        {
            return new ConnectedSqlCommandExecutor(connection);
        }
    }
}
