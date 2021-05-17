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
    public partial class ThongTinKH : Form
    {
        string TK = "";
        ThongTinKH_controller kh;
        public ThongTinKH()
        {
            InitializeComponent();
        }

        public ThongTinKH(string tk):this()
        {
            TK += tk;
            kh = new ThongTinKH_controller();
        }

        private void ThongTinKH_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kh.load_form(TK);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            label3.Text = TK;
            label5.Text = ""+kh.data_KH(TK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatLenh form = new DatLenh(TK, kh.data_KH(TK));
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LS_GD form = new LS_GD(TK, kh.data_KH(TK));
            form.Show();
            this.Hide();
        }
    }
}
