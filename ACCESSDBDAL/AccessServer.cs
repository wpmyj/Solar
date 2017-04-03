using System;
using System.Collections.Generic;
using System.Text;
using Model_Data;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;

namespace ACCESSDBDAL
{
    public class AccessServer
    {
        //历史数据 查询
        public static DataTable GetHistoricData(DateTime TheBegin, DateTime TheEnd, string tableName)
        {
            string begin = TheBegin.ToString("yyyy-MM-dd HH:mm:ss");
            string end = TheEnd.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = string.Format("select * from {0} where ( Dtime>#{1}# and Dtime<#{2}# ) order by Dtime", tableName, begin, end);
            return AccessDbHelper.ExecuteSql_GetTable(sql);
        }
        //插入 数据
        public static bool InsertData(string tableName,List<int> ids, List<string> values)
        {
            List<string> colnames = new List<string>();
            foreach (int item in ids)
                colnames.Add("sid" + item.ToString());                
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string InsertSql = "insert into {0} (dtime,{1}) values(#{2}#,{3})";
            InsertSql = string.Format(InsertSql, tableName,string.Join(",",colnames.ToArray()), time, string.Join(",", values.ToArray()));
            return AccessDbHelper.ExecuteSql(InsertSql)>0;
        }
        //历史事件 查询
        public static DataTable GetAlermHistoricEvent(DateTime BeginTime, DateTime EndTime)
        {
            string begin = BeginTime.ToString("yyyy-MM-dd HH:mm:ss");
            string end = EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = string.Format("select * from Alarm_History_Table where ( SaveTime>#{0}# and SaveTime<#{1}# ) order by SaveTime desc", begin, end);
            DataTable AlarmTable = AccessDbHelper.ExecuteSql_GetTable(sql);
            if (AlarmTable != null && AlarmTable.Columns.Count > 0)
            {
                //移除不相关的列
                AlarmTable.Columns.Remove("KeyId");
                //修改表格 列名
                AlarmTable.Columns["MessageStr"].ColumnName = Model_Data.Language.Desc.EventInfo;
                AlarmTable.Columns["SaveTime"].ColumnName = Model_Data.Language.Desc.EventTime;
            }
            return AlarmTable;
        }
        //插入事件
        public static bool InsertAlarm(DateTime time,string Msg)
        {
            string savetime = time.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = string.Format("insert into Alarm_History_Table (SaveTime,MessageStr) values (#{0}#,'{1}')", savetime, Msg); ;
            return AccessDbHelper.ExecuteSql(sql) > 0;
        }

        //创建 历史数据 表格
        public static int CreateDataTable(string TableName, List<AnalogModel> SignalList)
        {
            string tabName = TableName;
            //声明要创建的表名，你也可以改为从textbox中获取；
            string sqlStr = "create table ";
            sqlStr += tabName + "( ";//"EA_Device_" + 
            sqlStr += "KeyId AUTOINCREMENT PRIMARY KEY, ";
            //col0为列名，同样可以改为通过从textbox中获取
            //identity(1,1)是标记递增种子
            //primary key定义主键

            sqlStr += "dtime datetime,";
            foreach (AnalogModel row in SignalList)
            {
                if (!row.ISRecord)
                    continue;
                sqlStr += "sid" + row.SignalId.ToString() + " " + row.SignalType + ",";
            }
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " )";

            return AccessDbHelper.ExecuteSql(sqlStr);
        }
        //创建 历史事件 表格
        public static int CreateEventTable()
        {
            string sql = "create table Alarm_History_Table ( KeyId AUTOINCREMENT PRIMARY KEY,SaveTime datetime,MessageStr text(100) )";
            return AccessDbHelper.ExecuteSql(sql); 
        }

        //判断 表格 是否存在
        public static Boolean IsTableExist(string tablename)
        {
            string sql =string.Format("select MSysObjects.name from MSysObjects where (((MSysObjects.name)='{0}') AND ((MSysObjects.type)=1 ));",tablename);
            return AccessDbHelper.GetSingle(sql) !=null;            
        }
        //删除 表格
        public static Boolean DropTable(string TableName)
        {
            string sqlStr = string.Format("drop table {0}", TableName);
            return AccessDbHelper.ExecuteSql(sqlStr) > 0;
        }
        //判断 存储过程 是否存在
        public static Boolean IsProcessExist(string ProcessName)
        {
            string sql = string.Format("select MSysObjects.name from MSysObjects where (((MSysObjects.name)='{0}') AND ((MSysObjects.type)=5 ));", ProcessName);
            return AccessDbHelper.GetSingle(sql) != null;
        }
        //删除 存储过程
        public static Boolean DropProcedure(string ProcedureName)
        {
            string sqlStr = string.Format("drop procedure {0}", ProcedureName);
            return AccessDbHelper.ExecuteSql(sqlStr) > 0;
        }

    }
}
