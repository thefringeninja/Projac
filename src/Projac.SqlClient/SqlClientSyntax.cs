using System.Data.Common;
using System.Reflection;
using Projac.Sql;

namespace Projac.SqlClient;

/// <summary>
///     Fluent T-SQL syntax.
/// </summary>
public partial class SqlClientSyntax
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
		if (parameters.Length > Limits.MaxParameterCount)
			throw new ArgumentException(
				$"The parameter count is limited to {Limits.MaxParameterCount}.",
				nameof(parameters));
		return parameters;
	}

	// ReSharper disable UnusedParameter.Local
	private static void ThrowIfMaxParameterCountExceeded(IDbParameterValue[] parameters)
		// ReSharper restore UnusedParameter.Local
	{
		if (parameters.Length > Limits.MaxParameterCount)
			throw new ArgumentException(
				$"The parameter count is limited to {Limits.MaxParameterCount}.",
				nameof(parameters));
	}

	private static string FormatDbParameterName(string name)
	{
		return "@" + name;
	}
}
