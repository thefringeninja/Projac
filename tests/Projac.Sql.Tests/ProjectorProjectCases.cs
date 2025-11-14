using System.Data;
using NUnit.Framework;
using Projac.Sql.Tests.Framework;

namespace Projac.Sql.Tests;

public class ProjectorProjectCases
{
	public static IEnumerable<TestCaseData> ProjectMessageCases()
	{
		//Match
		var commands1 = new[] { CommandFactory(), CommandFactory() };
		var handler1 = new SqlProjectionHandler(typeof(object), _ => commands1);
		var resolver1 = new SqlProjectionHandlerResolver(message => [handler1]);
		yield return new TestCaseData(
			resolver1,
			new object(),
			commands1);
		//Mismatch
		var resolver2 = new SqlProjectionHandlerResolver(message => []);
		yield return new TestCaseData(
			resolver2,
			new object(), Array.Empty<SqlNonQueryCommand>());
		//Multimatch
		var commands3 = new[] { CommandFactory(), CommandFactory() };
		var commands4 = new[] { CommandFactory(), CommandFactory() };
		var handler3 = new SqlProjectionHandler(typeof(object), _ => commands3);
		var handler4 = new SqlProjectionHandler(typeof(object), _ => commands4);
		var resolver3 = new SqlProjectionHandlerResolver(message => [handler3, handler4]);
		yield return new TestCaseData(
			resolver3,
			new object(),
			commands3.Concat(commands4).ToArray());
	}

	public static IEnumerable<TestCaseData> ProjectMessagesCases()
	{
		//Partial match
		var commands1 = new[] { CommandFactory(), CommandFactory() };
		var handler1 = new SqlProjectionHandler(typeof(string), _ => commands1);
		var resolver1 = Resolve.WhenEqualToHandlerMessageType([handler1]);
		yield return new TestCaseData(
			resolver1,
			new object[] { "123", 123 },
			commands1);
		//Mismatch
		var resolver2 = Resolve.WhenEqualToHandlerMessageType([]);
		yield return new TestCaseData(
			resolver2,
			new object[] { new(), 123 }, Array.Empty<SqlNonQueryCommand>());
		//Multimatch
		var commands3 = new[] { CommandFactory(), CommandFactory() };
		var commands4 = new[] { CommandFactory(), CommandFactory() };
		var handler3 = new SqlProjectionHandler(typeof(object), _ => commands3);
		var handler4 = new SqlProjectionHandler(typeof(object), _ => commands4);
		var resolver3 = Resolve.WhenEqualToHandlerMessageType([handler3, handler4]);
		yield return new TestCaseData(
			resolver3,
			new object[] { new(), new() },
			commands3.Concat(commands4).Concat(commands3).Concat(commands4).ToArray());
		//Multitype Match
		var commands5 = new[] { CommandFactory(), CommandFactory() };
		var commands6 = new[] { CommandFactory(), CommandFactory() };
		var handler5 = new SqlProjectionHandler(typeof(string), _ => commands5);
		var handler6 = new SqlProjectionHandler(typeof(int), _ => commands6);
		var resolver4 = Resolve.WhenEqualToHandlerMessageType([handler5, handler6]);
		yield return new TestCaseData(
			resolver4,
			new object[] { "123", 123 },
			commands5.Concat(commands6).ToArray());
		//Match
		var commands7 = new[] { CommandFactory(), CommandFactory() };
		var commands8 = new[] { CommandFactory(), CommandFactory() };
		var handler7 = new SqlProjectionHandler(typeof(object), _ => commands7);
		var handler8 = new SqlProjectionHandler(typeof(object), _ => commands8);
		var resolver5 = Resolve.WhenEqualToHandlerMessageType([handler7, handler8]);
		yield return new TestCaseData(
			resolver5,
			new object[] { new() },
			commands7.Concat(commands8).ToArray());
	}

	private static SqlNonQueryCommand CommandFactory()
	{
		return new SqlNonQueryCommandStub("text", [], CommandType.Text);
	}
}