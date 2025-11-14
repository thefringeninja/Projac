using System.Data;
using System.Data.Common;
using Npgsql;
using NpgsqlTypes;
using NUnit.Framework;

namespace Projac.Npgsql.Tests
{
    internal static class NpgsqlParameterAssertions
    {
        public static void ExpectNpgsqlParameter(this DbParameter parameter, 
            string name, 
            NpgsqlDbType sqlDbType,
            object value,
            bool nullable = false, 
            int size = 0,
            int precision = 0, 
            int scale = 0)
        {
            Assert.That(parameter, Is.Not.Null);
            Assert.That(parameter, Is.InstanceOf<NpgsqlParameter>());
            
            ((NpgsqlParameter)parameter).ExpectNpgsqlParameter(name, sqlDbType, value, nullable, size, precision, scale);
        }

        public static void ExpectNpgsqlParameter(this NpgsqlParameter parameter,
            string name,
            NpgsqlDbType sqlDbType,
            object value,
            bool nullable = false,
            int size = 0,
            int precision = 0,
            int scale = 0)
        {
            Assert.That(parameter, Is.Not.Null);

            Assert.That(parameter.ParameterName, Is.EqualTo(name));
            Assert.That(parameter.Direction, Is.EqualTo(ParameterDirection.Input));
            Assert.That(parameter.SourceColumn, Is.EqualTo(""));
            Assert.That(parameter.SourceColumnNullMapping, Is.False);
            Assert.That(parameter.SourceVersion, Is.EqualTo(DataRowVersion.Default));
            Assert.That(parameter.Value, Is.EqualTo(value));
            Assert.That(parameter.Size, Is.EqualTo(size));
            Assert.That(parameter.IsNullable, Is.EqualTo(nullable));
            Assert.That(parameter.NpgsqlDbType, Is.EqualTo(sqlDbType));
            Assert.That(parameter.Precision, Is.EqualTo(precision));
            Assert.That(parameter.Scale, Is.EqualTo(scale));
        }
    }
}