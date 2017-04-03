using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Collections;
using System.Threading;


namespace ACCESSDBDAL
{

    public class AccessDbHelper
    {

        private static string connectionString = ConfigurationManager.AppSettings["ConnectString"];

        private static OleDbConnection conn;

        public static Exception exception = null;
        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            set { connectionString = value; }
            get
            {
                return connectionString;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessDbHelper()
        {
            //#warning 注意，如果采用这种方式构建实例，必须在web.config中配置“conn”的数据库连接字符串
            //connectionString = ConfigurationManager.AppSettings["ConnectString"].ToString();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        public AccessDbHelper(string _connectionString)
        {
            //#error 数据库连接字符串不能为空
            connectionString = _connectionString;
        }

        public static void SetconnectString()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectString"].ToString();
        }

        public static void SetconnectString(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public static void Connect()
        {
            if (conn == null)
                conn = new OleDbConnection(connectionString);
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public static void DisConnect()
        {
            conn.Close();
        }

        public static void DisposeConn()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static object lockobj = new object();//用于控制数据库访问的 同步锁对象

        #region RunProcedure_ExecuteNonQuery----V1

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">参数</param>
        /// <returns>成功执行则返回受影响的行数，异常则返回-1</returns>
        public static int RunProcedure_ExecuteNonQuery(string storedProcName, IDataParameter[] parameters)
        {
            int result = -1;
            try
            {
                Monitor.Enter(lockobj);
                Connect();
                OleDbCommand cmd = BuildQueryCommand(conn, storedProcName, parameters);
                result = cmd.ExecuteNonQuery();//返回存储过程中增、删、改等受影响的行数之和
            }
            catch (Exception e)
            {
                exception = e;
                result = -1;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
            return result;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <returns>成功执行则返回受影响的行数，异常则返回-1</returns>
        public static int RunProcedure_ExecuteNonQuery(string storedProcName)
        {
            int result = -1;
            try
            {
                Monitor.Enter(lockobj);
                Connect();
                OleDbCommand cmd = BuildQueryCommand(conn, storedProcName);
                result = cmd.ExecuteNonQuery();//返回存储过程中增、删、改等受影响的行数之和
            }
            catch (Exception e)
            {
                exception = e;
                result = -1;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
            return result;
        }

        #endregion

        #region RunProcedure_ExecuteDatable----V1

        public static DataTable RunProcedure_ExecuteDataTabl(string storedProcName, IDataParameter[] parameters)
        {
            DataTable DT = new DataTable();
            try
            {
                Monitor.Enter(lockobj);
                Connect();
                OleDbDataAdapter dataAdap = new OleDbDataAdapter();
                dataAdap.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                dataAdap.Fill(DT);
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
            return DT;
        }

        public static DataTable RunProcedure_ExecuteDataTabl(string storedProcName)
        {
            DataTable DT = new DataTable();
            try
            {
                Monitor.Enter(lockobj);
                Connect();
                OleDbDataAdapter dataAdap = new OleDbDataAdapter();
                dataAdap.SelectCommand = BuildQueryCommand(conn, storedProcName);
                dataAdap.Fill(DT);
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
            return DT;
        }

        #endregion

        /// <summary>
        /// 执行一个查询，返回查询结果集的第一行第一列，忽略其它行和列
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public static Object ExecuteScalar(string sql, CommandType commandType, OleDbParameter[] parameters)
        {
            object result = null;
            try
            {
                Monitor.Enter(lockobj);
                Connect();
                OleDbCommand command = new OleDbCommand(sql, conn);
                command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                //如果同时传入了参数，则添加这些参数
                if (parameters != null)
                {
                    foreach (OleDbParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                result = command.ExecuteScalar();
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
            return result;//返回查询结果的第一行第一列，忽略其它行和列
        }

        #region 执行SQL语句

        /// <summary>
        /// 执行SQL语句，返回受影响的记录数
        /// <para>一般用于增、删、改，而不用于查询，因为如果是查询受影响的行数返回为-1</para>
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            int rows = -1;
            try
            {
                Monitor.Enter(lockobj);
                Connect();
                OleDbCommand cmd = new OleDbCommand(SQLString, conn);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
            return rows;
        }

        public static DataTable ExecuteSql_GetTable(string SQLString)
        {
            DataTable DT = new DataTable();
            try
            {
                Monitor.Enter(lockobj);
                Connect();
                OleDbDataAdapter dataAdap = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand(SQLString, conn);
                cmd.CommandType = CommandType.Text;
                dataAdap.SelectCommand = cmd;
                dataAdap.Fill(DT);
            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
            return DT;
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// <para>对于增、删、改语句：</para>
        ///  <para>insert into course values('zhuangyq','语文',80)</para>
        ///  <para>delete from course where id = 28</para>
        ///  <para>update course set fenshu = '102' where id = 26</para>
        ///  <para>以上三句在执行cmd.ExecuteScalar();语句时，才对数据库操作。此时返回的obj为nul</para>
        ///  <para>只有执行select * From course语句时，obj为查询所返回的结果集中的第一行的第一列</para>
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            try
            {
                Monitor.Enter(lockobj);
                Connect();
                OleDbCommand cmd = new OleDbCommand(SQLString, conn);
                object obj = cmd.ExecuteScalar();
                if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
            finally
            {
                Monitor.Exit(lockobj);
            }
        }

        #endregion

        #region 数据库维护：压缩修复

        public static void CompactAccessDB()
        {
            string connectionString1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};";
            string connectionString2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Engine Type=5";
            //
            string sourceFile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\AcDb_Trial.mdb";//此处为获取数据库路径
            connectionString1 = string.Format(connectionString1, sourceFile);
            //
            string tempFile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\temp.mdb";
            connectionString2 = string.Format(connectionString2, tempFile);

            object objJRO = null;
            try
            {
                Monitor.Enter(lockobj);
                DisposeConn();//执行之前必须确保 数据库没有被连接
                objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));

                object[] oParams;
                oParams = new object[] { connectionString1, connectionString2 };

                objJRO.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, oParams);

                System.IO.File.Delete(sourceFile);
                System.IO.File.Move(tempFile, sourceFile);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //无论如何，使用完毕后后必须主动清理COM资源
                if (objJRO != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
                    objJRO = null;
                }
                Monitor.Exit(lockobj);
            }
        }

        #endregion

        #region BuildQueryCommand

        private static OleDbCommand BuildQueryCommand(OleDbConnection conn, string storedProcName, IDataParameter[] parameters)
        {
            OleDbCommand cmd = new OleDbCommand(storedProcName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (OleDbParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd;
        }

        private static OleDbCommand BuildQueryCommand(OleDbConnection conn, string storedProcName)
        {
            OleDbCommand cmd = new OleDbCommand(storedProcName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        #endregion
    }

}
