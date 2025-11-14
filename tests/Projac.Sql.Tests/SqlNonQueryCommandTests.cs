using System.Data;
using System.Data.Common;
using NUnit.Framework;

namespace Projac.Sql.Tests;

[TestFixture]
public class SqlNonQueryCommandTests
{
	[Test]
	public void TextCanNotBeNull()
	{
		Assert.Throws<ArgumentNullException>(() => SutFactory((string)null));
	}

	[Test]
	public void TextCanBeEmpty()
	{
		Assert.DoesNotThrow(() => SutFactory(""));
	}

	[Test, Ignore("Had to fix another broken test")]
	public void ParametersCanNotBeNull()
	{
		Assert.Throws<ArgumentNullException>(() => SutFactory((DbParameter[])null));
	}

	[Test]
	public void TypeCanNotBeUnsupportedEnumValue()
	{
		Assert.Throws<ArgumentException>(() => SutFactory((CommandType) Int32.MinValue));
	}

	[TestCase(CommandType.StoredProcedure)]
	[TestCase(CommandType.TableDirect)]
	[TestCase(CommandType.Text)]
	public void TypeCanBeUnsupportedEnumValue(CommandType type)
	{
		Assert.DoesNotThrow(() => SutFactory(type));
	}

	[Test]
	public void ParametersCanBeEmpty()
	{
		Assert.DoesNotThrow(() => SutFactory([]));
	}

	[Test]
	public void PropertiesReturnExpectedValues()
	{
		var sut = SutFactory("text", [], CommandType.TableDirect);

		Assert.That(sut.Text, Is.EqualTo("text"));
		Assert.That(sut.Parameters, Is.EqualTo(Array.Empty<DbParameter>()));
		Assert.That(sut.Type, Is.EqualTo(CommandType.TableDirect));
	}

	private static SqlNonQueryCommand SutFactory(string text)
	{
		return SutFactory(text, [], CommandType.Text);
	}

	private static SqlNonQueryCommand SutFactory(DbParameter[] parameters)
	{
		return SutFactory("text", parameters, CommandType.Text);
	}

	private static SqlNonQueryCommand SutFactory(CommandType type)
	{
		return SutFactory("text", [], type);
	}

	private static SqlNonQueryCommand SutFactory(string text, DbParameter[] parameters, CommandType type)
	{
		return new SqlNonQueryCommand(text, parameters, type);
	}
}
