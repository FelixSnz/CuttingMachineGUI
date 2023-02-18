using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using CuttingMachineGUI.Components;

namespace CuttingMachineGUI.BusinessLogic.Models
{
    internal class Canvas
    {

        #region Variables
        public Graphics graphics;
        public Rectangle selectedRect;
        public Rectangle lastSelectedRect;
        public Point offset;
        public int SurfaceWidth;
        public int SurfaceHeight;
        public int FabricHeight;
        private int DistanceBetweenCuts;
        private int CutsMargin;
        public string Units;
        public List<Rectangle> Rects = new List<Rectangle>();
        private MyPanel myPanel;
        #endregion


        public Canvas(MyPanel panel)

        {
            InitializeFields();
            myPanel = panel;
            graphics = panel.CreateGraphics();

        }

        private void InitializeFields()
        {
            SurfaceWidth = Convert.ToInt32(ConfigurationManager.AppSettings["SurfaceWidth"]);
            SurfaceHeight = Convert.ToInt32(ConfigurationManager.AppSettings["SurfaceHeight"]);
            FabricHeight = Convert.ToInt32(ConfigurationManager.AppSettings["FabricHeight"]);
            DistanceBetweenCuts = Convert.ToInt32(ConfigurationManager.AppSettings["DistanceBetweenCuts"]);
            CutsMargin = Convert.ToInt32(ConfigurationManager.AppSettings["CutsMargin"]);
            Units = ConfigurationManager.AppSettings["Units"];
        }

        public void UpdateGraphics()
        {
            graphics = myPanel.CreateGraphics();
        }

        public void Redraw(PaintEventArgs e)
        {
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen ligthBluePen = new Pen(Color.Green, 1);
            foreach (Rectangle Rect in Rects)
            {
                int x = Rect.X;
                int y = Rect.Y;
                int width = Rect.Width;
                int height = Rect.Height;
                e.Graphics.FillRectangle(whiteBrush, x, y, width, height);
                e.Graphics.DrawRectangle(ligthBluePen, x, y, width - 1, height - 1);
            }
        }

        public void Update()
        {
            graphics = myPanel.CreateGraphics();
            myPanel.Size = new Size(SurfaceWidth, FabricHeight);
            myPanel.Location = new Point(0, 0);
            ControlPaint.DrawBorder(graphics, myPanel.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);

            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen ligthBluePen = new Pen(Color.Green, 1);
            foreach (Rectangle Rect in Rects)
            {
                int x = Rect.X;
                int y = Rect.Y;
                int width = Rect.Width;
                int height = Rect.Height;
                graphics.FillRectangle(whiteBrush, x, y, width, height);
                graphics.DrawRectangle(ligthBluePen, x, y, width - 1, height - 1);
            }
        }



        public (int, int) getNextCutPosition(int newWidth, int newHeight)
        {

            int x = -1;
            int y = -1;

            if (Rects.Count == 0)
            {
                return (CutsMargin, CutsMargin);
            }
            else
            {
                Rectangle lastCutRect = Rects.Last();

                //if (lastCutRect.Right + newWidth + DistanceBetweenCuts <= FabricPanel.ClientSize.Width)
                if (lastCutRect.Right + newWidth + DistanceBetweenCuts <= SurfaceHeight)
                {
                    // There is enough space to add the new cut to the right of the last cut
                    x = lastCutRect.Right + DistanceBetweenCuts;
                    y = CutsMargin;


                }
                else if (lastCutRect.Bottom + newHeight + DistanceBetweenCuts <= FabricHeight)
                //else if (lastCutRect.Bottom + newHeight + DistanceBetweenCuts <= FabricPanel.ClientSize.Height)
                {
                    // There is not enough space to add the new cut to the right of the last cut, so add it below the last cut
                    x = CutsMargin;
                    y = lastCutRect.Bottom + DistanceBetweenCuts;

                }

                foreach (var rect in Rects)
                {
                    if (rect.IntersectsWith(new Rectangle(x, y, newWidth, newHeight)))
                    {
                        // There is overlap, so return (-1, -1)
                        return (-1, -1);
                    }
                }
                return (x, y);

            }
        }

        public void Clear()
        {
            Rects.Clear();
            UpdateGraphics();
            graphics.Clear(Color.FromArgb(10, 0, 30));
        }






        public void AddRect(int width, int height)
        {
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen lightBluePen = new Pen(Color.Green, 1);


            Size canvasSize = myPanel.ClientSize;
            (int x, int y) = getNextCutPosition(width, height);



            if (x >= 0 && y >= 0)
            {
                Rectangle nextRect = new Rectangle(x, y, width, height);
                graphics.FillRectangle(whiteBrush, nextRect);
                graphics.DrawRectangle(lightBluePen, nextRect);
                Rects.Add(nextRect);


            }
            else
            {
                throw new Exception("invalid figure");
            }

        }
    }

    
}
