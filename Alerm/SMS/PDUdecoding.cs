/////////////////////////////////////
///��    ����PDUdecoding.cs
///��    Ҫ����Թ��ڶ��ű��루USC2��
///��ɽṹ�������ĸ�������
///          smsDecodedCenterNumber(string srvCenterNumber)            �������ĺű���
///          smsPDUEncoded(string srvContent)                          �������ݱ���
///          smsDecodedNumber(string srvNumber)                        ���ն����ֻ��ű���
///          smsDecodedsms(string strCenterNumber, string strNumber, string strSMScontent)   �������ŵı���
///          һ���ֶ�
///          string nLength;   //Ҫ�������ݵĳ���,�����������,�����ֻ��ż���Ҫ���͵�����
///          
////////////////////////////////////
using System;
using System.Text;

namespace SMS
{
	public class PDUdecoding
	{
		
		public string nLength;   //Ҫ�������ݵĳ���,�����������,�����ֻ��ż���Ҫ���͵�����
		/// <summary>
			/// �������ܣ��������ݱ���
			/// �������ƣ�smsPDUEncoded(string srvContent)
			/// ��    ����srvContent Ҫ����ת���Ķ�������,string����
			/// �� �� ֵ�������Ķ������ݣ�string����
			/// ����˵����
			///          1������Big-Endian �ֽ�˳��� Unicode ��ʽ���룬Ҳ��˵�Ѹߵ�λ�Ļ��������������
			///          2����ת����Ķ������ݴ���ֽ�����
			///          3��ȥ���ڽ���Unicode��ʽ�����У������ֽ��е�"-",���磺00-21�����0021
			///          4���������������ݵĳ��ȳ�2��������λ16������
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
		/// �������ܣ��������ĺű���
		/// �������ƣ�smsDecodedCenterNumber(string srvCenterNumber)
		/// ��    ����srvCenterNumber Ҫ����ת���Ķ������ĺ�,string����
		/// �� �� ֵ�������Ķ������ĺţ�string����
		/// ����˵����
		///          1��������λ��ż��λ������
		///          2���������ĺ���ż�������󣬿��������Ƿ�Ϊż����������ǣ�������F
		///          3�����϶������ĺ����ͣ�91Ϊ���ʻ�
		///          4����������Ķ������ĺų��ȣ����񻯳ɶ�λ��ʮ������
		/// </summary>
		public string smsDecodedCenterNumber(string srvCenterNumber)
		{
			string s = null;
			int nLength = srvCenterNumber.Length;
			for(int i = 1 ; i < nLength;i += 2)                       //��ż����
			{
				s += srvCenterNumber[i];
				s += srvCenterNumber[i-1];
			}
			if(!(nLength % 2 == 0))                           //�Ƿ�Ϊż�������Ǿͼ���F���������һλ����ϵ�Fλ����
			{
				s += 'F';
				s += srvCenterNumber[nLength - 1];
			}
			s = String.Format("91{0}",s);                    //����91,���������������Ϊ���ʻ�
			s = String.Format("{0:X2}{1}",s.Length / 2,s);   //�����������ĺų��ȣ�����ʽ���ɶ�λʮ����
			return s;
		}

		/// <summary>
		/// �������ܣ����ն����ֻ��ű���
		/// �������ƣ�smsDecodedNumber(string srvNumber)
		/// ��    ����srvCenterNumber Ҫ����ת���Ķ������ĺ�,string����
		/// �� �� ֵ�������Ľ��ն����ֻ��ţ�string����
		/// ����˵����
		///          1����鵱ǰ�����ֻ����Ƿ񰴱�׼��ʽ��д�����ǣ��Ͳ��ϡ�86��
		///          1��������λ��ż��λ������
		///          2���������ĺ���ż�������󣬿��������Ƿ�Ϊż����������ǣ�������F
		/// </summary>
		public string smsDecodedNumber(string srvNumber)
		{
			string s = null;
			if (!(srvNumber.Substring(0,2) == "86"))
			{
				srvNumber = String.Format("86{0}",srvNumber);     //��鵱ǰ�����ֻ����Ƿ񰴱�׼��ʽ��д�����ǣ��Ͳ��ϡ�86��
			}
			int nLength = srvNumber.Length;
			for(int i = 1 ; i < nLength ; i += 2)                 //������λ��ż��λ����
			{
				s += srvNumber[i];
				s += srvNumber[i-1];
			}
			if(!(nLength % 2 == 0))                              //�Ƿ�Ϊż�������Ǿͼ���F���������һλ����ϵ�Fλ����
			{
				s += 'F';
				s += srvNumber[nLength - 1];
			}
			return s;
		}

		/// <summary>
		/// �������ܣ��������ŵı���
		/// �������ƣ�smsDecodedsms(string strCenterNumber, string strNumber, string strSMScontent)
		/// ��    ����strCenterNumber Ҫ����ת���Ķ������ĺ�,string����
		///           strNumber       �����ֻ����룬string����
		///           strSMScontent   ��������
		/// �� �� ֵ�������Ķ��ű��룬������ATָ����ִ�У�string����
		/// ����˵����
		///           11000D91��000800   �ڹ��ڣ�����PDU����ԭ������д���ڴˣ���ϸ�����뿴�ҵ�����      
		/// </summary>
		public string smsDecodedsms(string strCenterNumber, string strNumber, string strSMScontent)
		{
			string s = String.Format("{0}11000D91{1}000800{2}",smsDecodedCenterNumber(strCenterNumber),smsDecodedNumber(strNumber),smsPDUEncoded(strSMScontent));
			nLength =String.Format("{0:D2}", (s.Length - smsDecodedCenterNumber(strCenterNumber).Length) / 2 );   //��ȡ�������ݼ����ֻ����볤��
			return s;
		}
	}
}
