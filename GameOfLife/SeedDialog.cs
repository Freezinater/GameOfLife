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
    public partial class SeedDialog : Form
    {
        public SeedDialog()
        {
            InitializeComponent();
        }

        int givenSeed = 0;

        public int seed
        {
            get
            {
                return givenSeed;
            }

            set
            {
                if (value < 0)
                {
                    givenSeed = Math.Abs(seed);
                }
                else
                {
                    givenSeed = value;
                }
            }
        }

        private void btn_RandomSeed_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            numericUpDown1.Value = rng.Next();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            givenSeed = (int) numericUpDown1.Value;
        }
    }
}
