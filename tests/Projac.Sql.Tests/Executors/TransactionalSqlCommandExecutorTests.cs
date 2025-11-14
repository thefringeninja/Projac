#if NET46 || NET452
using System.Configuration;
#endif
using NUnit.Framework;
using Projac.Sql.Executors;

namespace Projac.Sql.Tests.Executors;

[TestFixture]
public class TransactionalSqlCommandExecutorTests
{
	[Test]
	public void IsAsynchronousSqlNonQueryCommandExecutor()
	{
		NUnit.Framework.Assert.That((IAsyncSqlNonQueryCommandExecutor)SutFactory(), Is.InstanceOf<IAsyncSqlNonQueryCommandExecutor>());
	}

	[Test]
	public void IsSynchronousTransactionalSqlNonQueryCommandExecutor()
	{
		NUnit.Framework.Assert.That((ISqlNonQueryCommandExecutor)SutFactory(), Is.InstanceOf<ISqlNonQueryCommandExecutor>());
	}


	[Test]
	public void ExecuteNonQueryCommandCanNotBeNull()
	{
		var sut = SutFactory();
		Assert.Throws<ArgumentNullException>(
			() => sut.ExecuteNonQuery((SqlNonQueryCommand)null));
	}

	[Test]
	public void ExecuteNonQueryCommandsCanNotBeNull()
	{
		var sut = SutFactory();
		Assert.Throws<ArgumentNullException>(
			() => sut.ExecuteNonQuery((IEnumerable<SqlNonQueryCommand>) null));
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
	public void ExecuteNonQueryAsyncCommandsCanNotBeNull()
	{
		var sut = SutFactory();
		Assert.That(async () => 
				await sut.ExecuteNonQueryAsync((IEnumerable<SqlNonQueryCommand>) null),
			Throws.ArgumentNullException);
	}

	[Test]
	public void ExecuteNonQueryAsyncTokenCommandsCanNotBeNull()
	{
		var sut = SutFactory();
		Assert.That(async () =>
				await sut.ExecuteNonQueryAsync((IEnumerable<SqlNonQueryCommand>) null, CancellationToken.None),
			Throws.ArgumentNullException);
	}
	private static SqlCommandExecutor SutFactory()
	{
		return new SqlCommandExecutor(new TestDbProviderFactory(), "");
	}
}