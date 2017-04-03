using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SolarMonitor.DeviceUI.Solar_PV;
using Model_Data;
using Model_Data.CommunicateEntity;
using SolarMonitor.DeviceUI;
using Communication.CommunicateToLowerMonitor;

namespace SolarMonitor.Solar_PV
{
    public partial class EASolar : DevExpress.XtraEditors.XtraUserControl, IDeviceUI
    {
        private CommDeviceEntity EASolar_Info = null;
        private string[] threePhase = { "A相", "B相", "C相" };
        private const int AnalogLen = 33;
        private const int DigitalLen = 23;
        private string VersionNumberName = "版本号：";//by 师姐
        private string VersionNumberText;
        private OneStateUserControl.SetInfo SystemStateInfo = new OneStateUserControl.SetInfo();

        //私有定义
        private enum SystemStateEnum
        {
            Off = 0x00,
            On = 0x01
        }
        private class SysTemStateDescribe
        {
            public static string Describe = Model_Data.Language.EaSolar.UnConnect;//1 未连接
            public static string Describe0 = Model_Data.Language.EaSolar.Connected;//2 通讯成功
            public static string Describe1 = Model_Data.Language.EaSolar.Disconnected;//3 通讯失败
        }

        //加载语言类信息
        private void LoadLanguageInfo()
        {
            //Tab
            xtraTabPage4.Text = Model_Data.Language.EaSolar.FaultInfo;
            xtraTabPage3.Text = Model_Data.Language.EaSolar.DevControl_Tab;
            xtraTabPage5.Text = Model_Data.Language.EaSolar.SystemSettings;
            xtraTabPage6.Text = Model_Data.Language.EaSolar.Real_timeInfo;

            layoutControlGroup2.Text = Model_Data.Language.EaSolar.SystemData;
            labelControl2.Text = Model_Data.Language.EaSolar.TotalGeneratedEnergy;
            labelControl3.Text = Model_Data.Language.EaSolar.DailyGeneratedEnergy;
            labelControl4.Text = Model_Data.Language.EaSolar.BatteryVoltage;
            labelControl5.Text = Model_Data.Language.EaSolar.PVPower;
            labelControl9.Text = Model_Data.Language.EaSolar.Temperature;
            VersionNumberName = Model_Data.Language.EaSolar.VersionNumber;//版本号：在下面的importantInt、refleshSystemData、 SetanaloData有相应改动
        }

        public EASolar()
        {
            InitializeComponent();
            LoadLanguageInfo();//语言类初始化函数
            ArrayInt(false);
            RefreshPagesShow();
            StartControlPage.SetInfoDelegate = SetInfoFunction;
            systemControlPage.SetInfoDelegate = SetInfoFunction;
        }

        #region 初始化部分

        private void ArrayInt(bool commustate)
        {
            //初始化 版本信息
            VersionNumberText = VersionNumberName;
            //初始化 显著信息（界面左边LED）
            InfoIni();
            //初始化 状态信息
            StatePageInt(commustate);
            //初始化 基本信息
            devRt1.Inition();
            //初始化 设备控制界面
            StartControlPage.LoadShowInfo(commustate);
            //初始化 系统控制界面
            systemControlPage.LoadShowInfo(commustate);
        }

        //
        private void InfoIni()
        {
            DigitalGaugeControl5.SetUserControlInfo("0");//温度

            lbBatteryVol.SetUserControlInfo("0");//电池电压

            lgPVpower.SetUserControlInfo("0");//PV功率

            lbDayEnergy.SetUserControlInfo("0");//日发电量

            lgTotalEnergy.SetUserControlInfo("0");//总发电量
        }
        //初始化2-状态信息
        private void StatePageInt(bool commustate)
        {
            //右边故障状态页面
            //0-AC状态
            FaultPage1.StateArray[0].Name = Model_Data.Language.EaSolar.ACStatus;
            FaultPage1.StateArray[0].Value = 3;
            //1-AC充电状态
            FaultPage1.StateArray[1].Name = Model_Data.Language.EaSolar.ACChargingStatus;
            FaultPage1.StateArray[1].Value = 3;
            //2-PV充电状态
            FaultPage1.StateArray[2].Name = Model_Data.Language.EaSolar.PVChargingStatus;
            FaultPage1.StateArray[2].Value = 3;
            //3-开机状态
            FaultPage1.StateArray[3].Name = Model_Data.Language.EaSolar.ONStatus;
            FaultPage1.StateArray[3].Value = 3;
            //4-AC频率模式
            FaultPage1.StateArray[4].Name = Model_Data.Language.EaSolar.ACFrequencyMode;
            FaultPage1.StateArray[4].Value = 3;
            //5-整流器工作模式
            FaultPage1.StateArray[5].Name = Model_Data.Language.EaSolar.RectiferWorkMode;
            FaultPage1.StateArray[5].Value = 3;
            //6-优先工作模式
            FaultPage1.StateArray[6].Name = Model_Data.Language.EaSolar.PriorityMode;
            FaultPage1.StateArray[6].Value = 3;

            int Index = 7;
            for (int i = 7; i < FaultPage1.StateArray.Length; i++)
            {
                FaultPage1.StateArray[Index].Name = "";
                FaultPage1.StateArray[Index].Value = 4;
                Index++;
            }
        }
        //初始化3-故障页面
        public void FaultPageInfoArrayInt(bool commstate)
        {
            if (commstate == true)
            {
                FaultPage1.StateArray[0].Value = 0;
                FaultPage1.StateArray[0].Name = "状态正常";
            }
            else
            {
                FaultPage1.StateArray[0].Value = 4;
                FaultPage1.StateArray[0].Name = "";
            }
            for (int i = 1; i < FaultPage1.StateArray.Length; i++)
            {
                FaultPage1.StateArray[i].Value = 4;
                FaultPage1.StateArray[i].Name = "";
            }
        }

        #endregion

        //页面更新部分
        private void RefreshPagesShow()
        {
            SystemState.SetUserControlInfo(SystemStateInfo);//设置系统状态
            FaultPage1.UpdateStateView();
        }


        #region 对外接口部分

        //对外接口函数
        public void SetParaMeter(DeviceBll device, DeviceModel dm)
        {
            //用来标志定时器在运行
            lbFlag.ForeColor = lbFlag.ForeColor == Color.Red ? Color.Blue : Color.Red;

            if (EASolar_Info == null)
            {
                EASolar_Info = device.Device;
            }
            if (device.Device.ComState == DivCommStateEnum.Failed)
            {
                SystemStateInfo.Name = SysTemStateDescribe.Describe1;
                SystemStateInfo.Value = 1;
            }
            else if (device.Device.ComState == DivCommStateEnum.Success)
            {
                SystemStateInfo.Name = SysTemStateDescribe.Describe0;
                SystemStateInfo.Value = 0;
            }
            else
            {
                SystemStateInfo.Name = SysTemStateDescribe.Describe;
                SystemStateInfo.Value = 2;
            }
            if (device.Device.ComState == Model_Data.CommunicateEntity.DivCommStateEnum.Success)
            {
                if (device.AnalogList != null && device.DigitalList != null)
                {
                    SetAnalogData(dm.Analog);
                    SetDigitalData(dm.Digital);
                    StartControlPage.LoadShowInfo(true);
                    systemControlPage.LoadShowInfo(true);
                }
            }
            else
            {
                ArrayInt(false);
            }
            RefreshPagesShow();

        }

        //设置模拟量
        private int SetAnalogData(List<AnalogModel> AnalogArray)
        {
            if (AnalogArray.Count < AnalogLen) return 0;

            //版本号
            VersionNumberText = VersionNumberName + float.Parse(AnalogArray[0].Value.ToString());

            devRt1.RefreshData(AnalogArray);

            try
            {
                //温度
                string[] tempStr = null;
                string temp = AnalogArray[5].Value.ToString();
                if (temp.LastIndexOf(".") > 0)
                {
                    tempStr = temp.Split(new char[1] { '.' });
                    temp = tempStr[0] + " " + "." + tempStr[1];
                }
                DigitalGaugeControl5.SetUserControlInfo(temp);//温度

                //电池电压
                temp = AnalogArray[8].Value.ToString();
                if (temp.LastIndexOf(".") > 0)
                {
                    tempStr = temp.Split(new char[1] { '.' });
                    temp = tempStr[0] + " " + "." + tempStr[1];
                }
                lbBatteryVol.SetUserControlInfo(temp);//电池电压

                //PV功率
                temp = AnalogArray[10].Value.ToString();
                if (temp.LastIndexOf(".") > 0)
                {
                    tempStr = temp.Split(new char[1] { '.' });
                    temp = tempStr[0] + " " + "." + tempStr[1];
                }
                lgPVpower.SetUserControlInfo(temp);//PV功率

                //日发电量
                temp = AnalogArray[11].Value.ToString();
                if (temp.LastIndexOf(".") > 0)
                {
                    tempStr = temp.Split(new char[1] { '.' });
                    temp = tempStr[0] + " " + "." + tempStr[1];
                }
                lbDayEnergy.SetUserControlInfo(temp);//日发电量

                //总发电量
                temp = AnalogArray[12].Value.ToString();
                if (temp.LastIndexOf(".") > 0)
                {
                    tempStr = temp.Split(new char[1] { '.' });
                    temp = tempStr[0] + " " + "." + tempStr[1];
                }
                lgTotalEnergy.SetUserControlInfo(temp);//总发电量

            }
            catch (Exception ex)
            {
                throw ex;
            }

            #region 设备当前时间

            string str1 = AnalogArray[22].Value.ToString();
            string str2 = AnalogArray[23].Value.ToString();
            string str3 = AnalogArray[24].Value.ToString();
            if (str1 != "0000" && str2 != "0000" && str3 != "0000")
            {
                string str_YM = "20" + str1.Substring(0, 2) + "-" + str1.Substring(2, 2) + "-";
                string str_DH = str2.Substring(0, 2) + " " + str2.Substring(2, 2) + ":";
                string str_MS = str3.Substring(0, 2) + ":" + str3.Substring(2, 2);
                DateTime dt2;
                if (DateTime.TryParse(str_YM + str_DH + str_MS, out dt2))
                    systemControlPage.ShowMachineTime(dt2);
            }
            #endregion

            return 0;
        }

        //设置数字量
        private void SetDigitalData(List<DigitalModel> DigitalArray)
        {
            if (DigitalArray.Count < 22)
                return;
            int DigitalIndex = 0;
            int SetIndex = 0;
            int FaultSetIndex = 7;
            //AC故障
            SetOneData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            //private 欠压
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);//欠压
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);//过压
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);//反接
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);//过载
            //AC充电开
            SetIndex = 1;
            SetData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            //PV充电开
            SetIndex = 2;
            SetZeroData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            //过温保护
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            //MPPT TGBT
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            //母线故障
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            //开机状态
            SetIndex = 3;
            SetZeroData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            //倒计时关机激活
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            //倒计时开机激活
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            //电池过充保护
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            //PV充电倒计时开启激活
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            //AC频率自振
            SetIndex = 4;
            SetData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            //PV和电池模式
            SetIndex = 5;
            SetData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            //pv优先工作模式
            SetIndex = 6;
            SetData(DigitalArray, ref  DigitalIndex, ref SetIndex);

            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
        }

        #endregion


        //设置1值表示异常0值表示正常的量
        private void SetOneData(List<DigitalModel> DigitalArray, ref int DigitalIndex, ref int SetIndex)
        {
            if (DigitalArray[DigitalIndex].Value == 1)
            {
                FaultPage1.StateArray[SetIndex].Name = FaultPage1.StateStrArray[DigitalIndex].Fault;
                FaultPage1.StateArray[SetIndex].Value = 1;
            }
            else
            {
                FaultPage1.StateArray[SetIndex].Name = FaultPage1.StateStrArray[DigitalIndex].Normal;
                FaultPage1.StateArray[SetIndex].Value = 0;
            }
            DigitalIndex++;
        }
        //设置0值表示异常1值表示正常的量
        private void SetZeroData(List<DigitalModel> DigitalArray, ref int DigitalIndex, ref int SetIndex)
        {
            if (DigitalArray[DigitalIndex].Value == 1)
            {
                FaultPage1.StateArray[SetIndex].Name = FaultPage1.StateStrArray[DigitalIndex].Fault;
                FaultPage1.StateArray[SetIndex].Value = 0;
            }
            else
            {
                FaultPage1.StateArray[SetIndex].Name = FaultPage1.StateStrArray[DigitalIndex].Normal;
                FaultPage1.StateArray[SetIndex].Value = 1;
            }
            DigitalIndex++;
        }
        //设置0值/1值表示正常的量
        private void SetData(List<DigitalModel> DigitalArray, ref int DigitalIndex, ref int SetIndex)
        {
            if (DigitalArray[DigitalIndex].Value == 1)
            {
                FaultPage1.StateArray[SetIndex].Name = FaultPage1.StateStrArray[DigitalIndex].Fault;
                FaultPage1.StateArray[SetIndex].Value = 0;
            }
            else
            {
                FaultPage1.StateArray[SetIndex].Name = FaultPage1.StateStrArray[DigitalIndex].Normal;
                FaultPage1.StateArray[SetIndex].Value = 0;
            }
            DigitalIndex++;
        }
        //设置那些只有错误意义的状态
        private void SetOneFaultDigital(List<DigitalModel> DigitalArray, ref int DigitalIndex, ref int FaultSetIndex)
        {
            if (DigitalArray[DigitalIndex].Value == 1)
            {
                FaultPage1.StateArray[FaultSetIndex].Name = FaultPage1.StateStrArray[DigitalIndex].Fault;
                FaultPage1.StateArray[FaultSetIndex].Value = 1;
                FaultSetIndex++;
            }
            else
            {
                FaultPage1.StateArray[FaultSetIndex].Value = 4;
            }
            DigitalIndex++;
        }

        //设置遥控量部分
        private void SetInfoFunction(object SetInfo)
        {
            CommDeviceModbuseControlEntity TempEntity;
            if (SetInfo is CommDeviceModbuseControlEntity)
            {
                TempEntity = (CommDeviceModbuseControlEntity)SetInfo;
                if (EASolar_Info != null)
                {
                    TempEntity.DivID = EASolar_Info.UnitId;
                    DeviceObj.SetInfoFunction(TempEntity);
                }
            }
        }

    }

}
