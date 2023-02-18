using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Text.Json;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;
using MessageBox = System.Windows.Forms.MessageBox;
using CuttingMachineGUI.BusinessLogic.Models;

namespace CuttingMachineGUI.Forms
{
    public partial class DesignMaker : Form
    {

        private Canvas myCanvas;



        public DesignMaker()
        {
            InitializeComponent();

            InitializeTooltips();


            myCanvas = new Canvas(FabricPanel);
            FabricPanel.Location = new Point(0, 0);
            BgPanel.Size = new Size(myCanvas.SurfaceWidth, myCanvas.SurfaceHeight);
            FabricPanel.Size = new Size(myCanvas.SurfaceWidth, myCanvas.FabricHeight);


        }




        private void InitializeTooltips()
        {
            ToolTip SingleCutBtnTooltip = new ToolTip();
            SingleCutBtnTooltip.SetToolTip(this.SingleCutBtn, "agregar un corte");

            ToolTip MatrixCutBtnTooltip = new ToolTip();
            MatrixCutBtnTooltip.SetToolTip(this.MatrixCutBtn, "agregar matriz de cortes");

            ToolTip ClearBtnTooltip = new ToolTip();
            ClearBtnTooltip.SetToolTip(this.ClearBtn, "borrar diseño actual");

            ToolTip SortBtnTooltip = new ToolTip();
            SortBtnTooltip.SetToolTip(this.SortBtn, "optimizar espacio");

            ToolTip LoadDesignBtnTooltip = new ToolTip();
            LoadDesignBtnTooltip.SetToolTip(this.LoadDesignBtn, "cargar diseño");

            ToolTip SaveDesignBtnBtnTooltip = new ToolTip();
            SaveDesignBtnBtnTooltip.SetToolTip(this.SaveDesignBtn, "guardar diseño");

            ToolTip DesignSettingsBtnTooltip = new ToolTip();
            DesignSettingsBtnTooltip.SetToolTip(this.DesignSettingsBtn, "ajustes de diseño");
        }

        private struct RGBColors
        {
            public static Color whiteblue = Color.FromArgb(154, 246, 255);
            public static Color whitered = Color.FromArgb(255, 64, 64);
            public static Color whitegreen = Color.FromArgb(74, 255, 64);
            public static Color grayblue = Color.FromArgb(57, 96, 142);

            public static Color blackblue = Color.FromArgb(10, 0, 30);
            public static Color erasecolor = Color.FromArgb(10, 0, 30);

        }

        private void SingleCutBtn_Click(object sender, EventArgs e)
        {

            SubForms.NewSingleCut newForm = new SubForms.NewSingleCut("Agregar corte", myCanvas.Units, false);

            newForm.StartPosition = FormStartPosition.CenterScreen;

            if (newForm.ShowDialog() == DialogResult.OK)
            {
                myCanvas.AddRect(newForm.HorizontalDistance, newForm.VerticalDistance);
            }

            newForm.Close();
        }

        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.BgPanel.ClientRectangle, Color.Green, ButtonBorderStyle.Solid);
        }


        private void FabricPanel_Paint(object sender, PaintEventArgs e)
        {
            myCanvas.UpdateGraphics();
            ControlPaint.DrawBorder(e.Graphics, this.FabricPanel.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);

            // Redraw all the figures
            myCanvas.Redraw(e);

        }



        private void FabricPanel_MouseDown(object sender, MouseEventArgs e)
        {
            FabricPanel.SuspendLayout();
            foreach (Rectangle Rect in myCanvas.Rects)
            {
                if (Rect.Contains(e.Location))
                {
                    myCanvas.selectedRect = Rect;
                    myCanvas.offset = new Point(e.Location.X - Rect.X, e.Location.Y - Rect.Y);
                    break;
                }

            }
        }

        private void FabricPanel_MouseMove(object sender, MouseEventArgs e)
        {

            if (myCanvas.selectedRect != Rectangle.Empty)
            {

                int dx = (e.Location.X - myCanvas.selectedRect.X);
                int dy = (e.Location.Y - myCanvas.selectedRect.Y);

                int index = myCanvas.Rects.IndexOf(myCanvas.selectedRect);

                myCanvas.Rects[index] = new Rectangle(
                    myCanvas.selectedRect.X + dx - myCanvas.offset.X,
                    myCanvas.selectedRect.Y + dy - myCanvas.offset.Y,
                    myCanvas.selectedRect.Width,
                    myCanvas.selectedRect.Height
                    );

                myCanvas.selectedRect = myCanvas.Rects[index];
                FabricPanel.Invalidate();

            }

        }



        private void FabricPanel_MouseUp(object sender, MouseEventArgs e)
        {
            FabricPanel.ResumeLayout();
            myCanvas.lastSelectedRect = myCanvas.selectedRect;
            myCanvas.selectedRect = Rectangle.Empty;
        }

        private void FabricPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (Rectangle rect in myCanvas.Rects) // myRectangles is a List<Rectangle> that contains your drawn rectangles
                {
                    if (rect.Contains(e.Location))
                    {
                        // show the context menu strip
                        figureMenuStrip.Show(FabricPanel, e.Location);
                        return;
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EraseDrawnRect(myCanvas.lastSelectedRect);
            myCanvas.Rects.Remove(myCanvas.lastSelectedRect);
        }

        private void redimensionarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SubForms.NewSingleCut newCutForm = new SubForms.NewSingleCut("Redimensionar", myCanvas.Units, false);

            newCutForm.StartPosition = FormStartPosition.CenterScreen;


            if (newCutForm.ShowDialog() == DialogResult.OK)
            {

                EraseDrawnRect(myCanvas.lastSelectedRect);
                int index = myCanvas.Rects.IndexOf(myCanvas.lastSelectedRect);

                myCanvas.Rects[index] = new Rectangle(
                    myCanvas.lastSelectedRect.X,
                    myCanvas.lastSelectedRect.Y,
                    newCutForm.HorizontalDistance, //width
                    newCutForm.VerticalDistance    //height
                    );
                FabricPanel.Invalidate();
            }

            newCutForm.Close();

        }

        private void rotarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EraseDrawnRect(myCanvas.lastSelectedRect);

            Rectangle rotatedRect = new Rectangle(
                myCanvas.lastSelectedRect.Location,
                new Size(
                    myCanvas.lastSelectedRect.Height,
                    myCanvas.lastSelectedRect.Width
                    )
                );

            int index = myCanvas.Rects.IndexOf(myCanvas.lastSelectedRect);
            myCanvas.Rects[index] = rotatedRect;
            FabricPanel.Invalidate();
        }

        private void SaveDesignBtn_Click(object sender, EventArgs e)
        {
            // Prompt the user to select a file location to save the JSON file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Save rectangles as JSON file";
            saveFileDialog.FileName = JsonFileNameLbl.Text;
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Serialize the list of rectangles to a JSON string
                string jsonString = JsonSerializer.Serialize(myCanvas.Rects);

                // Write the JSON string to the specified file path
                File.WriteAllText(filePath, jsonString);
                JsonFileNameLbl.Text = filePath.Split('\\').Last();

            }
        }

        private void LoadFileBtn_Click(object sender, EventArgs e)
        {
            
            // Prompt the user to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.Title = "Open Json file";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                myCanvas.Clear();
                string filePath = openFileDialog.FileName;

                // Read the contents of the file
                string fileContents = File.ReadAllText(filePath);

                // Display the rects in canvas
                myCanvas.Rects = JsonSerializer.Deserialize<List<Rectangle>>(fileContents);
                FabricPanel.Invalidate();
                JsonFileNameLbl.Text = filePath.Split('\\').Last();
            }
        }

        private void EraseDrawnRect(Rectangle Rect)
        {
            SolidBrush eraser = new SolidBrush(RGBColors.blackblue);
            myCanvas.graphics.FillRectangle(eraser, Rect.X, Rect.Y, Rect.Width + 1, Rect.Height + 1);

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "No se han guardado las ultimas modificaciones, seguro que quiere continuar?",
                "Borrar diseño actual",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                myCanvas.Clear();

                ControlPaint.DrawBorder(myCanvas.graphics, this.FabricPanel.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);


            }
        }
    }
}