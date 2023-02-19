using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using CuttingMachineGUI.Components;

using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace CuttingMachineGUI.BusinessLogic.Models
{
    internal class Canvas
    {

        #region Variables
        public Graphics _graphics;
        public Rectangle _selectedRect;
        public Rectangle _lastSelectedRect;
        public Point _offset;
        public int _surfaceWidth;
        public int _surfaceHeight;
        public int _fabricHeight;
        public string _units;
        public List<Rectangle> _rects;

        private Stack<List<Rectangle>> _undoStack = new Stack<List<Rectangle>>();
        private Stack<List<Rectangle>> _redoStack = new Stack<List<Rectangle>>();


        private int distanceBetweenCuts;
        private int cutsMargin;
        private MyPanel myPanel;

        #endregion

        



        #region SettersAndGetters
        public Graphics Graphics
        {
            get
            {
                return _graphics;
            }
            set
            {
                _graphics = value;
            }
        }

        public Rectangle selectedRect
        {
            get
            {
                return _selectedRect;
            }
            set
            {
                _selectedRect = value;
            }
        }

        public Rectangle lastSelectedRect
        {
            get
            {
                return _lastSelectedRect;
            }
            set
            {
                _lastSelectedRect = value;
            }
        }

        public Point offset
        {
            get
            {
                return _offset;
            }
            set
            {
                _offset = value;
            }
        }

        public int SurfaceWidth
        {
            get
            {
                return _surfaceWidth;
            }
            set
            {
                _surfaceWidth = value;
            }
        }

        public int SurfaceHeight
        {
            get
            {
                return _surfaceHeight;
            }
            set
            {
                _surfaceHeight = value;
            }
        }

        public int FabricHeight
        {
            get
            {
                return _fabricHeight;
            }
            set
            {
                _fabricHeight = value;
            }
        }

        public string Units
        {
            get
            {
                return _units;
            }
            set
            {
                _units = value;
            }
        }

        public List<Rectangle> Rects
        {
            get
            {
                return _rects;
            }
            set
            {
                _rects = value;
            }
        }
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
            SurfaceWidth = Convert.ToInt32(ConfigurationManager.AppSettings["SurfaceWidth"]);
            SurfaceHeight = Convert.ToInt32(ConfigurationManager.AppSettings["SurfaceHeight"]);
            FabricHeight = Convert.ToInt32(ConfigurationManager.AppSettings["FabricHeight"]);
            distanceBetweenCuts = Convert.ToInt32(ConfigurationManager.AppSettings["DistanceBetweenCuts"]);
            cutsMargin = Convert.ToInt32(ConfigurationManager.AppSettings["CutsMargin"]);
            Units = ConfigurationManager.AppSettings["Units"];
        }

        public void UpdateGraphics()
        {
            Graphics = myPanel.CreateGraphics();
        }

        public void Redraw(Graphics graphics)
        {
            //MessageBox.Show("redrawing");
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

        private Point getNextPosition(int newWidth, int newHeight)
        {
            int x = -1;
            int y = -1;

            if (Rects.Count == 0)
            {
                return new Point(cutsMargin, cutsMargin);
            }
            else
            {
                Rectangle lastCutRect = Rects.Last();

                //if (lastCutRect.Right + newWidth + DistanceBetweenCuts <= FabricPanel.ClientSize.Width)
                if (lastCutRect.Right + newWidth + distanceBetweenCuts <= SurfaceHeight)
                {
                    // There is enough space to add the new cut to the right of the last cut
                    x = lastCutRect.Right + distanceBetweenCuts;
                    y = cutsMargin;


                }
                else if (lastCutRect.Bottom + newHeight + distanceBetweenCuts <= FabricHeight)
                //else if (lastCutRect.Bottom + newHeight + DistanceBetweenCuts <= FabricPanel.ClientSize.Height)
                {
                    // There is not enough space to add the new cut to the right of the last cut, so add it below the last cut
                    x = cutsMargin;
                    y = lastCutRect.Bottom + distanceBetweenCuts;

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

        public void Clear()
        {
            Rects.Clear();
            Graphics.Clear(Color.FromArgb(10, 0, 30));
            UpdateGraphics();
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
            if (_undoStack.Count > 0)
            {
                if (!Utils.Polygons.AreRectanglesEqual(Rects, _undoStack.First()))
                {
                    _undoStack.Push(Rects.ToList());
                    Console.WriteLine("updating");
                }
                else
                {
                    Console.WriteLine("its equal");
                }
            }
            else
            {
                _undoStack.Push(Rects.ToList());
                Console.WriteLine("updating");

            }
        }

        public void undo()
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(Rects.ToList()); // Add the current state to the redo list
                Rects = _undoStack.Pop(); // Update the rectangle list with the last state of the undo list
            }
        }

        public void redo()
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(Rects.ToList()); // Add the current state to the undo list
                Rects = _redoStack.Pop(); // Update the rectangle list with the last state of the redo list
            }
        }

        public void AddRect(int width, int height)
        {
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen lightBluePen = new Pen(Color.Green, 1);

            Point nextPosition = getNextPosition(width, height);

            if (nextPosition.X >= 0 && nextPosition.Y >= 0)
            {
                Rectangle nextRect = new Rectangle(nextPosition.X, nextPosition.Y, width, height);
                Graphics.FillRectangle(whiteBrush, nextRect);
                Graphics.DrawRectangle(lightBluePen, nextRect);
                Rects.Add(nextRect);
            }
            else
            {
                throw new Exception("invalid figure");
            }

        }

        public void AddMultipleRects(int width, int height, int widthAmount, int heightAmount)
        {

            int totalWidth = (cutsMargin * 2) + widthAmount * width + (widthAmount - 1) * distanceBetweenCuts;
            int totalHeight = (cutsMargin * 2) + heightAmount * height + (heightAmount - 1) * distanceBetweenCuts;
            int startX = cutsMargin;
            int startY = cutsMargin;

            if (totalWidth > myPanel.Width || totalHeight > myPanel.Height)
            {
                MessageBox.Show("The requested rectangles exceed the size of the panel.");
                return;
            }

            for (int i = 0; i < widthAmount; i++)
            {
                for (int j = 0; j < heightAmount; j++)
                {
                    int x = startX + i * (width + distanceBetweenCuts);
                    int y = startY + j * (height + distanceBetweenCuts);
                    Rectangle nextRect = new Rectangle(x, y, width, height);
                    Graphics.DrawRectangle(Pens.White, nextRect);
                    Rects.Add(nextRect);
                }
            }
        }
    }
}
