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
    public partial class SettingsDialog : Form
    {

        public int WidthValue
        {
            get
            {
                return (int)num_Width.Value;
            }
            set
            {
                num_Width.Value = value;
            }
        }

        public int HeightValue
        {
            get
            {
                return (int)num_Height.Value;
            }
            set
            {
                num_Height.Value = value;
            }
        }

        public int DelayValue
        {
            get
            {
                return (int)num_Delay.Value;
            }
            set
            {
                num_Delay.Value = value;
            }
        }

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }
    }
}
