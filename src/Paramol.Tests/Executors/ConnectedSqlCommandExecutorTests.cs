﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using NUnit.Framework;
using Paramol.Executors;
using Paramol.Tests.Framework;

namespace Paramol.Tests.Executors
{
    [TestFixture]
    public class ConnectedSqlCommandExecutorTests
    {
        [Test]
        public void IsAsynchronousSqlNonQueryCommandExecutor()
        {
            Assert.IsInstanceOf<IAsyncSqlNonQueryCommandExecutor>(SutFactory());
        }

        [Test]
        public void IsSynchronousSqlNonQueryCommandExecutor()
        {
            Assert.IsInstanceOf<ISqlNonQueryCommandExecutor>(SutFactory());
        }

        [Test]
        public void IsSynchronousSqlQueryCommandExecutor()
        {
            Assert.IsInstanceOf<ISqlQueryCommandExecutor>(SutFactory());
        }

        [Test]
        public void IsAsynchronousSqlQueryCommandExecutor()
        {
            Assert.IsInstanceOf<IAsyncSqlQueryCommandExecutor>(SutFactory());
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
            Assert.Throws<ArgumentNullException>(
                async () => await sut.ExecuteNonQueryAsync((SqlNonQueryCommand)null));
        }

        [Test]
        public void ExecuteNonQueryAsyncTokenCommandCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.Throws<ArgumentNullException>(
                async () => await sut.ExecuteNonQueryAsync((SqlNonQueryCommand)null, CancellationToken.None));
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
            Assert.Throws<ArgumentNullException>(
                async () => await sut.ExecuteReaderAsync(null));
        }

        [Test]
        public void ExecuteReaderAsyncTokenCommandsCanNotBeNull()
        {
            var sut = SutFactory();
            Assert.Throws<ArgumentNullException>(
                async () => await sut.ExecuteReaderAsync(null, CancellationToken.None));
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