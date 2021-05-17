using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Model;

namespace MVC.Controller
{
    class DatLenh_Controller
    {
        DatLenh_model model = new DatLenh_model();
        public bool insert_gd(string ma_gd, string ma_kh, string ma_san, float gia, int sl, int thanhtien, DateTime date, string trangthai, string lenh, string loai_lenh, string phien, string ma_ck)
        {
            if(model.insert_gd(ma_gd, ma_kh, ma_san, gia, sl, thanhtien, date, trangthai, lenh, loai_lenh, phien, ma_ck))
            {
                return true;
            }
            return false;
            
        }

        public bool insert_cp(string ma_cp, string ma_kh, int sl)
        {
            if(model.insert_cp_model(ma_cp, ma_kh, sl))
            {
                return true;
            }
            return false;
        }

        public bool update_kh_controller(string ma_kh, int sdc)
        {
            if (model.update_kh_model(ma_kh, sdc))
            {
                return true;
            }
            return false;
        }
        public int sl_controller(string ma_kh, string ma_ck)
        {
            return model.sl_model(ma_kh, ma_ck);
        }

        public bool update_SLCP_controller(string ma_kh, string ma_cp, int sl)
        {
            if (model.update_SLCP_model(ma_kh, ma_cp, sl))
            {
                return true;
            }
            return false;
        }
    }
}
