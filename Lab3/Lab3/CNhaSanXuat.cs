using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class CNhaSanXuat
    {
        private string m_mansx, m_tennsx, m_sodt, m_diachi;
        public string MaNSX
        {
            get { return m_mansx; }
            set { m_mansx = value; }
        }
        public string TenNSX
        {
            get { return m_tennsx; }
            set { m_tennsx = value; }
        }
        public string SoDT
        {
            get { return m_sodt; }
            set { m_sodt = value; }
        }
        public string DiaChi
        {
            get { return m_diachi; }
            set { m_diachi = value; }
        }
        public CNhaSanXuat()
        {
            m_mansx = "";
            m_tennsx = "";
            m_sodt = "";
            m_diachi = "";
        }
        public CNhaSanXuat(string ma, string ten, string sodt, string dc)
        {
            m_mansx = ma;
            m_tennsx = ten;
            m_sodt = sodt;
            m_diachi = dc;
        }
    }
}
