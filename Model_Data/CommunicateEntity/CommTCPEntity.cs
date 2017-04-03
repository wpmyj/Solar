using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Data.CommunicateEntity
{
    public class CommTCPEntity:TcpModel
    {
        public int ReadOverTime = 200;
        public int WriteOverTime = 200;
    }
}
