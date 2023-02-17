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
using System.Windows.Media.Media3D;

namespace CuttingMachineGUI.Forms
{
    public partial class DesignMaker : Form
    {

        private Graphics myCanvas;
        private Rectangle selectedRect;
        private Rectangle lastSelectedRect;
        private Point offset;



        private int SurfaceWidth = Convert.ToInt32(ConfigurationManager.AppSettings["SurfaceWidth"]);
        private int SurfaceHeight = Convert.ToInt32(ConfigurationManager.AppSettings["SurfaceHeight"]);
        private int FabricHeight = Convert.ToInt32(ConfigurationManager.AppSettings["FabricHeight"]);
        private int DistanceBetweenCuts = Convert.ToInt32(ConfigurationManager.AppSettings["DistanceBetweenCuts"]);
        private int CutsMargin = Convert.ToInt32(ConfigurationManager.AppSettings["CutsMargin"]);


        List<Rectangle> cutRects = new List<Rectangle>();


        public DesignMaker()
        {
            InitializeComponent();
            System.Windows.Forms.ToolTip SingleCutBtnTooltip = new System.Windows.Forms.ToolTip();
            SingleCutBtnTooltip.SetToolTip(this.SingleCutBtn, "agregar un corte");

            System.Windows.Forms.ToolTip MatrixCutBtnTooltip = new System.Windows.Forms.ToolTip();
            MatrixCutBtnTooltip.SetToolTip(this.MatrixCutBtn, "agregar matriz de cortes");

            myCanvas = this.FabricPanel.CreateGraphics();
        }

        private struct RGBColors
        {
            public static Color whiteblue = Color.FromArgb(154, 246, 255);
            public static Color whitered = Color.FromArgb(255, 64, 64);
            public static Color whitegreen = Color.FromArgb(74, 255, 64);
            public static Color grayblue = Color.FromArgb(57, 96, 142);

            public static Color blackblue = Color.FromArgb(10, 0, 30);
            public static Color erasecolor = Color.FromArgb(10, 0, 30);

            //10, 0, 30

        }

        private (int, int) getNextCutPosition(int newWidth, int newHeight)
        {

            int x = -1;
            int y = -1;

            if (cutRects.Count == 0)
            {
                return (CutsMargin, CutsMargin);
            }
            else
            {
                Rectangle lastCutRect = cutRects.Last();

                if (lastCutRect.Right + newWidth + DistanceBetweenCuts <= FabricPanel.ClientSize.Width)
                {
                    // There is enough space to add the new cut to the right of the last cut
                    x = lastCutRect.Right + DistanceBetweenCuts;
                    y = CutsMargin;


                }
                else if (lastCutRect.Bottom + newHeight + DistanceBetweenCuts <= FabricPanel.ClientSize.Height)
                {
                    // There is not enough space to add the new cut to the right of the last cut, so add it below the last cut
                    x = CutsMargin;
                    y = lastCutRect.Bottom + DistanceBetweenCuts;

                }

                foreach (var cut in cutRects)
                {
                    if (cut.IntersectsWith(new Rectangle(x, y, newWidth, newHeight)))
                    {
                        // There is overlap, so return (-1, -1)
                        return (-1, -1);
                    }
                }
                return (x, y);

            }
        }

        private void AddFigureToCanvas(int width, int height)
        {
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen lightBluePen = new Pen(Color.Green, 1);


            Size canvasSize = FabricPanel.ClientSize;
            (int x, int y) = getNextCutPosition(width, height);



            if (x >= 0 && y >= 0)
            {
                Rectangle nextRect = new Rectangle(x, y, width, height);
                myCanvas.FillRectangle(whiteBrush, nextRect);
                myCanvas.DrawRectangle(lightBluePen, nextRect);
                cutRects.Add(nextRect);


            }
            else
            {
                MessageBox.Show("invalid figure");
            }

        }


        private void SingleCutBtn_Click(object sender, EventArgs e)
        {

            SubForms.NewSingleCut newForm = new SubForms.NewSingleCut();

            newForm.StartPosition = FormStartPosition.CenterScreen;


            if (newForm.ShowDialog() == DialogResult.OK)
            {
                AddFigureToCanvas(newForm.HorizontalDistance, newForm.VerticalDistance);
            }

            newForm.Close();
        }

        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            this.BgPanel.Size = new Size(SurfaceWidth, SurfaceHeight);
            ControlPaint.DrawBorder(e.Graphics, this.BgPanel.ClientRectangle, Color.Green, ButtonBorderStyle.Solid);

        }


        private void FabricPanel_Paint(object sender, PaintEventArgs e)
        {
            myCanvas = this.FabricPanel.CreateGraphics();
            this.FabricPanel.Size = new Size(SurfaceWidth, FabricHeight);
            this.FabricPanel.Location = new Point(0, SurfaceHeight - this.FabricPanel.Size.Height);
            ControlPaint.DrawBorder(e.Graphics, this.FabricPanel.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);


            // Redraw all the figures
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen ligthBluePen = new Pen(Color.Green, 1);
            foreach (Rectangle cutRect in cutRects)
            {
                int x = cutRect.X;
                int y = cutRect.Y;
                int width = cutRect.Width;
                int height = cutRect.Height;
                e.Graphics.FillRectangle(whiteBrush, x, y, width, height);
                e.Graphics.DrawRectangle(ligthBluePen, x, y, width - 1, height - 1);
            }

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
                myCanvas = this.FabricPanel.CreateGraphics();
                cutRects.Clear();
                myCanvas.Clear(RGBColors.blackblue);

                this.FabricPanel.Size = new Size(SurfaceWidth, FabricHeight);
                this.FabricPanel.Location = new Point(0, SurfaceHeight - this.FabricPanel.Size.Height);
                ControlPaint.DrawBorder(myCanvas, this.FabricPanel.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);


            }


        }

        private void FabricPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse down");
            foreach (Rectangle cutRect in cutRects)
            {
                if (cutRect.Contains(e.Location))
                {
                    Console.WriteLine("showing menu strip");
                    //figureMenuStrip.
                    selectedRect = cutRect;
                    offset = new Point(e.Location.X - cutRect.X, e.Location.Y - cutRect.Y);
                    break;
                }

            }
        }

        private void FabricPanel_MouseMove(object sender, MouseEventArgs e)
        {

            if (selectedRect != Rectangle.Empty)
            {


                int dx = (e.Location.X - selectedRect.X);
                int dy = (e.Location.Y - selectedRect.Y);

                int index = cutRects.IndexOf(selectedRect);


                EraseDrawnRect(selectedRect);

                cutRects[index] = new Rectangle(
                    selectedRect.X + dx - offset.X, 
                    selectedRect.Y + dy - offset.Y,
                    selectedRect.Width,
                    selectedRect.Height
                    );


                selectedRect = cutRects[index];
                FabricPanel_Paint(sender, new PaintEventArgs(myCanvas, FabricPanel.ClientRectangle));
                
            }

        }

        private void EraseDrawnRect(Rectangle Rect)
        {
            SolidBrush whiteBrush = new SolidBrush(RGBColors.blackblue);
            Pen ligthBluePen = new Pen(RGBColors.blackblue, 1);

            myCanvas.FillRectangle(whiteBrush, Rect.X, Rect.Y, Rect.Width, Rect.Height);
            myCanvas.DrawRectangle(ligthBluePen, Rect.X, Rect.Y, Rect.Width, Rect.Width);

        }

        private void FabricPanel_MouseUp(object sender, MouseEventArgs e)
        {
            lastSelectedRect = selectedRect;
            selectedRect = Rectangle.Empty;
            Console.WriteLine("cleaning selected rect");
        }

        private void FabricPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (Rectangle rect in cutRects) // myRectangles is a List<Rectangle> that contains your drawn rectangles
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
            EraseDrawnRect(lastSelectedRect);
            cutRects.Remove(lastSelectedRect);
        }
    }
}