using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Model_Data.Language
{
    public class LoadLanguageEntity
    {
        public static void LoadLanguageInfo(string LanSign,string pathName)//para2：xml文件路径
        {
            XmlDataDocument xmlDoc = new XmlDataDocument();            
            xmlDoc.Load(pathName);//xml位于debug文件夹下，打包时用
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("root").ChildNodes;//获取该节点的所有子节点
            foreach (XmlNode xn in nodeList)
            {
                switch (xn.Name)
                {
                    case "PublicInfo":
                        {
                            #region Public Information
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "DateTime":
                                        PublicInfo.DateTime = xn1.InnerText;break;
                                    case "Port":
                                        PublicInfo.Port = xn1.InnerText; break;
                                    case "DevID":
                                        PublicInfo.DevID = xn1.InnerText; break;
                                    case "PortID":
                                        PublicInfo.PortID = xn1.InnerText; break;
                                    case "SignalId":
                                        PublicInfo.SignID = xn1.InnerText; break;
                                    case "DevName":
                                        PublicInfo.DevName = xn1.InnerText; break;
                                    case "PortName":
                                        PublicInfo.PortName = xn1.InnerText; break;
                                    case "SignalName":
                                        PublicInfo.SignName = xn1.InnerText; break;
                                    case "SignDesc":
                                        PublicInfo.SignDesc = xn1.InnerText; break;
                                    case "SignalUnit":
                                        PublicInfo.SignalUnit = xn1.InnerText; break;
                                    case "SignalType":
                                        PublicInfo.SignalType = xn1.InnerText; break;
                                    case "DevTypeID":
                                        PublicInfo.DevTypeID = xn1.InnerText; break;

                                    case "OK":
                                        PublicInfo.OK = xn1.InnerText; break;
                                    case "View":
                                        PublicInfo.View = xn1.InnerText;break;
                                    case "Start":
                                        PublicInfo.Start = xn1.InnerText; break;
                                    case "Pause":
                                        PublicInfo.Pause = xn1.InnerText; break;
                                    case "Modify":
                                        PublicInfo.Modify = xn1.InnerText; break;
                                    case "Cancel":
                                        PublicInfo.Cancel = xn1.InnerText; break;
                                    case "Return":
                                        PublicInfo.Return = xn1.InnerText; break;
                                    case "Delete":
                                        PublicInfo.Delete = xn1.InnerText;break;
                                    case "Recover":
                                        PublicInfo.Recover = xn1.InnerText; break;
                                    case "Spntime":
                                        PublicInfo.Spntime = xn1.InnerText; break;
                                    case "ISModify":
                                        PublicInfo.ISModify = xn1.InnerText; break;
                                    case "UpdateSign":
                                        PublicInfo.UpdateSign = xn1.InnerText;break;

                                    case "CommuState":
                                        PublicInfo.CommuState = xn1.InnerText;break;
                                    case "SeleSign":
                                        PublicInfo.SeleSign = xn1.InnerText;break;
                                    case "EndTime":
                                        PublicInfo.EndTime = xn1.InnerText; break;
                                    case "StartTime":
                                        PublicInfo.StartTime = xn1.InnerText; break;
                                    case "ViewCurve":
                                        PublicInfo.ViewCurve = xn1.InnerText; break;
                                    case "ClickLoad":
                                        PublicInfo.ClickLoad = xn1.InnerText;break;
                                    case "InsertDB":
                                        PublicInfo.InsertDB = xn1.InnerText;break;
                                    case "SaveAndNext":
                                        PublicInfo.SaveAndNext = xn1.InnerText;break;
                                    case "SaveAndExit":
                                        PublicInfo.SaveAndExit = xn1.InnerText;break;
                                    case "NullWrite":
                                        PublicInfo.NullWrite = xn1.InnerText;break;
                                    case "Ana":
                                        PublicInfo.Ana = xn1.InnerText;break;
                                    case "Dig":
                                        PublicInfo.Dig = xn1.InnerText;break;
                                    case "Year":
                                        PublicInfo.Year = xn1.InnerText; break;
                                    case "Month":
                                        PublicInfo.Month = xn1.InnerText; break;
                                    case "Day":
                                        PublicInfo.Day = xn1.InnerText; break;
                                    case "Hour":
                                        PublicInfo.Hour = xn1.InnerText; break;
                                    case "Minute":
                                        PublicInfo.Minute = xn1.InnerText; break;
                                    case "Second":
                                        PublicInfo.Second = xn1.InnerText; break;

                                    case "SelPort":
                                        PublicInfo.SelPort = xn1.InnerText; break;
                                    case "SelDev":
                                        PublicInfo.SelDev = xn1.InnerText; break;
                                    case "SelSign":
                                        PublicInfo.SelSign = xn1.InnerText; break;

                                    case "NoRefresh":
                                        PublicInfo.NoRefresh = xn1.InnerText;break;

                                    //ListForm
                                    case "DevReal-timeData_ListForm":
                                        PublicInfo.DevRealtimeData_ListForm = xn1.InnerText;break;
                                    case "ID_ListForm":
                                        PublicInfo.ID_ListForm = xn1.InnerText; break;
                                    case "SignalName_ListForm":
                                        PublicInfo.SignalName_ListForm = xn1.InnerText; break;
                                    case "SignalValue_ListForm":
                                        PublicInfo.SignalValue_ListForm = xn1.InnerText; break;
                                    case "Unit_ListForm":
                                        PublicInfo.Unit_ListForm = xn1.InnerText;break;
                                    case "SignalTime_ListForm":
                                        PublicInfo.SignalTime_ListForm = xn1.InnerText; break;
                                    //历史数据界面加入打印导出按钮
                                    case "Print":
                                        PublicInfo.Print = xn1.InnerText; break;
                                    case "Export":
                                        PublicInfo.Export = xn1.InnerText; break;
                                    case "NoDataFound":
                                        PublicInfo.NoDataFound = xn1.InnerText; break;
                                    case "Info":
                                        PublicInfo.Info = xn1.InnerText; break;
                                }
                            }
                            #endregion
                        }
                        break;
                    case "AlarmClass":
                        {
                            #region AlarmClass
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "Tip":
                                        AlarmClass.Tip = xn1.InnerText; break;
                                    case "Error":
                                        AlarmClass.Error = xn1.InnerText; break;
                                    case "Warn":
                                        AlarmClass.Warning = xn1.InnerText; break;
                                    case "Time":
                                        AlarmClass.Time = xn1.InnerText;break;
                                    case "Date":
                                        AlarmClass.Date = xn1.InnerText;break;
                                    case "AlarmSource":
                                        AlarmClass.AlarmSource = xn1.InnerText; break;
                                    case "AlarmTime":
                                        AlarmClass.AlarmTime = xn1.InnerText;break;
                                    case "AlarmStr":
                                        AlarmClass.AlarmStr = xn1.InnerText;break;
                                    case "PortOpenedSuccess":
                                        AlarmClass.PortOpenSuccess = xn1.InnerText; break;
                                    case "PortOpenedFail":
                                        AlarmClass.PortOpenFail = xn1.InnerText; break;
                                    case "Port":
                                        AlarmClass.Port = xn1.InnerText;break;
                                    case "CommResume":
                                        AlarmClass.CommResume = xn1.InnerText; break;
                                    case "CommOK":
                                        AlarmClass.CommOK = xn1.InnerText; break;
                                    case "CommFail":
                                        AlarmClass.CommFail = xn1.InnerText; break;
                                }
                            }
                            #endregion
                        }
                        break;
                    case "SmachineForm":
                        {
                            #region SmachineForm
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "StartCommunicating":
                                        SmachineForm.StartCommunicating = xn1.InnerText; break;
                                    case "StopCommunicating":
                                        SmachineForm.StopCommunicating = xn1.InnerText; break;
                                    case "ParaSetting":
                                        SmachineForm.ParaSetting = xn1.InnerText; break;
                                    case "ReadHisEvent":
                                        SmachineForm.ReadHisEvent = xn1.InnerText; break;
                                    case "AddrSearching":
                                        SmachineForm.AddrSearching = xn1.InnerText; break;
                                    case "OpenInfoWnd":
                                        SmachineForm.OpenInfoWnd = xn1.InnerText; break;
                                    case "CloseInfoWnd":
                                        SmachineForm.CloseInfoWnd = xn1.InnerText; break;    
                                    case "Exit":
                                        SmachineForm.Exit = xn1.InnerText; break;
                                    case "SystemRelated":
                                        SmachineForm.SystemRelated = xn1.InnerText; break;
                                    case "OperateDocument":
                                        SmachineForm.OperateDocument = xn1.InnerText; break;
                                    case "Now":
                                        SmachineForm.Now = xn1.InnerText; break;
                                    case "Port":
                                        SmachineForm.Port = xn1.InnerText; break;
                                    case "Interval":
                                        SmachineForm.Interval = xn1.InnerText; break;
                                    case "Event":
                                        SmachineForm.Event = xn1.InnerText; break;
                                }
                            }
                            #endregion
                        }
                        break;
                    case "EASolar_GF8000":
                        {
                            #region SmachineForm
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "SystemData":
                                        EaSolar.SystemData = xn1.InnerText; break;
                                    case "UnConnect":
                                        EaSolar.UnConnect = xn1.InnerText; break;
                                    case "Connected":
                                        EaSolar.Connected = xn1.InnerText; break;
                                    case "Disconnected":
                                        EaSolar.Disconnected = xn1.InnerText; break;
                                    case "TotalGeneratedEnergy":
                                        EaSolar.TotalGeneratedEnergy = xn1.InnerText; break;
                                    case "DailyGeneratedEnergy":
                                        EaSolar.DailyGeneratedEnergy = xn1.InnerText; break;
                                    case "BatteryVoltage":
                                        EaSolar.BatteryVoltage = xn1.InnerText; break;
                                    case "PVPower":
                                        EaSolar.PVPower = xn1.InnerText; break;
                                    case "Temperature":
                                        EaSolar.Temperature = xn1.InnerText; break;
                                    case "VersionNumber":
                                        EaSolar.VersionNumber = xn1.InnerText; break;
                                    case "SetSuccess":
                                        EaSolar.SetSuccess = xn1.InnerText;break;//NEW ADD
                                    case "SetFailure":
                                        EaSolar.SetFailure = xn1.InnerText;break;//NEW ADD
                                    case "Prompt":
                                        EaSolar.Prompt = xn1.InnerText; break;//NEW ADD
                                    case "AreYouSureConfig":
                                        EaSolar.AreYouSureConfig = xn1.InnerText; break;//NEW ADD
                                    //Tab
                                    case "ACInfo_Tab":
                                        EaSolar.ACInfo_Tab = xn1.InnerText; break;
                                    case "Real-timeInfo":
                                        EaSolar.Real_timeInfo = xn1.InnerText; break;
                                    case "RatedInfo_Tab":
                                        EaSolar.RatedInfo_Tab = xn1.InnerText; break;
                                    case "FaultInfo":
                                        EaSolar.FaultInfo = xn1.InnerText; break;
                                    case "DevControl_Tab":
                                        EaSolar.DevControl_Tab = xn1.InnerText; break;
                                    case "SystemSettings":
                                        EaSolar.SystemSettings = xn1.InnerText; break;
                                    //ACInfoUC
                                    case "ACInfo":
                                        EaSolar.ACInfo = xn1.InnerText; break;
                                    case "ACInputVoltage":
                                        EaSolar.ACInputVoltage = xn1.InnerText; break;
                                    case "ACOutputVoltage":
                                        EaSolar.ACOutputVoltage = xn1.InnerText; break;
                                    case "ACOutputFrequency":
                                        EaSolar.ACOutputFrequency = xn1.InnerText; break;
                                    case "ACInputEnergy":
                                        EaSolar.ACInputEnergy = xn1.InnerText; break;
                                    case "ACOutputEnergy":
                                        EaSolar.ACOutputEnergy = xn1.InnerText; break;
                                    //Real-time Info
                                    case "PVInfo":
                                        EaSolar.PVInfo = xn1.InnerText; break;
                                    case "PVInputVoltage":
                                        EaSolar.PVInputVoltage = xn1.InnerText; break;
                                    case "PVChargingCurrent":
                                        EaSolar.PVChargingCurrent = xn1.InnerText; break;
                                    case "Percentage":
                                        EaSolar.Percentage = xn1.InnerText; break;
                                    case "LoadPercentage":
                                        EaSolar.LoadPercentage = xn1.InnerText; break;
                                    case "BatteryCapacityLevel":
                                        EaSolar.BatteryCapacityLevel = xn1.InnerText; break;
                                    //RatedInfo
                                    case "RatedInfo":
                                        EaSolar.RatedInfo = xn1.InnerText; break;
                                    case "RatedVol":
                                        EaSolar.RatedVol = xn1.InnerText; break;
                                    case "RatedBatteryVol":
                                        EaSolar.RatedBatteryVol = xn1.InnerText; break;
                                    case "ProductInfo":
                                        EaSolar.ProductInfo = xn1.InnerText; break;
                                    case "ProductType":
                                        EaSolar.ProductType = xn1.InnerText; break;
                                    case "ProductModel":
                                        EaSolar.ProductModel = xn1.InnerText; break;
                                    case "ChargingCurrentLevel":
                                        EaSolar.ChargingCurrentLevel = xn1.InnerText; break;
                                    case "CommuVersion":
                                        EaSolar.CommuVersion = xn1.InnerText; break;
                                    case "ControlVersion":
                                        EaSolar.ControlVersion = xn1.InnerText; break;
                                    //FaultInfo
                                    case "ACStatus":
                                        EaSolar.ACStatus = xn1.InnerText; break;
                                    case "ACNormal":
                                        EaSolar.ACNormal = xn1.InnerText; break;
                                    case "ACFault":
                                        EaSolar.ACFault = xn1.InnerText; break;
                                    case "PVLowVoltage":
                                        EaSolar.PVLowVoltage = xn1.InnerText; break;
                                    case "PVOverVoltage":
                                        EaSolar.PVOverVoltage = xn1.InnerText; break;
                                    case "PVReversed":
                                        EaSolar.PVReversed = xn1.InnerText; break;
                                    case "BatteryLowVoltage":
                                        EaSolar.BatteryLowVoltage = xn1.InnerText; break;
                                    case "BatteryOverDisCharge":
                                        EaSolar.BatteryOverDisCharge = xn1.InnerText; break;
                                    case "BatteryFault":
                                        EaSolar.BatteryFault = xn1.InnerText; break;
                                    case "OverLoad":
                                        EaSolar.OverLoad = xn1.InnerText; break;
                                    case "ACChargingStatus":
                                        EaSolar.ACChargingStatus = xn1.InnerText; break;
                                    case "ACChargingOff":
                                        EaSolar.ACChargingOff = xn1.InnerText; break;
                                    case "ACChargingOn":
                                        EaSolar.ACChargingOn = xn1.InnerText; break;
                                    case "PVChargingStatus":
                                        EaSolar.PVChargingStatus = xn1.InnerText; break;
                                    case "PVChargingOff":
                                        EaSolar.PVChargingOff = xn1.InnerText; break;
                                    case "PVChargingOn":
                                        EaSolar.PVChargingOn = xn1.InnerText; break;
                                    case "ThermalProtection":
                                        EaSolar.ThermalProtection = xn1.InnerText; break;
                                    case "MPPT_IGBTProtect":
                                        EaSolar.MPPT_IGBTProtect = xn1.InnerText; break;
                                    case "BUSFault":
                                        EaSolar.BUSFault = xn1.InnerText; break;
                                    case "ON_OFFStatus":
                                        EaSolar.ON_OFFStatus = xn1.InnerText; break;
                                    case "ONStatus":
                                        EaSolar.ONStatus = xn1.InnerText; break;
                                    case "OFFStatus":
                                        EaSolar.OFFStatus = xn1.InnerText; break;
                                    case "ShutDownActive":
                                        EaSolar.ShutDownActive = xn1.InnerText; break;
                                    case "PowerOnActive":
                                        EaSolar.PowerOnActive = xn1.InnerText; break;
                                    case "BatteryOverChargeProtect":
                                        EaSolar.BatteryOverChargeProtect = xn1.InnerText; break;
                                    case "ActivateCountDownPVCharging":
                                        EaSolar.ActivateCountDownPVCharging = xn1.InnerText; break;
                                    case "ACFrequencyMode":
                                        EaSolar.ACFrequencyMode = xn1.InnerText; break;
                                    case "ACFrequencySelf-oscillationMode":
                                        EaSolar.ACFrequencySelfoscillationMode = xn1.InnerText; break;
                                    case "ACFrequencyPhase-lockedMode":
                                        EaSolar.ACFrequencyPhaselockedMode = xn1.InnerText; break;
                                    case "RectiferWorkMode":
                                        EaSolar.RectiferWorkMode = xn1.InnerText; break;
                                    case "PVAndBatteryMode":
                                        EaSolar.PVAndBatteryMode = xn1.InnerText; break;
                                    case "PriorityMode":
                                        EaSolar.PriorityMode = xn1.InnerText; break;
                                    case "PVPriorityMode":
                                        EaSolar.PVPriorityMode = xn1.InnerText; break;
                                    case "ACPriorityMode":
                                        EaSolar.ACPriorityMode = xn1.InnerText; break;
                                    case "SPIFault":
                                        EaSolar.SPIFault = xn1.InnerText; break;
                                    case "BatteryTestMode":
                                        EaSolar.BatteryTestMode = xn1.InnerText; break;
                                    //DevControl
                                    case "DevControlInfo":
                                        EaSolar.DevControlInfo=xn1.InnerText;break;
                                    case "BatteryTest1Min":
                                        EaSolar.BatteryTest1Min = xn1.InnerText; break;
                                    case "BatteryLowVolTest":
                                        EaSolar.BatteryLowVolTest = xn1.InnerText; break;
                                    case "BatteryTestCancel":
                                        EaSolar.BatteryTestCancel = xn1.InnerText; break;
                                    case "ShutDownCanceling":
                                        EaSolar.ShutDownCanceling = xn1.InnerText; break;
                                    case "SwitchOn":
                                        EaSolar.SwitchOn = xn1.InnerText; break;
                                    case "ShutDown":
                                        EaSolar.ShutDown = xn1.InnerText; break;
                                    case "Sleep":
                                        EaSolar.Sleep = xn1.InnerText; break;
                                    case "OK_DevControl":
                                        EaSolar.OK_DevControl = xn1.InnerText; break;
                                    case "Cancel_DevControl":
                                        EaSolar.Cancel_DevControl = xn1.InnerText; break;
                                    //SystemSetting
                                    case "SystemInfoSetting":
                                        EaSolar.SystemInfoSetting = xn1.InnerText; break;
                                    case "DevCommAddr":
                                        EaSolar.DevCommAddr = xn1.InnerText; break;
                                    case "DevCommBaud":
                                        EaSolar.DevCommBaud = xn1.InnerText; break;
                                    case "ModbusProtocolMode":
                                        EaSolar.ModbusProtocolMode = xn1.InnerText; break;
                                    case "ParityBitCheck":
                                        EaSolar.ParityBitCheck = xn1.InnerText; break;
                                    case "StopBitCheck":
                                        EaSolar.StopBitCheck = xn1.InnerText; break;
                                    case "DateSettings":
                                        EaSolar.DateSettings = xn1.InnerText; break;
                                    case "DevCurrentTime":
                                        EaSolar.DevCurrentTime = xn1.InnerText; break;
                                    case "DaySetting_Radio":
                                        EaSolar.DaySetting_Radio = xn1.InnerText; break;
                                    case "DaySetting":
                                        EaSolar.DaySetting = xn1.InnerText; break;
                                    case "ClearRecords":
                                        EaSolar.ClearRecords = xn1.InnerText; break;
                                    case "OK_SystemSetting":
                                        EaSolar.OK_SystemSetting = xn1.InnerText; break;
                                    case "Cancel_SystemSetting":
                                        EaSolar.Cancel_SystemSetting = xn1.InnerText; break;
                                    case "SelectTheRightItem":
                                        EaSolar.SelectTheRightItem = xn1.InnerText; break;
                                }
                            }
                            #endregion//Added by zq
                        }
                        break;
                    case "AlarmSet":
                        {
                            #region AlarmSet
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "Text":
                                        AlarmSet.Text = xn1.InnerText;break;
                                    case "Host":
                                        AlarmSet.Host = xn1.InnerText; break;
                                    case "Subject":
                                        AlarmSet.Subject = xn1.InnerText; break;
                                    case "SubText":
                                        AlarmSet.SubText = xn1.InnerText; break;
                                    case "Number":
                                        AlarmSet.Number = xn1.InnerText; break;
                                    case "Password":
                                        AlarmSet.Password = xn1.InnerText; break;
                                    case "EmailSet":
                                        AlarmSet.EmailSet = xn1.InnerText; break;
                                    case "SMSSet":
                                        AlarmSet.SMSSet= xn1.InnerText; break;
                                    case "PhoneSet":
                                        AlarmSet.PhoneSet = xn1.InnerText; break;
                                    case "CCAddr":
                                        AlarmSet.CCAddr = xn1.InnerText; break;
                                    case "BCCAddr":
                                        AlarmSet.BCCAddr = xn1.InnerText; break;
                                    case "ToAddr":
                                        AlarmSet.ToAddr = xn1.InnerText; break;
                                    case "ToMsg":
                                        AlarmSet.ToMsg = xn1.InnerText; break;
                                    case "FromAddr":
                                        AlarmSet.FromAddr = xn1.InnerText; break;
                                    case "FromName":
                                        AlarmSet.FromName = xn1.InnerText; break;
                                    case "TimeOut":
                                        AlarmSet.TimeOut = xn1.InnerText; break;
                                    case "EmailAlarmSet":
                                        AlarmSet.EmailAlarmSet = xn1.InnerText; break;
                                    case "SMSAlarmSet":
                                        AlarmSet.SMSAlarmSet = xn1.InnerText; break;
                                    case "PhoneAlarmSet":
                                        AlarmSet.PhoneAlarmSet = xn1.InnerText; break;
                                    case "StartEmail":
                                        AlarmSet.StartEmail = xn1.InnerText; break;
                                    case "StartSMS":
                                        AlarmSet.StartSMS = xn1.InnerText; break;
                                    case "StartPhone":
                                        AlarmSet.StartPhone = xn1.InnerText; break;
                                    case "StartDev":
                                        AlarmSet.StartDev = xn1.InnerText; break;
                                    case "StartSig":
                                        AlarmSet.StartSig = xn1.InnerText; break;
                                    case "SMSSaveSucc":
                                        AlarmSet.SMSSaveSucc = xn1.InnerText; break;
                                    case "PhoneSaveSucc":
                                        AlarmSet.PhoneSaveSucc = xn1.InnerText; break;
                                    case "EmailSaveSucc":
                                        AlarmSet.EmailSaveSucc = xn1.InnerText; break;
                                    case "IllegalAdde":
                                        AlarmSet.IllegalAdde = xn1.InnerText; break;
                                    case "CorrectTimeout":
                                        AlarmSet.CorrectTimeout = xn1.InnerText; break;
                                }
                            }
                            #endregion
                        }
                        break;
                    case "SerialInfo":
                        {
                            #region SerialInfo
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "Serial":
                                       Serial_Info_Set.Serial = xn1.InnerText;break;
                                    case "SerialNum":
                                        Serial_Info_Set.SerialNum = xn1.InnerText; break;
                                    case "BaudRate":
                                        Serial_Info_Set.BaudRate = xn1.InnerText; break;
                                    case "DataBits":
                                        Serial_Info_Set.DataBit = xn1.InnerText; break;
                                    case "StopBits":
                                        Serial_Info_Set.StopBit = xn1.InnerText; break;
                                    case "IPAddr":
                                        Serial_Info_Set.IPAddr = xn1.InnerText; break;
                                    case "Parity":
                                        Serial_Info_Set.Parity = xn1.InnerText; break;
                                    case "BasicInfo":
                                        Serial_Info_Set.BasicInfo = xn1.InnerText; break;
                                    case "SerialInfo":
                                        Serial_Info_Set.SerialInfo = xn1.InnerText; break;
                                    case "ReTime":
                                        Serial_Info_Set.ReTime = xn1.InnerText; break;
                                    case "TCPIPInfo":
                                        Serial_Info_Set.TCPIPInfo = xn1.InnerText; break;

                                    case "OK":
                                        Serial_Info_Set.BtnOK = xn1.InnerText; break;
                                    case "Cancel":
                                        Serial_Info_Set.BtnCancel = xn1.InnerText; break;
                                    case "AdvancedOption":
                                        Serial_Info_Set.BtnAdvancedOption = xn1.InnerText; break;

                                    case "PortNotSupport"://暂时不支持该端口
                                        Serial_Info_Set.PortNotSupport = xn1.InnerText; break;
                                    case "NoEmptyStr"://不能输入空字符
                                        Serial_Info_Set.NoEmptyStr = xn1.InnerText; break;
                                    case "FailSelection"://选择失败
                                        Serial_Info_Set.FailSelection = xn1.InnerText; break;
                                    case "WaitAndScanningTimeInfo1":
                                        Serial_Info_Set.WaitAndScanningTimeInfo1 = xn1.InnerText; break;
                                    case "WaitAndScanningTimeInfo2":
                                        Serial_Info_Set.WaitAndScanningTimeInfo2 = xn1.InnerText; break;
                                    case "WaitAndScanningTimeInfo3":
                                        Serial_Info_Set.WaitAndScanningTimeInfo3 = xn1.InnerText; break;
                                    case "Warning":
                                        Serial_Info_Set.Warning = xn1.InnerText; break;

                                    case "Port":
                                        Serial_Info_Set.Port = xn1.InnerText; break;
                                    case "PortName":
                                        Serial_Info_Set.PortName_Ad = xn1.InnerText; break;
                                    case "Description":
                                        Serial_Info_Set.Description = xn1.InnerText; break;
                                    case "ScanningInterval":
                                        Serial_Info_Set.ScanningInterval = xn1.InnerText; break;
                                    case "OverTime":
                                        Serial_Info_Set.OverTime = xn1.InnerText; break;
                                    case "ReconnectionTimes":
                                        Serial_Info_Set.ReconnectionTimes = xn1.InnerText; break;
                                    case "ResumeTime":
                                        Serial_Info_Set.ResumeTime = xn1.InnerText; break;
                                    case "ReadOverTime":
                                        Serial_Info_Set.ReadOverTime = xn1.InnerText; break;
                                    case "WriteOverTime":
                                        Serial_Info_Set.WriteOverTime = xn1.InnerText; break;
                                    case "Device":
                                        Serial_Info_Set.Device = xn1.InnerText; break;
                                    case "DevName":
                                        Serial_Info_Set.DevName = xn1.InnerText; break;
                                    case "DevAddr":
                                        Serial_Info_Set.DevAddr = xn1.InnerText; break;
                                    case "WriteDataInterval":
                                        Serial_Info_Set.WriteDataInterval = xn1.InnerText; break;
                                    case "Ok_Ad":
                                        Serial_Info_Set.Ok_Ad = xn1.InnerText; break;
                                    case "Cancel_Ad":
                                        Serial_Info_Set.Cancel_Ad = xn1.InnerText; break;
                                    case "NoNullInput":
                                        Serial_Info_Set.NoNullInput = xn1.InnerText; break;
                                }
                            }
                            #endregion
                        }
                        break;
                    case "ChildForm":
                        {
                            #region ChildForm
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xnl1 in xnl)
                            {
                                switch (xnl1.Name)
                                {
                                    #region For ParaSetting
                                    case "ParaSetting":
                                        ChildForm.ParaSetting = xnl1.InnerText; break;
                                    case "ConnectSetting":
                                        ChildForm.ConnectSetting = xnl1.InnerText; break;
                                    case "PortSelect":
                                        ChildForm.PortSelect = xnl1.InnerText; break;
                                    case "CommProtocol":
                                        ChildForm.CommProtocol = xnl1.InnerText; break;
                                    case "DevSelection":
                                        ChildForm.DevSelection = xnl1.InnerText; break;
                                    case "TCPIPSetting":
                                        ChildForm.TCPIPSetting = xnl1.InnerText; break;
                                    case "IPAddr":
                                        ChildForm.IPAddr = xnl1.InnerText; break;
                                    case "PortNum":
                                        ChildForm.PortNum = xnl1.InnerText; break;
                                    #endregion
                                    #region For AutoSearchAddr
                                    case "Addr":
                                        ChildForm.Addr = xnl1.InnerText;break;
                                    case "Termination":
                                        ChildForm.Termination = xnl1.InnerText; break;
                                    case "SearchText":
                                        ChildForm.SearchText = xnl1.InnerText; break;
                                    case "AppAddr":
                                        ChildForm.AppAddr = xnl1.InnerText; break;
                                    case "SearchDev":
                                        ChildForm.SearchDev = xnl1.InnerText; break;
                                    case "InPrepare":
                                        ChildForm.InPrepare = xnl1.InnerText; break;
                                    case "ConnSucc":
                                        ChildForm.ConnSucc = xnl1.InnerText; break;
                                    case "ConnFail":
                                        ChildForm.ConnFail = xnl1.InnerText; break;
                                    //case "APortOpenFailddr":
                                    case "PortOpenFail"://mark（08-21）
                                        ChildForm.PortOpenFail = xnl1.InnerText; break;
                                    case "TestComplete":
                                        ChildForm.TestComplete = xnl1.InnerText; break;
                                    case "StartNewAddr":
                                        ChildForm.StartNewAddr = xnl1.InnerText; break;
                                    case "RenewDB":
                                        ChildForm.RenewDB = xnl1.InnerText; break;
                                    case "SearchEnd":
                                        ChildForm.SearchEnd = xnl1.InnerText; break;
                                    case "SearchEndFirst":
                                        ChildForm.SearchEndFirst = xnl1.InnerText; break;    
                                    #endregion
                                    #region For ReadHistoricData
                                    case "Read":
                                        ChildForm.Read = xnl1.InnerText; break;
                                    case "Info":
                                        ChildForm.Info = xnl1.InnerText; break;
                                    case "Time":
                                        ChildForm.Time = xnl1.InnerText; break;
                                    case "Signal":
                                        ChildForm.Signal = xnl1.InnerText; break;
                                    case "Status":
                                        ChildForm.Status = xnl1.InnerText; break;
                                    case "ReadHisyText":
                                        ChildForm.ReadHisyText = xnl1.InnerText; break;
                                    case "HisyCount":
                                        ChildForm.HisyCount = xnl1.InnerText; break;
                                    case "ClearAfterRead":
                                        ChildForm.ClearAfterRead = xnl1.InnerText; break;
                                    case "PanelText":
                                        ChildForm.PanelText = xnl1.InnerText; break;
                                    case "NoLoadEquip":
                                        ChildForm.NoLoadEquip = xnl1.InnerText; break;
                                    case "ReadHisy":
                                        ChildForm.ReadHisy = xnl1.InnerText; break;
                                    case "NoHisyRead":
                                        ChildForm.NoHisyRead = xnl1.InnerText; break;
                                    case "ClearHisySucc":
                                        ChildForm.ClearHisySucc = xnl1.InnerText; break;
                                    #endregion
                                    case "Analog":
                                        {
                                            XmlNodeList xnll = xn.ChildNodes;
                                            foreach (XmlNode xnll1 in xnl)
                                            {
                                                switch (xnll1.Name)
                                                {
                                                    case "Text":
                                                        ChildForm.AnalogText = xnll1.InnerText;break;
                                                    case "ShowSignalInfo":
                                                        ChildForm.ShowSignalInfo = xnll1.InnerText;break;
                                                    case "SignalInfo":
                                                        ChildForm.SignalInfo = xnll1.InnerText;break;
                                                    case "OriginalValue":
                                                        ChildForm.OriginalValue = xnll1.InnerText;break;
                                                    case "ModifyValue":
                                                        ChildForm.ModifyValue = xnll1.InnerText;break;
                                                    case "Did":
                                                        ChildForm.Did = xnll1.InnerText;break;
                                                    case "Desc":
                                                        ChildForm.Description = xnll1.InnerText;break;
                                                    case "HighestRange":
                                                        ChildForm.HighestRange = xnll1.InnerText;break;
                                                    case "HigherRange":
                                                        ChildForm.HigherRange = xnll1.InnerText;break;
                                                    case "LowestRange":
                                                        ChildForm.LowestRange = xnll1.InnerText;break;
                                                    case "LowerRange":
                                                        ChildForm.LowerRange = xnll1.InnerText;break;
                                                    case "SafeArea":
                                                        ChildForm.SaftArea = xnll1.InnerText;break;
                                                    case "SafeLevel":
                                                        ChildForm.SaftLevel = xnll1.InnerText;break;
                                                    case "FactorA":
                                                        Language.ChildForm.FactorA = xnll1.InnerText;break;
                                                    case "FactorB":
                                                        Language.ChildForm.FactorB = xnll1.InnerText;break;
                                                    case "DataLen":
                                                        Language.ChildForm.DataLen = xnll1.InnerText;break;
                                                    case "DataStart":
                                                        Language.ChildForm.DataStart = xnll1.InnerText;break;
                                                    case "RegisterType":
                                                        Language.ChildForm.RegisterType = xnll1.InnerText;break;
                                                    case "ISContinuous":
                                                        Language.ChildForm.ISContinuous = xnll1.InnerText;break;
                                                    case "DataAnaly":
                                                        Language.ChildForm.DataAnaly = xnll1.InnerText;break;
                                                    case "IsRecord":
                                                        Language.ChildForm.ISRecord = xnll1.InnerText;break;
                                                    case "AlarmConditions":
                                                        Language.ChildForm.AlarmConditions = xnll1.InnerText;break;
                                                    case "Valch":
                                                        Language.ChildForm.Valch = xnll1.InnerText;break;
                                                    case "SignalIni":
                                                        Language.ChildForm.SignalIni = xnll1.InnerText;break;
                                                    case "AnaSignReadFreq":
                                                        ChildForm.AnaSignReadFreq = xnll1.InnerText;break;
                                                }
                                            }
                                        }
                                        break;
                                    case "Digital":
                                        {
                                             XmlNodeList xnll = xn.ChildNodes;
                                             foreach (XmlNode xnll1 in xnl)
                                             {
                                                 switch (xnll1.Name)
                                                 {
                                                     case "Text":
                                                         Language.ChildForm.DigitalText = xnll1.InnerText; break;
                                                     case "ShowSignalInfo":
                                                         Language.ChildForm.ShowDigitalInfo = xnll1.InnerText; break;
                                                     case "ZeroDesc":
                                                         Language.ChildForm.ZeroDesc = xnll1.InnerText; break;
                                                     case "ZeroValue":
                                                         Language.ChildForm.ZeroValue = xnll1.InnerText;break;
                                                     case "OneDesc":
                                                         Language.ChildForm.OneDesc = xnll1.InnerText; break;
                                                     case "OneValue":
                                                         Language.ChildForm.OneValue = xnll1.InnerText;break;
                                                     case "SignDesc":
                                                         Language.ChildForm.SignDesc = xnll1.InnerText;break;
                                                     case "SignAlarmCont":
                                                         Language.ChildForm.SignAlarmCont = xnll1.InnerText;break;
                                                     case "SignReadFreq":
                                                         Language.ChildForm.SignReadFreq = xnll1.InnerText;break;
                                                 }
                                             }
                                        }
                                        break;                                
                                }
                            }
                            #endregion
                        }
                        break;
                    case "ChildUser_TabPage":
                        {
                            #region ChildUser_TabPage
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "Tab2Text":
                                        ChildUser_TabPage.Tab2Text = xn1.InnerText;break;
                                    case "Tab3Text":
                                        ChildUser_TabPage.Tab3Text = xn1.InnerText;break;
                                    case "Tab4Text":
                                        ChildUser_TabPage.Tab4Text = xn1.InnerText; break;
                                    case "Tab5Text":
                                        ChildUser_TabPage.Tab5Text = xn1.InnerText;break;
                                    case "RealList":
                                        ChildUser_TabPage.RealList = xn1.InnerText; break;
                                    case "HisyList":
                                        ChildUser_TabPage.HisyList = xn1.InnerText;break;
                                    case "HisyEvent":
                                        ChildUser_TabPage.HisyEvent = xn1.InnerText;break;
                                    case "XTimeLimit":
                                        ChildUser_TabPage.XTimeLimit = xn1.InnerText;break;
                                }
                            }
                            #endregion
                        }
                        break;
                    case "UserControl":
                        {
                            #region UserControl
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "PortWnd":
                                        UserControl.PortWnd = xn1.InnerText;break;
                                    case "AddDevWnd":
                                        UserControl.AddDevWnd = xn1.InnerText;break;
                                    case "SetDevWnd":
                                        UserControl.SetDevWnd = xn1.InnerText;break;
                                    case "DevBasicMsg":
                                        UserControl.DevBasicMsg = xn1.InnerText;break;
                                    case "AnaList":
                                        UserControl.AnaList = xn1.InnerText;break;
                                    case "DigList":
                                        UserControl.DigList = xn1.InnerText;break;
                                    //BasicMsg
                                    case "Desc":
                                        UserControl.Desc = xn1.InnerText;break;
                                    case "Type":
                                        UserControl.Type = xn1.InnerText;break;
                                    case "Unit":
                                        UserControl.Unit = xn1.InnerText;break;
                                    case "State":
                                        UserControl.State = xn1.InnerText;break;
                                    case "ReTime":
                                        UserControl.ReTime = xn1.InnerText;break;
                                    case "DevType":
                                        UserControl.DevType = xn1.InnerText;break;
                                    case "TimeOut":
                                        UserControl.TimeOut = xn1.InnerText;break;
                                    case "ScantTime":
                                        UserControl.ScantTime = xn1.InnerText;break;
                                    case "RecoveyTime":
                                        UserControl.RecoveyTime = xn1.InnerText;break;
                                    case "WriteTime":
                                        UserControl.WriteTime = xn1.InnerText;break;
                                    case "ReadTimeOut":
                                        UserControl.ReadTimeOut = xn1.InnerText;break;
                                    case "WriteTimeOut":
                                        UserControl.WriteTimeOut = xn1.InnerText;break;
                                    case "RefreshTimer":
                                        UserControl.RefreshTimer = xn1.InnerText;break;
                                        //CardText
                                    case "DevID":
                                        UserControl.DevID = xn1.InnerText;break;
                                    case "DevName":
                                        UserControl.DevName = xn1.InnerText;break;
                                    case "CommState":
                                        UserControl.CommState = xn1.InnerText;break;
                                        //Button
                                    case "InsertDev":
                                        UserControl.InsertDev = xn1.InnerText;break;
                                    case "InsertPort":
                                        UserControl.InsertPort = xn1.InnerText;break;
                                    case "UpdatePort":
                                        UserControl.UpdatePort = xn1.InnerText;break;
                                    case "SaveMod":
                                        UserControl.SaveMod = xn1.InnerText;break;
                                    case "AnaEdit":
                                        UserControl.AnaEdit = xn1.InnerText;break;
                                    case "DigEdit":
                                        UserControl.DigEdit = xn1.InnerText;break;
                                    case "EditSucc":
                                        UserControl.EditSucc = xn1.InnerText;break;
                                    //TabText
                                    case "RealList":
                                        UserControl.RealList = xn1.InnerText;break;
                                    case "RealData":
                                        UserControl.RealData = xn1.InnerText;break;
                                    case "RealView":
                                        UserControl.RealView = xn1.InnerText;break;
                                    case "HisyView":
                                        UserControl.HisyView = xn1.InnerText;break;
                                    case "HisyData":
                                        UserControl.HisyData = xn1.InnerText;break;
                                    case "HisEvent":
                                        UserControl.HisEvent = xn1.InnerText;break;
                                        //Other
                                    case "SysDefault":
                                        UserControl.SysDefault = xn1.InnerText;break;
                                    case "DescText":
                                        UserControl.DescText = xn1.InnerText;break;
                                    //Other1 by zq
                                    case "PortName":
                                        UserControl.PortName = xn1.InnerText; break;
                                    case "DeviceName":
                                        UserControl.DeviceName = xn1.InnerText; break;
                                    case "CommunicateState":
                                        UserControl.CommunicateState = xn1.InnerText; break;
                                    case "RefreshInvert":
                                        UserControl.RefreshInvert = xn1.InnerText; break;
                                    case "Suspend":
                                        UserControl.Suspend = xn1.InnerText; break;
                                    case "Resume":
                                        UserControl.Resume = xn1.InnerText; break;
                                    case "FormView"://表格形式显示
                                        UserControl.FormView = xn1.InnerText; break;
                                    case "CustomUIView"://表格形式显示
                                        UserControl.CustomUIView = xn1.InnerText; break;
                                }
                            }
                            #endregion
                        }
                        break;
                    case "Desc":
                        {
                            #region Desc
                            XmlNodeList xnl = xn.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                switch (xn1.Name)
                                {
                                    case "Msg":
                                        Desc.Msg = xn1.InnerText; break;
                                    case "Fault_MainForm":
                                        Desc.Fault_MainForm = xn1.InnerText; break;
                                    case "IsDele":
                                        Desc.IsDele = xn1.InnerText; break;
                                    case "NotOpen":
                                        Desc.NotOpen = xn1.InnerText; break;
                                    case "HelpFile":
                                        Desc.HelpFile = xn1.InnerText; break;
                                    case "NotSupportPDF":
                                        Desc.NotSupportPDF = xn1.InnerText; break;
                                    case "NotExistFile":
                                        Desc.NotExistFile = xn1.InnerText; break;
                                    case "CurrentVersion":
                                        Desc.CurrentVersion = xn1.InnerText; break;
                                    case "BelongsToEAST":
                                        Desc.BelongsToEAST = xn1.InnerText; break;
                                    case "FillError":
                                        Desc.FillError = xn1.InnerText; break;
                                    case "IniFail":
                                        Desc.IniFail = xn1.InnerText; break;
                                    case "CheckInputData":
                                        Desc.CheckInputData = xn1.InnerText; break;
                                    case "InputDataError":
                                        Desc.InputDataError = xn1.InnerText; break;
                                    //ChildUser_TabPage
                                    case "ObtainFilure":
                                        Desc.ObtainFailure = xn1.InnerText;break;
                                    case "TimeNotNull":
                                        Desc.TimeNotNull = xn1.InnerText; break;
                                    case "TimeNotData":
                                        Desc.TimeNotData = xn1.InnerText; break;
                                    case "TimeLimit":
                                        Desc.TimeLimit = xn1.InnerText;break;
                                    case "SelStartTime":
                                        Desc.SelStartTime = xn1.InnerText;break;
                                    case "Warning":
                                        Desc.Warning_ChildUserTab = xn1.InnerText;break;
                                    case "Prompting":
                                        Desc.Prompting_ChildUserTab = xn1.InnerText; break;
                                    case "Fault":
                                        Desc.Fault_ChildUserTab = xn1.InnerText; break;
                                    case "Suspend":
                                        Desc.Suspend_ChildUserTab = xn1.InnerText; break;
                                    case "Resume":
                                        Desc.Resume_ChildUserTab = xn1.InnerText; break;
                                    case "EventTime":
                                        Desc.EventTime = xn1.InnerText; break;
                                    case "EventSource":
                                        Desc.EventSource = xn1.InnerText; break;
                                    case "EventInfo":
                                        Desc.EventInfo = xn1.InnerText; break;
                                }
                            }
                            #endregion
                        }
                        break;
                    case "ScheduleStr":
                        {
                            #region ScheduleStr
                            XmlNodeList xnl = xn.ChildNodes;
                        foreach (XmlNode xn1 in xnl) {

                            switch (xn1.Name) { 
                                case "scheduleManager":
                                    ScheduleStr.scheduleManager = xn1.InnerText;break;
                                case "addScheduleTask":
                                    ScheduleStr.addScheduleTask = xn1.InnerText;break;
                                case "deleteScheduleTask":
                                    ScheduleStr.deleteScheduleTask = xn1.InnerText;break;
                                case "OK":
                                    ScheduleStr.OK = xn1.InnerText;break;
                                case "task":
                                    ScheduleStr.task = xn1.InnerText;break;
                                case "taskDate":
                                    ScheduleStr.taskDate = xn1.InnerText;break;
                                case "frequency":
                                    ScheduleStr.frequency = xn1.InnerText;break;
                                case "once":
                                    ScheduleStr.once = xn1.InnerText;break;
                                case "everyDay":
                                    ScheduleStr.everyDay = xn1.InnerText;break;
                                case "BatteryTest":
                                    ScheduleStr.BatteryTest = xn1.InnerText;break;
                                case "OpenTheInverter":
                                    ScheduleStr.OpenTheInverter = xn1.InnerText;break;
                                case "CloseTheInverter":
                                    ScheduleStr.CloseTheInverter = xn1.InnerText;break;
                                case "cancel":
                                    ScheduleStr.cancel = xn1.InnerText;break;
                                case "Event":
                                    ScheduleStr.Event = xn1.InnerText; break;
                                case "ExecutionTime":
                                    ScheduleStr.ExecutionTime = xn1.InnerText; break;
                                case "State":
                                    ScheduleStr.State = xn1.InnerText; break;
                                case "Lastexecution":
                                    ScheduleStr.Lastexecution = xn1.InnerText; break;
                                case "Weekly":
                                    ScheduleStr.Weekly = xn1.InnerText;break;
                                case "Result":
                                    ScheduleStr.Result = xn1.InnerText;break;
                                case "AwaitingExecution":
                                    ScheduleStr.AwaitingExecution = xn1.InnerText;break;
                                case "Failure":
                                    ScheduleStr.Failure = xn1.InnerText; break;
                                case "Success":
                                    ScheduleStr.success = xn1.InnerText; break;
                                case "MaxTask":
                                    ScheduleStr.MaxTask = xn1.InnerText;break;
                            }
                        }
                        #endregion
                        }
                        break;
                }                
            }
        }
    }
}
