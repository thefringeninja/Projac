using Projac.Sql.Executors;

namespace Projac.Sql;

/// <summary> 
/// Projects a single message or a set of messages in a synchronous manner to the matching handlers.
/// </summary>
public class SqlProjector
{
	private readonly SqlProjectionHandlerResolver _resolver;
	private readonly ISqlNonQueryCommandExecutor _executor;

	/// <summary>
	/// Initializes a new instance of the <see cref="SqlProjector"/> class.
	/// </summary>
	/// <param name="resolver">The handler resolver.</param>
	/// <param name="executor">The command executor.</param>
	/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="resolver"/> or <paramref name="executor"/> is <c>null</c>.</exception>
	public SqlProjector(SqlProjectionHandlerResolver resolver, ISqlNonQueryCommandExecutor executor)
	{
		ArgumentNullException.ThrowIfNull(resolver);
		ArgumentNullException.ThrowIfNull(executor);

		_resolver = resolver;
		_executor = executor;
	}

	/// <summary>
	/// Projects the specified message.
	/// </summary>
	/// <param name="message">The message to project.</param>
	/// <returns>The number of <see cref="SqlNonQueryCommand">commands</see> executed.</returns>
	/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is <c>null</c>.</exception>
	public int Project(object message)
	{
		ArgumentNullException.ThrowIfNull(message);

		return _executor.
			ExecuteNonQuery(
				from handler in _resolver(message)
				from statement in handler.Handler(message)
				select statement);
	}

	/// <summary>
	/// Projects the specified messages.
	/// </summary>
	/// <param name="messages">The messages to project.</param>
	/// <returns>The number of <see cref="SqlNonQueryCommand">commands</see> executed.</returns>
	/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="messages"/> are <c>null</c>.</exception>
	public int Project(IEnumerable<object> messages)
	{
		ArgumentNullException.ThrowIfNull(messages);

		return _executor.
			ExecuteNonQuery(
				from message in messages
				from handler in _resolver(message)
				from statement in handler.Handler(message)
				select statement);
	}
}
