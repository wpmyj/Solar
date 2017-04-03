using System;
using System.Collections.Generic;
using System.Text;
using Model_Data.CommunicateEntity;

namespace SolarMonitor.SolarSchedule
{
    public enum ScheduleOffGrid :int
    {
        On = 1,//开机
        Off = 2,//关机
        Test = 3,//电池测试
    }


    public class OffGridTask{

        private ScheduleOffGrid type;

        public OffGridTask(ScheduleOffGrid type)
        {
            this.type = type;
        }

        public bool handle(ScheduleTask sender, String msg)
        {
            switch (type)
            {
                case ScheduleOffGrid.On:
                    return powerOn(sender, msg);
                case ScheduleOffGrid.Off:
                    return powerOff(sender, msg);
                case ScheduleOffGrid.Test:
                    return test(sender, msg);
                default:
                    return false;
            }
        }

        private bool powerOn(ScheduleTask sender, String msg)
        {
            byte[] data = { 0xff, 0xff };
            return send(14, data);
        }

        private bool powerOff(ScheduleTask sender, String msg)
        {
            byte[] data = { 0x00, 0x00 };
            return send(7, data);
        }

        private bool test(ScheduleTask sender, String msg)
        {
            byte[] data = { 0xff, 0xff };
            return send(2, data);
        }

        private bool send(short address,byte[] data)
        {
            CommDeviceModbuseControlEntity command = new CommDeviceModbuseControlEntity();
            command.DivID = DeviceObj.GetDevice().Device.UnitId;
            command.functioncode = FunctionCode.WriteSingleRegister;
            command.SetInfoStartAdr = address;
            command.RegisterLen = 2;
            command.SetData = data;
            DeviceObj.GetWrapper().sendCommand(command);
            return command.IsSuccess;
        }


    }



}
