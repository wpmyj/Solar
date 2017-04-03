using System;
using System.Collections.Generic;

using System.Text;
using Model_Data.Alarm;

namespace Alarm
{

    public class AlarmManager
    {
        public static SMS sms = new SMS();
        public static MAIL mail = new MAIL();
        public static CALL call = new CALL();


        public static SmsObj sobj;
        public static MailObj mobj;
        public static CallObj cobj;
        public static List<AlarmMode> LAM;
        //初始化相关数据结构
        public static void Inition()
        {
            sobj = OperateAlarmConfigClass.GetSMSinfo();
            mobj = OperateAlarmConfigClass.GetMailInfo();
            cobj = OperateAlarmConfigClass.GetPhoneInfo();

            LAM = OperateAlarmConfigClass.GetAlarmModes();

            CallObj callObj = new CallObj();
            callObj.BaudRate = 1200;
            callObj.DataBits = (byte)8;
            callObj.StopBits=(byte)1;
            callObj.Parity=(byte)0;
            callObj.PortNum = "COM1";
            OperateAlarmConfigClass.ModifyPhoneInfo(callObj);

            SmsObj smsObj = new SmsObj();
            smsObj.BaudRate = 1200;
            smsObj.databits = (byte)8;
            smsObj.stopBits = (byte)1;
            smsObj.parity=(byte)4;
            smsObj.portName = "COM6";
            OperateAlarmConfigClass.ModifySMSinfo(smsObj);

            MailObj mailObj = new MailObj();
            mailObj.From = "lupc@eastups.com";
            mailObj.FromName = "East";
            mailObj.PassWord = "1234";
            mailObj.Host = "192.168.1.81";
            mailObj.Subject = "这是自动报警邮件";
            mailObj.TimeOut = 8;
            OperateAlarmConfigClass.ModifyMailInfo(mailObj);

        }

    }
}
