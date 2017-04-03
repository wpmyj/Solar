using System;
using System.Collections.Generic;

using System.Text;
using Alarm;


namespace test
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {

            //MailObj mailg = getmail();
            //AlarmManager.mail.fillqueue(mailg,1);

            //SmsObj smsg=getsms();
            //AlarmManager.sms.fillqueue(smsg,1);

            CallObj callg = getcall();
            AlarmManager.call.fillqueue(callg, 1);

        }
        //public void todo()
        //{
        //    MAIL mtd = new MAIL();

        //    for (int i = 0; i < 5; i++)
        //    {

        //        MAIL.MailObj mail = getmail();
        //        mail.Subject = "Normal" + i.ToString();
        //        mtd.fillqueue(mail, 1);
        //    }
        //    for (int i = 0; i < 5; i++)
        //    {
        //        MAIL.MailObj mail = getmail();
        //        mail.Subject = "High" + i.ToString();
        //        mtd.fillqueue(mail, 2);
        //    }
        //}
        private static MailObj getmail()
        {
            MailObj mail = new MailObj();
            mail.From = "dixl@eastups.com";
            mail.CC.Add("dixl@eastups.com");
            mail.CC.Add("lupc@eastups.com");
            mail.To.Add("dixl@eastups.com");
            mail.Subject = "normal";
            mail.Body = "hhhu";
            return mail;
        }

        private static SmsObj getsms()
        {
            SmsObj sms = new SmsObj();
            sms.phoneNumbers.Add("13650367330");
            sms.smsContent = "zhong国24";
            return sms;
        }

        private static CallObj getcall()
        {
            CallObj call = new CallObj();
            call.phoneNumber = "13650367330";
            return call;
        }
    }
}
