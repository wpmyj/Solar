using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Data.CommunicateEntity
{
    public class CommandClass
    {
        public byte[] Command;
        public object[] Command_Object;
        public short RecLen;
    }

    public class CommDeviceEntity
    {
        public byte UnitId;
        public string DeviceName;

        public int write2DBInterval = 10000;//Invert
        public DivCommStateEnum ComState = DivCommStateEnum.Connecting;//通讯状态标识符,1表示正常通讯，false表示通讯失败
        public bool RecoverState = true;//重连状态
        public int RecoverCounter = 1;//重连计数
        public int ReconnectCount = 5;//断开后从新连接计数的最大值

        public int DeviceTypeID;
        public string DeviceTypeName;

        public List<string> CharactorList = new List<string>();//用于存储设备中模拟量与数字量之外的一些信息
        public List<CommandClass> AnalogCommandList = new List<CommandClass>();//在modbus协议中为模拟量查询命令列表，在EA协议中为必须回复的量的查询命令列表
        public List<CommandClass> DigitalCommandList = new List<CommandClass>();//在modbus协议中为状态查询命令列表，在EA协议中为可以不回复的量的查询命令列表

        public string AnalogSignalValueTableName;
        public string UIpath;//存储该设备UI路径
    }
}
