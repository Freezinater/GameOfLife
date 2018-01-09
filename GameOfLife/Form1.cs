using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        // The universe array
        bool[,] universe = new bool[5, 5];

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            //Initialize timer
            timer.Interval = 50;
            timer.Enabled = false;
            timer.Tick += Tick;

            //Set up buttons on toolstrip.
            tsb_advance.Enabled = true;
            tsb_run.Enabled = true;
            tsb_pause.Enabled = false;
        }

        private void Tick(object sender, EventArgs e)
        {
            //Advance 1 generation
            NextGeneration();
        }

        private void NextGeneration()
        {
            // Create a grid of the next generation of the current universe.
            bool[,] nextGen = new bool[universe.GetLength(0), universe.GetLength(1)];

            // Copy the current universe into this array.
            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    nextGen[x, y] = universe[x, y];
                }
            }

            // Loop through cells in the universe
            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    // Process amount of living cells surrounding the current cell
                    int neighbors = GetNeighborCount(universe, x, y);

                    if (universe[x, y])
                    {
                        // Kill a living cell if it has less than 2 or more than 3 neighbors, otherwise do nothing
                        if (neighbors < 2 || neighbors > 3)
                        {
                            nextGen[x, y] = false;
                        }
                    }
                    else
                    {
                        // Bring a cell to life if it has exactly 3 neighbors.
                        if (neighbors == 3)
                        {
                            nextGen[x, y] = true;
                        }
                    }
                }
            }

            // Replace the current generation of the universe with the newly adjusted generation.
            universe = nextGen;

            // Increment generation count and update status label
            generations++;
            toolStripStatusLabel1.Text = "Generations: " + generations;

            // Repaint the panel.
            graphicsPanel1.Invalidate();
        }

        private int GetNeighborCount(bool[,] grid, int x, int y)
        {
            int count = 0;

            // Loop through the neighbors surrounding the passed in coordinates.
            for (int ix = x - 1; ix <= x + 1; ix++)
            {
                for (int iy = y - 1; iy <= y + 1; iy++)
                {
                    // Check that the coordinate is in bounds of the array.
                    if (!(iy < 0 || iy >= grid.GetLength(1) || ix < 0 || ix >= grid.GetLength(0)))
                    {
                        // Check that the coordinates are not the ones of the cell passed in. We don't want to count it as a living neighbor.
                        if (ix != x || iy != y)
                        {
                            // Increment count if the neighbor cell is alive.
                            if (grid[ix, iy])
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // The width and height of each cell in pixels
            int cellWidth = graphicsPanel1.Width / universe.GetLength(0);
            int cellHeight = graphicsPanel1.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // Brush for filling in the cells depending on whether or not they're alive.
            Brush cellPen = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush
                    if (universe[x, y])
                    {
                        e.Graphics.FillRectangle(cellPen, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            //Get the location clicked.
            Point loc = e.Location;

            //generations++;
            
            //Convert the coordinates to a cell.
            int cellX = loc.X / (graphicsPanel1.Width / universe.GetLength(0));
            int cellY = loc.Y / (graphicsPanel1.Height / universe.GetLength(1));

            //Flip the cell's state.
            universe[cellX, cellY] = !universe[cellX, cellY];

            graphicsPanel1.Invalidate();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            graphicsPanel1.Invalidate();
        }

        private void tsb_advance_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void tsb_pause_Click(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Enable the run and advance buttons and disable the pause button.
            tsb_advance.Enabled = true;
            tsb_run.Enabled = true;
            tsb_pause.Enabled = false;
        }

        private void tsb_run_Click(object sender, EventArgs e)
        {
            // Start the timer.
            timer.Start();

            // Disable the run and advance buttons and enable the pause button.
            tsb_advance.Enabled = false;
            tsb_run.Enabled = false;
            tsb_pause.Enabled = true;
        }

        private void tsb_clear_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    // Kill all living cells.
                    universe[x, y] = false;
                }

                // Reset generation count and update status label
                generations = 0;
                toolStripStatusLabel1.Text = "Generations: " + generations;

                // Repaint the screen.
                graphicsPanel1.Invalidate();
            }
        }
    }
}
