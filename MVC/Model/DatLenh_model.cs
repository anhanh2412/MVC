using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    class DatLenh_model
    {
        public bool insert_gd(string ma_gd, string ma_kh, string ma_san, float gia, int sl, int thanhtien, DateTime date, string trangthai, string lenh, string loai_lenh, string phien, string ma_ck)
        {
            if (XuLy.insert_GD(ma_gd, ma_kh, ma_san, gia, sl, thanhtien, date, trangthai, lenh, loai_lenh, phien, ma_ck))
            {
                return true;
            }
            return false;

        }

        public bool insert_cp_model(string ma_cp, string ma_kh, int sl)
        {
            if (XuLy.insert_CP(ma_cp, ma_kh, sl))
            {
                return true;
            }
            return false;
        }

        public bool update_kh_model(string ma_kh, int sdc)
        {
            if (XuLy.update_TTKH(ma_kh, sdc))
            {
                return true;
            }
            return false;
        }

        public int sl_model(string ma_kh, string ma_ck)
        {
            return XuLy.sl_CP(ma_kh, ma_ck);
        }

        public bool update_SLCP_model(string ma_kh, string ma_cp, int sl)
        {
            if (XuLy.update_SLCP(ma_kh, ma_cp, sl))
            {
                return true;
            }
            return false;
        }
    }
}
