using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator.DbSchema.DbSchemaProvider
{
    public interface IDbSchemaProvider
    {
        //string ConnectionString {get; }
        string Description { get; }
        string Name { get; }
        string GetDatabaseName(string connectionString);
        ColumnSchema[] GetTableColumns(string connectionString, TableSchema table);
        TableSchema[] GetTables(string connectionString, DatabaseSchema database);
        TableSchema GetTable(string connectionString, string name);

    }
}
