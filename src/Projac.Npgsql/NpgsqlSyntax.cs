using System.Data.Common;
using System.Reflection;
using Projac.Sql;

namespace Projac.Npgsql;

/// <summary>
///     Fluent T-SQL syntax.
/// </summary>
public partial class NpgsqlSyntax
{
	private static DbParameter[] CollectFromAnonymousType(object parameters)
	{
		if (parameters == null)
			return [];
		return ThrowIfMaxParameterCountExceeded(
			parameters.
				GetType().
				GetProperties(BindingFlags.Instance | BindingFlags.Public).
				Where(property => typeof(IDbParameterValue).IsAssignableFrom(property.PropertyType)).
				Select(property =>
					((IDbParameterValue)property.GetGetMethod().Invoke(parameters, null)).
					ToDbParameter(FormatDbParameterName(property.Name))).
				ToArray());
	}

	private static DbParameter[] ThrowIfMaxParameterCountExceeded(DbParameter[] parameters)
	{
		ArgumentOutOfRangeException.ThrowIfGreaterThan(parameters.Length, Limits.MaxParameterCount);
		return parameters;
	}

	// ReSharper disable UnusedParameter.Local
	private static void ThrowIfMaxParameterCountExceeded(IDbParameterValue[] parameters)
		// ReSharper restore UnusedParameter.Local
	{
		ArgumentOutOfRangeException.ThrowIfGreaterThan(parameters.Length, Limits.MaxParameterCount);
	}

	private static string FormatDbParameterName(string name)
	{
		return "@" + name;
	}
}
