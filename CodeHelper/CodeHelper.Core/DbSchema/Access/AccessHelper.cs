using System;   
using System.Text;   
using System.Collections;   
using System.Collections.Specialized;   
using System.Data;   
using System.Data.OleDb;   
using System.Configuration;

namespace Util
{    /// <summary>   
    /// 数据访问抽象基础类(ACCESS)   
    /// Copyright (C) 2006-2007 NMJU.NET   
    /// All rights reserved   
    /// </summary>   
    public abstract class AccessHelper
    {
        //数据库连接字符串(web.config来配置)   
        //public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];   
        // public static string connectionString = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["AccessConnectionString"]);   
        //public static string connectionString = ConfigurationManager.AppSettings["AccessConnectionString"];
        public AccessHelper()
        {
        }

        #region 公用方法

        //public static int GetMaxID(string FieldName, string TableName)
        //{
        //    string strsql = "select max(" + FieldName + ")+1 from " + TableName;
        //    object obj = AccessHelper.GetSingle(strsql);
        //    if (obj == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return int.Parse(obj.ToString());
        //    }
        //}
        public static bool Exists(string connectionString, string strSql)
        {
            object obj = AccessHelper.GetSingle(connectionString, strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Exists(string connectionString, string strSql, params OleDbParameter[] cmdParms)
        {
            object obj = AccessHelper.GetSingle(connectionString, strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  执行简单SQL语句

        /// <summary>   
        /// 执行SQL语句，返回影响的记录数   
        /// </summary>   
        /// <param name="SQLString">SQL语句</param>   
        /// <returns>影响的记录数</returns>   
        public static int ExecuteSql(string connectionString, string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>   
        /// 执行SQL语句，设置命令的执行等待时间   
        /// </summary>   
        /// <param name="SQLString"></param>   
        /// <param name="Times"></param>   
        /// <returns></returns>   
        public static int ExecuteSqlByTime(string connectionString, string SQLString, int Times)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>   
        /// 执行多条SQL语句，实现数据库事务。   
        /// </summary>   
        /// <param name="SQLStringList">多条SQL语句</param>        
        public static void ExecuteSqlTran(string connectionString, ArrayList SQLStringList)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                OleDbTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.OleDb.OleDbException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>   
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)   
        /// </summary>   
        /// <param name="strSQL">SQL语句</param>   
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>   
        /// <returns>影响的记录数</returns>   
        public static int ExecuteSqlInsertImg(string connectionString, string strSQL, byte[] fs)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(strSQL, connection);
                System.Data.OleDb.OleDbParameter myParameter = new System.Data.OleDb.OleDbParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.OleDb.OleDbException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>   
        /// 执行一条计算查询结果语句，返回查询结果（object）。   
        /// </summary>   
        /// <param name="SQLString">计算查询结果语句</param>   
        /// <returns>查询结果（object）</returns>   
        public static object GetSingle(string connectionString,string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }


        /// <summary>   
        /// 执行查询语句，返回SqlDataReader(使用该方法切记要手工关闭SqlDataReader和连接)   
        /// </summary>   
        /// <param name="strSQL">查询语句</param>   
        /// <returns>SqlDataReader</returns>   
        public static OleDbDataReader ExecuteReader(string connectionString, string strSQL)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(strSQL, connection);
            try
            {
                connection.Open();
                OleDbDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用   
            //{   
            //  cmd.Dispose();   
            //  connection.Close();   
            //}    


        }
        /// <summary>   
        /// 执行查询语句，返回DataSet   
        /// </summary>   
        /// <param name="SQLString">查询语句</param>   
        /// <returns>DataSet</returns>   
        public static DataSet Query(string connectionString, string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        /// <summary>   
        /// 执行查询语句，返回DataSet,设置命令的执行等待时间   
        /// </summary>   
        /// <param name="SQLString"></param>   
        /// <param name="Times"></param>   
        /// <returns></returns>   
        public static DataSet Query(string connectionString, string SQLString, int Times)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }



        #endregion

        #region 执行带参数的SQL语句

        /// <summary>   
        /// 执行SQL语句，返回影响的记录数   
        /// </summary>   
        /// <param name="SQLString">SQL语句</param>   
        /// <returns>影响的记录数</returns>   
        public static int ExecuteSql(string connectionString, string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>   
        /// 执行多条SQL语句，实现数据库事务。   
        /// </summary>   
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>   
        public static void ExecuteSqlTran(string connectionString, Hashtable SQLStringList)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    try
                    {
                        //循环   
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }


        /// <summary>   
        /// 执行一条计算查询结果语句，返回查询结果（object）。   
        /// </summary>   
        /// <param name="SQLString">计算查询结果语句</param>   
        /// <returns>查询结果（object）</returns>   
        public static object GetSingle(string connectionString, string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>   
        /// 执行查询语句，返回SqlDataReader (使用该方法切记要手工关闭SqlDataReader和连接)   
        /// </summary>   
        /// <param name="strSQL">查询语句</param>   
        /// <returns>SqlDataReader</returns>   
        public static OleDbDataReader ExecuteReader(string connectionString, string SQLString, params OleDbParameter[] cmdParms)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                OleDbDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用   
            //{   
            //  cmd.Dispose();   
            //  connection.Close();   
            //}    

        }

        /// <summary>   
        /// 执行查询语句，返回DataSet   
        /// </summary>   
        /// <param name="SQLString">查询语句</param>   
        /// <returns>DataSet</returns>   
        public static DataSet Query(string connectionString, string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;   
            if (cmdParms != null)
            {


                foreach (OleDbParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 获取根据指定字段排序并分页查询。


        ///**/
        ///// <summary>   
        ///// 分页查询数据记录总数获取   
        ///// </summary>   
        ///// <param name="_tbName">----要显示的表或多个表的连接</param>   
        ///// <param name="_ID">----主表的主键</param>   
        ///// <param name="_strCondition">----查询条件,不需where</param>           
        ///// <param name="_Dist">----是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>   
        ///// <returns></returns>   
        //public static string getPageListCounts(string _ID, string _tbName, string _strCondition, int _Dist)
        //{
        //    //---存放取得查询结果总数的查询语句                       
        //    //---对含有DISTINCT的查询进行SQL构造   
        //    //---对含有DISTINCT的总数查询进行SQL构造   
        //    string strTmp = "", SqlSelect = "", SqlCounts = "";

        //    if (_Dist == 0)
        //    {
        //        SqlSelect = "Select ";
        //        SqlCounts = "COUNT(*)";
        //    }
        //    else
        //    {
        //        SqlSelect = "Select DISTINCT ";
        //        SqlCounts = "COUNT(DISTINCT " + _ID + ")";
        //    }
        //    if (_strCondition == string.Empty)
        //    {
        //        strTmp = SqlSelect + " " + SqlCounts + " FROM " + _tbName;
        //    }
        //    else
        //    {
        //        strTmp = SqlSelect + " " + SqlCounts + " FROM " + " Where (1=1) " + _strCondition;
        //    }
        //    return strTmp;
        //}


        ///// <summary>   
        ///// 智能返回SQL语句   
        ///// </summary>   
        ///// <param name="primaryKey">主键（不能为空）</param>   
        ///// <param name="queryFields">提取字段（不能为空）</param>   
        ///// <param name="tableName">表（理论上允许多表）</param>   
        ///// <param name="condition">条件（可以空）</param>   
        ///// <param name="OrderBy">排序，格式：字段名+""+ASC（可以空）</param>   
        ///// <param name="pageSize">分页数（不能为空）</param>   
        ///// <param name="pageIndex">当前页，起始为：1（不能为空）</param>   
        ///// <returns></returns>   

        //public static string getPageListSql(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        //{
        //    string strTmp = ""; //---strTmp用于返回的SQL语句   
        //    string SqlSelect = "", SqlPrimaryKeySelect = "", strOrderBy = "", strWhere = " where 1=1 ", strTop = "";
        //    //0：分页数量   
        //    //1:提取字段   
        //    //2:表   
        //    //3:条件   
        //    //4:主键不存在的记录   
        //    //5:排序   
        //    SqlSelect = " select top {0} {1} from {2} {3} {4} {5}";
        //    //0:主键   
        //    //1:TOP数量,为分页数*(排序号-1)   
        //    //2:表   
        //    //3:条件   
        //    //4:排序   
        //    SqlPrimaryKeySelect = " and {0} not in (select {1} {0} from {2} {3} {4}) ";

        //    if (orderBy != "")
        //        strOrderBy = " order by " + orderBy;
        //    if (condition != "")
        //        strWhere += " and " + condition;
        //    int pageindexsize = (pageIndex - 1) * pageSize;
        //    if (pageindexsize > 0)
        //    {
        //        strTop = " top " + pageindexsize.ToString();

        //        SqlPrimaryKeySelect = String.Format(SqlPrimaryKeySelect, primaryKey, strTop, tableName, strWhere, strOrderBy);

        //        strTmp = String.Format(SqlSelect, pageSize.ToString(), queryFields, tableName, strWhere, SqlPrimaryKeySelect, strOrderBy);

        //    }
        //    else
        //    {
        //        strTmp = String.Format(SqlSelect, pageSize.ToString(), queryFields, tableName, strWhere, "", strOrderBy);

        //    }
        //    return strTmp;
        //}


        ///// <summary>   
        ///// 获取根据指定字段排序并分页查询。DataSet   
        ///// </summary>   
        ///// <param name="pageSize">每页要显示的记录的数目</param>   
        ///// <param name="pageIndex">要显示的页的索引</param>   
        ///// <param name="tableName">要查询的数据表</param>   
        ///// <param name="queryFields">要查询的字段,如果是全部字段请填写：*</param>   
        ///// <param name="primaryKey">主键字段，类似排序用到</param>   
        ///// <param name="orderBy">是否为升序排列：0为升序，1为降序</param>   
        ///// <param name="condition">查询的筛选条件</param>   
        ///// <returns>返回排序并分页查询的DataSet</returns>   
        //public static DataSet GetPagingList(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        //{
        //    string sql = getPageListSql(primaryKey, queryFields, tableName, condition, orderBy, pageSize, pageIndex);

        //    return Query(sql);
        //}
        //public static string GetPagingListSQL(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        //{
        //    string sql = getPageListSql(primaryKey, queryFields, tableName, condition, orderBy, pageSize, pageIndex);

        //    return sql;
        //}
        //public static int GetRecordCount(string _ID, string _tbName, string _strCondition, int _Dist)
        //{
        //    string sql = getPageListCounts(_ID, _tbName, _strCondition, _Dist);

        //    object obj = AccessHelper.GetSingle(sql);
        //    if (obj == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return int.Parse(obj.ToString());
        //    }
        //}
        #endregion

    }
}
