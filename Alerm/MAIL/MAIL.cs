using System;
using System.Collections.Generic;

using System.Text;
using System.Net.Mail;
using System.Web;
using System.Threading;
using System.Diagnostics;

namespace Alarm
{
    /// <summary>
    /// 消息内容
    /// </summary>
    public class MailObj
    {
        public string Subject = "NO SUBJECT";
        public string From;
        public string FromName = "NO NAME";//发件人姓名
        public List<string> To=new List<string>();//发送地址
        public List<string> CC = new List<string>();//抄送地址
        public List<string> Bcc = new List<string>();//密送地址，研华没有，暂时不用
        public string Body;//内容
        public string Host;//邮件服务器
        public string PassWord;
        public int TimeOut = 200;//超时时间
    }

    public enum EmailSendType
    {
        Send = 1,//主送
        CC = 2,//抄送
        BCC = 3,//密送
    }

   public  class MAIL
    {
        private  Thread Sendmail = null;
        private  bool IsThreadOn = false;



        Queue<MailObj> NormalPriority = new Queue<MailObj>();//普通列
        Queue<MailObj> HighPriority = new Queue<MailObj>();//优先列


        public  void fillqueue(MailObj mail, int Priority)//调用接口，mail是填充内容，priority是优先级
        {
            if (Priority == 1)
            {
               NormalPriority.Enqueue(mail);//填充
            }
            else
            {
                HighPriority.Enqueue(mail);
            }
            if (!IsThreadOn)
            {
                IsThreadOn = true;
                Sendmail = new Thread(SendMailThread);
                Sendmail.Start();
            }
        }


        void SendMailThread()
        {
            while (true)
            {
                if (HighPriority.Count > 0)
                {
                    while (HighPriority.Count != 0)
                    {
                        SendMail2(HighPriority.Peek());
                        HighPriority.Dequeue();//发送后清除顶端填充的内容
                    }
                }
                else
                {
                    SendMail2(NormalPriority.Peek());
                    NormalPriority.Dequeue();
                }
                if (HighPriority.Count + NormalPriority.Count == 0)
                {
                    IsThreadOn = false;
                    break;
                }
            }
        }

        private  void SendMail2(MailObj mail)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            if (mail.To != null)
            {
                foreach (string item in mail.To)
                {
                    msg.To.Add(item);
                }
            }
            else
            {
                Debug.WriteLine("发送地址必须填写");
            }

            if (mail.CC != null)
            {
                foreach (string item in mail.CC)
                {
                    msg.CC.Add(item);
                }
            }
            try
            {
                msg.From = new MailAddress(mail.From,mail.FromName, System.Text.Encoding.UTF8);
                msg.Subject = mail.Subject;//邮件标题 
                msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 
                msg.Body = mail.Body;//邮件内容 
                msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 
                msg.IsBodyHtml = false;//是否是HTML邮件 
                msg.Priority = MailPriority.High;//邮件优先级 

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(mail.From, mail.PassWord);
                //注册的邮箱和密码 
                client.Host = mail.Host;
                client.Timeout = mail.TimeOut;
                object userState = msg;

                //client.SendAsync(msg, userState);
                client.Send(msg);
                Debug.WriteLine("发送成功");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString(), "发送邮件出错");
            }
        }


    }
}
