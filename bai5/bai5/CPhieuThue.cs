using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace bai5
{
    public enum KieuLoaiPhong { A, B, C, D}
    [Serializable]
    class CPhieuThue
    {
        private string m_mapt;
        private DateTime m_ngaybd;
        private DateTime m_ngaykt;
        private string m_tenkh;
        private KieuLoaiPhong m_loaiphong;
        public CPhieuThue() {
            m_mapt = "";
            m_ngaybd = DateTime.Now;
            m_ngaykt = DateTime.Now;
            m_tenkh = "";
            m_loaiphong = KieuLoaiPhong.A;
        }
        public CPhieuThue(string mapt, DateTime ngaybd, DateTime ngaykt, string tenkh, KieuLoaiPhong loaiphong) {
            m_mapt = mapt;
            m_ngaybd = ngaybd;
            m_ngaykt = ngaykt;
            m_tenkh = tenkh;
            m_loaiphong = loaiphong;
        }
        public string MaPT {
            get { return m_mapt; }
            set { m_mapt = value; }
        }
        public DateTime NgayBD {
            get { return m_ngaybd; }
            set { m_ngaybd = value; }
        }
        public DateTime NgayKT {
            get {return m_ngaykt; }
            set { m_ngaykt = value; }
        }
        public string TenKH {
            get { return m_tenkh; }
            set { m_tenkh = value; }
        }
        public KieuLoaiPhong loaiPhong {
            get { return m_loaiphong; }
            set { m_loaiphong = value; }
        }
        public int SoNgayThue {
            get { return (NgayKT - NgayBD).Days + 1; }
        }
        public int TienThue {
            get {
                if(loaiPhong==KieuLoaiPhong.A)
                    return SoNgayThue * 250000;
                if(loaiPhong==KieuLoaiPhong.B)
                    return SoNgayThue * 400000;
                if (loaiPhong == KieuLoaiPhong.C)
                    return SoNgayThue * 600000;
                else
                    return SoNgayThue * 900000;
            }
        }
    }
}
