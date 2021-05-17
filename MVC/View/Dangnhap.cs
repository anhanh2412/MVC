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
    public partial class Dangnhap : Form
    {
        DangNhap_Controller tt = new DangNhap_Controller();
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tk = textBox1.Text;
            string pass = textBox2.Text;
            if (tt.check_login1(tk, pass) == true)
            {
                ThongTinKH form = new ThongTinKH(tk);
                form.Show();
                this.Hide();

            }
            else MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
        }
    }
}
