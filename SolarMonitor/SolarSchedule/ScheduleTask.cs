using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SolarMonitor.SolarSchedule
{
    /// <summary>
    /// 日程任务对象
    /// </summary>
    public class ScheduleTask
    {
        private object locker = new object();//锁对象

        /// <summary>
        /// 任务执行时间
        /// 表示本任务将要在这个时间执行，必须在初始化的时候传入
        /// </summary>
        public DateTime time { private set; get; }
        /// <summary>
        /// 任务频率
        /// </summary>
        public ScheduleFrequence frequence { private set; get; }
        /// <summary>
        /// 任务当前状态
        /// </summary>
        public ScheduleResult result { private set; get; }
        /// <summary>
        /// 上次执行时间
        /// 注意：该值初始值为 DateTime.MinValue
        /// </summary>
        public DateTime preExecuteTime { private set; get; }
        /// <summary>
        /// 上传执行结果
        /// 注意：仅当上次执行时间有效的 时候 才有效
        /// </summary>
        public bool preExcecuteResult { private set; get; }
        /// <summary>
        /// 执行异常的时候，可以存储一个异常描述字符
        /// </summary>
        public string errorString { set; get; }
        /// <summary>
        /// 任务标签
        /// </summary>
        public int tag { set; get; }

        public event TaskHandle handle = null;
        //public ScheduleTask() { }//空构造函数
        public ScheduleTask(DateTime time, ScheduleFrequence frequence)
        {
            this.time = time;
            this.frequence = frequence;
            result = ScheduleResult.UnExecute;
            preExecuteTime = DateTime.MinValue;
            if (time < DateTime.Now)
            {
                switch (frequence)
                {
                    case ScheduleFrequence.Single:
                        this.result = ScheduleResult.Outdate;
                        break;
                    case ScheduleFrequence.EveryDay:
                        this.time = DateTime.Now.AddDays(1);//明天执行
                        break;
                    case ScheduleFrequence.EveryWeek:
                        int days = (int)((DateTime.Now - time).TotalDays);
                        this.time = time.AddDays(7 * (days / 7 + 1));
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 默认处理器
        /// </summary>
        private void defaultHandle()
        {
            Monitor.Enter(locker);

            preExecuteTime = DateTime.Now;//记录执行时间
            switch (frequence)
            {
                case ScheduleFrequence.Single:
                    result = ScheduleResult.Success;//执行完毕
                    break;
                case ScheduleFrequence.EveryDay:
                    result = ScheduleResult.UnExecute;//待执行                    
                    time = time.AddDays(1);//修改执行时间 为下一天
                    break;
                case ScheduleFrequence.EveryWeek:
                    result = ScheduleResult.UnExecute;//待执行                    
                    time = time.AddDays(7);//修改执行时间 为下一天
                    break;
                default:
                    break;
            }

            Monitor.Exit(locker);

            log();
        }

        private void log()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("任务状态：");
            sb.AppendFormat("       任务执行时间：{0}\r\n", time.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            sb.AppendFormat("       任务执行频率：{0}\r\n", frequence.ToString());
            sb.AppendFormat("       任务当前状态：{0}\r\n", transResult(result));
            sb.AppendFormat("       上传执行时间：{0}\r\n", transPreResult(preExecuteTime));
            sb.AppendFormat("       上次执行结果：{0}\r\n", preExcecuteResult.ToString());
            sb.AppendFormat("       错误描述字符：{0}\r\n", errorString);
            System.Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 过滤器
        /// </summary>
        /// <returns></returns>         
        private bool filter()
        {
            bool result = false;
            //如果是单次任务，但是任务不是待执行状态，则过滤
            if (this.frequence == ScheduleFrequence.Single && this.result != ScheduleResult.UnExecute)
                return true;

            return result;
        }

        internal void execute()
        {
            if (filter())
                return;
            if (handle != null)
            {
                if (handle.Invoke(this, this.errorString))
                    this.preExcecuteResult = true;
                else
                    this.preExcecuteResult = false;
            }
            defaultHandle();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(tag == 1)
                sb.AppendFormat("{0}",Model_Data.Language.ScheduleStr.OpenTheInverter);
            else if (tag == 2)
                sb.AppendFormat("{0}",Model_Data.Language.ScheduleStr.CloseTheInverter);
            else if (tag == 3)
                sb.AppendFormat("{0}",Model_Data.Language.ScheduleStr.BatteryTest);
            sb.AppendFormat(" {0}", time.ToString("yyyy-MM-dd HH:mm:ss dddd"));
            sb.AppendFormat(" {0}", transFreq(frequence));
            sb.AppendFormat(" {0}", transResult(result));
            //sb.AppendFormat("{0,-30}", transPreResult(preExecuteTime));
            //sb.AppendFormat("{0}", transPreResult(preExcecuteResult));
            //sb.AppendFormat("{0}", errorString);
            return sb.ToString();
        }
        //频率解析
        public static string transFreq(ScheduleFrequence frequence)
        {
            string str = string.Empty;
            switch (frequence)
            {
                case ScheduleFrequence.Single: str = Model_Data.Language.ScheduleStr.once; break;
                case ScheduleFrequence.EveryDay: str = Model_Data.Language.ScheduleStr.everyDay; break;
                case ScheduleFrequence.EveryWeek: str = Model_Data.Language.ScheduleStr.Weekly; break;
            }
            return str;
        }
        //执行结果解析
        public  static string transResult(ScheduleResult result)
        {
            string str = string.Empty;
            switch (result)
            {
                case ScheduleResult.UnExecute: str = Model_Data.Language.ScheduleStr.AwaitingExecution; break;
                case ScheduleResult.Outdate: str = Model_Data.Language.ScheduleStr.Failure; break;
                case ScheduleResult.Success: str = Model_Data.Language.ScheduleStr.success; break;
            }
            return str;
        }

        public static string transTask(int offGrid) {

            string str = string.Empty;
            switch (offGrid)
            {
                case 1: str = Model_Data.Language.ScheduleStr.OpenTheInverter; break;
                case 2: str = Model_Data.Language.ScheduleStr.CloseTheInverter; break;
                case 3: str = Model_Data.Language.ScheduleStr.BatteryTest; break;
            }
            return str;
        } 

        public static  string transPreResult(DateTime time)
        {
            if (time == DateTime.MinValue)
                return "N/A";
            else
                return time.ToString("yyyy-MM-dd HH:mm:ss dddd");
        }
    }

    /// <summary>
    /// 任务事件
    /// </summary>
    /// <param name="sender">任务引用</param>
    /// <param name="msg">错误消息：如果执行失败，可以传入一个错误描述消息给任务</param>
    /// <returns>是否执行成功</returns>
    public delegate bool TaskHandle(ScheduleTask sender, String msg);

    public enum ScheduleFrequence : int
    {
        Single = 0,//单次执行
        EveryDay = 1, //每天执行
        EveryWeek = 2,//每周
    }

    public enum ScheduleResult : int
    {
        UnExecute = 0, //待执行
        Outdate = 1,//超期
        Success = 2,//成功
    }

}
