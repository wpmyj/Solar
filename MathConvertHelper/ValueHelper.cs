using System;
using System.Collections.Generic;
using System.Text;

namespace MathConvertHelper
{
    public class ValueHelper
    {
        #region 大小端判断
        public static bool LittleEndian = false;

        static ValueHelper()
        {
           
                short tester = 1;
                byte[] mybit=BitConverter.GetBytes(tester);
                LittleEndian = (mybit[0] == (byte)1);
           
        }
        #endregion

        #region Factory
        private static ValueHelper _Instance = null;
        public static ValueHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = LittleEndian ? new LittleEndianValueHelper() : new ValueHelper();
                }
                return _Instance;
            }
        }
        #endregion

        protected ValueHelper()
        {

        }

        public virtual Byte[] GetBytes(short value)
        {
            return BitConverter.GetBytes(value);
        }

        public virtual Byte[] GetBytes(int value)
        {
            return BitConverter.GetBytes(value);
        }

        public virtual Byte[] GetBytes(float value)
        {
            return BitConverter.GetBytes(value);
        }

        public virtual Byte[] GetBytes(double value)
        {
            return BitConverter.GetBytes(value);
        }

        public virtual short GetShort(byte[] data)
        {
            return BitConverter.ToInt16(data, 0);
        }

        public virtual int GetInt(byte[] data)
        {
            return BitConverter.ToInt32(data, 0);
        }

        public virtual float GetFloat(byte[] data)
        {
            return BitConverter.ToSingle(data, 0);
        }

        public virtual double GetDouble(byte[] data)
        {
            return BitConverter.ToDouble(data, 0);
        }
    }

    internal class LittleEndianValueHelper : ValueHelper
    {
        public override Byte[] GetBytes(short value)
        {
            return this.Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(int value)
        {
            return this.Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(float value)
        {
            return this.Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(double value)
        {
            return this.Reverse(BitConverter.GetBytes(value));
        }

        public override short GetShort(byte[] data)
        {
            return BitConverter.ToInt16(this.Reverse(data), 0);
        }

        public override int GetInt(byte[] data)
        {
            return BitConverter.ToInt32(this.Reverse(data), 0);
        }

        public override float GetFloat(byte[] data)
        {
            return BitConverter.ToSingle(this.Reverse(data), 0);
        }

        public override double GetDouble(byte[] data)
        {
            return BitConverter.ToDouble(this.Reverse(data), 0);
        }

        private Byte[] Reverse(Byte[] data)
        {
            Array.Reverse(data);
            return data;
        }
    }
}
