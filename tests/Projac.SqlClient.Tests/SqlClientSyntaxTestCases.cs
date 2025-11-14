using System.Data;
using NUnit.Framework;
using Projac.SqlClient;

namespace Projac.Sql.Tests.SqlClient;

public class SqlClientSyntaxTestCases
{
	private static readonly SqlClientSyntax Sql = new();

	public static IEnumerable<TestCaseData> QueryProcedureCases()
	{

		yield return new TestCaseData(
			Sql.QueryProcedure("text"),
			new SqlQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedure("text", parameters: null),
			new SqlQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedure("text", new { }),
			new SqlQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedure("text", new { Parameter = new SqlParameterValueStub() }),
			new SqlQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@Parameter")
			], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedure("text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new SqlQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@Parameter1"),
				new SqlParameterValueStub().ToDbParameter("@Parameter2")
			], CommandType.StoredProcedure));
	}

	public static IEnumerable<TestCaseData> QueryProcedureIfCases()
	{
		yield return new TestCaseData(
			Sql.QueryProcedureIf(true, "text"),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureIf(true, "text", parameters: null),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureIf(true, "text", new { }),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureIf(true, "text", new { Parameter = new SqlParameterValueStub() }),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.QueryProcedureIf(true, "text",
				new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter1"),
					new SqlParameterValueStub().ToDbParameter("@Parameter2")
				], CommandType.StoredProcedure)
			});

		yield return new TestCaseData(
			Sql.QueryProcedureIf(false, "text"), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureIf(false, "text", parameters: null), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureIf(false, "text", new { }), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureIf(false, "text", new { Parameter = new SqlParameterValueStub() }), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureIf(false, "text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }), Array.Empty<SqlQueryCommand>());
	}

	public static IEnumerable<TestCaseData> QueryProcedureUnlessCases()
	{
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(false, "text"),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(false, "text", parameters: null),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(false, "text", new { }),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(false, "text", new { Parameter = new SqlParameterValueStub() }),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(false, "text",
				new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter1"),
					new SqlParameterValueStub().ToDbParameter("@Parameter2")
				], CommandType.StoredProcedure)
			});

		yield return new TestCaseData(
			Sql.QueryProcedureUnless(true, "text"), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(true, "text", parameters: null), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(true, "text", new { }), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(true, "text", new { Parameter = new SqlParameterValueStub() }), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureUnless(true, "text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }), Array.Empty<SqlQueryCommand>());
	}

	public static IEnumerable<TestCaseData> QueryProcedureFormatCases()
	{
		yield return new TestCaseData(
			Sql.QueryProcedureFormat("text"),
			new SqlQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedureFormat("text", parameters: null),
			new SqlQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedureFormat("text", new IDbParameterValue[0]),
			new SqlQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedureFormat("text", new SqlParameterValueStub()),
			new SqlQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@P0")
			], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedureFormat("text {0}", new SqlParameterValueStub()),
			new SqlQueryCommand("text @P0", [
				new SqlParameterValueStub().ToDbParameter("@P0")
			], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedureFormat("text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new SqlQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@P0"),
				new SqlParameterValueStub().ToDbParameter("@P1")
			], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.QueryProcedureFormat("text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new SqlQueryCommand("text @P0 @P1", [
				new SqlParameterValueStub().ToDbParameter("@P0"),
				new SqlParameterValueStub().ToDbParameter("@P1")
			], CommandType.StoredProcedure));
	}

	public static IEnumerable<TestCaseData> QueryProcedureFormatIfCases()
	{
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(true, "text"),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(true, "text", parameters: null),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(true, "text", new IDbParameterValue[0]),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(true, "text", new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(true, "text {0}", new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text @P0", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(true, "text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(true, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text @P0 @P1", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.StoredProcedure)
			});

		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(false, "text"), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(false, "text", parameters: null), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(false, "text", new IDbParameterValue[0]), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(false, "text", new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(false, "text {0}", new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(false, "text", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatIf(false, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
	}

	public static IEnumerable<TestCaseData> QueryProcedureFormatUnlessCases()
	{
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(false, "text"),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(false, "text", parameters: null),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(false, "text", new IDbParameterValue[0]),
			new[] { new SqlQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(false, "text", new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(false, "text {0}", new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text @P0", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(false, "text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(false, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text @P0 @P1", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.StoredProcedure)
			});

		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(true, "text"), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(true, "text", parameters: null), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(true, "text", new IDbParameterValue[0]), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(true, "text", new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(true, "text {0}", new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(true, "text", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryProcedureFormatUnless(true, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
	}

	public static IEnumerable<TestCaseData> NonQueryProcedureCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryProcedure("text"),
			new SqlNonQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedure("text", parameters: null),
			new SqlNonQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedure("text", new { }),
			new SqlNonQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedure("text", new { Parameter = new SqlParameterValueStub() }),
			new SqlNonQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@Parameter")
			], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedure("text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new SqlNonQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@Parameter1"),
				new SqlParameterValueStub().ToDbParameter("@Parameter2")
			], CommandType.StoredProcedure));
	}

	public static IEnumerable<TestCaseData> NonQueryProcedureIfCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(true, "text"),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(true, "text", parameters: null),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(true, "text", new { }),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(true, "text", new { Parameter = new SqlParameterValueStub() }),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(true, "text",
				new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter1"),
					new SqlParameterValueStub().ToDbParameter("@Parameter2")
				], CommandType.StoredProcedure)
			});

		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(false, "text"), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(false, "text", parameters: null), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(false, "text", new { }), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(false, "text", new { Parameter = new SqlParameterValueStub() }), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureIf(false, "text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }), Array.Empty<SqlNonQueryCommand>());
	}

	public static IEnumerable<TestCaseData> NonQueryProcedureUnlessCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(false, "text"),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(false, "text", parameters: null),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(false, "text", new { }),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(false, "text", new { Parameter = new SqlParameterValueStub() }),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(false, "text",
				new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter1"),
					new SqlParameterValueStub().ToDbParameter("@Parameter2")
				], CommandType.StoredProcedure)
			});

		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(true, "text"), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(true, "text", parameters: null), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(true, "text", new { }), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(true, "text", new { Parameter = new SqlParameterValueStub() }), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureUnless(true, "text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }), Array.Empty<SqlNonQueryCommand>());
	}

	public static IEnumerable<TestCaseData> NonQueryProcedureFormatCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormat("text"),
			new SqlNonQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormat("text", parameters: null),
			new SqlNonQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormat("text", new IDbParameterValue[0]),
			new SqlNonQueryCommand("text", [], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormat("text", new SqlParameterValueStub()),
			new SqlNonQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@P0")
			], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormat("text {0}", new SqlParameterValueStub()),
			new SqlNonQueryCommand("text @P0", [
				new SqlParameterValueStub().ToDbParameter("@P0")
			], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormat("text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new SqlNonQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@P0"),
				new SqlParameterValueStub().ToDbParameter("@P1")
			], CommandType.StoredProcedure));
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormat("text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new SqlNonQueryCommand("text @P0 @P1", [
				new SqlParameterValueStub().ToDbParameter("@P0"),
				new SqlParameterValueStub().ToDbParameter("@P1")
			], CommandType.StoredProcedure));
	}

	public static IEnumerable<TestCaseData> NonQueryProcedureFormatIfCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(true, "text"),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(true, "text", parameters: null),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(true, "text", new IDbParameterValue[0]),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(true, "text", new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(true, "text {0}", new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text @P0", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(true, "text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(true, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text @P0 @P1", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.StoredProcedure)
			});

		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(false, "text"), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(false, "text", parameters: null), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(false, "text", new IDbParameterValue[0]), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(false, "text", new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(false, "text {0}", new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(false, "text", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatIf(false, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
	}

	public static IEnumerable<TestCaseData> NonQueryProcedureFormatUnlessCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(false, "text"),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(false, "text", parameters: null),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(false, "text", new IDbParameterValue[0]),
			new[] { new SqlNonQueryCommand("text", [], CommandType.StoredProcedure) });
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(false, "text", new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(false, "text {0}", new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text @P0", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(false, "text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.StoredProcedure)
			});
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(false, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text @P0 @P1", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.StoredProcedure)
			});

		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(true, "text"), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(true, "text", parameters: null), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(true, "text", new IDbParameterValue[0]), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(true, "text", new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(true, "text {0}", new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(true, "text", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryProcedureFormatUnless(true, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
	}

	public static IEnumerable<TestCaseData> NonQueryStatementCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryStatement("text"),
			new SqlNonQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatement("text", parameters: null),
			new SqlNonQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatement("text", new { }),
			new SqlNonQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatement("text", new { Parameter = new SqlParameterValueStub() }),
			new SqlNonQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@Parameter")
			], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatement("text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new SqlNonQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@Parameter1"),
				new SqlParameterValueStub().ToDbParameter("@Parameter2")
			], CommandType.Text));
	}

	public static IEnumerable<TestCaseData> NonQueryStatementIfCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(true, "text"),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(true, "text", parameters: null),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(true, "text", new { }),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(true, "text", new { Parameter = new SqlParameterValueStub() }),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(true, "text",
				new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter1"),
					new SqlParameterValueStub().ToDbParameter("@Parameter2")
				], CommandType.Text)
			});

		yield return new TestCaseData(
			Sql.NonQueryStatementIf(false, "text"), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(false, "text", parameters: null), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(false, "text", new { }), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(false, "text", new { Parameter = new SqlParameterValueStub() }), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementIf(false, "text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }), Array.Empty<SqlNonQueryCommand>());
	}

	public static IEnumerable<TestCaseData> NonQueryStatementUnlessCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(false, "text"),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(false, "text", parameters: null),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(false, "text", new { }),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(false, "text", new { Parameter = new SqlParameterValueStub() }),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(false, "text",
				new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter1"),
					new SqlParameterValueStub().ToDbParameter("@Parameter2")
				], CommandType.Text)
			});

		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(true, "text"), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(true, "text", parameters: null), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(true, "text", new { }), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(true, "text", new { Parameter = new SqlParameterValueStub() }), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementUnless(true, "text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }), Array.Empty<SqlNonQueryCommand>());
	}

	public static IEnumerable<TestCaseData> NonQueryStatementFormatCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryStatementFormat("text"),
			new SqlNonQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatementFormat("text", parameters: null),
			new SqlNonQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatementFormat("text", new IDbParameterValue[0]),
			new SqlNonQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatementFormat("text", new SqlParameterValueStub()),
			new SqlNonQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@P0")
			], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatementFormat("text {0}", new SqlParameterValueStub()),
			new SqlNonQueryCommand("text @P0", [
				new SqlParameterValueStub().ToDbParameter("@P0")
			], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatementFormat("text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new SqlNonQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@P0"),
				new SqlParameterValueStub().ToDbParameter("@P1")
			], CommandType.Text));
		yield return new TestCaseData(
			Sql.NonQueryStatementFormat("text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new SqlNonQueryCommand("text @P0 @P1", [
				new SqlParameterValueStub().ToDbParameter("@P0"),
				new SqlParameterValueStub().ToDbParameter("@P1")
			], CommandType.Text));
	}

	public static IEnumerable<TestCaseData> NonQueryStatementFormatIfCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(true, "text"),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(true, "text", parameters: null),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(true, "text", new IDbParameterValue[0]),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(true, "text", new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(true, "text {0}", new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text @P0", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(true, "text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(true, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text @P0 @P1", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.Text)
			});

		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(false, "text"), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(false, "text", parameters: null), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(false, "text", new IDbParameterValue[0]), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(false, "text", new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(false, "text {0}", new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(false, "text", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatIf(false, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
	}

	public static IEnumerable<TestCaseData> NonQueryStatementFormatUnlessCases()
	{
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(false, "text"),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(false, "text", parameters: null),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(false, "text", new IDbParameterValue[0]),
			new[] { new SqlNonQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(false, "text", new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(false, "text {0}", new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text @P0", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(false, "text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(false, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlNonQueryCommand("text @P0 @P1", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.Text)
			});

		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(true, "text"), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(true, "text", parameters: null), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(true, "text", new IDbParameterValue[0]), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(true, "text", new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(true, "text {0}", new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(true, "text", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
		yield return new TestCaseData(
			Sql.NonQueryStatementFormatUnless(true, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlNonQueryCommand>());
	}

	public static IEnumerable<TestCaseData> QueryStatementCases()
	{
		yield return new TestCaseData(
			Sql.QueryStatement("text"),
			new SqlQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatement("text", parameters: null),
			new SqlQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatement("text", new { }),
			new SqlQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatement("text", new { Parameter = new SqlParameterValueStub() }),
			new SqlQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@Parameter")
			], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatement("text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new SqlQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@Parameter1"),
				new SqlParameterValueStub().ToDbParameter("@Parameter2")
			], CommandType.Text));
	}

	public static IEnumerable<TestCaseData> QueryStatementIfCases()
	{
		yield return new TestCaseData(
			Sql.QueryStatementIf(true, "text"),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementIf(true, "text", parameters: null),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementIf(true, "text", new { }),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementIf(true, "text", new { Parameter = new SqlParameterValueStub() }),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.QueryStatementIf(true, "text",
				new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter1"),
					new SqlParameterValueStub().ToDbParameter("@Parameter2")
				], CommandType.Text)
			});

		yield return new TestCaseData(
			Sql.QueryStatementIf(false, "text"), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementIf(false, "text", parameters: null), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementIf(false, "text", new { }), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementIf(false, "text", new { Parameter = new SqlParameterValueStub() }), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementIf(false, "text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }), Array.Empty<SqlQueryCommand>());
	}

	public static IEnumerable<TestCaseData> QueryStatementUnlessCases()
	{
		yield return new TestCaseData(
			Sql.QueryStatementUnless(false, "text"),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementUnless(false, "text", parameters: null),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementUnless(false, "text", new { }),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementUnless(false, "text", new { Parameter = new SqlParameterValueStub() }),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.QueryStatementUnless(false, "text",
				new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@Parameter1"),
					new SqlParameterValueStub().ToDbParameter("@Parameter2")
				], CommandType.Text)
			});

		yield return new TestCaseData(
			Sql.QueryStatementUnless(true, "text"), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementUnless(true, "text", parameters: null), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementUnless(true, "text", new { }), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementUnless(true, "text", new { Parameter = new SqlParameterValueStub() }), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementUnless(true, "text", new { Parameter1 = new SqlParameterValueStub(), Parameter2 = new SqlParameterValueStub() }), Array.Empty<SqlQueryCommand>());
	}

	public static IEnumerable<TestCaseData> QueryStatementFormatCases()
	{
		yield return new TestCaseData(
			Sql.QueryStatementFormat("text"),
			new SqlQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatementFormat("text", parameters: null),
			new SqlQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatementFormat("text", new IDbParameterValue[0]),
			new SqlQueryCommand("text", [], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatementFormat("text", new SqlParameterValueStub()),
			new SqlQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@P0")
			], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatementFormat("text {0}", new SqlParameterValueStub()),
			new SqlQueryCommand("text @P0", [
				new SqlParameterValueStub().ToDbParameter("@P0")
			], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatementFormat("text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new SqlQueryCommand("text", [
				new SqlParameterValueStub().ToDbParameter("@P0"),
				new SqlParameterValueStub().ToDbParameter("@P1")
			], CommandType.Text));
		yield return new TestCaseData(
			Sql.QueryStatementFormat("text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new SqlQueryCommand("text @P0 @P1", [
				new SqlParameterValueStub().ToDbParameter("@P0"),
				new SqlParameterValueStub().ToDbParameter("@P1")
			], CommandType.Text));
	}

	public static IEnumerable<TestCaseData> QueryStatementFormatIfCases()
	{
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(true, "text"),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(true, "text", parameters: null),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(true, "text", new IDbParameterValue[0]),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(true, "text", new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(true, "text {0}", new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text @P0", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(true, "text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(true, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text @P0 @P1", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.Text)
			});

		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(false, "text"), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(false, "text", parameters: null), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(false, "text", new IDbParameterValue[0]), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(false, "text", new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(false, "text {0}", new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(false, "text", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatIf(false, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
	}

	public static IEnumerable<TestCaseData> QueryStatementFormatUnlessCases()
	{
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(false, "text"),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(false, "text", parameters: null),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(false, "text", new IDbParameterValue[0]),
			new[] { new SqlQueryCommand("text", [], CommandType.Text) });
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(false, "text", new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(false, "text {0}", new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text @P0", [
					new SqlParameterValueStub().ToDbParameter("@P0")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(false, "text", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.Text)
			});
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(false, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()),
			new[]
			{
				new SqlQueryCommand("text @P0 @P1", [
					new SqlParameterValueStub().ToDbParameter("@P0"),
					new SqlParameterValueStub().ToDbParameter("@P1")
				], CommandType.Text)
			});

		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(true, "text"), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(true, "text", parameters: null), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(true, "text", new IDbParameterValue[0]), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(true, "text", new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(true, "text {0}", new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(true, "text", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
		yield return new TestCaseData(
			Sql.QueryStatementFormatUnless(true, "text {0} {1}", new SqlParameterValueStub(), new SqlParameterValueStub()), Array.Empty<SqlQueryCommand>());
	}
}