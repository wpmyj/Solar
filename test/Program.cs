using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream txt = File.Open("DeviceCN.xml", FileMode.OpenOrCreate);
            System.Xml.Serialization.XmlSerializer serial = new System.Xml.Serialization.XmlSerializer(typeof(Model_Data.DeviceModel));
            Model_Data.DeviceModel obj = (Model_Data.DeviceModel)serial.Deserialize(txt);
            serial.Serialize(Console.Out, obj);
              
            ACCESSDBDAL.AccessDbHelper.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=iSmart.mdb";
            bool aa = ACCESSDBDAL.AccessServer.IsTableExist("List_Port");
            bool bb = ACCESSDBDAL.AccessServer.IsTableExist("List1_Port");
            ACCESSDBDAL.AccessServer.CreateDataTable(obj.TableName, obj.Analog);
            ACCESSDBDAL.AccessServer.CreateEventTable();
        }
    }
}
