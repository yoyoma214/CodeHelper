using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CodeHelper.DataBaseHelper;
using Project;
using CodeHelper.Core;
using System.Data.SqlClient;
using System.Data.Common;

namespace CodeHelper
{

    //public static class DbExtentions
    //{
    //    public static string ToOleDbConnection(this ConnectionType conn)
    //    {
    //        if ((DatabaseType)conn.DbType == DatabaseType.SqlServer)
    //        {
    //            var sqlConn = new SqlConnection(conn.ConnectionString);
    //            var oleConn = new OleDbConnection();
    //            return string.Format("Provider=SQLOLEDB;data source={0};initial catalog={3};userid={1};password={2};",
    //                sqlConn.DataSource,"sa","LinuxMan2.6",sqlConn.Database);

    //        }
    //        return null;
    //    }
    //}

    /// <summary>
    /// OleDbHelperCxx 的摘要说明。
    /// </summary>
    public sealed class DbHelper
    {
        private IDbConnection Connection = null;
        private IDbDataAdapter Adapter = null;

        public DbHelper(string conn)
        {
            Connection = new OleDbConnection(conn);
        }

        public DbHelper(ConnectionType conn)
        {
            if ((DatabaseType)conn.DbType == DatabaseType.SqlServer)
            {
                Connection = new SqlConnection(conn.ConnectionString);
                Adapter = new SqlDataAdapter();
                
            }
        }

        public DbHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private void Open()
        {
            if (this.Connection.State == ConnectionState.Closed)
                this.Connection.Open();
        }

        public void Close()
        {
            if (this.Connection.State == ConnectionState.Open)
                this.Connection.Close();
        }

        #region 实例方法
        /// <summary>
        /// 执行影响数据库的操作，并返回一个影响的行数
        /// </summary>
        /// <param name="ConnStr">连接数据字符串</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <returns>返回影响数据库的行数</returns>
        public int ExecuteNonQuery(string cmdText)
        {
            var cmd = this.Connection.CreateCommand();// new OleDbCommand(cmdText, this.Connection);
            cmd.CommandText = cmdText;
            this.Open();
            int i = cmd.ExecuteNonQuery();
            //conn.Close();
            return i;
        }


        /// <summary>
        /// 查询数据库记录并返回一个值
        /// </summary>
        /// <param name="ConnStr">连接数据字符串</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <returns>返回查询的结果</returns>
        public int ExecuteScalar(string cmdText)
        {
            //OleDbCommand cmd = new OleDbCommand(cmdText, this.Connection);
            var cmd = Connection.CreateCommand();
            cmd.CommandText = cmdText;
            this.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            //conn.Close();
            return i;
        }
        /// <summary>
        /// 查询数据库记录（使用OleDbDataReader读取器读取数据）
        /// </summary>
        /// <param name="ConnStr">连接数据字符串</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <returns>返回记录</returns>
        public IDataReader ExecuteDataRead(string cmdText)
        {

            //OleDbCommand cmd = new OleDbCommand(cmdText, this.Connection);
            var cmd = Connection.CreateCommand();
            cmd.CommandText = cmdText;
            this.Open();
            var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        /// <summary>
        /// 查询数据库记录（使用OleDbDataAdapter读取器读取数据）
        /// </summary>
        /// <param name="ConnStr">连接数据字符串</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <returns>返回记录</returns>
        public DataSet ExecuteDataSet(String cmdText)
        {
            //OleDbConnection conn = new OleDbConnection(ConnStr);
            //conn.Open();
            this.Open();
            DataSet ds = new DataSet();
             var cmd = Connection.CreateCommand();
            cmd.CommandText = cmdText;
            //OleDbDataAdapter da = new OleDbDataAdapter(cmdText, this.Connection);
            this.Adapter.SelectCommand = cmd;
            this.Adapter.Fill(ds);
            //conn.Close();
            return ds;
        }
        #endregion

        #region 静态方法
        /// <summary>
        /// 执行影响数据库的操作，并返回一个影响的行数
        /// </summary>
        /// <param name="ConnStr">连接数据字符串</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <returns>返回影响数据库的行数</returns>
        public static int ExecuteNonQuery(string ConnStr, string cmdText)
        {
            OleDbConnection conn = new OleDbConnection(ConnStr);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }


        /// <summary>
        /// 查询数据库记录并返回一个值
        /// </summary>
        /// <param name="ConnStr">连接数据字符串</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <returns>返回查询的结果</returns>
        public static int ExecuteScalar(string ConnStr, string cmdText)
        {
            OleDbConnection conn = new OleDbConnection(ConnStr);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);
            conn.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return i;
        }
        /// <summary>
        /// 查询数据库记录（使用OleDbDataReader读取器读取数据）
        /// </summary>
        /// <param name="ConnStr">连接数据字符串</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <returns>返回记录</returns>
        public static OleDbDataReader ExecuteDataRead(string ConnStr, string cmdText)
        {

            OleDbConnection conn = new OleDbConnection(ConnStr);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        /// <summary>
        /// 查询数据库记录（使用OleDbDataAdapter读取器读取数据）
        /// </summary>
        /// <param name="ConnStr">连接数据字符串</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <returns>返回记录</returns>
        public static DataSet ExecuteDataSet(string ConnStr, String cmdText)
        {
            OleDbConnection conn = new OleDbConnection(ConnStr);
            conn.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmdText, conn);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        #endregion
    }


}
