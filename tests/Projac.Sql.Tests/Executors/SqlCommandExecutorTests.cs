#if NET46 || NET452
using System.Configuration;
#endif
using NUnit.Framework;
using Projac.Sql.Executors;

namespace Projac.Sql.Tests.Executors;

[TestFixture]
public class SqlCommandExecutorTests
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

#if NET46 || NET452
        [Test]
        public void ConnectionStringSettingsCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => SutFactory(null));
        }

        [Test]
        public void SqlClientProviderNameIsSupported()
        {
            Assert.DoesNotThrow(
                () => SutFactory(ConnectionStringSettingsFactory("System.Data.SqlClient")));
        }

        [Test]
        public void NonExistingProviderNameThrows()
        {
            Assert.Throws<ArgumentException>(
                () => SutFactory(ConnectionStringSettingsFactory(Guid.NewGuid().ToString("N"))));
        }
#endif

	[Test]
	public void ExecuteNonQueryCommandCanNotBeNull()
	{
		var sut = SutFactory();
		Assert.Throws<ArgumentNullException>(
			() => sut.ExecuteNonQuery((SqlNonQueryCommand)null));
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
	public void ExecuteNonQueryAsyncCommandsCanNotBeNull()
	{
		var sut = SutFactory();
		Assert.That(async () =>
				await sut.ExecuteNonQueryAsync((IEnumerable<SqlNonQueryCommand>)null),
			Throws.ArgumentNullException);
	}

	[Test]
	public void ExecuteNonQueryAsyncTokenCommandsCanNotBeNull()
	{
		var sut = SutFactory();
		Assert.That(async () =>
				await sut.ExecuteNonQueryAsync((IEnumerable<SqlNonQueryCommand>)null, CancellationToken.None),
			Throws.ArgumentNullException);
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

	private static SqlCommandExecutor SutFactory()
	{
		return new SqlCommandExecutor(new TestDbProviderFactory(), "");
	}
}