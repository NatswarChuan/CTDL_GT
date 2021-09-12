using System;
using System.Collections.Generic;
using System.Text;

namespace CTDL_GT
{
    class KhachHang
    {
        //Fields
        private string maKH;
        private string hoTen;
        private string sdt;
        private string diaChi;

        //Constructors
        public KhachHang() { }

        public KhachHang(string maKH,string hoTen,string sdt,string diaChi)
        {
            this.maKH = maKH;
            this.hoTen = hoTen;
            this.sdt = sdt;
            this.diaChi = diaChi;
        }

        //Properties
        public string MaKH { get => maKH; set => maKH = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    
        //Methods

        /// <summary>
        /// toString
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            return $"\tMa khach hang: {this.maKH}\n\tHo ten: {this.hoTen}\n\tSo dien thoai: {this.sdt}\n\tDia chi: {this.diaChi}";
        }
    }
}
