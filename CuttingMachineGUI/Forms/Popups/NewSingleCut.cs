using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuttingMachineGUI.SubForms
{
    public partial class NewSingleCut : Form
    {
        public int VerticalDistance;
        public int HorizontalDistance;
        public int VerticalAmount;
        public int HorizontalAmount;
        public NewSingleCut(string Title, string units, bool MultiCut)
        {
            InitializeComponent();

            TitleLabel.Text = Title;
            UnitsLbl1.Text = units;
            UnitsLbl2.Text = units;
            this.Text = string.Empty;
            this.ControlBox = false;

            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            if (MultiCut)
            {
                this.Size = new Size(this.Size.Width + 60, this.Size.Height);
            }
        }



        private void CloseWindowBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void OkBtn_Click(object sender, EventArgs e)
        {

            VerticalDistance = Convert.ToInt32(VerticalDistanceTxtBox.Text);
            HorizontalDistance = Convert.ToInt32(HorizontalDistanceTxtBox.Text);
            VerticalAmount = Convert.ToInt32(VerticalAmountCmbBox.Text);
            HorizontalAmount = Convert.ToInt32(HorizontalAmountCmbBox.Text);


            this.DialogResult = DialogResult.OK;
            




        }


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            this.panel3_MouseDown(sender, e);
        }

        private void NewSingleCut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("enter clicked");
                // Enter key was pressed
                // Your code here

                OkBtn_Click(sender, e);
            }

        }
    }
}
