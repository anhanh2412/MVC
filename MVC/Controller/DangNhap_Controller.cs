using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Model;

namespace MVC.Controller
{
    class DangNhap_Controller
    {
        DangNhap model = new DangNhap();
        public bool check_login1(string tk, string pass)
        {
            if (model.check_login(tk, pass) == true)
            {
                return true;
            }
            else return false;
        }
    }
}
