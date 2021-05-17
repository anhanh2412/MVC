using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MVC.Model
{
    class ThongTinKH_model
    {
        // public string ma_kh { get; set; }
        // public string ma_ck { get; set; }
        // public string sdc { get; set; }
        // public int sl { get; set; }

        public DataTable re_load(string tk)
        {
            DataTable tb;
            string lenh = "SELECT Ma_CP, SL FROM CK where CK.Ma_KH = '"+tk+"'";
            tb = XuLy.getData(lenh);
            return tb;
        }

        public int getData(string tk)
        {
            string lenh = "Select SDC from KhachHang where Ma_KH = '"+tk+"'";
            int sdc = XuLy.getSDC(lenh);
            return sdc;
        }

    }
}
