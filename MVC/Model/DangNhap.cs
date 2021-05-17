using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    class DangNhap
    {
        public bool check_login(string tk, string mk)
        {
            string sql = "SELECT * From KhachHang where Ma_KH = '" + tk + "' AND MK = '" + mk + "'";
            if (XuLy.check(sql) == true)
            {
                return true;
            }
            else return false;
        }
    }
}
