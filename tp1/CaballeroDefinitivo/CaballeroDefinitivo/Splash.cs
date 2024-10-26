using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaballeroDefinitivo
{
    public partial class Splash : Form
    {
        public Splash(int segundos)
        { 
            InitializeComponent();
            timer1.Interval = segundos * 1000;
            timer1.Start();
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
    }
}
