using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Model;
using System.Data;

namespace MVC.Controller
{
    class LSGD_controller
    {
        LSGD_model model = new LSGD_model();
        public DataTable getGD_controller(string ma_kh)
        {
            return model.getGD_model(ma_kh);
        }
    }
}
