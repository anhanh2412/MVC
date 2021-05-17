using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MVC.Model
{
    class LSGD_model
    {
        public DataTable getGD_model(string ma_kh)
        {
            return XuLy.getdata_GD(ma_kh);
        }
    }
}
