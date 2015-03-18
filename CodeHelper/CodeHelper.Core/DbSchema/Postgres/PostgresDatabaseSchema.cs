using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.ApplicationBlocks.Data;
using Npgsql;
using System.Data;

namespace CodeHelper.DataBaseHelper.DbSchema.Postgres
{
    public class PostgresDatabaseSchema : DatabaseSchema
    {
        public override bool TestConnect()
        {
            try
            {                
                var conn = new NpgsqlConnection(this.ConnectionString);
                var comm = new NpgsqlCommand();
                comm.Connection = conn;
                conn.Open();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select 1";
                var sda = new NpgsqlDataAdapter(comm);
                var ds = new DataSet();
                sda.Fill(ds);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
