using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        // The random number generator
        Random rng = new Random();

        // The seed for the random number generator
        int seed;

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

            // Initialize timer
            timer.Interval = 50;
            timer.Enabled = false;
            timer.Tick += Tick;

            // Initialize the seed.
            seed = rng.Next();

            // Disable pause buttons on toolstrip and dropdown menu.
            tsb_pause.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
        }

        // NextGeneration - Simulates advancing the universe by 1 generation.
        //
        // Parameters: None
        private void NextGeneration()
        {
            // Create a grid to represent the next generation of the current universe.
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

        // GetNeighborCount - Returns the amount of cells living surrounding the specified cell coordinates.
        //
        // Parameters:
        // bool[,] grid - The universe we're searching through.
        // int x - The x coordinate of the cell whose neighbors we're counting.
        // int y - The y coordinate of the cell whose neighbors we're counting.
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

        // StopSim - Stops the simulation.
        //
        // Parameters: None
        private void StopSim()
        {
            // Stop the timer
            timer.Stop();

            // Enable the run and advance buttons and disable the pause button.
            tsb_advance.Enabled = true;
            tsb_run.Enabled = true;
            tsb_pause.Enabled = false;

            advanceToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            pauseToolStripMenuItem.Enabled = false;
        }

        // StartSim - Starts simulating generations of the universe.
        //
        // Parameters: None
        private void StartSim()
        {
            // Start the timer.
            timer.Start();

            // Disable the run and advance buttons and enable the pause button.
            tsb_advance.Enabled = false;
            tsb_run.Enabled = false;
            tsb_pause.Enabled = true;

            advanceToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = true;
        }

        // ClearUniverse - Clears the universe.
        //
        // Parameters: None
        private void ClearUniverse()
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

        // RandomizeUniverse - Randomizes the current array.
        //
        // Parameters:
        // int seed - The seed for the rng.
        private void RandomizeUniverse(int seed)
        {
            rng = new Random(seed);

            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    int temp = rng.Next(2);

                    if (temp == 1)
                    {
                        universe[x, y] = true;
                    }
                    else
                    {
                        universe[x, y] = false;
                    }
                }
            }

            graphicsPanel1.Invalidate();
        }

        // SaveUniverse - Saves the universe array to a file given via SaveFileDialog
        //
        // Parameters: None
        private void SaveUniverse()
        {
            // Set up initial variables
            string filepath;
            DateTime date;

            // Set up SaveFileDialog
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.DefaultExt = ".cells";
            dlg.Filter += "Universe Files (*.cells)|*.cells";
            dlg.Filter += "|All Files (*.*)|*.*";

            // Check if user selected the Save button.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Get the file path
                filepath = dlg.FileName;

                // Get the date and time along with a formatted string.
                date = DateTime.Now;
                string dateString = date.GetDateTimeFormats()[43]; // M/D/YYYY H:MM AM/PM

                // Prepare StreamWriter
                StreamWriter writer = new StreamWriter(filepath);

                // Write initial date and time to file.
                writer.WriteLine("!" + dateString);

                // Loop through the universe
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        // Write the appropriate characters depending on cell's state.
                        if (universe[x, y])
                        {
                            writer.Write("O");
                        }
                        else
                        {
                            writer.Write(".");
                        }
                    }

                    // Start new line after each row.
                    writer.WriteLine();
                }

                // Close the writer.
                writer.Close();
            }
        }

        // LoadUniverse - Load a universe from a file given via OpenFileDialog
        //
        // Parameters: None
        private void LoadUniverse()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".cells";
            dlg.Filter += "Universe Files (*.cells)|*.cells";
            dlg.Filter += "| All Files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filepath = dlg.FileName;

                StreamReader reader = new StreamReader(filepath);

                try
                {
                    // Skip past initial date/time line
                    reader.ReadLine();

                    // Read in the first line and take its length - 1 to get universe width
                    string text = reader.ReadLine() + "\n";
                    int loadWidth = text.Length - 1;

                    // Initialize the height of the universe because we have at least 1 row in file.
                    int loadHeight = 1;

                    // Count the remaining lines while adding them to the previous string's contents.
                    while (!reader.EndOfStream)
                    {
                        text += reader.ReadLine() + "\n";
                        loadHeight++;
                    }

                    // Close the string.
                    reader.Close();

                    // Prepare to read through the newly made string.
                    StringReader strReader = new StringReader(text);

                    // Create new bool array of the size given via file.
                    bool[,] loaded = new bool[loadWidth, loadHeight];
                    int x = 0, y = 0;

                    // String to hold contents returned via the StringReader
                    string line;

                    // Read through the string and set cells as needed.
                    while (!((line = strReader.ReadLine()) == null))
                    {
                        for (x = 0; x < line.Length; x++)
                        {
                            loaded[x, y] = (line[x] == 'O');
                        }

                        y++;
                    }

                    // Assign the new array to the current universe
                    universe = loaded;

                    // Close the StringReader
                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("There was an error loading the file.\n\n" + e.Message + "\n\nFile path: " + filepath);
                }
                finally
                {
                    // Check if reader is closed and close it if not.
                    if (reader.BaseStream == null)
                    {
                        reader.Close();
                    }
                    
                    graphicsPanel1.Invalidate();
                }
            }
        }

        // Event Handlers
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // The width and height of each cell in pixels
            float cellWidth = (float) graphicsPanel1.Width / universe.GetLength(0);
            float cellHeight = (float) graphicsPanel1.Height / universe.GetLength(1);

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
                    RectangleF cellRect = RectangleF.Empty;
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

            seed_statusLabel.Text = "Seed: " + seed;
        }

        private void Tick(object sender, EventArgs e)
        {
            //Advance 1 generation
            NextGeneration();
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
            StopSim();
        }

        private void tsb_run_Click(object sender, EventArgs e)
        {
            StartSim();
        }

        private void tsb_clear_Click(object sender, EventArgs e)
        {
            ClearUniverse();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearUniverse();
        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSim();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopSim();
        }

        private void fromSystemTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gets a long of the ticks of the current date and time. Afterwards, cast it to an int.
            seed = (int) DateTime.Now.Ticks;
            RandomizeUniverse(seed);
        }

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does nothing with the current seed and just creates a new universe with said seed.
            RandomizeUniverse(seed);
        }

        private void fromNewSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a dialog to allow user to input seed.
            SeedDialog dlg = new SeedDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Randomize universe on given seed.
                seed = dlg.seed;
                RandomizeUniverse(seed);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUniverse();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUniverse();
        }
    }
}
