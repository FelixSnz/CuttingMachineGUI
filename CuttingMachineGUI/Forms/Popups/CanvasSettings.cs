using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuttingMachineGUI.BusinessLogic.Models;

namespace CuttingMachineGUI.Popups
{
    public partial class CanvasSettings : Form
    {

        public int Height;
        public int Width;
        public int VerticalCopies;
        public int HorizontalCopies;

        private string _units;

        Canvas currentCanvas; 



        public CanvasSettings(Canvas myCanvas)
        {

            currentCanvas = myCanvas;
            
            InitializeComponent();

            SurfaceHeightTxtBox.Text= myCanvas.SurfaceHeight.ToString();
            SurfaceWidthTxtBox.Text= myCanvas.SurfaceWidth.ToString();
            ClothHeightTxtBox.Text = myCanvas.ClothHeight.ToString();
            SeparationTxtBox.Text = myCanvas.distanceBetweenCuts.ToString();
            MarginTxtBox.Text = myCanvas.cutsMargin.ToString();

            string UnitsFromSettings = myCanvas.Units;



            if (UnitsFromSettings == "mm")
            {
                MillimetersCheckBox.Checked = true;
                InchesCheckBox.Checked = false;
            }
            else if (UnitsFromSettings == "in")
            {
                MillimetersCheckBox.Checked = false;
                InchesCheckBox.Checked = true;
            }
            else
            {
                throw new Exception($"Unexpected unit format, recv: {_units}, expected: 'mm' or 'in'");

            }


            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;





        }


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SurfaceWidth"].Value = SurfaceWidthTxtBox.Text;
            config.AppSettings.Settings["SurfaceHeight"].Value = SurfaceHeightTxtBox.Text;
            config.AppSettings.Settings["ClothHeight"].Value = ClothHeightTxtBox.Text;
            config.AppSettings.Settings["DistanceBetweenCuts"].Value = SeparationTxtBox.Text;
            config.AppSettings.Settings["CutsMargin"].Value = MarginTxtBox.Text;

            if (MillimetersCheckBox.Checked)
            {
                config.AppSettings.Settings["Units"].Value = "mm";
            }
            else
            {
                config.AppSettings.Settings["Units"].Value = "in";
            }
            config.Save(ConfigurationSaveMode.Modified);
            this.currentCanvas.UpdateSettings();
            var result = MessageBox.Show("Se requiere volver a iniciar la aplicacion para cargar los cambios, desea salir ahora ?",
                "salir de la aplicacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Call your Save function.
            }
        }

        private void MillimetersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MillimetersCheckBox.Checked)
            {
                InchesCheckBox.Checked = false;
                // Perform actions for the "On" state
            }

        }

        private void InchesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InchesCheckBox.Checked)
            {
                MillimetersCheckBox.Checked = false;
                // Perform actions for the "On" state
            }
        }
    }
}
