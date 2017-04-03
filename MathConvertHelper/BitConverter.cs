using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MathConvertHelper
{

    public static class BitConverter
    {
        public static unsafe long DoubleToInt64Bits(double value)
        {
            return *(((long*)&value));
        }
        public static unsafe double Int64BitsToDouble(long value)
        {
            return *(((double*)&value));
        }

        public static byte[] GetBytes(bool value)
        {
            return new byte[] { (value ? ((byte)1) : ((byte)0)) };
        }
        public static byte[] GetBytes(char value)
        {
            return new byte[2] { (byte)(value & 0xFF), (byte)((value >> 8) & 0xFF) };
        }
        //低位前，高位后
        public static byte[] GetBytes(short value)
        {
            return new byte[2] { (byte)(value & 0xFF), (byte)((value >> 8) & 0xFF) };
        }
        //高位前，低位后
        public static byte[] GetBytesRevecse(short value)
        {
            return new byte[2] { (byte)((value >> 8) & 0xFF), (byte)(value & 0xFF) };
        }

        public static byte[] GetBytes(ushort value)
        {
            return new byte[2] { (byte)(value & 0xFF), (byte)((value >> 8) & 0xFF) };
        }
        public static byte[] GetBytes(int value)
        {
            return new byte[4] {  
                    (byte)(value & 0xFF),  
                    (byte)((value >> 8) & 0xFF),  
                    (byte)((value >> 16) & 0xFF),  
                    (byte)((value >> 24) & 0xFF) };
        }
        public static byte[] GetBytes(uint value)
        {
            return new byte[4] {  
                    (byte)(value & 0xFF),  
                    (byte)((value >> 8) & 0xFF),  
                    (byte)((value >> 16) & 0xFF),  
                    (byte)((value >> 24) & 0xFF) };
        }

        public static byte[] GetBytes(long value)
        {
            return new byte[8] {  
                    (byte)(value & 0xFF),  
                    (byte)((value >> 8) & 0xFF),  
                    (byte)((value >> 16) & 0xFF),  
                    (byte)((value >> 24) & 0xFF), 
                    (byte)((value >> 32) & 0xFF), 
                    (byte)((value >> 40) & 0xFF), 
                    (byte)((value >> 48) & 0xFF), 
                    (byte)((value >> 56) & 0xFF)};
        }
        public static byte[] GetBytes(ulong value)
        {
            return new byte[8] {  
                    (byte)(value & 0xFF),  
                    (byte)((value >> 8) & 0xFF),  
                    (byte)((value >> 16) & 0xFF),  
                    (byte)((value >> 24) & 0xFF), 
                    (byte)((value >> 32) & 0xFF), 
                    (byte)((value >> 40) & 0xFF), 
                    (byte)((value >> 48) & 0xFF), 
                    (byte)((value >> 56) & 0xFF)};
        }
        public static unsafe byte[] GetBytes(float value)
        {
            int val = *((int*)&value);
            return GetBytes(val);
        }
        public static unsafe byte[] GetBytes(double value)
        {
            long val = *((long*)&value);
            return GetBytes(val);
        }

        //取得ASCII编码方式的数组
        //参数一：value需要转换的值16进制数字
        //参数二：bytelen转换后的字符串长度
        //参数三：ResultByte转换后存储结果的数组
        //参数四：byteindex存储结果的起始位置
        public static void GetASCIIBytes(UInt16 value,int bytelen,byte[] ResultByte,int byteindex)
        {
            string tempstr = value.ToString();
            if (tempstr.Length < bytelen)
            {
                for (int i = tempstr.Length; i < bytelen; i++)
                {
                    tempstr = "0" + tempstr;
                }
            }
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            asciiEncoding.GetBytes(tempstr, 0, bytelen, ResultByte, byteindex);
        }

        /// <summary>
        /// 获得字符串的ASCII码数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetASCIIbyteArrayFromStr(string str)
        {
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            return asciiEncoding.GetBytes(str);
        }

        public static bool ToBoolean(byte[] value, int index = 0)
        {
            return value[index] != 0;
        }
        public static char ToChar(byte[] value, int index = 0)
        {
            return (char)(value[0 + index] << 0 | value[1 + index] << 8);
        }
        public static char ToCharReverse(byte[] value, int index = 0)
        {
            return (char)(value[0 + index] << 8 | value[1 + index] << 0);
        }
        public static short ToInt16(byte[] value, int index = 0)
        {
            return (short)(
                value[0 + index] << 0 |
                value[1 + index] << 8);
        }

        public static short ToInt16Reverse(byte[] value, int index = 0)
        {
            return (short)(
                value[0 + index] << 8 |
                value[1 + index] << 0);
        }

        //long integer
        public static int ToInt32(byte[] value, int index = 0)
        {
            Array.Reverse(value);
            value = Swap(value);
            return (
                value[0 + index] << 0 |
                value[1 + index] << 8 |
                value[2 + index] << 16 |
                value[3 + index] << 24);
        }
        //long swap
        public static int ToInt32Swapped(byte[] value, int index = 0)
        {
            value = Swap(value);
            return ToInt32(value);
        }

        public static int ToInt32ReverseSwap(byte[] value, int index = 0)
        {
            return (
                value[0 + index] << 24 |
                value[1 + index] << 16 |
                value[2 + index] << 8 |
                value[3 + index] << 0);
        }

        public static long ToInt64(byte[] value, int index = 0)
        {
            return (
                value[0 + index] << 0 |
                value[1 + index] << 8 |
                value[2 + index] << 16 |
                value[3 + index] << 24 |
                value[4 + index] << 32 |
                value[5 + index] << 40 |
                value[6 + index] << 48 |
                value[7 + index] << 56);
        }
        public static long ToInt64Reverse(byte[] value, int index = 0)
        {
            return (
                value[0 + index] << 56 |
                value[1 + index] << 48 |
                value[2 + index] << 40 |
                value[3 + index] << 32 |
                value[4 + index] << 24 |
                value[5 + index] << 16 |
                value[6 + index] << 8 |
                value[7 + index] << 0);
        }

        public static ushort ToUInt16(byte[] value, int index = 0)
        {
            return (ushort)(
                value[0 + index] << 0 |
                value[1 + index] << 8);
        }
        public static ushort ToUInt16Reverse(byte[] value, int index = 0)
        {
            return (ushort)(
                value[0 + index] << 8 |
                value[1 + index] << 0);
        }
        public static uint ToUInt32(byte[] value, int index = 0)
        {
            return (uint)(
                value[0 + index] << 0 |
                value[1 + index] << 8 |
                value[2 + index] << 16 |
                value[3 + index] << 24);
        }
        public static uint ToUInt32Reverse(byte[] value, int index = 0)
        {
            return (uint)(
                value[0 + index] << 24 |
                value[1 + index] << 16 |
                value[2 + index] << 8 |
                value[3 + index] << 0);
        }
        public static ulong ToUInt64(byte[] value, int index = 0)
        {

            return (ulong)(
                value[0 + index] << 0 |
                value[1 + index] << 8 |
                value[2 + index] << 16 |
                value[3 + index] << 24 |
                value[4 + index] << 32 |
                value[5 + index] << 40 |
                value[6 + index] << 48 |
                value[7 + index] << 56);
        }
        public static ulong ToUInt64Reverse(byte[] value, int index = 0)
        {
            return (ulong)(
                value[0 + index] << 56 |
                value[1 + index] << 48 |
                value[2 + index] << 40 |
                value[3 + index] << 32 |
                value[4 + index] << 24 |
                value[5 + index] << 16 |
                value[6 + index] << 8 |
                value[7 + index] << 0);
        }
        //floating point
        public static unsafe float ToSingle(byte[] value, int index = 0)
        {
            int i = ToInt32(value);
            return *(((float*)&i));


        }

        //float swap
        public static unsafe float ToSingleReverse(byte[] value, int index = 0)
        {
            int i = ToInt32((Swap(value)));
            return *(((float*)&i));

        }

        public static unsafe double ToDouble(byte[] value, int index = 0)
        {
            //ulong l = ToUInt64(value);
            //return *(((double*)&l));
            //Array.Reverse(value);
            //value = Swap(value);
            long l = ToInt64(value);
            return Int64BitsToDouble(l);

            //float f = ToSingle(value);


            //long l;
            //l = value[0];
            //l &= 0xff;
            //l |= ((long)value[1] << 8);
            //l &= 0xffff;
            //l |= ((long)value[2] << 16);
            //l &= 0xffffff;
            //l |= ((long)value[3] << 24);
            //l &= 0xffffffffl;
            //l |= ((long)value[4] << 32);
            //l &= 0xffffffffffl;
            //l |= ((long)value[5] << 40);
            //l &= 0xffffffffffffl;
            //l |= ((long)value[6] << 48);
            //l &= 0xffffffffffffffl;
            //l |= ((long)value[7] << 56);
            //return Double.longBitsToDouble(l);
            //return Double.
            //return  BitConverter.ToDouble(value, index);

        }

        //把字节数组转换为Unicode编码字符串数组
        public static string ToUnicodeString(byte[] value, int index = 0)
        {
            return ToString(value, index, value.Length - index);
        }
        public static string ToString(byte[] value, int index, int length)
        {
            char[] c = new char[length * 3];
            byte b;

            for (int y = 0, x = 0; y < length; ++y, ++x)
            {
                b = (byte)(value[index + y] >> 4);
                c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = (byte)(value[index + y] & 0xF);
                c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                c[++x] = '-';
            }
            return new string(c, 0, c.Length - 1);
        }

        //把字节数组转换为ASCII编码字符串数组
        public static string ToASCIIString(byte[] value, int index = 0)
        {
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            return asciiEncoding.GetString(value,index,value.Length-index);
        }

        //把BCD码 转换为时间（GF8000）
        public static DateTime BCDtoDate(byte[] BCD)
        {
            DateTime DT = new DateTime(2000,1,1);
          DT=  DT.AddYears(BCD2INT(BCD[0]));
          DT = DT.AddMonths(BCD2INT(BCD[1]) - 1);
          DT = DT.AddDays(BCD2INT(BCD[2]) - 1);
          DT = DT.AddHours(BCD2INT(BCD[3]));
          DT = DT.AddMinutes(BCD2INT(BCD[4]));
          DT = DT.AddSeconds(BCD2INT(BCD[5]));
          return DT;
        }

        private static int  BCD2INT(byte BCD)
        {
            return ((int)(BCD >> 4) * 10 + (BCD & 0x0F));
        }


        private static Byte[] Reverse(Byte[] data)
        {
            Array.Reverse(data);
            return data;
        }

        /**把字节数组转换成BCD编码的字符
         * 如果是非法BCD码，则返回0；
         * **/
        public static string ToBCD16(Byte[] data)
        {
            if ((int)(data[1] & 0x0F) > 9)
                data[1] =(byte)(data[1] & 0xF0);
            if ((int)(data[1] >>4) > 9)
                data[1] = (byte)(data[1] & 0x0F);
            if ((int)(data[0] & 0x0F) > 9)
                data[0] = (byte)(data[1] & 0xF0);
            if ((int)(data[0] >>4) > 9)
                data[0] = (byte)(data[0] & 0x0F);
            string str_low = (data[1] >> 4).ToString() + (data[1] & 0x0F).ToString();
            string str_hig= (data[0] >> 4).ToString() + (data[0] & 0x0F).ToString();
            return str_hig + str_low;
        }


        private static Byte[] Swap(Byte[] data)
        {
            //Byte tmp= new Byte();
            int quaterlength = data.Length / 4;
            int datalen = data.Length;
            for (int i = 0; i < quaterlength; i++)
            {
                Byte tmp0 = data[2 * i];
                Byte tmp1 = data[2 * i + 1];
                data[2 * i] = data[datalen - 2 * i - 2];
                data[2 * i + 1] = data[datalen - 2 * i - 1];
                data[datalen - 2 * i - 2] = tmp0;
                data[datalen - 2 * i - 1] = tmp1;
            }
            return data;
        }

    }

}
