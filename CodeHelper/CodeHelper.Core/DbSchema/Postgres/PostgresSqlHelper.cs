using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;

namespace CodeHelper.DataBaseHelper.DbSchema.Postgres
{
    public static class PostgresSqlHelper
    {
        public static DataSet ExecuteDataset(string conncetionString,CommandType commandType, string sql)
        {
            using (var conn = new NpgsqlConnection(conncetionString))
            {
                var comm = new NpgsqlCommand();
                comm.Connection = conn;
                conn.Open();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sql;
                var sda = new NpgsqlDataAdapter(comm);
                var ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
        }
        public static DataSet ExecuteDataset(NpgsqlConnection conn, CommandType commandType, string sql)
        {
            var comm = new NpgsqlCommand();
            comm.Connection = conn;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            comm.CommandType = CommandType.Text;
            comm.CommandText = sql;
            var sda = new NpgsqlDataAdapter(comm);
            var ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}
