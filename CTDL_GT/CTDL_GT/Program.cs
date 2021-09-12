using System;

namespace CTDL_GT
{
    class Program
    {
        static void Main(string[] args)
        {
            TienIch tienIch = new TienIch();
            char key = '\0';
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Menu:\n\t" +
                    "1. Nhap danh sach bien lai.\n\t" +
                    "2. Xuat danh sach bien lai.\n\t" +
                    "3. Xuat file KHQuaHanTT.txt.\n\t" +
                    "4. Xuat file TrungBinhDienTieuThu.txt.\n\t" +
                    "5. Xoa bien lai.\n\t" +
                    "6. Sua tinh trang bien lai.\n\t" +
                    "7. Sap xep bien lai theo tien tang dan.\n\t" +
                    "ESC. Thoat chuong trinh.");
                    key = Console.ReadKey(true).KeyChar;
                } while (!key.Equals((char)ConsoleKey.Escape)
                && !key.Equals((char)ConsoleKey.NumPad1)
                && !key.Equals((char)ConsoleKey.D1)
                && !key.Equals((char)ConsoleKey.NumPad2)
                && !key.Equals((char)ConsoleKey.D2)
                && !key.Equals((char)ConsoleKey.NumPad3)
                && !key.Equals((char)ConsoleKey.D3)
                && !key.Equals((char)ConsoleKey.NumPad4)
                && !key.Equals((char)ConsoleKey.D4)
                && !key.Equals((char)ConsoleKey.NumPad5)
                && !key.Equals((char)ConsoleKey.D5)
                && !key.Equals((char)ConsoleKey.NumPad6)
                && !key.Equals((char)ConsoleKey.D6)
                && !key.Equals((char)ConsoleKey.NumPad7)
                && !key.Equals((char)ConsoleKey.D7));

                switch (key)
                {
                    case (char)ConsoleKey.NumPad1:
                    case (char)ConsoleKey.D1:
                        Console.Clear();
                        tienIch.NhapListBienLai();
                        break;
                    case (char)ConsoleKey.NumPad2:
                    case (char)ConsoleKey.D2:
                        Console.Clear();
                        tienIch.XuatDanhSach();
                        Console.ReadKey();
                        break;
                    case (char)ConsoleKey.NumPad3:
                    case (char)ConsoleKey.D3:
                        Console.Clear();
                        tienIch.ThongTinKhachHangQuaHan();
                        break;
                    case (char)ConsoleKey.NumPad4:
                    case (char)ConsoleKey.D4:
                        Console.Clear();
                        tienIch.TrungBinhLuongDienTieuThu();
                        break;
                    case (char)ConsoleKey.NumPad5:
                    case (char)ConsoleKey.D5:
                        Console.Clear();
                        tienIch.XoaBienLai();
                        break;
                    case (char)ConsoleKey.NumPad6:
                    case (char)ConsoleKey.D6:
                        Console.Clear();
                        tienIch.SuaTinhTrangBienLai();
                        break;
                    case (char)ConsoleKey.NumPad7:
                    case (char)ConsoleKey.D7:
                        Console.Clear();
                        tienIch.SapXepBienLai();
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }
            } while (key != (char)ConsoleKey.Escape);
            
        }
    }
}
