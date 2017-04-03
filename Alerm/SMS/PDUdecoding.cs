/////////////////////////////////////
///文    件：PDUdecoding.cs
///概    要：针对国内短信编码（USC2）
///组成结构：包含四个函数：
///          smsDecodedCenterNumber(string srvCenterNumber)            短信中心号编码
///          smsPDUEncoded(string srvContent)                          短信内容编码
///          smsDecodedNumber(string srvNumber)                        接收短信手机号编码
///          smsDecodedsms(string strCenterNumber, string strNumber, string strSMScontent)   整个短信的编码
///          一个字段
///          string nLength;   //要发送内容的长度,由两部分组成,接收手机号加上要发送的内容
///          
////////////////////////////////////
using System;
using System.Text;

namespace SMS
{
	public class PDUdecoding
	{
		
		public string nLength;   //要发送内容的长度,由两部分组成,接收手机号加上要发送的内容
		/// <summary>
			/// 函数功能：短信内容编码
			/// 函数名称：smsPDUEncoded(string srvContent)
			/// 参    数：srvContent 要进行转换的短信内容,string类型
			/// 返 回 值：编码后的短信内容，string类型
			/// 函数说明：
			///          1，采用Big-Endian 字节顺序的 Unicode 格式编码，也就说把高低位的互换在这里完成了
			///          2，将转换后的短信内容存进字节数组
			///          3，去掉在进行Unicode格式编码中，两个字节中的"-",例如：00-21，变成0021
			///          4，将整条短信内容的长度除2，保留两位16进制数
			/// </summary>
		public string smsPDUEncoded(string srvContent)
			{
				Encoding encodingUTF = System.Text.Encoding.BigEndianUnicode;
				string s = null;
				byte [] encodedBytes = encodingUTF.GetBytes(srvContent);
				for (int i =0;i < encodedBytes.Length;i++)
				{
					s += BitConverter.ToString(encodedBytes,i,1);
				}
				s = String.Format("{0:X2}{1}",s.Length / 2,s);
				
				return s;
			}

		/// <summary>
		/// 函数功能：短信中心号编码
		/// 函数名称：smsDecodedCenterNumber(string srvCenterNumber)
		/// 参    数：srvCenterNumber 要进行转换的短信中心号,string类型
		/// 返 回 值：编码后的短信中心号，string类型
		/// 函数说明：
		///          1，将奇数位和偶数位交换。
		///          2，短信中心号奇偶数交换后，看看长度是否为偶数，如果不是，最后添加F
		///          3，加上短信中心号类型，91为国际化
		///          4，计算编码后的短信中心号长度，并格化成二位的十六进制
		/// </summary>
		public string smsDecodedCenterNumber(string srvCenterNumber)
		{
			string s = null;
			int nLength = srvCenterNumber.Length;
			for(int i = 1 ; i < nLength;i += 2)                       //奇偶互换
			{
				s += srvCenterNumber[i];
				s += srvCenterNumber[i-1];
			}
			if(!(nLength % 2 == 0))                           //是否为偶数，不是就加上F，并对最后一位与加上的F位互换
			{
				s += 'F';
				s += srvCenterNumber[nLength - 1];
			}
			s = String.Format("91{0}",s);                    //加上91,代表短信中心类型为国际化
			s = String.Format("{0:X2}{1}",s.Length / 2,s);   //编码后短信中心号长度，并格式化成二位十六制
			return s;
		}

		/// <summary>
		/// 函数功能：接收短信手机号编码
		/// 函数名称：smsDecodedNumber(string srvNumber)
		/// 参    数：srvCenterNumber 要进行转换的短信中心号,string类型
		/// 返 回 值：编码后的接收短信手机号，string类型
		/// 函数说明：
		///          1，检查当前接收手机号是否按标准格式书写，不是，就补上“86”
		///          1，将奇数位和偶数位交换。
		///          2，短信中心号奇偶数交换后，看看长度是否为偶数，如果不是，最后添加F
		/// </summary>
		public string smsDecodedNumber(string srvNumber)
		{
			string s = null;
			if (!(srvNumber.Substring(0,2) == "86"))
			{
				srvNumber = String.Format("86{0}",srvNumber);     //检查当前接收手机号是否按标准格式书写，不是，就补上“86”
			}
			int nLength = srvNumber.Length;
			for(int i = 1 ; i < nLength ; i += 2)                 //将奇数位和偶数位交换
			{
				s += srvNumber[i];
				s += srvNumber[i-1];
			}
			if(!(nLength % 2 == 0))                              //是否为偶数，不是就加上F，并对最后一位与加上的F位互换
			{
				s += 'F';
				s += srvNumber[nLength - 1];
			}
			return s;
		}

		/// <summary>
		/// 函数功能：整个短信的编码
		/// 函数名称：smsDecodedsms(string strCenterNumber, string strNumber, string strSMScontent)
		/// 参    数：strCenterNumber 要进行转换的短信中心号,string类型
		///           strNumber       接收手机号码，string类型
		///           strSMScontent   短信内容
		/// 返 回 值：完整的短信编码，可以在AT指令中执行，string类型
		/// 函数说明：
		///           11000D91和000800   在国内，根据PDU编码原则，我们写死在此，详细解释请看我的文章      
		/// </summary>
		public string smsDecodedsms(string strCenterNumber, string strNumber, string strSMScontent)
		{
			string s = String.Format("{0}11000D91{1}000800{2}",smsDecodedCenterNumber(strCenterNumber),smsDecodedNumber(strNumber),smsPDUEncoded(strSMScontent));
			nLength =String.Format("{0:D2}", (s.Length - smsDecodedCenterNumber(strCenterNumber).Length) / 2 );   //获取短信内容加上手机号码长度
			return s;
		}
	}
}
