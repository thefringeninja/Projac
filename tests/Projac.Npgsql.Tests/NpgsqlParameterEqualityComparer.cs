using System.Collections.Generic;
using Npgsql;

namespace Projac.Npgsql.Tests
{
    internal class NpgsqlParameterEqualityComparer : IEqualityComparer<NpgsqlParameter>
    {
        public bool Equals(NpgsqlParameter x, NpgsqlParameter y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null)
            {
                return Equals(x.ParameterName, y.ParameterName) &&
                       Equals(x.Direction, y.Direction) &&
                       Equals(x.Value, y.Value) &&
                       Equals(x.IsNullable, y.IsNullable) &&
                       Equals(x.NpgsqlDbType, y.NpgsqlDbType) &&
                       Equals(x.Size, y.Size) &&
                       Equals(x.Precision, y.Precision) &&
                       Equals(x.Scale, y.Scale) &&
                       Equals(x.SourceColumn, y.SourceColumn) &&
                       Equals(x.SourceColumnNullMapping, y.SourceColumnNullMapping) &&
                       Equals(x.SourceVersion, y.SourceVersion);
            }
            return false;
        }

        public int GetHashCode(NpgsqlParameter obj)
        {
            if (obj == null)
                return 0;
            return obj.ParameterName.GetHashCode() ^
                   obj.Direction.GetHashCode() ^
                   (obj.Value == null ? 0 : obj.Value.GetHashCode()) ^
                   obj.IsNullable.GetHashCode() ^
                   obj.NpgsqlDbType.GetHashCode() ^
                   obj.Size.GetHashCode() ^
                   obj.Precision.GetHashCode() ^
                   obj.Scale.GetHashCode() ^
                   obj.SourceColumn.GetHashCode() ^
                   obj.SourceColumnNullMapping.GetHashCode() ^
                   obj.SourceVersion.GetHashCode();
        }
    }
}