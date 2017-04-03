using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Data.Language
{

    public class SmachineForm
    {
        public static string StartCommunicating;
        public static string StopCommunicating;
        public static string ParaSetting;
        public static string ReadHisEvent;
        public static string AddrSearching;

        public static string OpenInfoWnd;
        public static string CloseInfoWnd;

        public static string Exit;

        public static string SystemRelated;
        public static string OperateDocument;

        public static string Now;//系统当前时间

        public static string Port;
        public static string Interval;
        public static string Event;

    }
    public class EaSolar
    {
        public static string SystemData;
        public static string UnConnect;
        public static string Connected;
        public static string Disconnected;
        public static string TotalGeneratedEnergy;
        public static string DailyGeneratedEnergy;
        public static string BatteryVoltage;
        public static string PVPower;
        public static string Temperature;
        public static string VersionNumber;
        public static string SetSuccess;
        public static string SetFailure;
        public static string Prompt;
        public static string AreYouSureConfig;
        
        //Tab
        public static string ACInfo_Tab;
        public static string Real_timeInfo;
        public static string RatedInfo_Tab;
        public static string FaultInfo;
        public static string DevControl_Tab;
        public static string SystemSettings;
        //ACInfoUC
        public static string ACInfo;
        public static string ACInputVoltage;
        public static string ACOutputVoltage;
        public static string ACOutputFrequency;
        public static string ACInputEnergy;
        public static string ACOutputEnergy;

        //Real-time Info
        public static string PVInfo;
        public static string PVInputVoltage;
        public static string PVChargingCurrent;
        public static string Percentage;
        public static string LoadPercentage;
        public static string BatteryCapacityLevel;
        //RatedInfo
        public static string RatedInfo;
        public static string RatedVol;

        public static string RatedBatteryVol;
        public static string ProductInfo;
        public static string ProductType;

        public static string ProductModel;
        public static string ChargingCurrentLevel;

        public static string CommuVersion;
        public static string ControlVersion;

        //FaultInfo
        public static string ACStatus;
        public static string ACNormal;
        public static string ACFault;
        public static string PVLowVoltage;
        public static string PVOverVoltage;
        public static string PVReversed;
        public static string BatteryLowVoltage;
        public static string BatteryOverDisCharge;
        public static string BatteryFault;
        public static string OverLoad;
        public static string ACChargingStatus;
        public static string ACChargingOff;
        public static string ACChargingOn;
        public static string PVChargingStatus;
        public static string PVChargingOff;
        public static string PVChargingOn;
        public static string ThermalProtection;//过温保护
        public static string MPPT_IGBTProtect;
        public static string BUSFault;
        public static string ON_OFFStatus;
        public static string OFFStatus;
        public static string ONStatus;
        public static string ShutDownActive;
        public static string PowerOnActive;
        public static string BatteryOverChargeProtect;
        public static string ActivateCountDownPVCharging;
        public static string ACFrequencyMode;
        public static string ACFrequencySelfoscillationMode;
        public static string ACFrequencyPhaselockedMode;
        public static string RectiferWorkMode;
        public static string PVAndBatteryMode;
        public static string PriorityMode;
        public static string PVPriorityMode;
        public static string ACPriorityMode;
        public static string SPIFault;
        public static string BatteryTestMode;
        //DevControl
        public static string DevControlInfo;
        public static string BatteryTest1Min;
        public static string BatteryLowVolTest;
        public static string BatteryTestCancel;
        public static string ShutDownCanceling;
        public static string SwitchOn;
        public static string ShutDown;
        public static string Sleep;
        public static string OK_DevControl;
        public static string Cancel_DevControl;
        //SystemSetting
        public static string SystemInfoSetting;
        public static string DevCommAddr;
        public static string DevCommBaud;
        public static string ModbusProtocolMode;
        public static string ParityBitCheck;
        public static string StopBitCheck;
        public static string DateSettings;
        public static string DevCurrentTime;
        public static string DaySetting_Radio;
        public static string DaySetting;
        public static string ClearRecords;
        public static string OK_SystemSetting;
        public static string Cancel_SystemSetting;
        public static string SelectTheRightItem;
    }
    //公共信息
    public class PublicInfo
    {
        public static string DateTime;//端口
        public static string Port;//端口
        public static string DevID;
        public static string PortID;
        public static string SignID;
        public static string DevName;
        public static string PortName;
        public static string SignName;
        public static string SignDesc;//信号描述
        public static string SignalUnit;//工程单位
        public static string SignalType;//信号类型
        public static string DevTypeID;//设备类型ID

        public static string OK;
        public static string View;//查看
        public static string Pause;//暂停
        public static string Start;//启动
        public static string Cancel;
        public static string Modify;
        public static string Return;
        public static string Delete;//删除
        public static string Recover;//恢复
        public static string Spntime;//刷新时间
        public static string ISModify;//可修改
        public static string UpdateSign;//更新信号

        public static string CommuState;//通讯状态
        public static string SeleSign;//选择信号
        public static string EndTime;//结束时间
        public static string StartTime;//起始时间
        public static string ViewCurve;//查看曲线
        public static string ClickLoad;//点击重载
        public static string InsertDB;//插入数据库
        public static string SaveAndNext;//保存并一个
        public static string SaveAndExit;//保存退出
        public static string NullWrite;//未填写
        public static string Ana;//模拟量
        public static string Dig;//数字量
        public static string Year;
        public static string Month;
        public static string Day;
        public static string Hour;
        public static string Minute;
        public static string Second;

        public static string SelPort;//请选择端口：
        public static string SelDev;//请选择设备：
        public static string SelSign;//请选择信号

        public static string NoRefresh;//不刷新

        //ListForm
        public static string DevRealtimeData_ListForm;//设备实时数据
        public static string ID_ListForm;//ID
        public static string SignalName_ListForm;//信号名
        public static string SignalValue_ListForm;//信号值
        public static string Unit_ListForm;//单位
        public static string SignalTime_ListForm;//信号时间

        public static string Print;//打印
        public static string Export;//导出
        public static string NoDataFound;//数据信息为空
        public static string Info;//提示
    }
    //告警设置界面
    public class AlarmSet
    {
        public static string Text;//告警信息设置
        public static string EmailSet;//邮件告警
        public static string SMSSet;//短信告警
        public static string PhoneSet;//电话告警
        public static string StartDev;//在设备中启用此设置
        public static string StartSig;//在信号中启用此设置
        public static string Number;//接收端号码
        //Email
        public static string EmailAlarmSet;//邮件通知设定
        public static string Subject;//主题
        public static string SubText;//自动告警邮件
        public static string FromAddr;//发送地址
        public static string FromName;//发送人姓名
        public static string Host;//邮件服务器
        public static string Password;//密码
        public static string TimeOut;//超时时间设置
        public static string ToMsg;//接收者信息
        public static string ToAddr;//接收人地址
        public static string CCAddr;//抄送地址
        public static string BCCAddr;//密送地址
        public static string StartEmail;//启动邮件告警
        //SMS
        public static string SMSAlarmSet;//短信告警设置
        public static string StartSMS;//启动短信告警
        //Phone
        public static string PhoneAlarmSet;//电话告警设置
        public static string StartPhone;//启动电话告警
        //MessageBoxShow
        public static string IllegalAdde;//{0}是非法的邮件地址
        public static string EmailSaveSucc;//邮件设置保存成功
        public static string SMSSaveSucc;//短信设置保存成功
        public static string PhoneSaveSucc;//电话设置保存成功
        public static string CorrectTimeout;//请输入正确的超时时间
    }
    public class Serial_Info_Set
    {
        public static string Serial;//串口
        public static string SerialNum;//串口号
        public static string IPAddr;//IP地址
        public static string PortName;//串口号
        public static string BaudRate;//波特率
        public static string DataBit;//数据位
        public static string StopBit;//停止位
        public static string Parity;//奇偶校验
        public static string SerialInfo;//串口参数设置
        public static string BasicInfo;//基本信息设置
        public static string ReTime;//回收等待时间
        public static string TCPIPInfo;//TCP/IP信息设置
        //按钮
        public static string BtnOK;//确定
        public static string BtnCancel;//取消
        public static string BtnAdvancedOption;//高级选项
        //按下确定按钮后的提示信息相关
        public static string PortNotSupport;//暂时不支持该端口
        public static string NoEmptyStr;//不能输入空字符
        public static string FailSelection;//选择失败
        public static string WaitAndScanningTimeInfo1;//扫描时间为
        public static string WaitAndScanningTimeInfo2;//回收等待时间为
        public static string WaitAndScanningTimeInfo3;//回收等待时间必须小于扫描时间
        public static string Warning;//警告
        //高级选项
        public static string Port;//端口
        public static string PortName_Ad;//端口名称
        public static string Description;//描述
        public static string ScanningInterval;//扫描时间
        public static string OverTime;//超时时间
        public static string ReconnectionTimes;//重连次数
        public static string ResumeTime;//恢复时间

        public static string ReadOverTime;//读超时时间
        public static string WriteOverTime;//写超时时间
        public static string Device;//设备
        public static string DevName;//设备名称
        public static string DevAddr;//设备地址
        public static string WriteDataInterval;//写入数据间隔
        public static string Ok_Ad;//确定
        public static string Cancel_Ad;//取消
        public static string NoNullInput;//请确保输入不为空

    }
    public class ChildForm
    {
        //For ParaSetting
        public static string ParaSetting;//参数设置
        public static string ConnectSetting;//连接设置
        public static string PortSelect;//连接设置
        public static string CommProtocol;//通讯协议
        public static string DevSelection;//设备选择
        public static string TCPIPSetting;//TCP/IP设置
        public static string IPAddr;//IP地址
        public static string PortNum;//端口号

        //For AutoSearchAddr
        public static string Addr;//地址：
        public static string Termination;//终止
        public static string SearchText;//设备地址自动搜索
        public static string AppAddr;//应用地址
        public static string SearchDev;//搜索设备
        public static string InPrepare;//准备中。。。
        public static string ConnSucc;//连接成功!
        public static string ConnFail;//连接失败!
        public static string PortOpenFail;//端口打开失败!
        public static string TestComplete;//测试完成!
        public static string StartNewAddr;//已经启用新地址!
        public static string RenewDB;//正在更新数据库
        public static string SearchEnd;//搜索被强制结束!
        public static string SearchEndFirst;//暂时无法关闭，请先终止搜索!
        //For ReadHistoricData
        public static string Read;//读取
        public static string Info;//信息
        public static string Time;//时间
        public static string Signal;//信号
        public static string Status;//状态
        public static string ReadHisyText;//读下位机历史事件
        public static string HisyCount;//历史事件总条数
        public static string ClearAfterRead;//读取后清除
        public static string PanelText;//下位机存储的历史数据
        public static string NoLoadEquip;//没有载入设备
        public static string ReadHisy;//地区历史数据中
        public static string NoHisyRead;//没有历史数据可以读取
        public static string ClearHisySucc;//已经成功清除下位机历史记录
        //For Public
        public static string Description;//信号描述
        public static string OriginalValue;//初始值
        public static string DataStart;//数据起始地址
        public static string RegisterType;//寄存器类型
        public static string ISContinuous;//是否连续
        public static string ISRecord;//是否记录
        public static string ISReport;//是否上报
        //For AnalogSignal
        public static string AnalogText;//模拟信号修改界面
        public static string ShowSignalInfo;//信号信息显示
        public static string SignalInfo;//信号信息
        public static string ModifyValue;//修改值
        public static string Did;//Did
        public static string SignalId;//信号ID
        public static string SignalName;//信号名
        public static string HighestRange;//最高量程
        public static string HigherRange;//高量程
        public static string LowestRange;//最低量程
        public static string LowerRange;//低量程
        public static string SaftArea;//安全区域
        public static string SaftLevel;//安全等级
        public static string FactorA;//比例因子A
        public static string FactorB;//比例因子B
        public static string DataLen;//数据长度
        public static string DataAnaly;//数据解析方式
        public static string AlarmConditions;//报警条件
        public static string Valch;//填充字符串
        public static string SignalIni;//信号初始值
        public static string AnaSignReadFreq;//模拟信号读取频率
        //For DigitalSignal
        public static string DigitalText;//数字信号修改界面
        public static string ShowDigitalInfo;//设置数字信号
        public static string ZeroDesc;//值0描述
        public static string OneDesc;//值1描述
        public static string OneValue;//值1意义
        public static string ZeroValue;//值0意义
        public static string SignDesc;//信号描述
        public static string SignAlarmCont;//信号报警条件
        public static string SignReadFreq;//信号读取频率
    }
    public class AlarmClass
    {
        public static string Time;//时间
        public static string Date;//日期
        public static string Year;//年份
        public static string Month;//月份
        public static string AlarmSource;//告警源
        public static string AlarmTime;//告警时间
        public static string AlarmStr;//报警信息
        public static string Warning;//警告
        public static string Error;//错误
        public static string Tip;//提示

        public static string Port;//告警信息内容：“端口”
        public static string PortOpenSuccess;//端口“打开成功”
        public static string PortOpenFail;//端口“打开失败”
        public static string CommResume;//“通讯恢复”
        public static string CommOK;//“通讯成功”
        public static string CommFail;//“通讯成功”
    }
    public class ChildUser_TabPage
    {
        public static string Tab2Text;//设备实时信息
        public static string Tab3Text;//设备实时曲线信息
        public static string Tab4Text;//设备历史曲线信息
        public static string Tab5Text;//设备历史数据信息
        public static string RealList;//实时列表显示
        public static string HisyList;//历史数据列表
        public static string HisyEvent;//历史事件列表
        public static string XTimeLimit;//X轴时间范围
    }
    public class UserControl
    {
        public static string PortWnd;//端口信息
        public static string AddDevWnd;//添加设备界面
        public static string SetDevWnd;//设备信息设置
        public static string DevBasicMsg;//填写设备基本信息
        public static string AnaList;//模拟信号列表
        public static string DigList;//数字信号列表
        //BasicMsg
        public static string Desc;//描述
        public static string Type;//类型
        public static string Unit;//单元号
        public static string State;//启用状态
        public static string ReTime;//重连次数
        public static string DevType;//设备类型
        public static string TimeOut;//超时时间
        public static string ScantTime;//扫描时间
        public static string RecoveyTime;//恢复时间
        public static string WriteTime;//写入数据时间
        public static string ReadTimeOut;//读超时时间
        public static string WriteTimeOut;//写超时时间
        public static string RefreshTimer;//定时器刷新时间
        //CardText
        public static string DevID;//设备编号
        public static string DevName;//设备名称
        public static string CommState;//通讯状态
        //Button
        public static string InsertDev;//插入设备
        public static string InsertPort;//插入端口
        public static string UpdatePort;//更新端口
        public static string SaveMod;//保存修改
        public static string AnaEdit;//模拟信号编辑
        public static string DigEdit;//数字信号编辑
        public static string EditSucc;//编辑完成
        //TabText
        public static string RealList;//实时列表
        public static string RealData;//实时数据//mark zq
        public static string RealView;//实时曲线
        public static string HisyView;//历史曲线
        public static string HisyData;//历史数据
        public static string HisEvent;//历史事件
        //Other
        public static string SysDefault;//系统默认
        public static string DescText;//请输入描述
        //Other1 by zq
        public static string PortName;//端口名称
        public static string DeviceName;//设备名称
        public static string CommunicateState;//通讯状态
        public static string RefreshInvert;//刷新时间
        public static string Suspend;//暂停刷新
        public static string Resume;//暂停刷新
        public static string FormView;//表格显示
        public static string CustomUIView;//表格显示
    }
    public class Desc
    {
        //Smachine
        public static string Msg;//信息
        public static string Fault_MainForm;//信息
        public static string IsDele;//是否删除 {0}吗？
        public static string NotOpen;//无法打开，原因可能是：
        public static string HelpFile;//帮助文件
        public static string NotSupportPDF;//本系统不支持PDF文件
        public static string NotExistFile;//该文件已经被转移或者损坏

        public static string CurrentVersion;//当前版本
        public static string BelongsToEAST;//所有解释权归易事特所有！

        public static string FillError;//信息填充错误
        public static string IniFail;//初始化失败:不能获取初始化数据!
        public static string CheckInputData;//输入有空值，请检查输入的数据!
        public static string InputDataError;//输入信息有误，请确保输入数据正确！


        //ChildUser_TabPage
        public static string ObtainFailure;//获取数据失败！原因如下:
        public static string TimeNotNull;//输入时间不能为空值
        public static string TimeNotData;//该段时间内不存在数据记录
        public static string TimeLimit;//起始时间必须小于当前时间
        public static string SelStartTime;//请先选择开始时间，并插入模拟信号类型失败确保结束时间大于开始时间!
        public static string Warning_ChildUserTab;//警告
        public static string Prompting_ChildUserTab;//提示
        public static string Fault_ChildUserTab;//错误
        public static string Suspend_ChildUserTab;//暂停
        public static string Resume_ChildUserTab;//恢复
        public static string EventTime;//事件时间
        public static string EventSource;//事件源
        public static string EventInfo;//事件信息

    }
    //排程字符串
    public class ScheduleStr {
        public static string scheduleManager;//排程管理
        public static string addScheduleTask;//添加任务
        public static string deleteScheduleTask;//删除任务
        public static string OK;//确定
        public static string task;//任务
        public static string taskDate;//任务日期
        public static string frequency;//频率
        public static string once;//一次
        public static string everyDay;//每天
        public static string BatteryTest;//电池测试
        public static string OpenTheInverter;// 开逆变器
        public static string CloseTheInverter;//关逆变器
        public static string cancel;//取消
        public static string Event;//事件
        public static string ExecutionTime;//执行时间
        public static string State;//状态
        public static string Lastexecution;//上次执行时间
        public static string Weekly;//每周 
        public static string Result;//执行结果
        public static string AwaitingExecution;//等待执行
        public static string Failure;//执行失败
        public static string success;//执行成功
        public static string MaxTask;//最多任务数

    }

}
