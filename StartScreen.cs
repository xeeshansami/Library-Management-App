using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class StartScreen : Form
    {
        public int StatCount { get; set; }
        public StartScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (StatCount < 20)
            {
                StatCount++;
            }
            else
            {
                timer1.Stop();
                Main m1 = new Main();
                m1.Show();
                this.Hide();
            }
        }
    }
}
