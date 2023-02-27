using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using CuttingMachineGUI.Components;

using Size = System.Drawing.Size;
using Point = System.Drawing.Point;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using Rectangle = System.Drawing.Rectangle;

using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Media;
using System.Drawing.Printing;
using System.Windows.Shapes;

namespace CuttingMachineGUI.BusinessLogic.Models
{
    public class Canvas
    {

        #region Variables
        public Graphics Graphics;
        public Rectangle selectedRect;
        public Rectangle lastSelectedRect;
        public Point offset;

        public double SurfaceWidth;
        public int SurfaceWidthPixels;

        public int SurfaceHeightPixels;
        public double SurfaceHeight;

        public int ClothHeightPixels;
        public double ClothHeight;

        public int distanceBetweenCutsPixels;
        public double distanceBetweenCuts;

        public int cutsMarginPixels;
        public double cutsMargin;

        private double MillimetersConversionFactor;
        private double InchesConversionFactor;

        public string Units;
        public List<Rectangle> Rects;

        private Stack<List<Rectangle>> UndoStack = new Stack<List<Rectangle>>();
        private Stack<List<Rectangle>> RedoStack = new Stack<List<Rectangle>>();

        private MyPanel myPanel;

        #endregion

        
        public Canvas(MyPanel panel)

        {
            InitializeFields();
            myPanel = panel;
            Graphics = panel.CreateGraphics();
            Rects = new List<Rectangle>();

        }

        private void InitializeFields()
        {
            UpdateSettings();
        }

        public void UpdateSettings()
        {

            Units = ConfigurationManager.AppSettings["Units"];

            SurfaceWidth = Convert.ToDouble(ConfigurationManager.AppSettings["SurfaceWidth"]);
            SurfaceHeight = Convert.ToDouble(ConfigurationManager.AppSettings["SurfaceHeight"]);
            ClothHeight = Convert.ToDouble(ConfigurationManager.AppSettings["ClothHeight"]);
            distanceBetweenCuts = Convert.ToDouble(ConfigurationManager.AppSettings["DistanceBetweenCuts"]);
            cutsMargin = Convert.ToDouble(ConfigurationManager.AppSettings["CutsMargin"]);

            MillimetersConversionFactor = Convert.ToDouble(ConfigurationManager.AppSettings["MillimetersConversionFactor"]);
            InchesConversionFactor = Convert.ToDouble(ConfigurationManager.AppSettings["InchesConversionFactor"]);

            switch (Units)
            {
                case "mm":
                    SurfaceHeightPixels = Convert.ToInt32(SurfaceHeight * MillimetersConversionFactor);
                    SurfaceWidthPixels = Convert.ToInt32(SurfaceWidth * MillimetersConversionFactor);
                    ClothHeightPixels = Convert.ToInt32(ClothHeight * MillimetersConversionFactor);
                    distanceBetweenCutsPixels = Convert.ToInt32(distanceBetweenCuts * MillimetersConversionFactor);
                    cutsMarginPixels = Convert.ToInt32(cutsMargin * MillimetersConversionFactor);

                    break;
                case "in":

                    SurfaceHeightPixels = Convert.ToInt32(SurfaceHeight * InchesConversionFactor);
                    SurfaceWidthPixels = Convert.ToInt32(SurfaceWidth * InchesConversionFactor);
                    ClothHeightPixels = Convert.ToInt32(ClothHeight * InchesConversionFactor);
                    distanceBetweenCutsPixels = Convert.ToInt32(distanceBetweenCuts * InchesConversionFactor);
                    cutsMarginPixels = Convert.ToInt32(cutsMargin * InchesConversionFactor);
                    break;
                default:
                    throw new Exception("invalid units");
                    break;
            }




            

        }

        public void UpdateGraphics()
        {
            Graphics = myPanel.CreateGraphics();
        }

        private bool SelectedRectColliding()
        {


            if (selectedRect != null)
            {
                foreach (Rectangle Rect in Rects)
                {
                    if (Rect != selectedRect)
                    {
                        if (selectedRect.IntersectsWith(Rect) || !myPanel.ClientRectangle.Contains(selectedRect))
                        {
                            return true;
                        }
                    }

                }
            }
            return false;

        }

        public void Redraw(Graphics graphics)
        {
            //MessageBox.Show("redrawing");
            SolidBrush validbrush = new SolidBrush(Color.White);
            SolidBrush invalidbrush = new SolidBrush(Color.Red);
            Pen pen = new Pen(Color.Green, 1);


            foreach (Rectangle Rect in Rects)
            {
                int x = Rect.X;
                int y = Rect.Y;
                int width = Rect.Width;
                int height = Rect.Height;

                if (SelectedRectColliding() && Rect == selectedRect)
                {
                    graphics.FillRectangle(invalidbrush, x, y, width, height);
                }
                else
                {
                    graphics.FillRectangle(validbrush, x, y, width, height);
                }
                graphics.DrawRectangle(pen, x, y, width - 1, height - 1);
            }
        }

        private Point getNextPosition(int newWidth, int newHeight)
        {
            int x = -1;
            int y = -1;

            if (Rects.Count == 0)
            {
                return new Point(cutsMarginPixels, cutsMarginPixels);
            }
            else
            {
                Rectangle lastCutRect = Rects.Last();

                if (lastCutRect.Right + newWidth + distanceBetweenCutsPixels <= SurfaceHeightPixels)
                {
                    // There is enough space to add the new cut to the right of the last cut
                    x = lastCutRect.Right + distanceBetweenCutsPixels;
                    y = cutsMarginPixels;


                }
                else if (lastCutRect.Bottom + newHeight + distanceBetweenCutsPixels <= ClothHeightPixels)
                {
                    // There is not enough space to add the new cut to the right of the last cut, so add it below the last cut
                    x = cutsMarginPixels;
                    y = lastCutRect.Bottom + distanceBetweenCutsPixels;

                }

                foreach (var rect in Rects)
                {
                    if (rect.IntersectsWith(new Rectangle(x, y, newWidth, newHeight)))
                    {
                        // There is overlap, so return (-1, -1)
                        return new Point(-1, -1);
                    }
                }
                return new Point(x, y);

            }
        }

        //public Point FindValidPosition(int width, int height)
        //{
        //    int maxRectangles = (canvasWidth - 2 * margin) / (rectWidth + separation) * (canvasHeight - 2 * margin) / (rectHeight + separation);

        //    for (int x = margin; x <= canvasWidth - margin - rectWidth; x += rectWidth + separation)
        //    {
        //        for (int y = margin; y <= canvasHeight - margin - rectHeight; y += rectHeight + separation)
        //        {
        //            Rectangle newRect = new Rectangle(x, y, rectWidth, rectHeight);
        //            bool isValid = true;
        //            foreach (Rectangle rect in rectangles)
        //            {
        //                if (newRect.IntersectsWith(rect))
        //                {
        //                    isValid = false;
        //                    break;
        //                }
        //            }
        //            if (isValid)
        //            {
        //                rectangles.Add(newRect);
        //                // draw the rectangle on the canvas using Graphics object
        //                break;
        //            }
        //        }
        //        if (rectangles.Count == maxRectangles)
        //        {
        //            // canvas is full
        //            break;
        //        }
        //    }
        //}

        public void UpdateLastRect()
        {
            int selected_index = Rects.IndexOf(selectedRect);
            int last_index = Rects.IndexOf(Rects.Last());
            Rects[selected_index] = Rects[last_index];
            Rects[last_index] = selectedRect;
        }

        public void Clear()
        {
            updateUndoStack();
            Rects.Clear();
            Graphics.Clear(Color.FromArgb(10, 0, 30));
            Redraw(Graphics);
            UpdateGraphics();
        }

        public void SafeRectRelease()
        {
            if (SelectedRectColliding())
            {
                int index = Rects.IndexOf(selectedRect);
                Rects[index] = lastSelectedRect;
                //Redraw(Graphics);
                UndoStack.Pop();
            }
        }

        public void onDragRect(MouseEventArgs e)
        {

            if (selectedRect != Rectangle.Empty)
            {

                int dx = (e.Location.X - selectedRect.X);
                int dy = (e.Location.Y - selectedRect.Y);

                int index = Rects.IndexOf(selectedRect);

                Rects[index] = new Rectangle(
                    selectedRect.X + dx - offset.X,
                    selectedRect.Y + dy - offset.Y,
                    selectedRect.Width,
                    selectedRect.Height
                    );

                selectedRect = Rects[index];

            }

        }

        public void updateUndoStack()
        {
            if (UndoStack.Count > 0)
            {
                if (!Utils.Polygons.AreRectanglesEqual(Rects, UndoStack.First()))
                {
                    UndoStack.Push(Rects.ToList());
                    Console.WriteLine("updating");
                }
            }
            else
            {
                UndoStack.Push(Rects.ToList());
                Console.WriteLine("updating");
            }
        }

        public void undo()
        {
            if (UndoStack.Count > 0)
            {
                RedoStack.Push(Rects.ToList()); // Add the current state to the redo list
                Rects = UndoStack.Pop(); // Update the rectangle list with the last state of the undo list
            }
        }

        public void redo()
        {
            if (RedoStack.Count > 0)
            {
                UndoStack.Push(Rects.ToList()); // Add the current state to the undo list
                Rects = RedoStack.Pop(); // Update the rectangle list with the last state of the redo list
            }
        }

        private int UnitsToPixels(double unitsValue)
        {
            switch (Units)
            {
                case "mm":
                    return Convert.ToInt32(unitsValue * MillimetersConversionFactor);
                case "in":
                    return Convert.ToInt32(unitsValue * InchesConversionFactor);
                default:
                    throw new Exception("invalid units");
            }
        }

        public void AddRect(double width, double height)
        {
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen lightBluePen = new Pen(Color.Green, 1);

            int pixels_width = UnitsToPixels(width);
            int pixels_height = UnitsToPixels(height);

            Point nextPosition = getNextPosition(pixels_width, pixels_height);

            if (nextPosition.X >= 0 && nextPosition.Y >= 0)
            {
                Rectangle nextRect = new Rectangle(
                    nextPosition.X,
                    nextPosition.Y,
                    pixels_width,
                    pixels_height
                );

                Graphics.FillRectangle(whiteBrush, nextRect);
                Graphics.DrawRectangle(lightBluePen, nextRect);
                Rects.Add(nextRect);
            }
            else
            {
                throw new Exception($"invalid figure position: x={nextPosition.X}, y={nextPosition.Y}");
            }

        }

        public void AddMultipleRects(double width, double height, int widthAmount, int heightAmount)
        {

            int totalWidth = (cutsMarginPixels * 2)
               + widthAmount * UnitsToPixels(width)
               + (widthAmount - 1) * distanceBetweenCutsPixels;

            int totalHeight = (cutsMarginPixels * 2)
                + heightAmount * UnitsToPixels(height)
                + (heightAmount - 1) * distanceBetweenCutsPixels;

            int startX = cutsMarginPixels;
            int startY = cutsMarginPixels;

            if (totalWidth > myPanel.Width || totalHeight > myPanel.Height)
            {
                MessageBox.Show("The requested rectangles exceed the size of the panel.");
                return;
            }

            for (int i = 0; i < widthAmount; i++)
            {
                for (int j = 0; j < heightAmount; j++)
                {
                    int x = startX + i * (UnitsToPixels(width) + distanceBetweenCutsPixels);
                    int y = startY + j * (UnitsToPixels(height) + distanceBetweenCutsPixels);

                    Rectangle nextRect = new Rectangle(x, y, UnitsToPixels(width), UnitsToPixels(height));
                    Graphics.DrawRectangle(Pens.White, nextRect);
                    Rects.Add(nextRect);
                }
            }
        }
    }
}
