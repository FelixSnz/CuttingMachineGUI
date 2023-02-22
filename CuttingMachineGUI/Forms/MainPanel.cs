using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Point = System.Drawing.Point;
using MessageBox = System.Windows.Forms.MessageBox;

namespace CuttingMachineGUI
{
    public partial class MainPanel : Form
    {

        //private fields
        private IconButton CurrentBtn;
        private Panel LeftBorderBtn;
        private Form CurrentChildForm;

        //Structs

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);

        }


        public MainPanel()
        {
            InitializeComponent();

            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new System.Drawing.Size(7, 60);
            panelMenu.Controls.Add(LeftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
     
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void HighligthBtn(object senderBtn, Color color)
        {

            if (senderBtn != null)
            {
                UnHighligthCurrentBtn();


                //current button
                CurrentBtn = (IconButton)senderBtn;
                CurrentBtn.BackColor = Color.FromArgb(37, 36, 81);
                CurrentBtn.ForeColor = color;
                CurrentBtn.TextAlign = ContentAlignment.MiddleCenter;
                CurrentBtn.IconColor = color;
                CurrentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                CurrentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //left border on current button
                LeftBorderBtn.BackColor = color;
                LeftBorderBtn.Location = new Point(0, CurrentBtn.Location.Y + panelLogo.Size.Height + 6);
                LeftBorderBtn.Visible = true;
                LeftBorderBtn.BringToFront();

            }
        }

        private void UnHighligthCurrentBtn()
        {
            if (CurrentBtn != null)
            {
                CurrentBtn.BackColor = Color.FromArgb(31, 30, 68);
                CurrentBtn.ForeColor = Color.Gainsboro;
                CurrentBtn.TextAlign = ContentAlignment.MiddleLeft;
                CurrentBtn.IconColor = Color.Gainsboro;
                CurrentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                CurrentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }
            CurrentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            BasePanel.Controls.Add(childForm);
            BasePanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            CurrentPanelLbl.Text = childForm.Text;
        }




        #region EventMethods
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            HighligthBtn(sender, RGBColors.color6);
            OpenChildForm(new Forms.AxisHome());
        }

        private void ESBtn_Click(object sender, EventArgs e)
        {
            HighligthBtn(sender, RGBColors.color6);
            OpenChildForm(new Forms.InputsAndOutputs());
        }

        private void ManualModeBtn_Click(object sender, EventArgs e)
        {
            HighligthBtn(sender, RGBColors.color6);
            OpenChildForm(new Forms.ManualControl());
        }

        private void ModelsBtn_Click(object sender, EventArgs e)
        {
            HighligthBtn(sender, RGBColors.color6);
            OpenChildForm(new Forms.ModelSelection());
        }

        private void CloseWindowBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void MaximizeWdBtn_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void MinimizeWdBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MainPanelBtn_Click(object sender, EventArgs e)
        {
            LeftBorderBtn.Visible = false;
            UnHighligthCurrentBtn();
            CurrentChildForm.Close();
            CurrentPanelLbl.Text = "Panel Principal";
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            if (UserPanel.Height == 51) {

                UserPanel.Height = 170;
                UserBtn.Rotation = 180;
            }
            else
            {
                UserPanel.Height = 51;
                UserBtn.Rotation = 0;

            }
        }

        private void DesignLoaderBtn_Click(object sender, EventArgs e)
        {
            HighligthBtn(sender, RGBColors.color6);
            OpenChildForm(new Forms.DesignLoader());
        }

        private void DesignMakerBtn_Click(object sender, EventArgs e)
        {
            HighligthBtn(sender, RGBColors.color6);
            OpenChildForm(new Forms.DesignMaker());
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            HighligthBtn(sender, RGBColors.color6);
            OpenChildForm(new Forms.Settings());
        }

        private void CurrentPanelLbl_MouseDown(object sender, MouseEventArgs e)
        {
            panelTitleBar_MouseDown(sender, e);
        }


        private void windowBtnsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            panelTitleBar_MouseDown(sender, e);
        }
        #endregion

        private void MainPanel_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            //{

            //    MessageBox.Show("asdadasd");

            //}
        }


    }
}
