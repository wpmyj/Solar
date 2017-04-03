using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
namespace Model_Data.CommunicateEntity
{
    public class CommSerialEntity:SerialModel
    {
        public int ReadOverTime = 200;
        public int WriteOverTime = 200;
    }
}
