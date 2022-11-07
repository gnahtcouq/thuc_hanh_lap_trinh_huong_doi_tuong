using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai5 {
    class CXuLyPhieuThue {
        private Dictionary<string, CPhieuThue> dsPT;
        public CXuLyPhieuThue() {
            dsPT = new Dictionary<string, CPhieuThue>();
        }

        public List<CPhieuThue> layDSPhieuThue() {
            return dsPT.Values.ToList();
        }
        public CPhieuThue tim(string mspt) {
            foreach (CPhieuThue pt in dsPT.Values) {
                if (pt.MaPT == mspt)
                    return pt;
            }
            return null;
        }
        public void them(CPhieuThue pt) {
            if (tim(pt.MaPT) == null)
                dsPT.Add(pt.MaPT, pt);
            else MessageBox.Show("Mã phiếu thuê" + pt.MaPT + " đã tồn tại");
        }

        public void xoa(string mapt) {
            CPhieuThue n = tim(mapt);
            if (n == null)
                MessageBox.Show("Không tồn tại");
            else
                dsPT.Remove(mapt);
        }

        public void sua(CPhieuThue pt) {
            CPhieuThue n = tim(pt.MaPT);
            if (n == null)
                MessageBox.Show("Không tồn tại");
            else {
                n.NgayBD = pt.NgayBD;
                n.NgayKT = pt.NgayKT;
                n.TenKH = pt.TenKH;
                n.loaiPhong = pt.loaiPhong;
            }
        }

        public void ghiFile(string tenfile) {
            try {
                FileStream fs = new FileStream(tenfile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dsPT);
                fs.Close();
                MessageBox.Show("Lưu file thành công");
            }
            catch (Exception error) {
                MessageBox.Show(error.ToString());
            }
        }

        public void docFile(string tenfile) {
            try {
                FileStream fs = new FileStream(tenfile, FileMode.Open);
                dsPT = new Dictionary<string, CPhieuThue>();
                BinaryFormatter bf = new BinaryFormatter();
                dsPT = (Dictionary<string, CPhieuThue>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception error) {
                MessageBox.Show("Không có file để đọc dữ liệu");
            }
        }
    }
}
