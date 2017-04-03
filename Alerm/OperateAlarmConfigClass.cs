using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using Model_Data.Alarm;

namespace Alarm
{
    public class OperateAlarmConfigClass
    {

        private static string GetFilePath()
        {
            return System.Environment.CurrentDirectory + "\\AlarmConfig.xml";
        }
        private static XmlDocument GetXmlDocument()
        {
            string strFilePathName = GetFilePath();
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(strFilePathName);
            }
            catch (Exception)
            {
                return null;
            }
            return document;
        }

        /*以下三个函数是 获取 电话，短信，邮件 物理地址信息，*/
        /*如果XML配置文件配置正常，则返回正常的信息实体数据，如果XML数据损坏，则返回NULL，请调用的注意判断*/
        //获取电话配置信息
        public static CallObj GetPhoneInfo()
        {
            XmlDocument xmlDocument = GetXmlDocument();
            if (xmlDocument == null)
                return null;
            CallObj cobj = new CallObj();
            try
            {
                XmlElement rootElement = xmlDocument.DocumentElement;
                XmlNode PhoneNode = rootElement.SelectSingleNode("PhoneAlarmConfig");
                cobj.BaudRate = Convert.ToInt32(PhoneNode.FirstChild.FirstChild.Value);
                cobj.DataBits = Convert.ToByte(PhoneNode.ChildNodes[1].FirstChild.Value);
                cobj.StopBits = Convert.ToByte(PhoneNode.ChildNodes[2].FirstChild.Value);
                cobj.Parity = Convert.ToByte(PhoneNode.ChildNodes[3].FirstChild.Value);
                cobj.PortNum = PhoneNode.ChildNodes[4].FirstChild.Value;
            }
            catch (Exception)
            {
                return null;
            }
            return cobj;
        }
        //获取短信配置信息
        public static SmsObj GetSMSinfo()
        {
            XmlDocument xmlDocument = GetXmlDocument();
            if (xmlDocument == null)
                return null;
            SmsObj sobj = new SmsObj();
            try
            {
                XmlElement rootElement = xmlDocument.DocumentElement;
                XmlNode SMSNode = rootElement.SelectSingleNode("SMSAlarmConfig");
                sobj.BaudRate = Convert.ToInt32(SMSNode.FirstChild.FirstChild.Value);
                sobj.databits = Convert.ToByte(SMSNode.ChildNodes[1].FirstChild.Value);
                sobj.stopBits = Convert.ToByte(SMSNode.ChildNodes[2].FirstChild.Value);
                sobj.parity = Convert.ToByte(SMSNode.ChildNodes[3].FirstChild.Value);
                sobj.portName = SMSNode.ChildNodes[4].FirstChild.Value;
            }
            catch (Exception)
            {
                return null;
            }

            return sobj;
        }
        //获取邮件配置信息
        public static MailObj GetMailInfo()
        {
            XmlDocument xmlDocument = GetXmlDocument();
            if (xmlDocument == null)
                return null;
            MailObj mobj = new MailObj();
            try
            {
                XmlElement rootElement = xmlDocument.DocumentElement;
                XmlNode EmailNode = rootElement.SelectSingleNode("EmailAlarmConfig");
                mobj.From = EmailNode.FirstChild.FirstChild.Value;
                mobj.FromName = EmailNode.ChildNodes[1].FirstChild.Value;
                mobj.PassWord = EmailNode.ChildNodes[2].FirstChild.Value;
                mobj.Host = EmailNode.ChildNodes[3].FirstChild.Value;
                mobj.Subject = EmailNode.ChildNodes[4].FirstChild.Value;
                mobj.TimeOut = Convert.ToInt32(EmailNode.ChildNodes[5].FirstChild.Value);
            }
            catch (Exception)
            {
                return null;
            }
            return mobj;
        }

        /*以下三个函数是修改配置信息，修改完成返回真，否则返回假*/
        //修改电话配置
        public static Boolean ModifyPhoneInfo(CallObj cobj_para)
        {
            XmlDocument xmlDocument = GetXmlDocument();
            if (xmlDocument == null)
                return false;
            try
            {
                XmlElement rootElement = xmlDocument.DocumentElement;
                XmlNode PhoneNode = rootElement.SelectSingleNode("PhoneAlarmConfig");
                PhoneNode.FirstChild.FirstChild.InnerText = (cobj_para.BaudRate).ToString();
                PhoneNode.ChildNodes[1].FirstChild.InnerText = ((int)(cobj_para.DataBits)).ToString();
                PhoneNode.ChildNodes[2].FirstChild.InnerText = ((int)(cobj_para.StopBits)).ToString();
                PhoneNode.ChildNodes[3].FirstChild.InnerText = ((int)(cobj_para.Parity)).ToString();
                PhoneNode.ChildNodes[4].FirstChild.InnerText = cobj_para.PortNum;
                xmlDocument.Save(GetFilePath());
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        //修改短信配置
        public static Boolean ModifySMSinfo(SmsObj smsObj_para)
        {
            XmlDocument xmlDocument = GetXmlDocument();
            if (xmlDocument == null)
                return false;
            try
            {
                XmlElement rootElement = xmlDocument.DocumentElement;
                XmlNode SMSNode = rootElement.SelectSingleNode("SMSAlarmConfig");
                SMSNode.FirstChild.FirstChild.Value = (smsObj_para.BaudRate).ToString();
                SMSNode.ChildNodes[1].FirstChild.Value = ((int)(smsObj_para.databits)).ToString();
                SMSNode.ChildNodes[2].FirstChild.Value = ((int)(smsObj_para.stopBits)).ToString();
                SMSNode.ChildNodes[3].FirstChild.Value = ((int)(smsObj_para.parity)).ToString(); ;
                SMSNode.ChildNodes[4].FirstChild.Value = smsObj_para.portName;
                xmlDocument.Save(GetFilePath());
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        //修改邮件配置
        public static Boolean ModifyMailInfo(MailObj mailObj_para)
        {
            XmlDocument xmlDocument = GetXmlDocument();
            if (xmlDocument == null)
                return false;
            try
            {
                XmlElement rootElement = xmlDocument.DocumentElement;
                XmlNode EmailNode = rootElement.SelectSingleNode("EmailAlarmConfig");
                EmailNode.FirstChild.FirstChild.Value = mailObj_para.From;
                EmailNode.ChildNodes[1].FirstChild.Value = mailObj_para.FromName;
                EmailNode.ChildNodes[2].FirstChild.Value = mailObj_para.PassWord;
                EmailNode.ChildNodes[3].FirstChild.Value = mailObj_para.Host;
                EmailNode.ChildNodes[4].FirstChild.Value = mailObj_para.Subject;
                EmailNode.ChildNodes[5].FirstChild.Value = (mailObj_para.TimeOut).ToString();
                xmlDocument.Save(GetFilePath());
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        //获取报警模式
        public static List<AlarmMode> GetAlarmModes()
        {
            XmlDocument xmlDocument = GetXmlDocument();
            if (xmlDocument == null)
                return null;
            List<AlarmMode> LAM = new List<AlarmMode>();
            try
            {
                XmlElement rootElement = xmlDocument.DocumentElement;
                XmlNode ModeNode = rootElement.SelectSingleNode("AlarmMode");
                foreach (XmlNode child in ModeNode)
                {
                    AlarmMode AM = new AlarmMode();
                    AM.Name = child.Name;
                    AM.Value = Convert.ToInt32(child.FirstChild.Value);
                    LAM.Add(AM);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return LAM;
        }
    }
}
