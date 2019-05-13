using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace SelfAvoidingPaths
{
    public partial class WalksForm : Form
    {
        public WalksForm()
        {
            InitializeComponent();
        }

        private List<List<Point>> _walks;
        private int _walkWidth, _walkHeight;

        private async void BtnGenerate_Click(object sender, EventArgs e)
        {
            lblResults.Text = "Working...";
            lblWalkNum.Text = "";
            btnGenerate.Enabled = false;
            trkWalk.Visible = false;
            picCanvas.Image = null;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            _walkWidth = int.Parse(txtWidth.Text);
            _walkHeight = int.Parse(txtHeight.Text);

            var watch = new Stopwatch();

            watch.Start();
            await Task.Run(() => _walks = FindWalks(_walkWidth, _walkHeight)).ConfigureAwait(true);
            watch.Stop();

            var noun = (_walks.Count == 1 ? " walk " : " walks ");
            lblResults.Text = "Found " +
                              _walks.Count + noun + "in " +
                              watch.Elapsed.TotalSeconds.ToString("0.00") +
                              " seconds";

            // Display the first walk.
            if (_walks.Count > 0)
            {
                DisplayWalk(0);
                if (_walks.Count > 1)
                {
                    trkWalk.Maximum = _walks.Count - 1;
                    trkWalk.Value = 0;
                    trkWalk.Visible = true;
                }
            }

            btnGenerate.Enabled = true;
            Cursor = Cursors.Default;
        }

        // Generate all self-avoiding walks.
        private List<List<Point>> FindWalks(int width, int height)
        {
            List<List<Point>> walks = new List<List<Point>>();

            // Make an array to show where we have been.
            bool[,] visited = new bool[width + 1, height + 1];

            // Get the number of points we need to visit.
            int numPoints = (width + 1) * (height + 1);

            // Start the walk at (0, 0).
            Stack<Point> currentWalk = new Stack<Point>();
            currentWalk.Push(new Point(0, 0));
            visited[0, 0] = true;

            // Search for walks.
            FindWalks(numPoints, walks, currentWalk,
                0, 0, width, height, visited);
            return walks;
        }

        // Extend the walk that is at (current_x, current_y).
        private void FindWalks(int numPoints,
            List<List<Point>> walks, Stack<Point> currentWalk,
            int currentX, int currentY,
            int width, int height, bool[,] visited)
        {
            // If we have visited every position,
            // then this is a complete walk.
            if (currentWalk.Count == numPoints)
            {
                walks.Add(currentWalk.ToList());

                if (walks.Count % 1000 == 0)
                {
                    Application.DoEvents();
                }
            }
            else
            {
                // Try the possible moves.
                var nextPoints = new Point[]
                {
                    new Point(currentX - 1, currentY),
                    new Point(currentX + 1, currentY),
                    new Point(currentX, currentY - 1),
                    new Point(currentX, currentY + 1),
                };

                foreach (var point in nextPoints)
                {
                    if (point.X < 0) continue;
                    if (point.X > width) continue;
                    if (point.Y < 0) continue;
                    if (point.Y > height) continue;
                    if (visited[point.X, point.Y]) continue;

                    // Try visiting this point.
                    visited[point.X, point.Y] = true;
                    currentWalk.Push(point);

                    FindWalks(numPoints, walks, currentWalk,
                        point.X, point.Y, width, height, visited);

                    // We're done visiting this point.
                    visited[point.X, point.Y] = false;
                    currentWalk.Pop();
                }
            }
        }

        // Display the selected walk.
        private void TrkWalk_Scroll(object sender, EventArgs e)
        {
            DisplayWalk(trkWalk.Value);
        }

        private void DisplayWalk(int walkNum)
        {
            lblWalkNum.Text = "Walk " + walkNum;
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                Bitmap bm = DrawWalk(_walks[walkNum],
                    _walkWidth, _walkHeight,
                    picCanvas.ClientSize.Width,
                    picCanvas.ClientSize.Height,
                    Color.White, Brushes.Green, pen);
                picCanvas.Image = bm;
            }
        }

        // Draw a walk.
        private Bitmap DrawWalk(List<Point> walk,
            int width, int height, int bmWidth, int bmHeight,
            Color bgColor, Brush dotBrush, Pen pen)
        {
            var bm = new Bitmap(bmWidth, bmHeight);

            // See how big to make each row and column.
            var scaleX = bmWidth / (width + 2);
            var scaleY = bmHeight / (height + 2);
            var scale = Math.Min(scaleX, scaleY);
            var offsetX = (bmWidth - scale * width) / 2;
            var offsetY = (bmHeight - scale * height) / 2;
            var dotR = scaleX * 0.1f;
            var dotW = 2 * dotR;

            // Draw the walk.
            using (var gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(bgColor);

                // Draw a grid of dots.
                for (var x = 0; x <= width; x++)
                {
                    for (var y = 0; y <= height; y++)
                    {
                        gr.FillEllipse(dotBrush,
                            offsetX + x * scale - dotR,
                            offsetY + y * scale - dotR,
                            dotW, dotW);
                    }
                }

                // Draw the walk.
                if (walk.Count > 1)
                {
                    gr.DrawLines(pen, walk.ToArray().Select(point => new PointF(offsetX + point.X * scale, offsetY + point.Y * scale)).ToArray());
                }
            }

            return bm;
        }
    }
}
