using System.Data;
using System.Data.Common;

namespace Projac.Sql.Tests.Executors;

public class TestDbTransaction : DbTransaction
{
	private readonly TestDbConnection _connection;

	public TestDbTransaction(TestDbConnection connection)
	{
		ArgumentNullException.ThrowIfNull(connection);
		_connection = connection;
	}

	public override void Commit()
	{
	}

	public override void Rollback()
	{
	}

	protected override DbConnection DbConnection
	{
		get { return _connection; }
	}

	public override IsolationLevel IsolationLevel
	{
		get { return IsolationLevel.Unspecified; }
	}
}
