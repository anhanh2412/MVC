using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVC.Controller;

namespace MVC.View
{
    public partial class LS_GD : Form
    {
        string TK;
        int SDC;
        LSGD_controller con = new LSGD_controller();
        public LS_GD()
        {
            InitializeComponent();
        }

        public LS_GD(string tk, int sdc):this()
        {
            TK = tk;
            SDC = sdc;
        }

        private void LS_GD_Load(object sender, EventArgs e)
        {
            label14.Text = TK;
            label12.Text = ""+SDC;
            dataGridView1.DataSource = con.getGD_controller(TK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatLenh form = new DatLenh(TK, SDC);
            form.Show();
            this.Hide();
        }
    }
}
