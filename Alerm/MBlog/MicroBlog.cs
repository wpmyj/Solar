using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
//using MBClient.Entities;
//using System.Runtime.Serialization.Json;
using System.Data;
//using System.Drawing;

namespace Alarm
{
    class MicroBlog
    {
    }/*
    internal class ReadDataBySinaAPI
    {
        
        internal ReadDataBySinaAPI() { }
        /// <summary>   
        /// 根据用户登录信息登录并读取用户信息到DataSet   
        /// 如果用户新浪通行证身份验证成功且用户已经开通微博则返回 http状态为 200；   
        /// 如果是不则返回401的状态和错误信息。此方法用了判断用户身份是否合法且已经开通微博。   
        /// http://open.t.sina.com.cn/wiki/index.php/Account/verify_credentials   
        /// </summary>   
        /// <param name="url">API URL (XML Format)http://api.t.sina.com.cn/account/verify_credentials.xml?source=AppKey   
        /// </param>   
        /// <returns></returns>   
        internal static DataSet ReadXMLDataToDataSet(string url)
        {
            CredentialCache mycache = new CredentialCache();
            mycache.Add(new Uri(url), "Basic", new NetworkCredential(UserInfo.UserName, UserInfo.Password));
            WebRequest myReq = WebRequest.Create(url);
            myReq.Credentials = mycache;
            myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(UserInfo.UserNamePassword)));
            WebResponse wr = myReq.GetResponse();
            DataSet ds = new DataSet();
            using (Stream receiveStream = wr.GetResponseStream())
            {
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                //string content = reader.ReadToEnd();   
                ds.ReadXml(reader);
                reader.Close();
            }
            wr.Close();
            return ds;
        }
        internal static string ReadXMLDataToString(string url)
        {
            CredentialCache mycache = new CredentialCache();
            mycache.Add(new Uri(url), "Basic", new NetworkCredential(UserInfo.UserName, UserInfo.Password));
            WebRequest myReq = WebRequest.Create(url);
            myReq.Credentials = mycache;
            myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(UserInfo.UserNamePassword)));
            WebResponse wr = myReq.GetResponse();
            string strData = null;
            using (Stream receiveStream = wr.GetResponseStream())
            {
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                strData = reader.ReadToEnd();
                reader.Close();
            }
            wr.Close();
            return strData;
        }
        /// <summary>   
        /// 以JSON格式字符串返回用户所有关注用户最新n条微博信息。和用户“我的首页”返回内容相同。   
        /// http://open.t.sina.com.cn/wiki/index.php/Statuses/friends_timeline   
        /// </summary>   
        /// <param name="url">API URL (JSON Format) http://api.t.sina.com.cn/statuses/friends_timeline.json?source=AppKey   
        /// </param>   
        /// <returns></returns>   
        internal static string ReadJsonDataToString(string url)
        {
            CredentialCache mycache = new CredentialCache();
            mycache.Add(new Uri(url), "Basic", new NetworkCredential(UserInfo.UserName, UserInfo.Password));
            WebRequest myReq = WebRequest.Create(url);
            myReq.Credentials = mycache;
            myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(UserInfo.UserNamePassword)));
            WebResponse wr = myReq.GetResponse();
            string content = null;
            using (Stream receiveStream = wr.GetResponseStream())
            {
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                content = reader.ReadToEnd();
                reader.Close();
            }
            wr.Close();
            return content;
        }
        /// <summary>   
        /// 将JSON格式字符串反序列化为Status集合对象   
        /// </summary>   
        /// <param name="url">同ReadJsonDataToString()</param>   
        /// <returns></returns>   
        internal static List<Status> DeserializeJsonToListObject(string url)
        {
            List<Status> listObj;
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Status>));
                StreamWriter wr = new StreamWriter(stream);
                string strJson = ReadJsonDataToString(url);
                wr.Write(strJson);
                wr.Flush();
                stream.Position = 0;
                Object obj = ser.ReadObject(stream);
                listObj = (List<Status>)obj;
                wr.Close();
            }
            return listObj;
        }
        /// <summary>   
        /// 获取并输出图片   
        /// </summary>   
        /// <param name="imgUrl">图片URL地址</param>   
        /// <returns></returns>   
        internal static Image GetAvatarImage(string imgUrl)
        {
            Uri myUri = new Uri(imgUrl);
            WebRequest webRequest = WebRequest.Create(myUri);
            WebResponse webResponse = webRequest.GetResponse();
            Bitmap myImage = new Bitmap(webResponse.GetResponseStream());
            return (Image)myImage;
        }
        /// <summary>   
        /// 发表一条微博   
        /// </summary>   
        /// <param name="url">API地址   
        /// http://api.t.sina.com.cn/statuses/update.json   
        /// </param>   
        /// <param name="data">AppKey和微博内容   
        /// "source=123456&status=" + System.Web.HttpUtility.UrlEncode(微博内容);   
        /// </param>   
        /// <returns></returns>   
        internal static bool PostBlog(string url, string data)
        {
            try
            {
                System.Net.WebRequest webRequest = System.Net.WebRequest.Create(url);
                System.Net.HttpWebRequest httpRequest = webRequest as System.Net.HttpWebRequest;
                System.Net.CredentialCache myCache = new System.Net.CredentialCache();
                myCache.Add(new Uri(url), "Basic",
                    new System.Net.NetworkCredential(UserInfo.UserName, UserInfo.Password));
                httpRequest.Credentials = myCache;
                httpRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(
                    new System.Text.ASCIIEncoding().GetBytes(UserInfo.UserName + ":" +
                    UserInfo.Password)));
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;//System.Text.Encoding.ASCII   
                byte[] bytesToPost = encoding.GetBytes(data);//System.Web.HttpUtility.UrlEncode(data)   
                httpRequest.ContentLength = bytesToPost.Length;
                System.IO.Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(bytesToPost, 0, bytesToPost.Length);
                requestStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }  
    */
}
