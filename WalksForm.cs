using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;
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
        private int _pathLength;
        private CancellationTokenSource _cts;

        private async void BtnGenerate_Click(object sender, EventArgs e)
        {
            lblResults.Text = "Working...";
            lblWalkNum.Text = "";
            lblTotal.Text = "";
            btnGenerate.Enabled = false;
            trkWalk.Visible = false;
            picCanvas.Image = null;
            Cursor = Cursors.WaitCursor;

            _pathLength = int.Parse(txtPathLength.Text);

            var watch = new Stopwatch();

            _cts = new CancellationTokenSource();
            var ct = _cts.Token;

            watch.Start();
            await Task.Run(() => _walks = FindWalks(_pathLength, ct)).ConfigureAwait(true);
            watch.Stop();

            var noun = (_walks.Count == 1 ? " walk " : " walks ");
            lblResults.Text = "Found " +
                              _walks.Count + noun + "in " +
                              watch.Elapsed.TotalSeconds.ToString("0.00") +
                              " seconds";

            lblTotal.Text = $"Total paths in coordinate system: {_walks.Count * 4}";

            if (cbVisualize.Checked)
            {
                if (_walks.Count > 0)
                {
                    DisplayWalk(0);
                    if (_walks.Count >= 1)
                    {
                        trkWalk.Maximum = _walks.Count - 1;
                        trkWalk.Value = 0;
                        trkWalk.Visible = true;
                    }
                }
            }

            _walks = new List<List<Point>>();
            btnGenerate.Enabled = true;
            Cursor = Cursors.Default;
        }

        // Generate all self-avoiding walks.
        private List<List<Point>> FindWalks(int pathLength, CancellationToken ct)
        {
            var walks = new List<List<Point>>();

            var side = pathLength + 1;
            // Make an array to show where we have been.
            var visited = new bool[side, side];

            // Start the walk at (0, 0).
            var currentWalk = new Stack<Point>();
            currentWalk.Push(new Point(0, 0));
            visited[0, 0] = true;

            try
            {
                // Search for walks.
                FindWalks(walks, currentWalk,
                    0, 0, side, pathLength, visited, ct);
                return walks;
            }
            catch (TaskCanceledException)
            {
                return walks;
            }
        }

        // Extend the walk that is at (current_x, current_y).
        private void FindWalks(
            List<List<Point>> walks, Stack<Point> currentWalk,
            int currentX, int currentY,
            int side, int pathLength, bool[,] visited, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                throw new TaskCanceledException();

            if (currentWalk.Count == pathLength + 1)
            {
                walks.Add(currentWalk.ToList());
            }
            else
            {
                // Try the possible moves.
                var nextPoints = new[]
                {
                    new Point(currentX - 1, currentY),
                    new Point(currentX + 1, currentY),
                    new Point(currentX, currentY - 1),
                    new Point(currentX, currentY + 1),
                };

                foreach (var point in nextPoints)
                {
                    if (point.X < 0) continue;
                    if (point.X > side) continue;
                    if (point.Y < 0) continue;
                    if (point.Y > side) continue;
                    if (visited[point.X, point.Y]) continue;

                    // Try visiting this point.
                    visited[point.X, point.Y] = true;
                    currentWalk.Push(point);

                    FindWalks(walks, currentWalk,
                        point.X, point.Y, side, pathLength, visited, ct);

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
            var walk = _walks[walkNum];

            using (Pen pen = new Pen(Color.Blue, 2))
            {
                var width = _pathLength;
                var height = _pathLength;

                if (!cbFixedSideSize.Checked)
                {
                    width = walk.OrderByDescending(item => item.X).First().X;
                    height = walk.OrderByDescending(item => item.Y).First().Y;
                }

                var bm = DrawWalk(walk,
                    width, height,
                    picCanvas.ClientSize.Width,
                    picCanvas.ClientSize.Height,
                    Color.White, Brushes.Green, pen);
                picCanvas.Image = bm;
            }
        }

        private void Terminate_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
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
