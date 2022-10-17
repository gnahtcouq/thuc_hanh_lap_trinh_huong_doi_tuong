using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class frmVatTu : Form
    {
        private Dictionary<string, CVatTu> dsVT;
        private void loadDanhSachVT()
        {
            dgvVatTu.DataSource = dsVT.Values.ToList();
            dgvVatTu.ClearSelection();
        }
        private CVatTu findVT(string ma)
        {
            foreach (CVatTu s in dsVT.Values)
                if (s.MaVT == ma)
                    return s;
            return null;
        }
        public frmVatTu()
        {
            InitializeComponent();
        }
        private void frmVatTu_Load(object sender, EventArgs e)
        {
            dsVT = new Dictionary<string, CVatTu>();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            CVatTu n = new CVatTu();
            n.MaVT = txtMaVT.Text;
            n.TenVT = txtTenVT.Text;
            n.DonViTinh = txtDonViTinh.Text;
            if (txtMaVT.Text == "")
                MessageBox.Show("Ma vat tu khong duoc de trong");
            else
            {
                if (findVT(n.MaVT) == null)
                {
                    dsVT.Add(n.MaVT,n);
                    loadDanhSachVT();
                }
                else
                    MessageBox.Show("Mã vat tu " + n.MaVT + " đã tồn tại. Không thêm được.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvVatTu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaVT.Text = dgvVatTu.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenVT.Text = dgvVatTu.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDonViTinh.Text = dgvVatTu.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (findVT(txtMaVT.Text) != null)
            {
                foreach (CVatTu c in dsVT.Values)
                    if (c.MaVT == txtMaVT.Text)
                    {
                        dsVT.Remove(txtMaVT.Text);
                        break;
                    }
                loadDanhSachVT();
            }
            else
            {
                MessageBox.Show("Vat tu khong ton tai khong the xoa duoc");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (findVT(txtMaVT.Text) != null)
            {
                foreach (CVatTu s in dsVT.Values)
                    if (txtMaVT.Text == s.MaVT)
                    {
                        s.TenVT = txtTenVT.Text;
                        s.DonViTinh = txtDonViTinh.Text;
                        break;
                    }
                loadDanhSachVT();
            }
            else
                MessageBox.Show("Khong tim thay vat tu can sua");
        }
    }
}
