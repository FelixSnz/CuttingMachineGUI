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

        Canvas currentCanvas;

        private double SurfaceHeightValue;
        private double SurfaceWidthValue;
        private double ClothHeightValue;
        private double SeparationValue;
        private double MarginValue;

        private string Units;



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
                throw new Exception($"Unexpected unit format, recv: {myCanvas.Units}, expected: 'mm' or 'in'");

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



        private void MillimetersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MillimetersCheckBox.Checked)
            {
                InchesCheckBox.Checked = false;
            }

        }

        private void InchesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InchesCheckBox.Checked)
            {
                MillimetersCheckBox.Checked = false;
            }
        }

        private void ValidateNewSettings()
        {

            SurfaceWidthValue = Convert.ToDouble(SurfaceWidthTxtBox.Text);
            SurfaceHeightValue = Convert.ToDouble(SurfaceHeightTxtBox.Text);
            ClothHeightValue = Convert.ToDouble(ClothHeightTxtBox.Text);
            SeparationValue = Convert.ToDouble(SeparationTxtBox.Text);
            MarginValue = Convert.ToDouble(MarginTxtBox.Text);


            Units = InchesCheckBox.Checked ? "in" : "mm";

            double ConversionFactor;

            int SurfaceWidthPixels;
            int SurfaceHeightPixels;
            int ClothHeightPixels;
            int SeparationPixels;
            int MarginPixels;

            switch (Units)
            {
                case "mm":
                    ConversionFactor = Convert.ToDouble(ConfigurationManager.AppSettings["MillimetersConversionFactor"]);
                    SurfaceWidthPixels = Convert.ToInt32(SurfaceWidthValue * ConversionFactor);
                    SurfaceHeightPixels = Convert.ToInt32(SurfaceHeightValue * ConversionFactor);
                    ClothHeightPixels = Convert.ToInt32(ClothHeightValue * ConversionFactor);
                    SeparationPixels = Convert.ToInt32(SeparationValue * ConversionFactor);
                    MarginPixels = Convert.ToInt32(MarginValue * ConversionFactor);
                    break;
                case "in":
                    ConversionFactor = Convert.ToDouble(ConfigurationManager.AppSettings["MillimetersConversionFactor"]);
                    SurfaceWidthPixels = Convert.ToInt32(SurfaceWidthValue * ConversionFactor);
                    SurfaceHeightPixels = Convert.ToInt32(SurfaceHeightValue * ConversionFactor);
                    ClothHeightPixels = Convert.ToInt32(ClothHeightValue * ConversionFactor);
                    SeparationPixels = Convert.ToInt32(SeparationValue * ConversionFactor);
                    MarginPixels = Convert.ToInt32(MarginValue * ConversionFactor);
                    break;
                default:
                    throw new Exception("invalid units");
            }
            if (ClothHeightValue > SurfaceHeightValue)
            {
                throw new Exception($"la altura de la tela no puede ser mayor a la base {SurfaceHeightValue}");
            }

            int SurfaceWidthResolutionLimit = Convert.ToInt32(ConfigurationManager.AppSettings["SurfaceWidthResolutionLimit"]);
            int SurfaceHeightResolutionLimit = Convert.ToInt32(ConfigurationManager.AppSettings["SurfaceHeightResolutionLimit"]);

            if (SurfaceWidthPixels > SurfaceWidthResolutionLimit)
            {
                throw new Exception($"el largo de la base no puede ser mayor a {SurfaceWidthResolutionLimit}");
            }

            if (SurfaceHeightPixels > SurfaceHeightResolutionLimit)
            {
                throw new Exception($"la altura de la base no puede ser mayor a {SurfaceHeightResolutionLimit}");
            }
        }

        private void SaveDesign_Click(object sender, EventArgs e)
        {

            try
            {
                ValidateNewSettings();
            }

            catch (Exception err)
            {
                MessageBox.Show(
                err.Message,
                "Una o mas medidas invalidas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
                );
                return;
            }



            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SurfaceWidth"].Value = SurfaceWidthTxtBox.Text;

 
            config.AppSettings.Settings["SurfaceHeight"].Value = SurfaceHeightTxtBox.Text;
            config.AppSettings.Settings["ClothHeight"].Value = ClothHeightTxtBox.Text;
            config.AppSettings.Settings["DistanceBetweenCuts"].Value = SeparationTxtBox.Text;
            config.AppSettings.Settings["CutsMargin"].Value = MarginTxtBox.Text;
            config.AppSettings.Settings["Units"].Value = InchesCheckBox.Checked ? "in" : "mm";

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

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();

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
