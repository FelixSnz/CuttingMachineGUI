using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuttingMachineGUI.BusinessLogic.Services;

namespace CuttingMachineGUI.Forms
{
    public partial class InputsAndOutputs : Form
    {

        PlcCommunicationService plcComm;
        public InputsAndOutputs()
        {
            InitializeComponent();

            //plcComm = new PlcCommunicationService("127.0.0.1", 1502);


        }

        private async void InputsAndOutputs_Load(object sender, EventArgs e)
        {

            //ushort holdingRegister1Value = await plcComm.ReadMemory(0);
            //label1.Text = holdingRegister1Value.ToString();

        }
    }
}
