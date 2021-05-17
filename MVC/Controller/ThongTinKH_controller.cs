using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Model;
using System.Data;

namespace MVC.Controller
{
    class ThongTinKH_controller
    {
        ThongTinKH_model model = new ThongTinKH_model();
        public DataTable load_form(string tk)
        {
            DataTable tb;
            tb = model.re_load(tk);
            return tb;
        }

        public int data_KH(string tk)
        {
            int sdc = model.getData(tk);
            return sdc;
        }
    }
}
