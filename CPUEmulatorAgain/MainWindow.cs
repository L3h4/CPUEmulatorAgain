using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hardware;
using Hardware.Types;
using Hardware.Buses;
using Hardware.Devices;
using Hardware.Devices.CPU;

namespace CPUEmulatorAgain
{
    public partial class MainWindow : Form
    {
        MotherBord motherBord;
        public MainWindow()
        {
            motherBord = new MotherBord();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            motherBord.Step();

        }
    }
}
