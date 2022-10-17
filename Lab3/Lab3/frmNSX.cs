using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class frmNSX : Form
    {
        //private Dictionary<string, CNhaSanXuat> dsNSX;
        private List<CNhaSanXuat> dsNSX;
        private void hienDSNhaSanXuat()
        {
            dgvNSX.DataSource = dsNSX.ToList();
        }
        private CNhaSanXuat timNSX(string ma)
        {
            foreach (CNhaSanXuat s in dsNSX)
                if (s.MaNSX == ma)
                    return s;
            return null;
        }
        public frmNSX()
        {
            InitializeComponent();
        }
        private void frmNSX_Load(object sender, EventArgs e)
        {
            dsNSX = new List<CNhaSanXuat>();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            CNhaSanXuat n = new CNhaSanXuat();
            n.MaNSX = txtMaNSX.Text;
            n.TenNSX = txtTenNSX.Text;
            n.SoDT = txtSoDT.Text;
            n.DiaChi = txtDiaChi.Text;
            if (txtMaNSX.Text == "")
                MessageBox.Show("Ma nha san xuat khong duoc de trong");
            else
            {
                if (timNSX(n.MaNSX) == null)
                {
                    dsNSX.Add(n);
                    hienDSNhaSanXuat();
                }
                else
                    MessageBox.Show("Mã nhà sản xuất " + n.MaNSX + " đã tồn tại. Không thêm được.");
            }
        }
        private void dgvNSX_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNSX.Text = dgvNSX.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNSX.Text = dgvNSX.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoDT.Text = dgvNSX.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDiaChi.Text = dgvNSX.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (timNSX(txtMaNSX.Text) != null)
            {
                foreach (CNhaSanXuat c in dsNSX)
                    if (c.MaNSX == txtMaNSX.Text)
                    {
                        dsNSX.Remove(c);
                        break;
                    }
                hienDSNhaSanXuat();
            }
            else
            {
                MessageBox.Show("Nha san xuat khong ton tai khong the xoa duoc");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (timNSX(txtMaNSX.Text) != null)
            {
                foreach (CNhaSanXuat s in dsNSX)
                    if (txtMaNSX.Text == s.MaNSX)
                    {
                        s.TenNSX = txtTenNSX.Text;
                        s.DiaChi = txtDiaChi.Text;
                        s.SoDT = txtSoDT.Text;
                        break;
                    }
                hienDSNhaSanXuat();
            }
            else
                MessageBox.Show("Khong tim thay nhan san xuat can sua");
        }

        private void frmNSX_FormClosing(object sender, FormClosingEventArgs e)
        {
            var close = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (close == DialogResult.Yes)
            {
                return;
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
