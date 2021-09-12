using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CTDL_GT
{
    class TienIch
    {
        private LinkedList list;
        public TienIch()
        {
            this.list = new LinkedList();
        }

        /// <summary>
        /// cau 1: nhap danh sach n bien lai
        /// </summary>
        public void NhapListBienLai()
        {
            BienLai bienLai;
            int n = 0;
            do
            {
                Console.Write("Nhap so luong bien lai: ");
            } while (!int.TryParse(Console.ReadLine(), out n));

            for (int i = 0; i < n; i++)
            {
                bienLai = NhapBienLai();
                this.list.AddLast(bienLai);
            }
        }

        /// <summary>
        /// nhap thong tin bien lai
        /// </summary>
        /// <returns></returns>
        private BienLai NhapBienLai()
        {
            KhachHang khachHang;
            int kyHoaDon, chiSoCu, chiSoMoi;
            DateTime hanThanhToan;
            bool tinhTrang;
            char key = '\0';

            Console.WriteLine("Nhap thong tin khach hang:");
            khachHang = NhapKhachHang();
            do
            {
                Console.Write("Nhap ky hoa don: ");
            } while (!int.TryParse(Console.ReadLine(), out kyHoaDon) || kyHoaDon < 1 || kyHoaDon > 12);
            do
            {
                Console.Write("Nhap chi so cu: ");
            } while (!int.TryParse(Console.ReadLine(), out chiSoCu));
            do
            {
                Console.Write("Nhap chi so moi: ");
            } while (!int.TryParse(Console.ReadLine(), out chiSoMoi) || chiSoMoi < chiSoCu);
            Console.WriteLine("Nhap han thanh toan: ");
            hanThanhToan = NhapHanThanhToan();
            do
            {
                Console.Write("Nhap tinh trang thanh toan (Y/N):");
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (char.ToUpper(key) != (char)ConsoleKey.N && char.ToUpper(key) != (char)ConsoleKey.Y);

            tinhTrang = char.ToUpper(key) == (char)ConsoleKey.Y;

            BienLai bienLai = new BienLai(khachHang, kyHoaDon, chiSoCu, chiSoMoi, hanThanhToan, tinhTrang);
            return bienLai;
        }

        /// <summary>
        /// nhap thong tin khach hang
        /// </summary>
        /// <returns></returns>
        private KhachHang NhapKhachHang()
        {
            string maKH, hoTen, sdt, diaChi;
            Console.Write("Nhap ma khach hang: ");
            maKH = Console.ReadLine();
            Console.Write("Nhap ho ten khach hang: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhap so dien thoai khach hang: ");
            sdt = Console.ReadLine();
            Console.Write("Nhap dia chi khach hang: ");
            diaChi = Console.ReadLine();
            KhachHang khachHang = new KhachHang(maKH, hoTen, sdt, diaChi);
            return khachHang;
        }

        /// <summary>
        /// nhap ngay han thanh toan
        /// </summary>
        /// <returns></returns>
        private DateTime NhapHanThanhToan()
        {
            int ngay, thang, nam;
            do
            {
                Console.Write("Ngay thanh toan: ");
            } while (!int.TryParse(Console.ReadLine(), out ngay) || ngay > 31 || ngay < 1);
            do
            {
                Console.Write("Thang thanh toan: ");
            } while (!int.TryParse(Console.ReadLine(), out thang)  || thang < 1 || thang > 12);
            do
            {
                Console.Write("Nam thanh toan: ");
            } while (!int.TryParse(Console.ReadLine(), out nam) || nam < 1);

            DateTime hanThanhToan = new DateTime(nam, thang, ngay);
            return hanThanhToan;
        }

        /// <summary>
        /// cau 2: hien thi danh sach ra man hinh
        /// </summary>
        public void XuatDanhSach()
        {
            for (Node i = this.list.First; i != null; i = i.Next)
            {
                Console.WriteLine(i.Value.toString());
            }
        }

        /// <summary>
        /// luu file
        /// </summary>
        /// <param name="link"></param>
        /// <param name="arrString"></param>
        private void WriteFile(string link, string[] arrString)
        {
            StreamWriter streamWriter;
            if (File.Exists(link))
            {
                File.SetAttributes(link, FileAttributes.Normal);
                streamWriter = new StreamWriter(link);
            }
            else
            {
                streamWriter = new StreamWriter(link);
                File.SetAttributes(link, FileAttributes.Normal);
            }
            for (int i = 0; i < arrString.Length - 1; i++)
            {
                streamWriter.WriteLine(arrString[i]);
            }
            streamWriter.Write(arrString[arrString.Length - 1]);
            streamWriter.Close();
            File.SetAttributes(link, FileAttributes.ReadOnly);
        }

        /// <summary>
        /// cau 3: luu danh sach khach hang qua han
        /// </summary>
        public void ThongTinKhachHangQuaHan()
        {
            string[] arrString = new string[0];

            for (Node i = this.list.First; i != null; i = i.Next)
            {
                if (DateTime.Now.CompareTo(i.Value.HanThanhToan) == 1 && !i.Value.TinhTrang)
                {
                    Array.Resize(ref arrString, arrString.Length + 1);
                    arrString[arrString.Length - 1] = i.Value.toString();
                }
            }

            if (arrString.Length > 0)
            {
                WriteFile("KHQuaHanTT.txt", arrString);
            }
        }

        /// <summary>
        /// cau 4: luu trung binh luong dien tieu thu cua quy hien tai
        /// </summary>
        /// <returns></returns>
        public double TrungBinhLuongDienTieuThu()
        {
            double result = 0;
            double tong = 0;
            int soLuong = 0;

            for (Node i = this.list.First; i != null; i = i.Next)
            {
                if (DateTime.Now.Month == i.Value.KyHoaDon)
                {
                    tong += i.Value.TongNangLuongDienTieuThu;
                    soLuong++;
                }
            }
            result = tong / soLuong;

            WriteFile("TrungBinhDienTieuThu.txt", new string[] { $"trung binh dien tieu thu ky {DateTime.Now.Month}: {result}"});

            return result;
        }

        /// <summary>
        /// cau 5: xoa bien lai co trung maKH
        /// </summary>
        public void XoaBienLai()
        {
            string key = "";
            Console.Write("Nhap ma khach hang can xoa: ");
            key = Console.ReadLine();
            this.list.Remove(key);
        }

        /// <summary>
        /// cau 6: sua tinh trang bien lai
        /// </summary>
        public void SuaTinhTrangBienLai()
        {
            string keys = "";
            char key = '\0';
            bool tinhTrang = false;
            Console.Write("Nhap ma khach hang can sau tinh trang: ");
            keys = Console.ReadLine();
            if (this.list.Count > 0)
            {
                BienLai bienLai = this.list.Finds(keys).First.Value;
                do
                {
                    Console.Write("Nhap tinh trang thanh toan (Y/N):");
                    key = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                } while (char.ToUpper(key) != (char)ConsoleKey.N && char.ToUpper(key) != (char)ConsoleKey.Y);

                tinhTrang = char.ToUpper(key) == (char)ConsoleKey.Y;

                bienLai.TinhTrang = tinhTrang;

                ThongTinKhachHangQuaHan();
            }        
        }

        /// <summary>
        /// cau 7: sap xep bien lai
        /// </summary>
        public void SapXepBienLai()
        {
            this.list.Sort();
            XuatDanhSach();
        }
    }
}
