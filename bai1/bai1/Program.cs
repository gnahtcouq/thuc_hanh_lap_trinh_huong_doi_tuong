using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1 {
    class Program {
        public static void GetNumber(ref int x, ref int y) {
            x = 5;
            y = 10;
        }

        static void NhapMang(int[,] a, out int n) {
            Console.Write("Nhap n=: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++) {
                    Console.Write("Nhap a[{0},{1}] = ", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
        }



        static void XuatMang(int[,] a, int n) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) { // j < n chứ không phải j < m
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static int KTNT(int n) {
            if (n < 2)
                return 0;
            else {
                for (int i = 2; i <= n / 2; i++)
                    if (n % i == 0)
                        return 0;
                return 1;
            }
        }

        static void XuatCacPhanTuTrenDuongCheoChinh(int[,] a, int n) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i == j)
                        Console.Write(a[i, j] + " ");
        }


        static void XuatCacSoNguyenTo(int[,] a, int n) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (KTNT(a[i, j]) == 1)
                        Console.Write(a[i, j] + " ");
        }

        static int TinhTongCacPhanTu(int[,] a, int n) {
            int sum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                        sum += a[i, j];
            return sum;
        }

        static int TinhTongCacSoNguyenTo(int[,] a, int n) {
            int sum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (KTNT(a[i, j]) == 1)
                        sum += a[i, j];
            return sum;
        }

        static int TinhTongCacPhanTuDongK(int[,] a, int n, int k) {
            int sum = 0;
            k--;
            for (int i = 0; i < n; i++)
                sum += a[k, i];
            return sum;
        }

        static void XuatSoPhanTuAmPhanTuDuong(int[,] a, int n) {
            int demAm = 0;
            int demDuong = 0;
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (a[i, j] > 0) {
                        demDuong++;
                    }
                    else {
                        demAm++;
                    }
                }
            }
            Console.Write("\n");
            Console.Write("Cau3. Tong cac so phan tu duong: ");
            Console.Write(demDuong);
            Console.Write("\n");
            Console.Write("Cau3. Tong cac so phan tu am: ");
            Console.Write(demAm);
        }

        static int DemSoLanXuatHienPhanTuX(int[,] a, int n, int x) {
            int count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] == x)
                        count++;
            return count;
        }

        static bool KiemTraSoHoanThien(int n) {
            int tong = 0;
            for (int i = 1; i <= n / 2; i++)
                if (n % i == 0)
                    tong += i;
            if (tong == n) return true;
            return false;
        }

        static void XuatRaCacSoHoanThien(int[,] a, int n) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (KiemTraSoHoanThien(a[i, j]))
                        Console.Write(a[i, j] + " ");
        }

        static void XuatRaChiSoViTriCacPhanTuBangN(int[,] a, int n, int m) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (m == a[i, j]) {
                        Console.Write("[");
                        Console.Write(i);
                        Console.Write(",");
                        Console.Write(j);
                        Console.Write("]");
                    }

        }

        static int DemCacPhanTuNhoHonX(int[,] a, int n, int x) {
            int count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] < x)
                        count++;
            return count;
        }

        static int TinhTongDongChan(int[,] a, int n) {
            int sum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i % 2 == 0)
                        sum += a[i, j];
            return sum;
        }

        static bool KiemTraMaTranDonVi(int[,] a, int n) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (i == j) {
                        if (a[i,j] != 1)
                            return false;
                    }
                    else if (a[i,j] != 0)
                        return false;
                }
            }
            return true;
        }

        static bool KiemTraMaTranDoiXung(int[,] a, int n) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < i; j++)
                    if (a[i, j] != a[j, i])
                        return false;
            return true;
        }
        static void CongHaiMaTran(int[,] a, int n) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] += a[i, j];
        }

        static void NhanHaiMaTran(int[,] a, int n) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] *= 2;
        }


        static void Main(string[] args) {
            //int a = 0, b = 0;
            //GetNumber(ref a, ref b);
            //Console.WriteLine("a={0}\n b={1}", a, b);
            //Console.ReadLine();

            //DateTime value = new DateTime(2014, 11, 20); // tạo một biến value có kiểu DateTime và gán nó bằng ngày 20/11/2014
            //Console.WriteLine(value); // xuất ra giá trị của value
            //Console.WriteLine(value == DateTime.Today); // kiểm tra nếu như giá trị của value bằng với thời gian của ngày hôm nay thì sẽ xuất True, không bằng thì xuất False
            //// Khai bao kieu DateTime
            //string simpleTime = "20/1/2000"; // khai báo một chuỗi và gán cho biến simpleTime một giá trị là "20/1/2000"
            //DateTime time = DateTime.Parse(simpleTime); // trả về một DateTime mới
            //Console.WriteLine(time); // xuất ra giá trị của time


            //Console.Write("Hom nay la ngay: ");
            //Console.WriteLine(DateTime.Today);


            //const int MAX = 10;
            //int n;
            //int[,] a = new int[MAX, MAX];
            //NhapMang(a, out n);
            //XuatMang(a, n);



            const int MAX = 10;
            int n, k, x, m;
            bool check;
            int[,] a = new int[MAX, MAX];
            NhapMang(a, out n);
            XuatMang(a, n);


            //Console.Write("Cau2.d Cac phan tu tren duong cheo chinh la: ");
            //XuatCacPhanTuTrenDuongCheoChinh(a, n);

            //Console.WriteLine();
            //Console.Write("Cau2.e Cac so nguyen to la: ");
            //XuatCacSoNguyenTo(a, n);

            //Console.WriteLine();
            //Console.WriteLine("Cau2.f Tong cac phan tu trong mang = " + TinhTongCacPhanTu(a, n));

            //Console.WriteLine("Cau3. Tong cac so nguyen to = " + TinhTongCacSoNguyenTo(a, n));

            //Console.Write("Nhap k = ");
            //k = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Cau3. Tinh tong cac phan tu dong  = " + TinhTongCacPhanTuDongK(a, n, k));

            //XuatSoPhanTuAmPhanTuDuong(a, n);

            //Console.WriteLine();
            //Console.Write("Nhap x = ");
            //x = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Cau3. So lan xuat hien cua phan tu x  = " + DemSoLanXuatHienPhanTuX(a, n, x));

            //Console.WriteLine();
            //Console.Write("Cau3. Cac so hoan thien la: ");
            //XuatRaCacSoHoanThien(a, n);

            //Console.WriteLine();
            //Console.Write("Nhap n = ");
            //m = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Cau3. Chi so vi tri cac phan tu bang n: ");
            //XuatRaChiSoViTriCacPhanTuBangN(a, n, m);


            //Console.WriteLine();
            //Console.Write("Nhap x = ");
            //x = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Cau4.a So phan tu nho hon x  = " + DemCacPhanTuNhoHonX(a, n, x));

            //Console.WriteLine("Cau4.b Tong dong chan = " + TinhTongDongChan(a, n));

            //check = KiemTraMaTranDonVi(a, n);
            //if (check)
            //    Console.WriteLine("Cau4.c Ma tran nay la ma tran don vi");
            //else
            //    Console.WriteLine("Cau4.c Ma tran nay khong phai la ma tran don vi");

            //check = KiemTraMaTranDoiXung(a, n);
            //if (check)
            //    Console.WriteLine("Cau4.d Ma tran nay la ma tran doi xung");
            //else
            //    Console.WriteLine("Cau4.d Ma tran nay khong phai la ma tran doi xung");

            //CongHaiMaTran(a, n);
            //Console.WriteLine("Cau4.e Ma tran sau khi cong hai");
            //XuatMang(a, n);

            //NhanHaiMaTran(a, n);
            //Console.WriteLine("Cau4.f Ma tran sau khi nhan hai");
            //XuatMang(a, n);

            Console.ReadLine();
        }
    }
}
