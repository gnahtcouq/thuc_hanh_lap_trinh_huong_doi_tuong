using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class CVatTu
    {
        private string m_mavt, m_tenvt, m_donvitinh;
        public string MaVT
        {
            get { return m_mavt; }
            set { m_mavt = value; }
        }
        public string TenVT
        {
            get { return m_tenvt; }
            set { m_tenvt = value; }
        }
        public string DonViTinh
        {
            get { return m_donvitinh; }
            set { m_donvitinh = value; }
        }
        public CVatTu()
        {
            m_mavt = "";
            m_tenvt = "";
            m_donvitinh = "";
        }
        public CVatTu(string ma, string ten, string donvitinh)
        {
            m_mavt = ma;
            m_tenvt = ten;
            m_donvitinh = donvitinh;
        }
    }
}
