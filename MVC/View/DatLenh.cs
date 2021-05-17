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
    public partial class DatLenh : Form
    {
        string ma_gd;
        string ma_san;
        float gia;
        int sl;
        int thanhtien;
        DateTime date;
        string trang_thai;
        string lenh;
        string loai_lenh;
        string phien;
        string ma_ck;
        int tc;
        float tran, san;
        int SDC;
        string TK;
        DatLenh_Controller con = new DatLenh_Controller();
        public DatLenh()
        {
            InitializeComponent();
        }

        public DatLenh(string tk, int sdc):this()
        {
            TK = tk;
            SDC = sdc;
        }

        private void DatLenh_Load(object sender, EventArgs e)
        {
            label14.Text = TK;
            label12.Text = "" + SDC;
            textBox5.Text = "T+2";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Random rd = new Random();
            tc = rd.Next(20, 40);
            if (comboBox1.Text == ("HSX"))
            {
                tran = tc + (tc * 0.07f);
                san = tc - (tc * 0.07f);

                while (true) {
                    tran *= 1000;
                    san *= 1000;
                    if (tran < 10000 && san < 10000 && (tran % 10 != 0 || san % 10 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.07f);
                        san = tc - (tc * 0.07f);
                    }
                    if (tran >= 10000 && tran <= 49950 && san >= 10000 && san <= 49950 && (tran % 50 != 0 || san % 50 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.07f);
                        san = tc - (tc * 0.07f);
                    }
                    else if (tran >= 50000 && san >= 50000 && (tran % 100 != 0 || san % 100 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.07f);
                        san = tc - (tc * 0.07f);
                    }
                    else break;
                }
                comboBox2.Items.Clear();
                comboBox2.Items.Add("AAA");
                comboBox2.Items.Add("AAM");
                comboBox2.Items.Add("AAT");

            }
            if (comboBox1.Text == "HNX")
            {
                tran = tc + (tc * 0.1f);
                san = tc - (tc * 0.1f);
                while (true)
                {
                    tran *= 1000;
                    san *= 1000;
                    if (tran < 10000 && san < 10000 && (tran % 10 != 0 || san % 10 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.1f);
                        san = tc - (tc * 0.1f);
                    }
                    if (tran >= 10000 && tran <= 49950 && san >= 10000 && san <= 49950 && (tran % 50 != 0 || san % 50 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.1f);
                        san = tc - (tc * 0.1f);
                    }
                    else if (tran >= 50000 && san >= 50000 && (tran % 100 != 0 || san % 100 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.1f);
                        san = tc - (tc * 0.1f);
                    }
                    else break;
                }
                comboBox2.Items.Clear();
                comboBox2.Items.Add("ASG");
                comboBox2.Items.Add("BSI");
                comboBox2.Items.Add("PAN");
            }
            else if (comboBox1.Text == "UpCom")
            {
                tran = tc + (tc * 0.15f);
                san = tc - (tc * 0.15f);
                while (true)
                {
                    tran *= 1000;
                    san *= 1000;
                    if (tran < 10000 && san < 10000 && (tran % 10 != 0 || san % 10 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.15f);
                        san = tc - (tc * 0.15f);
                    }
                    if (tran >= 10000 && tran <= 49950 && san >= 10000 && san <= 49950 && (tran % 50 != 0 || san % 50 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.15f);
                        san = tc - (tc * 0.15f);
                    }
                    else if (tran >= 50000 && san >= 50000 && (tran % 100 != 0 || san % 100 != 0))
                    {
                        tc = rd.Next(20, 40);
                        tran = tc + (tc * 0.15f);
                        san = tc - (tc * 0.15f);
                    }
                    else break;
                }
                comboBox2.Items.Clear();
                comboBox2.Items.Add("BIDV");
                comboBox2.Items.Add("FPT");
                comboBox2.Items.Add("ACB");

            }
        }

        bool boiSo(string ma_sanck, int a)
        {
            if (ma_sanck.Equals("HSX") && a % 10 == 0)
            {
                return true;
            }
            if((ma_sanck.Equals("HNX") || ma_sanck.Equals("UpCom")) && a % 100 == 0)
            {
                return true;
            }
            return false;
        }

        bool check_gia(float a)
        {
            a *= 1000;
            if (a >= san && a <= tran)
            {
                if (tran < 10000 && san < 10000 && a % 10 == 0)
                {
                    return true;
                }
                if (tran >= 10000 && tran <= 49950 && san >= 10000 & san <= 49950 && a % 50 == 0)
                {
                    return true;
                }
                else if (tran >= 50000 && san >= 50000 && a % 100 == 0)
                {
                    return true;
                }
            }MessageBox.Show("Giá phải lớn hơn giá trần và nhỏ hơn giá sàn");
            return false;
        }

        bool check_dl()
        {
            string hour = DateTime.Now.ToString("HH:mm:ss");
            string s = textBox3.Text;
            sl = int.Parse(textBox4.Text);
            if (comboBox1.Text == "HSX")
            {
                if (s.Equals("ATO"))
                {
                    string stp1 = "04:00:59"; // 08:59:59
                    string ep1 = "08:15:01"; //09:15:01
                    if (hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1)
                    {
                        if (boiSo(comboBox1.Text, sl))
                        {
                            gia = tran / 1000;
                            lenh = "ATO";
                            phien = "Phiên định kỳ";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else {
                        MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này");
                        return false;
                    }
                }
                if (s.Equals("MP"))
                {
                    string stp1 = "08:15:00";
                    string ep1 = "09:30:01";
                    string stp2 = "12:59:59";
                    string ep2 = "14:30:01";
                    if ((hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1) || (hour.CompareTo(stp2) == 1 && hour.CompareTo(ep2) == -1))
                    {
                        if (s.Equals("MP") && boiSo(comboBox1.Text, sl))
                        {
                            gia = tran / 1000;
                            lenh = "MP";
                            phien = "Phiên liên tục";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }
                }
                if (s.Equals("ATC"))
                {
                    MessageBox.Show("giá là ATC");
                    string stp1 = "19:30:00"; //14:30:00
                    string ep1 = "20:45:01"; //14:45:01
                    if (hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1)
                    {
                        if (s.Equals("ATC") && boiSo(comboBox1.Text, sl))
                        {
                            gia = tran / 1000;
                            lenh = "ATO";
                            phien = "Phiên định kỳ";
                            MessageBox.Show("dl ok");
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }
                }
                else
                {
                    string stp1 = "08:59:59";
                    string ep1 = "09:15:01";
                    string stp2 = "19:30:00"; //14:30:00
                    string ep2 = "20:45:01"; //14:45:01
                    string stp3 = "02:15:00";
                    string ep3 = "05:30:01";
                    string stp4 = "12:59:59";
                    string ep4 = "14:30:01";
                    if ((hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1) || (hour.CompareTo(stp2) == 1 && hour.CompareTo(ep2) == -1)){
                        if (boiSo(comboBox1.Text, sl))
                        {
                            lenh = "LO";
                            phien = "Phiên định kỳ";
                            return true;
                        }
                        
                    }
                    if((hour.CompareTo(stp3) == 1 && hour.CompareTo(ep3) == -1) || (hour.CompareTo(stp4) == 1 && hour.CompareTo(ep4) == -1)){
                        if (boiSo(comboBox1.Text, sl))
                        {
                            lenh = "LO";
                            phien = "Phiên liên tục";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }
                }

            }
            if (comboBox1.Text == "HNX")
            {
                if (s.Equals("ATC"))
                {
                    string stp1 = "13:59:59";
                    string ep1 = "14:45:01";
                    if (hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1)
                    {
                        if (s.Equals("ATC") && boiSo(comboBox1.Text, sl))
                        {
                            gia = tran / 1000;
                            gia = float.Parse(string.Format("{0:0.00}", gia));
                            lenh = "ATC";
                            phien = "Phiên định kỳ";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }
                }
                else
                {
                    string stp1 = "08:59:59";
                    string ep1 = "11:30:01";
                    string stp2 = "12:59:59";
                    string ep2 = "14:30:01";
                    string stp3 = "13:59:59";
                    string ep3 = "14:45:01";
                    if ((hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1) || (hour.CompareTo(stp2) == 1 && hour.CompareTo(ep2) == -1))
                    {
                        if (boiSo(comboBox1.Text, sl))
                        {
                            lenh = "LO";
                            phien = "Phiên liên tục";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    if (hour.CompareTo(stp3) == 1 && hour.CompareTo(ep3) == -1)
                    {
                        if (boiSo(comboBox1.Text, sl))
                        {
                            lenh = "LO";
                            phien = "Phiên định kỳ";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }

                }
            }
            return false;
        }

        public bool check_dlB() {
            string hour = DateTime.Now.ToString("HH:mm:ss");
            string s = textBox3.Text;
            sl = int.Parse(textBox4.Text);
            
            if (comboBox1.Text == "HSX")
            {
                if (s.Equals("ATO"))
                {
                    string stp1 = "04:00:59"; // 08:59:59
                    string ep1 = "08:15:01"; //09:15:01
                    if (hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1)
                    {
                        if (boiSo(comboBox1.Text, sl))
                        {
                            gia = san / 1000;
                            lenh = "ATO";
                            phien = "Phiên định kỳ";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này");
                        return false;
                    }
                }
                if (s.Equals("MP"))
                {
                    string stp1 = "08:15:00";
                    string ep1 = "09:30:01";
                    string stp2 = "12:59:59";
                    string ep2 = "14:30:01";
                    if ((hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1) || (hour.CompareTo(stp2) == 1 && hour.CompareTo(ep2) == -1))
                    {
                        if (s.Equals("MP") && boiSo(comboBox1.Text, sl))
                        {
                            gia = san / 1000;
                            lenh = "MP";
                            phien = "Phiên liên tục";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }
                }
                if (s.Equals("ATC"))
                {
                    MessageBox.Show("giá là ATC");
                    string stp1 = "19:30:00"; //14:30:00
                    string ep1 = "20:45:01"; //14:45:01
                    if (hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1)
                    {
                        if (s.Equals("ATC") && boiSo(comboBox1.Text, sl))
                        {
                            gia = san / 1000;
                            lenh = "ATO";
                            phien = "Phiên định kỳ";
                            MessageBox.Show("dl ok");
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }
                }
                else
                {
                    string stp1 = "08:59:59";
                    string ep1 = "09:15:01";
                    string stp2 = "19:30:00"; //14:30:00
                    string ep2 = "20:45:01"; //14:45:01
                    string stp3 = "02:15:00";
                    string ep3 = "05:30:01";
                    string stp4 = "12:59:59";
                    string ep4 = "14:30:01";
                    if ((hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1) || (hour.CompareTo(stp2) == 1 && hour.CompareTo(ep2) == -1))
                    {
                        if (boiSo(comboBox1.Text, sl))
                        {
                            lenh = "LO";
                            phien = "Phiên định kỳ";
                            return true;
                        }

                    }
                    if ((hour.CompareTo(stp3) == 1 && hour.CompareTo(ep3) == -1) || (hour.CompareTo(stp4) == 1 && hour.CompareTo(ep4) == -1))
                    {
                        if (boiSo(comboBox1.Text, sl))
                        {
                            lenh = "LO";
                            phien = "Phiên liên tục";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }
                }

            }
            if (comboBox1.Text == "HNX")
            {
                if (s.Equals("ATC"))
                {
                    string stp1 = "14:29:00";
                    string ep1 = "18:45:01";
                    if (hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1)
                    {
                        if (s.Equals("ATC") && boiSo(comboBox1.Text, sl))
                        {
                            gia = san / 1000;
                            gia = float.Parse(string.Format("{0:0.00}", gia));
                            lenh = "ATC";
                            phien = "Phiên định kỳ";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }
                }
                else
                {
                    string stp1 = "08:59:59";
                    string ep1 = "11:30:01";
                    string stp2 = "12:59:59";
                    string ep2 = "14:30:01";
                    string stp3 = "13:59:59";
                    string ep3 = "14:45:01";
                    if ((hour.CompareTo(stp1) == 1 && hour.CompareTo(ep1) == -1) || (hour.CompareTo(stp2) == 1 && hour.CompareTo(ep2) == -1))
                    {
                        if (boiSo(comboBox1.Text, sl))
                        {
                            lenh = "LO";
                            phien = "Phiên liên tục";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    if (hour.CompareTo(stp3) == 1 && hour.CompareTo(ep3) == -1)
                    {
                        if (boiSo(comboBox1.Text, sl))
                        {
                            lenh = "LO";
                            phien = "Phiên định kỳ";
                            return true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Số lượng bạn đặt không hợp lệ", "caption", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hiện tại không có phiên giao dịch lệnh này", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                            return false;
                        }
                    }

                }
            }
            return false;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                string s = textBox3.Text;
                if(radioButton1.Checked == true)
                {
                    if (s.Equals("ATO") || s.Equals("ATC") || s.Equals("MP"))
                    {
                        label1.Text = "Số lượng cổ phiếu mua được tối đa là: " + ((int)(SDC / tran));
                    }
                    else if (double.Parse(s) >= 0)
                    {
                        float a = float.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
                        gia = float.Parse(string.Format("{0:0.00}", a));
                        if (check_gia(a))
                        {

                            label1.Text = "Số lượng cổ phiếu mua được tối đa là: " + ((int)(SDC / (gia * 1000)) + "cổ phiếu");
                        }
                    }
                }
                if(radioButton2.Checked == true)
                {  
                    if (con.sl_controller(TK, comboBox2.Text) > 0)
                    {
                        if (s.Equals("ATO") || s.Equals("ATC") || s.Equals("MP"))
                        {
                            label1.Text = "Số lượng cổ phiếu bán được tối đa là: " + con.sl_controller(TK, comboBox2.Text);
                        }
                        else if (double.Parse(s) >= 0)
                        {
                            label1.Text = "Số lượng cổ phiếu bán được tối đa là: " + con.sl_controller(TK, ma_ck);
                        }
                    }

                    else label1.Text = "Bạn không sở hữu cổ phiếu này";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn nhập lệnh không hợp lệ");
               
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                    e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LS_GD form = new LS_GD(TK, SDC);
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThongTinKH form = new ThongTinKH(TK);
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(radioButton1.Checked == true)
            {
                if (check_dl())
                {
                    ma_gd = textBox1.Text;
                    ma_san = comboBox1.SelectedItem.ToString();
                    sl = int.Parse(textBox4.Text);
                    gia = float.Parse(string.Format("{0:0.00}", gia));
                    thanhtien = (int)gia * sl * 1000;
                    date = DateTime.Now;
                    trang_thai = "chờ khớp";
                    loai_lenh = radioButton1.Text;
                    ma_ck = comboBox2.SelectedItem.ToString();
                    int sd = SDC - thanhtien;
                    if(sd >= 0)
                    {
                        if (con.insert_gd(ma_gd, TK, ma_san, gia, sl, thanhtien, date, trang_thai, lenh, loai_lenh, phien, ma_ck))
                        {
                            if (con.update_kh_controller(TK, sd))
                            {
                                MessageBox.Show("Đặt lệnh thành công");
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Số dư tài khoản không đủ", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                        }
                    }
                }
           }else if(radioButton2.Checked == true)
            {
                if (check_dlB())
                {
                    ma_gd = textBox1.Text;
                    ma_san = comboBox1.SelectedItem.ToString();
                    sl = int.Parse(textBox4.Text);
                    thanhtien = (int)gia * sl * 1000;
                    date = DateTime.Now;
                    trang_thai = "chờ khớp";
                    loai_lenh = radioButton2.Text;
                    ma_ck = comboBox2.SelectedItem.ToString();
                    int sl_cp = con.sl_controller(TK, ma_ck);
                    if (sl_cp >= sl)
                    {
                        if (con.insert_gd(ma_gd, TK, ma_san, gia, sl, thanhtien, date, trang_thai, lenh, loai_lenh, phien, ma_ck))
                        {
                            sl_cp -= sl;
                            if (con.update_SLCP_controller(TK, ma_ck, sl_cp))
                            {
                                MessageBox.Show("Đặt lệnh thành công");
                                ThongTinKH form = new ThongTinKH(TK);
                                form.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                        {
                        DialogResult result = MessageBox.Show("Bạn không đủ số lượng cổ phiếu để bán", "caption", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ThongTinKH form = new ThongTinKH(TK);
                            form.Show();
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
