using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SolarMonitor.DeviceUI.Solar_PV
{
    public partial class OneDigitalGaugeUserControl : DevExpress.XtraEditors.XtraUserControl
    {

        public void SetUserControlInfo(string svalue)
        {
            if (svalue != null)
                digitalGauge1.Text = svalue;
        }

        public OneDigitalGaugeUserControl()
        {
            InitializeComponent();
        }

    }
}
