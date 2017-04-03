using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Data.CommunicateEntity
{
    //太阳能逆变器小机设置命令的枚举
    public enum M3_SetInfo_enum
    {
        UpperLimitVolt = 1,
        LowerLimitVolt = 2,
        UpperLimitFreq = 3,
        LowerLimitFreq = 4,
        Year = 5,
        Month = 6,
        Day = 7,
        Hour = 8,
        Minute = 9,
        Second = 10,
        SwitchOnOff = 11

    }

    public enum UPS_SetInfo_enum
    {
        ButteryTest10s=1,//电池测试10S
        ButteryTestToLow=2,//电池低电压测试
        OnOrOffBeep=3,//蜂鸣器开关
        CancelTest=4,//取消测试命令
        CancelClose=5,//取消关机命令
        ButteryTestnminu=6,//电池测试N分钟
        ShutDownnsLater=7,//定时N秒后关机
        RestartnsLater=8,//定时关机后N分钟再重启
        UPSAdr=9,//设备地址
        UPSBaund=10,//波特率
        ModbusProtocolMode = 11,//Modbus 协议模式
        UPSCheckbit = 12,//校验位选择
        USPStopbit=13,//停止位选择
        TurnOnCommand=14,//开机命令
        YearSet=15,//设置年份
        MonthSet=16,//设置月份
        DaySet=17,//设置日期
        HourSet=18,//设置小时
        MinuteSet=19,//设置分钟
        SecondSet=20,//设置秒钟
        ClearPowerRecord=21,//清空发电量数据
        ClearDataRecodr=22//清空记录数据
    }

    //在设置基于MOdbus协议的设备的遥控量时用于传递信息的类
    public class CommDeviceModbuseControlEntity
    {
        public int DivID;//单元ID（设备地址）
        public byte[] SetData;
        public bool IsSuccess = false;
        public short SetInfoStartAdr;//设置量的起始地址
        public FunctionCode functioncode;//命令码
        public short RegisterLen;//寄存器个数
    }
}
