using System;
using System.Collections.Generic;
using System.Text;
using Communication.CommunicateToLowerMonitor;
using Model_Data;

namespace SolarMonitor.DeviceUI
{
    interface IDeviceUI
    {
        void SetParaMeter(DeviceBll device, DeviceModel dm);
    }
}
