using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MVC.Model
{
    class XuLy
    {
        static string s = @"Data Source=DESKTOP-7HOLHB6\SQLEXPRESS;Initial Catalog=QLCK;Integrated Security=True";
        static SqlConnection conn;
        static SqlCommand cmm;
        static SqlDataAdapter data;
        static DataTable tb;

        public static DataTable getData(string sql)
        {
            conn = new SqlConnection(s);
            conn.Open();
            data = new SqlDataAdapter(sql, conn);
            tb = new DataTable();
            data.Fill(tb);
            conn.Close();
            return tb;
        }

        public static bool check(string sql)
        {
            
            conn = new SqlConnection(s);
            conn.Open();
            cmm = new SqlCommand(sql, conn);
            SqlDataReader da = cmm.ExecuteReader();
            if (da.Read() == true)
            {
                return true;
            }
            conn.Close();
            return false;
        }

        public static int getSDC(string sql)
        {
            conn = new SqlConnection(s);
            conn.Open();
            cmm = new SqlCommand(sql, conn);
            SqlDataReader da = cmm.ExecuteReader();
            int sdc = 0;
            while (da.Read())
            {
                sdc = da.GetInt32(0);
            }
            conn.Close();
            return sdc;
        }

        public static bool insert_GD(string Ma_gd, string Ma_kh, string Ma_san, float Gia, int Sl, int Thanhtien, DateTime Date, string Trangthai, string Lenh, string Loai_lenh, string Phien, string Ma_ck)
        {
            conn = new SqlConnection(s);
            string sql = "insert into GD(Ma_GD, Ma_KH, Ma_San, Don_Gia, SL, Thanh_Tien, Ngay_GD, Trang_Thai, Lenh, Loai_Lenh, Phien, Ma_CK)values(@ma_gd, @ma_kh, @ma_san, @gia, @sl, @thanhtien, @date, @trangthai, @lenh, @loai_lenh, @phien, @ma_ck)";
            try
            {
                conn.Open();
                cmm = new SqlCommand(sql, conn);
                cmm.Parameters.AddWithValue("@ma_gd", Ma_gd);
                cmm.Parameters.AddWithValue("@ma_kh", Ma_kh);
                cmm.Parameters.AddWithValue("@ma_san", Ma_san);
                cmm.Parameters.AddWithValue("@gia", Gia);
                cmm.Parameters.AddWithValue("@sl", Sl);
                cmm.Parameters.AddWithValue("@thanhtien", Thanhtien);
                cmm.Parameters.AddWithValue("@date", Date);
                cmm.Parameters.AddWithValue("@trangthai", Trangthai);
                cmm.Parameters.AddWithValue("@lenh", Lenh);
                cmm.Parameters.AddWithValue("@loai_lenh", Loai_lenh);
                cmm.Parameters.AddWithValue("@phien", Phien);
                cmm.Parameters.AddWithValue("@ma_ck", Ma_ck);
                cmm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static bool insert_CP(string ma_cp, string ma_kh,int sl)
        {
            conn = new SqlConnection(s);
            string sql = "insert into CK(Ma_CP, Ma_KH, SL)values(@ma_cp, @ma_kh, @sl)";
            try
            {
                conn.Open();
                cmm = new SqlCommand(sql, conn);
                cmm.Parameters.AddWithValue("@ma_cp", ma_cp );
                cmm.Parameters.AddWithValue("@ma_kh", ma_kh);
                cmm.Parameters.AddWithValue("@sl", sl);
                cmm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static bool update_TTKH(string ma_kh, int sdc)
        {
            conn = new SqlConnection(s);
            string sql = "update KhachHang set SDC = @sdc where Ma_KH = @ma_kh";
            try
            {
                conn.Open();
                cmm = new SqlCommand(sql, conn);
                cmm.Parameters.AddWithValue("@sdc", sdc);
                cmm.Parameters.AddWithValue("@ma_kh", ma_kh);
                cmm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
                throw;

            }
            return true;
        }

        public static int sl_CP(string ma_kh, string ma_cp)
        {
            conn = new SqlConnection(s);
            string sql = "Select SL from CK where Ma_KH = @maKH And Ma_CP = @maCP";
            conn.Open();
            cmm = new SqlCommand(sql, conn);
            cmm.Parameters.AddWithValue("@maKH", ma_kh);
            cmm.Parameters.AddWithValue("@maCP", ma_cp);
            SqlDataReader da = cmm.ExecuteReader();
            int sl = 0;
            while (da.Read())
            {
                sl = da.GetInt32(0);
            }
            conn.Close();
            return sl;
        }

        public static bool update_SLCP(string ma_kh, string ma_cp,  int sl)
        {
            conn = new SqlConnection(s);
            string sql = "update CK set SL = @SL_CP where Ma_KH = @ma_kh And Ma_CP = @Ma_CP";
            try
            {
                conn.Open();
                cmm = new SqlCommand(sql, conn);
                cmm.Parameters.AddWithValue("@SL_CP", sl);
                cmm.Parameters.AddWithValue("@ma_kh", ma_kh);
                cmm.Parameters.AddWithValue("@Ma_CP", ma_cp);
                cmm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
                throw;

            }
            return true;
        }

        public static DataTable getdata_GD(string ma_kh)
        {
            conn = new SqlConnection(s);
            string sql = "Select Ma_GD, Ma_San, Don_Gia, SL, Thanh_Tien, Ngay_GD, Trang_Thai, Lenh, Loai_Lenh, Phien, Ma_CK from GD where Ma_KH = '" + ma_kh + "'";
            conn.Open();
            data = new SqlDataAdapter(sql, conn);
            tb = new DataTable();
            data.Fill(tb);
            conn.Close();
            return tb;
        }
    }
}
