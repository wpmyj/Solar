using System;
using System.Collections.Generic;
using System.Text;
using Model_Data;
using Communication;
using Communication.CommunicateToLowerMonitor;
using System.Data;
using Model_Data.CommunicateEntity;
using Model_Data.UI_Entity;
using System.Configuration;
using System.IO;
namespace BLL
{
    public class DeviceObj
    {
        private static WrapperBll wrapper = null;
        private static bool flag = true;//是否初始成功
        private static DeviceModel dm = null;

        //
        public static bool Inition()
        {
            flag = flag && LoadData();//从数据库中读取端口、设备配置信息,生成通讯实例
            InitionCallback();
            return flag;
        }

        //

        #region 设置部分

        public static Boolean SetTcpIP(PortModel PE, TcpModel TCPE)
        {
          
            return true;
        }

        public static Boolean SetSerial(PortModel PE, SerialModel SE)
        {

            return true;
        }

        public static Boolean SetUSB(PortModel PE)
        {

            return false;
        }

        #endregion

        //启动轮询
        public static bool StartPoll()
        {
            if (wrapper == null) return false;
            wrapper.StartPoll();
            return true;
        }

        //停止轮询---暂时为单机服务
        public static void StopPoll()
        {
            if (wrapper != null)
            {
                wrapper.StopPoll();
            }

        }

        //
        public static bool ReLoad()
        {
            bool result = true;
            ClearPort();
            result=result&&LoadData();
            InitionCallback();//重新从底层获取回调
            return result;
        }

        //清理端口
        private static void ClearPort()
        {
            if (wrapper != null)
            {
                wrapper.DisposeTimer();
                wrapper.Dispose();
            }
        }


        #region 回调函数注册部分

        //向界面层提供的接口，界面只需要绑定一次即可
        private static DelegateEntity.AlarmDelegate IEventCallback = null;
        private static DelegateEntity.SetInfoMethod ISetCallback = null;

        //用于设置设备遥控量的响应函数
        public static void SetInfoFunction(object SetInfo)
        {
            CommDeviceModbuseControlEntity tempentity = new CommDeviceModbuseControlEntity();
            if (SetInfo is CommDeviceModbuseControlEntity)
                tempentity = (CommDeviceModbuseControlEntity)SetInfo;
            if (wrapper != null)
                wrapper.SetDivInfo(tempentity);
        }
        //
        public static void RegistEventCallback(DelegateEntity.AlarmDelegate EventCallback)
        {
            IEventCallback = EventCallback;
        }
        //
        public static void RegistSetInfoResultDelegate(DelegateEntity.SetInfoMethod SetInfoResultMethod)
        {
            ISetCallback = SetInfoResultMethod;
        }
        //从底层获取 回调接口
        private static void InitionCallback()
        {
            if (wrapper == null) return;
            wrapper.PortAlarmDelegate = EventCallback;
            ISetCallback = wrapper.SetInfoResultMethod;
        }
        private static void EventCallback(AlarmEntity AE)
        {
            if (IEventCallback != null) IEventCallback(AE);
        }
        private static void SetCallback(object Ob)
        {
            if (ISetCallback != null) ISetCallback(Ob);
        }

        #endregion

        #region 输入端口配置---根据数据库

        //开始加载
        private static bool LoadData()
        {
            if (wrapper != null)
            {
                //必须先清理
            }
            //根据配置文件 初始化设备对象
            try
            {
                FileStream txt = File.Open("Device.xml", FileMode.OpenOrCreate);
                System.Xml.Serialization.XmlSerializer serial = new System.Xml.Serialization.XmlSerializer(typeof(Model_Data.DeviceModel));
                dm = (Model_Data.DeviceModel)serial.Deserialize(txt);
            }
            catch (Exception)
            {
                
            }
            if (dm == null) return false;

            wrapper = PortSetting(dm);
            if (wrapper == null)
                return false;
            wrapper.CreatCommand();        
            return true;
        }

        //加载端口
        private static WrapperBll PortSetting(Model_Data.DeviceModel obj)
        {
            WrapperBll PS = new WrapperBll();
            PS.Port = obj.Port;
            switch (obj.Port.PortType)
            {
                case Protocol.Modbus_SerialPort:
                    PS.PortBll = AllPortBll.CreateInstance(Protocol.Modbus_SerialPort);
                    PS.PortBll.SetParaMeter(CreatCommSerialEntity(obj));
                    break;
                case Protocol.Modbus_TCPIPPort:
                    PS.PortBll = AllPortBll.CreateInstance(Protocol.Modbus_TCPIPPort);
                    PS.PortBll.SetParaMeter(CreatCommTCPEntity(obj));
                    break;
                case Protocol.Modbus_USBPort:
                    PS.PortBll = AllPortBll.CreateInstance(Protocol.Modbus_USBPort);
                    break;               
                default:
                    return null;
            }
            //Device
            DeviceBll deviceBLL = new DeviceBll();

            deviceBLL.Device.DeviceName = obj.DeviceName;
            deviceBLL.Device.UnitId = obj.UnitId;
            deviceBLL.Device.write2DBInterval = obj.WriteDBTime;
            deviceBLL.Device.AnalogSignalValueTableName = obj.TableName;
            deviceBLL.Device.UIpath = obj.UIPath;            
            //
            foreach (AnalogModel AnalogRow in obj.Analog)
            {
                AnalogBll analogSignalBLL = new AnalogBll();
                analogSignalBLL.AnalogInfo = AnalogRow;
                deviceBLL.AnalogList.Add(analogSignalBLL);
            }
            //
            foreach (DigitalModel DigitalRow in obj.Digital)
            {
                DigitalBll digitalSignalBLL = new DigitalBll();
                digitalSignalBLL.DigitalInfo = DigitalRow;
                deviceBLL.DigitalList.Add(digitalSignalBLL);
            }
            deviceBLL.SetSignalAlarmDelegate();
            if (deviceBLL != null)
            {
                PS.DeviceList.Add(deviceBLL);
            }
            PS.SetDeviceDelegate();
            return PS;
        }
        //创建用于通讯的tcp信息实例
        private static CommTCPEntity CreatCommTCPEntity(Model_Data.DeviceModel obj)
        {
            CommTCPEntity TCPE = new CommTCPEntity();
            TCPE.IP = obj.Port.TCP.IP;
            TCPE.Port = obj.Port.TCP.Port;
            TCPE.WriteOverTime = obj.Port.WriteOverTime;
            TCPE.ReadOverTime = obj.Port.ReadOverTime;
            return TCPE;
        }
        //创建用于通讯的串口信息实例
        private static CommSerialEntity CreatCommSerialEntity(Model_Data.DeviceModel obj)
        {            
            CommSerialEntity Serpara = new CommSerialEntity();
            Serpara.PortName = obj.Port.Serial.PortName;
            Serpara.BaudRate = obj.Port.Serial.BaudRate;
            Serpara.DataBit = obj.Port.Serial.DataBit;
            Serpara.Parity = obj.Port.Serial.Parity;
            Serpara.StopBit = obj.Port.Serial.StopBit;
            Serpara.RecoveryWaitTime = obj.Port.Serial.RecoveryWaitTime;

            Serpara.WriteOverTime = obj.Port.WriteOverTime;
            Serpara.ReadOverTime = obj.Port.ReadOverTime;
            return Serpara;
        }

        #endregion

        #region 数据服务部分

        //根据 设备获取设备 信息，创建设备 实时LIST-----模拟
        public static List<UI_Analog> GetDeviceAnalogSignalValueList()
        {
            DeviceBll Device = wrapper.DeviceList[0];
            if (Device == null)
                return null;
            if (Device.Device.ComState != DivCommStateEnum.Success)
                return null;
            List<UI_Analog> AnalogSignalValueList = new List<UI_Analog>();
            foreach (AnalogBll Signal in Device.AnalogList)
            {
                UI_Analog AnalogSignal_Item = new UI_Analog();
                AnalogSignal_Item.SignalName = Signal.AnalogInfo.SignalName;
                AnalogSignal_Item.SignalValue = Signal.AnalogInfo.Value;
                AnalogSignal_Item.SignalUnit = Signal.AnalogInfo.SignalUnit;
                AnalogSignalValueList.Add(AnalogSignal_Item);
            }
            return AnalogSignalValueList;
        }

        //根据 设备获取设备 信息，创建设备 实时LIST----数字
        public static List<UI_Digital> GetDeviceDigitalSignalValueList()
        {
            DeviceBll Device = wrapper.DeviceList[0];
            if (Device == null)
                return null;
            if (Device.Device.ComState != DivCommStateEnum.Success)
                return null;
            List<UI_Digital> DigitalSignalValueList = new List<UI_Digital>();
            foreach (DigitalBll Signal in Device.DigitalList)
            {
                UI_Digital DigitalSignal_Item = new UI_Digital();
                DigitalSignal_Item.SignalName = Signal.DigitalInfo.SignalName;
                DigitalSignal_Item.SignalValue = Signal.DigitalInfo.Value;
                DigitalSignalValueList.Add(DigitalSignal_Item);
            }
            return DigitalSignalValueList;
        }

        public static DeviceModel GetDeviceModel()
        {
            if (dm == null) return null;
            return dm;
        }

        public static PortModel GetPort()
        {
            if (wrapper == null) return null;
            return wrapper.Port;
        }

        public static WrapperBll GetWrapper()
        {
            return wrapper;
        }

        //根据端口ID 获取端口 扫描时间
        public static int GetPortScanTime()
        {
            if (wrapper == null) return -1;
            return wrapper.Port.ScanningTime;
        }

        //获取设备
        public static DeviceBll GetDevice()
        {
            if (wrapper == null) return null;
            return wrapper.DeviceList[0];
        }

        //获取 设备下 数字的 模拟量列表（用于填充绘制曲线的下拉框）
        public Boolean GetDeviceAnalogSignalName(ref List<string> list_signallist, bool IsSignalDrawLine = false)
        {
            List<AnalogBll> AnalogList = new List<AnalogBll>();
            //判断内存中是否存在该设备
            if (wrapper == null || wrapper.DeviceList[0] == null)
                return false;
            //由设备ID获取设备对象
            //从设备对象中 获取设备实体 数据
            AnalogList = wrapper.DeviceList[0].AnalogList;
            foreach (var item in AnalogList)
            {
                if (IsSignalDrawLine && item.AnalogInfo.AnalogReadFrequency != AnalogReadFrequency.EveryTime)
                    continue;
                list_signallist.Add(item.AnalogInfo.SignalName);
            }
            return true;
        }

        public static void UpdateDevice(DeviceModel device)
        { 
        
        }

        #endregion

    }
}
