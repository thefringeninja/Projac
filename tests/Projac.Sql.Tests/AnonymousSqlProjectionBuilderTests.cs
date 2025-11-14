using System.Data;
using NUnit.Framework;
using Projac.Sql.Tests.Framework;

namespace Projac.Sql.Tests;

[TestFixture]
public class AnonymousSqlProjectionBuilderTests
{
	private AnonymousSqlProjectionBuilder _sut;

	[SetUp]
	public void SetUp()
	{
		_sut = new AnonymousSqlProjectionBuilder();
	}

	[Test]
	public void HandlersCanNotBeNull()
	{
		Assert.Throws<ArgumentNullException>(() => new AnonymousSqlProjectionBuilder(null));
	}

	[Test]
	public void HandlersAreCopiedOnConstruction()
	{
		var handler1 = new SqlProjectionHandler(typeof(object), o => []);
		var handler2 = new SqlProjectionHandler(typeof(object), o => []);
		var sut = new AnonymousSqlProjectionBuilder([
			handler1, 
			handler2
		]);

		var result = sut.Build();

		Assert.That(result, Is.EquivalentTo([
			handler1, handler2
		]));

	}

	[Test]
	public void EmptyInstanceBuildReturnsExpectedResult()
	{
		var result = new AnonymousSqlProjectionBuilder().Build();

		Assert.That(result, Is.Empty);
	}

	[Test]
	public void InitialInstanceBuildReturnsExpectedResult()
	{
		var result = _sut.Build();

		Assert.That(result, Is.Empty);
	}

	[Test]
	public void WhenHandlerWithSingleCommandCanNotBeNull()
	{
		Assert.Throws<ArgumentNullException>(() => _sut.When((Func<object, SqlNonQueryCommand>)null));
	}


	[Test]
	public void WhenHandlerWithSingleCommandReturnsExpectedResult()
	{
		var result = _sut.When((object _) => CommandFactory());

		Assert.That(result, Is.InstanceOf<AnonymousSqlProjectionBuilder>());
	}

	[Test]
	public void WhenHandlerWithSingleCommandIsPreservedUponBuild()
	{
		var command = CommandFactory();
		Func<object, SqlNonQueryCommand> handler = _ => command;
		var result = _sut.When(handler).Build();

		Assert.That(
			result.Count(_ => _.Message == typeof(object) && _.Handler(null).SequenceEqual([command])),
			Is.EqualTo(1));
	}

	[Test]
	public void WhenHandlerWithSingleStatementPreservesPreviouslyCollectedStatementsUponBuild()
	{
		var commands = new[]
		{
			CommandFactory(),
			CommandFactory()
		};
		var command = CommandFactory();
		Func<object, SqlNonQueryCommand> handler = _ => command;
		var result = _sut.When((object _) => commands).When(handler).Build();

		Assert.That(
			result.Count(_ => _.Message == typeof(object) && _.Handler(null).SequenceEqual(commands)),
			Is.EqualTo(1));
	}

	[Test]
	public void WhenHandlerWithCommandArrayCanNotBeNull()
	{
		Assert.Throws<ArgumentNullException>(() => _sut.When((Func<object, SqlNonQueryCommand[]>)null));
	}

	[Test]
	public void WhenHandlerWithCommandArrayReturnsExpectedResult()
	{
		var result = _sut.When((object _) => [CommandFactory(), CommandFactory()]);

		Assert.That(result, Is.InstanceOf<AnonymousSqlProjectionBuilder>());
	}

	[Test]
	public void WhenHandlerWithStatementArrayIsPreservedUponBuild()
	{
		var command1 = CommandFactory();
		var command2 = CommandFactory();
		Func<object, SqlNonQueryCommand[]> handler = _ => [command1, command2];
		var result = _sut.When(handler).Build();

		Assert.That(
			result.Count(_ => _.Message == typeof(object) && _.Handler(null).SequenceEqual([command1, command2])),
			Is.EqualTo(1));
	}

	[Test]
	public void WhenHandlerWithStatementArrayPreservesPreviouslyCollectedStatementsUponBuild()
	{
		var commands = new[]
		{
			CommandFactory(),
			CommandFactory()
		};
		var command1 = CommandFactory();
		var command2 = CommandFactory();
		Func<object, SqlNonQueryCommand[]> handler = _ => [command1, command2];
		var result = _sut.When((object _) => commands).When(handler).Build();

		Assert.That(
			result.Count(_ => _.Message == typeof(object) && _.Handler(null).SequenceEqual(commands)),
			Is.EqualTo(1));
	}

	[Test]
	public void WhenHandlerWithCommandEnumerationCanNotBeNull()
	{
		Assert.Throws<ArgumentNullException>(() => _sut.When((Func<object, IEnumerable<SqlNonQueryCommand>>)null));
	}

	[Test]
	public void WhenHandlerWithCommandEnumerationReturnsExpectedResult()
	{
		var result = _sut.When((object _) => (IEnumerable<SqlNonQueryCommand>) [
			CommandFactory(), CommandFactory()
		]);

		Assert.That(result, Is.InstanceOf<AnonymousSqlProjectionBuilder>());
	}

	[Test]
	public void WhenHandlerWithStatementEnumerationIsPreservedUponBuild()
	{
		var command1 = CommandFactory();
		var command2 = CommandFactory();
		Func<object, IEnumerable<SqlNonQueryCommand>> handler = _ => (IEnumerable<SqlNonQueryCommand>) [
			command1, command2
		];
		var result = _sut.When(handler).Build();

		Assert.That(
			result.Count(_ => _.Message == typeof(object) && _.Handler(null).SequenceEqual([command1, command2])),
			Is.EqualTo(1));
	}

	[Test]
	public void WhenHandlerWithCommandEnumerationPreservesPreviouslyCollectedStatementsUponBuild()
	{
		var commands = new[]
		{
			CommandFactory(),
			CommandFactory()
		};
		var command1 = CommandFactory();
		var command2 = CommandFactory();
		Func<object, IEnumerable<SqlNonQueryCommand>> handler = _ => (IEnumerable<SqlNonQueryCommand>) [
			command1, command2
		];
		var result = _sut.When((object _) => commands).When(handler).Build();

		Assert.That(
			result.Count(_ => _.Message == typeof(object) && _.Handler(null).SequenceEqual(commands)),
			Is.EqualTo(1));
	}

	private static SqlNonQueryCommand CommandFactory()
	{
		return new SqlNonQueryCommandStub("text", [], CommandType.Text);
	}
}
