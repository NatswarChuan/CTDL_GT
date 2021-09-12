using System;
using System.Collections.Generic;
using System.Text;

namespace CTDL_GT
{
    class BienLai
    {
        //Fields
        private KhachHang khachHang;
        private int kyHoaDon;
        private int chiSoCu;
        private int chiSoMoi;
        private int tongNangLuongDienTieuThu;
        private double thanhTien;
        private DateTime hanThanhToan;
        private bool tinhTrang;

        //Contructors
        public BienLai() { }

        public BienLai(KhachHang khachHang, int kyHoaDon, int chiSoCu, int chiSoMoi, DateTime hanThanhToan, bool tinhTrang)
        {
            this.khachHang = khachHang;
            this.kyHoaDon = kyHoaDon;
            this.chiSoCu = chiSoCu;
            this.chiSoMoi = chiSoMoi;
            this.hanThanhToan = hanThanhToan;
            this.tinhTrang = tinhTrang;
            update();
        }

        public BienLai(string maKH, string hoTen, string sdt, string diaChi, int kyHoaDon, int chiSoCu, int chiSoMoi, DateTime hanThanhToan, bool tinhTrang)
        {
            this.khachHang = new KhachHang(maKH,hoTen,sdt,diaChi);
            this.kyHoaDon = kyHoaDon;
            this.chiSoCu = chiSoCu;
            this.chiSoMoi = chiSoMoi;
            this.hanThanhToan = hanThanhToan;
            this.tinhTrang = tinhTrang;
            update();
        }

        //Properties
        public int KyHoaDon { get => kyHoaDon; set => kyHoaDon = value; }
        public int ChiSoCu { get => chiSoCu; set { 
                chiSoCu = value;
                update();
            } }
        public int ChiSoMoi { get => chiSoMoi; set {
                chiSoMoi = value;
                update();
            } }
        public int TongNangLuongDienTieuThu { get => tongNangLuongDienTieuThu; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }
        public DateTime HanThanhToan { get => hanThanhToan; set => hanThanhToan = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        internal KhachHang KhachHang { get => khachHang; set => khachHang = value; }


        //Methods

        /// <summary>
        /// tinh tien phai dong
        /// </summary>
        /// <returns></returns>
        private double tinhTien()
        {
            double result = 0;


            if (this.tongNangLuongDienTieuThu <= 50)
            {
                result = this.tongNangLuongDienTieuThu * 1600;
            }
            else if (this.tongNangLuongDienTieuThu <= 100)
            {
                result = (50 * 1600) + ((this.tongNangLuongDienTieuThu - 50) * 2000);
            }
            else
            {
                result = (50 * 1600) + (50 * 2000) + ((this.tongNangLuongDienTieuThu - 100) * 3000);
            }

            return result;
        }

        /// <summary>
        /// cap nhat lai cac thong tin
        /// </summary>
        private void update()
        {
            this.tongNangLuongDienTieuThu = this.chiSoMoi - this.chiSoCu;
            this.thanhTien = tinhTien();
        }

        /// <summary>
        /// toString
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string tinhTrang = (this.tinhTrang) ? "da thanh toan" : "chua thanh toan";
            return $"Khach hang:\n{this.khachHang.toString()}\nKy hoa don: {this.kyHoaDon}\nChi so cu: {this.chiSoCu}\nChi so moi: {this.chiSoMoi}\nTong nang luong dien tieu thu: {this.tongNangLuongDienTieuThu}\nThanh tien: {this.thanhTien}\nHan thanh toan: {this.hanThanhToan.ToString("dd/MM/yyyy")}\nTinh trang: {tinhTrang}";
        }
    }
}
