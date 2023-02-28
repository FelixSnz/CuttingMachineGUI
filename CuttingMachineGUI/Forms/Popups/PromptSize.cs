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

namespace CuttingMachineGUI.Popups
{
    public partial class PromptSize : Form
    {
        public double height;
        public double width;
        public int VerticalCopies;
        public int HorizontalCopies;
        public PromptSize(string Title, string units, bool multiple)
        {
            InitializeComponent();

            titleLabel.Text = Title;
            UnitsLbl1.Text = units;
            UnitsLbl2.Text = units;
            this.Text = string.Empty;
            this.ControlBox = false;

            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            if (multiple)
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
            height = Convert.ToDouble(HeightTxtBox.Text);
            width = Convert.ToDouble(WidthTxtBox.Text);
            VerticalCopies = Convert.ToInt32(VerticalCopiesCmbBox.Text);
            HorizontalCopies = Convert.ToInt32(HorizontalCopiesCmbBox.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            this.titlePanel_MouseDown(sender, e);
        }

        private void EnterTrigger(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (WidthTxtBox.Text != "" && HeightTxtBox.Text != "")
                {
                    OkBtn_Click(sender, e);
                }
            }
        }

        private void DoubleFilter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
