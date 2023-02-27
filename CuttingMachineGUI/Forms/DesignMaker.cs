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
        private bool unsavedChanges;
        private List<Rectangle> savedRects;

        public DesignMaker()
        {
            InitializeComponent();
            InitializeTooltips();
            this.TabIndex = 1;
            this.Focus();   
            //this.KeyPreview = true;

            myCanvas = new Canvas(FabricPanel);
            FabricPanel.Location = new Point(0, 0);
            BgPanel.Size = new Size(myCanvas.SurfaceWidthPixels, myCanvas.SurfaceHeightPixels);
            FabricPanel.Size = new Size(myCanvas.SurfaceWidthPixels, myCanvas.ClothHeightPixels);
            unsavedChanges= false;
            UpdateFileNameLabel();
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

            ToolTip UndoBtnTooltip = new ToolTip();
            UndoBtnTooltip.SetToolTip(this.UndoBtn, "deshacer");

            ToolTip RedoBtnTooltip = new ToolTip();
            RedoBtnTooltip.SetToolTip(this.RedoBtn, "rehacer");
        }

        private struct RGBColors
        {
            public static Color whiteblue = Color.FromArgb(154, 246, 255);
            public static Color whitered = Color.FromArgb(255, 64, 64);
            public static Color whitegreen = Color.FromArgb(74, 255, 64);
            public static Color grayblue = Color.FromArgb(57, 96, 142);
            public static Color blackblue = Color.FromArgb(10, 0, 30);
            public static Color erasecolor = Color.FromArgb(10, 0, 30);
            public static Color invalidPosition = Color.FromArgb(251, 94, 94);

        }

        private void SingleCutBtn_Click(object sender, EventArgs e)
        {
            Popups.PromptSize promptSizeWindow = new Popups.PromptSize(
                "Agregar corte",
                myCanvas.Units, 
                false
                );

            promptSizeWindow.StartPosition = FormStartPosition.CenterScreen;

            if (promptSizeWindow.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myCanvas.updateUndoStack();
                    myCanvas.AddRect(
                        promptSizeWindow.width,
                        promptSizeWindow.height
                        );
                    unsavedChanges= true;
                    UpdateFileNameLabel();


                }
                catch (Exception ex) {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void MatrixCutBtn_Click(object sender, EventArgs e)
        {
            Popups.PromptSize promptSizeWindow = new Popups.PromptSize(
                "Agregar cortes",
                myCanvas.Units,
                true
                );

            promptSizeWindow.StartPosition = FormStartPosition.CenterScreen;

            if (promptSizeWindow.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myCanvas.updateUndoStack();
                    myCanvas.AddMultipleRects(
                        promptSizeWindow.width,
                        promptSizeWindow.height,
                        promptSizeWindow.HorizontalCopies,
                        promptSizeWindow.VerticalCopies
                        );
                    unsavedChanges = true;
                    UpdateFileNameLabel();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                e.Graphics,
                BgPanel.ClientRectangle,
                Color.Green,
                ButtonBorderStyle.Solid
                );
        }

        private void FabricPanel_Paint(object sender, PaintEventArgs e)
        {
            myCanvas.UpdateGraphics();
            ControlPaint.DrawBorder(
                e.Graphics,
                FabricPanel.ClientRectangle,
                Color.LightBlue,
                ButtonBorderStyle.Solid
                );

            // Redraw all the figures
            myCanvas.Redraw(e.Graphics);



        }

        private void FabricPanel_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Rectangle Rect in myCanvas.Rects)
            {
                if (Rect.Contains(e.Location))
                {

                    myCanvas.selectedRect = Rect;
                    myCanvas.UpdateLastRect();
                    myCanvas.lastSelectedRect = myCanvas.selectedRect;
                    myCanvas.offset = new Point(e.Location.X - Rect.X, e.Location.Y - Rect.Y);
                    myCanvas.updateUndoStack();
                    break;
                }
            }
        }



        private void FabricPanel_MouseMove(object sender, MouseEventArgs e)
        {
            myCanvas.onDragRect(e);

            //redraws the panel
            FabricPanel.Invalidate();

        }

        private void FabricPanel_MouseUp(object sender, MouseEventArgs e)
        {






            myCanvas.SafeRectRelease();
            myCanvas.lastSelectedRect = myCanvas.selectedRect;
            myCanvas.selectedRect = Rectangle.Empty;
            unsavedChanges = true;
            UpdateFileNameLabel();

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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCanvas.updateUndoStack();
            EraseDrawnRect(myCanvas.lastSelectedRect);
            myCanvas.Rects.Remove(myCanvas.lastSelectedRect);
            unsavedChanges = true;

            if (savedRects == null)
            {
                if (myCanvas.Rects.Count == 0)
                {
                    unsavedChanges = false;
                }
                else
                {
                    unsavedChanges = true;
                }
            }
            UpdateFileNameLabel();

        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Popups.PromptSize promtSizeWindow = new Popups.PromptSize(
                "Redimensionar",
                myCanvas.Units,
                false
                );

            promtSizeWindow.StartPosition = FormStartPosition.CenterScreen;

            if (promtSizeWindow.ShowDialog() == DialogResult.OK)
            {
                EraseDrawnRect(myCanvas.lastSelectedRect);
                int index = myCanvas.Rects.IndexOf(myCanvas.lastSelectedRect);
                myCanvas.updateUndoStack();

                myCanvas.Rects[index] = new Rectangle(
                    myCanvas.lastSelectedRect.X,
                    myCanvas.lastSelectedRect.Y,
                    promtSizeWindow.Width,
                    promtSizeWindow.Height    
                    );

                unsavedChanges = true;
                UpdateFileNameLabel();
                FabricPanel.Invalidate();
            }
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCanvas.updateUndoStack();
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
            unsavedChanges = true;
            UpdateFileNameLabel();
            FabricPanel.Invalidate();
        }

        private void SaveDesign(bool keep)
        {
            // Prompt the user to select a file location to save the JSON file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Save rectangles as JSON file";
            saveFileDialog.FileName = "*.json";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Serialize the list of rectangles to a JSON string
                string jsonString = JsonSerializer.Serialize(myCanvas.Rects);

                // Write the JSON string to the specified file path
                File.WriteAllText(filePath, jsonString);
                unsavedChanges = false;
                UpdateFileNameLabel();
                if (keep)
                {
                    JsonFileNameLbl.Text = filePath.Split('\\').Last();
                    savedRects = new List<Rectangle>(myCanvas.Rects);
                    

                }
                

            }
        }


        private void SaveDesignBtn_Click(object sender, EventArgs e)
        {
            SaveDesign(true);

        }

        private void LoadFileBtn_Click(object sender, EventArgs e)
        {

            if (unsavedChanges)
            {
                DialogResult askResult = MessageBox.Show(
                    "Desea guardar los cambios antes de cargar un nuevo archivo?",
                    "Cambios sin guardar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (askResult == DialogResult.Yes)
                {
                    SaveDesign(false); // Call your Save function.
                }

            }

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
                if (myCanvas.Rects.Count > 0)
                {
                    savedRects = new List<Rectangle>(myCanvas.Rects);
                }

                FabricPanel.Invalidate();
                JsonFileNameLbl.Text = filePath.Split('\\').Last();
                
            }
        }

        private void EraseDrawnRect(Rectangle Rect)
        {
            SolidBrush eraser = new SolidBrush(RGBColors.blackblue);
            myCanvas.Graphics.FillRectangle(
                eraser,
                Rect.X, 
                Rect.Y, 
                Rect.Width + 1, 
                Rect.Height + 1
                );
        }



        private void ClearBtn_Click(object sender, EventArgs e)
        {

            if (unsavedChanges)
            {
                DialogResult askResult = MessageBox.Show(
                    "Desea guardar los cambios antes de borrar el diseño actual?",
                    "Cambios sin guardar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (askResult == DialogResult.Yes)
                {
                    SaveDesign(false); // Call your Save function.

                }


            }
            myCanvas.Clear();
            if (savedRects == null)
            {
                if (myCanvas.Rects.Count == 0)
                {
                    unsavedChanges = false;
                }
                else
                {
                    unsavedChanges = true;
                }
            }
            
            UpdateFileNameLabel();
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            myCanvas.undo();
            FabricPanel.Invalidate();

            if (savedRects != null) 
            {

                if (myCanvas.Rects.SequenceEqual(savedRects))
                {
                    unsavedChanges = false;
                }
                else
                {
                    unsavedChanges = true;
                }
            }
            else
            {
                if (myCanvas.Rects.Count == 0)
                {
                    unsavedChanges = false;
                }
                else
                {
                    unsavedChanges = true;
                }
            }
            UpdateFileNameLabel();
        }

        private void RedoBtn_Click(object sender, EventArgs e)
        {
            myCanvas.redo();
            FabricPanel.Invalidate();

            if (savedRects != null)
            {
                if (myCanvas.Rects.SequenceEqual(savedRects))
                {
                    unsavedChanges = false;
                }
                else
                {
                    unsavedChanges = true;
                }
            }
            else
            {
                if (myCanvas.Rects.Count == 0)
                {
                    unsavedChanges = false;
                }
                else
                {
                    unsavedChanges = true;
                }
            }
            UpdateFileNameLabel();

        }

        void UpdateFileNameLabel()
        {
            string fileName = JsonFileNameLbl.Text;
            if (unsavedChanges)
            {
                if (!fileName.EndsWith("*"))
                    JsonFileNameLbl.Text = fileName + "*";
            }
            else
            {
                if (fileName.EndsWith("*"))
                    fileName = fileName.Substring(0, fileName.Length - 1);
                JsonFileNameLbl.Text = fileName;

            }
        }

        private void DesignMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show("Desea guardar los cambios antes de salir del editor?",
                    "Cambios sin guardar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveDesign(false); // Call your Save function.
                }
                else if (result == DialogResult.No)
                {
                    return; // User cancelled the load operati-on.
                }
            }
        }

        private void DesignMaker_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("someting pressed");
            if (e.Control && e.KeyCode == Keys.Z)
            {

                MessageBox.Show("eere");
            }
        }


        private void DesignerPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            MessageBox.Show("asdad");
            if (e.Control && e.KeyCode == Keys.S)
            {
                // Perform save action here
                e.IsInputKey = true; // Mark the event as handled so that it doesn't propagate to the parent form
            }
        }

        private void DesignSettingsBtn_Click(object sender, EventArgs e)
        {
            Popups.CanvasSettings canvasSettingsWindow = new Popups.CanvasSettings(myCanvas);

            canvasSettingsWindow.StartPosition = FormStartPosition.CenterScreen;

            if (canvasSettingsWindow.ShowDialog() == DialogResult.OK)
            {
               
            }

        }
    }
}