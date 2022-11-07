using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace bai5
{
    public partial class Form1 : Form
    {
        //private Dictionary<string, CPhieuThue> dsPT;

        private CXuLyPhieuThue xlPT;

        private string tenfile = "DSPT.dat";

        private void hienDSPhieuThue()
        {
            dgvPhieuThue.DataSource = xlPT.layDSPhieuThue();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dsPT = new Dictionary<string, CPhieuThue>();
            //try {
            //    FileStream fs = new FileStream("DSPT.dat", FileMode.OpenOrCreate);
            //    BinaryFormatter bf = new BinaryFormatter();

            //    dsPT = (Dictionary<string, CPhieuThue>)bf.Deserialize(fs);
            //    fs.Close();
            //    if (dsPT != null)
            //        hienDSPhieuThue();
            //}
            //catch {
            //    dsPT = new Dictionary<string, CPhieuThue>();
            //}

            xlPT = new CXuLyPhieuThue();
            xlPT.docFile(tenfile);
            hienDSPhieuThue();
        }

        private void dgvPhieuThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvPhieuThue.Rows[e.RowIndex].Cells[0].Value.ToString();
            //dtpNgayBD.Value = Convert.ToDateTime(dgvPhieuThue.Rows[e.RowIndex].Cells[1].Value);//
            dtpNgayKT.Value = Convert.ToDateTime(dgvPhieuThue.Rows[e.RowIndex].Cells[2].Value);
            txtTen.Text = dgvPhieuThue.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "A")
                radA.Checked = true;
            else if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "B")
                radB.Checked = true;
            else if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "C")
                radC.Checked = true;
            else
                radD.Checked = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CPhieuThue pt = new CPhieuThue();
            pt.MaPT = txtMa.Text;
            pt.NgayBD = dtpNgayBD.Value.Date;
            pt.NgayKT = dtpNgayKT.Value.Date;
            pt.TenKH = txtTen.Text;
            if (radA.Checked)
                pt.loaiPhong = KieuLoaiPhong.A;
            else if (radB.Checked)
                pt.loaiPhong = KieuLoaiPhong.B;
            else if (radC.Checked)
                pt.loaiPhong = KieuLoaiPhong.C;
            else
                pt.loaiPhong = KieuLoaiPhong.D;
            if (xlPT.tim(pt.MaPT) == null)
            {
                xlPT.them(pt);
                hienDSPhieuThue();
            }
            else
                MessageBox.Show("Mã phiếu thuê " + txtMa.Text + " không thể thêm");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xlPT.tim(txtMa.Text) != null)
            {
                xlPT.xoa(txtMa.Text);
                hienDSPhieuThue();
                MessageBox.Show("Xóa thành công");
            }
            else MessageBox.Show("Mã học sinh " + txtMa.Text + " không xóa được!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CPhieuThue pt = new CPhieuThue();
            pt.MaPT = txtMa.Text;
            pt.TenKH = txtTen.Text;
            pt.NgayBD = dtpNgayBD.Value;
            pt.NgayKT = dtpNgayKT.Value;
            pt.loaiPhong = radA.Checked == true ? KieuLoaiPhong.A : radB.Checked == true ? KieuLoaiPhong.B : radC.Checked == true ? KieuLoaiPhong.C : KieuLoaiPhong.D;
            xlPT.sua(pt);
            hienDSPhieuThue();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            //FileStream fs = new FileStream("DSPT.dat", FileMode.Open);
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(fs, dsPT);
            //MessageBox.Show("Lưu thành công");
            //fs.Close();
            xlPT.ghiFile(tenfile);
        }

        private void dgvPhieuThue_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMa.Text = dgvPhieuThue.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                dtpNgayBD.Value = Convert.ToDateTime(dgvPhieuThue.Rows[e.RowIndex].Cells["Column2"].Value);
                dtpNgayKT.Value = Convert.ToDateTime(dgvPhieuThue.Rows[e.RowIndex].Cells["Column3"].Value);
                txtTen.Text = (dgvPhieuThue.Rows[e.RowIndex].Cells["Column4"].Value.ToString());
                if (dgvPhieuThue.Rows[e.RowIndex].Cells["Column5"].Value.ToString() == "A")
                {
                    radA.Checked = true;
                }
                else if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "B")
                {
                    radB.Checked = true;
                }
                else if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "C")
                {
                    radC.Checked = true;
                }
                else
                {
                    radD.Checked = true;
                }
            }
        }




        //private List<CPhieuThue> dsPT;


        //private void hienDSPhieuThue()
        //{
        //    dgvPhieuThue.DataSource = dsPT.ToList();
        //}
        //public Form1()
        //{
        //    InitializeComponent();
        //}
        //private CPhieuThue timPT(string mapt)
        //{
        //    foreach (CPhieuThue a in dsPT)
        //    {
        //        if (a.MaPT == mapt) return a;
        //    }
        //    return null;
        //}

        //private void groupBox1_Enter(object sender, EventArgs e)
        //{

        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    dsPT = new List<CPhieuThue>();
        //    try
        //    {
        //        FileStream fs = new FileStream("DSPT.dat", FileMode.OpenOrCreate);
        //        BinaryFormatter bf = new BinaryFormatter();

        //        dsPT = (List<CPhieuThue>)bf.Deserialize(fs);
        //        fs.Close();
        //        if (dsPT != null)
        //            hienDSPhieuThue();
        //    }
        //    catch
        //    {
        //        dsPT = new List<CPhieuThue>();
        //    }

        //}

        //private void dgvPhieuThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    txtMa.Text = dgvPhieuThue.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    //dtpNgayBD.Value = Convert.ToDateTime(dgvPhieuThue.Rows[e.RowIndex].Cells[1].Value);//
        //    dtpNgayKT.Value = Convert.ToDateTime(dgvPhieuThue.Rows[e.RowIndex].Cells[2].Value);
        //    txtTen.Text = dgvPhieuThue.Rows[e.RowIndex].Cells[3].Value.ToString();
        //    if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "A")
        //        radA.Checked = true;
        //    else if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "B")
        //        radB.Checked = true;
        //    else if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "C")
        //        radC.Checked = true;
        //    else
        //        radD.Checked = true;
        //}

        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    CPhieuThue pt = new CPhieuThue();
        //    pt.MaPT = txtMa.Text;
        //    pt.NgayBD = dtpNgayBD.Value.Date;
        //    pt.NgayKT = dtpNgayKT.Value.Date;
        //    pt.TenKH = txtTen.Text;
        //    if (radA.Checked)
        //        pt.loaiPhong = KieuLoaiPhong.A;
        //    else if (radB.Checked)
        //        pt.loaiPhong = KieuLoaiPhong.B;
        //    else if (radC.Checked)
        //        pt.loaiPhong = KieuLoaiPhong.C;
        //    else
        //        pt.loaiPhong = KieuLoaiPhong.D;
        //    if (timPT(pt.MaPT) == null)
        //    {
        //        dsPT.Add(pt);
        //        hienDSPhieuThue();
        //    }
        //    else
        //        MessageBox.Show("Mã phiếu thuê " + txtMa.Text + " không thể thêm");
        //}

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    if (timPT(txtMa.Text) != null)
        //    {
        //        dsPT.Remove(timPT(txtMa.Text));
        //        hienDSPhieuThue();
        //        MessageBox.Show("Xóa thành công");
        //    }
        //    else MessageBox.Show("Ma hoc sinh " + txtMa.Text + " khong xoa duoc!");
        //}

        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    if (timPT(txtMa.Text) == null)
        //    {
        //        CPhieuThue pt = new CPhieuThue();
        //        pt.TenKH = txtTen.Text;
        //        pt.NgayBD = dtpNgayBD.Value;
        //        pt.NgayKT = dtpNgayKT.Value;
        //        pt.loaiPhong = radA.Checked == true ? KieuLoaiPhong.A : radB.Checked == true ? KieuLoaiPhong.B : radC.Checked == true ? KieuLoaiPhong.C : KieuLoaiPhong.D;

        //        else
        //            MessageBox.Show("Mã phiếu thuê" + txtMa.Text + " không thể sửa");
        //        hienDSPhieuThue();
        //    }

        //    private void btnLuu_Click(object sender, EventArgs e)
        //    {
        //        FileStream fs = new FileStream("DSPT.dat", FileMode.Open);
        //        BinaryFormatter bf = new BinaryFormatter();
        //        bf.Serialize(fs, dsPT);
        //        MessageBox.Show("Lưu thành công");
        //        fs.Close();
        //    }

        //    private void dgvPhieuThue_CellEnter(object sender, DataGridViewCellEventArgs e)
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            txtMa.Text = dgvPhieuThue.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
        //            dtpNgayBD.Value = Convert.ToDateTime(dgvPhieuThue.Rows[e.RowIndex].Cells["Column2"].Value);
        //            dtpNgayKT.Value = Convert.ToDateTime(dgvPhieuThue.Rows[e.RowIndex].Cells["Column3"].Value);
        //            txtTen.Text = (dgvPhieuThue.Rows[e.RowIndex].Cells["Column4"].Value.ToString());
        //            if (dgvPhieuThue.Rows[e.RowIndex].Cells["Column5"].Value.ToString() == "A")
        //            {
        //                radA.Checked = true;
        //            }
        //            else if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "B")
        //            {
        //                radB.Checked = true;
        //            }
        //            else if (dgvPhieuThue.Rows[e.RowIndex].Cells[4].Value.ToString() == "C")
        //            {
        //                radC.Checked = true;
        //            }
        //            else
        //            {
        //                radD.Checked = true;
        //            }
        //        }
    }
}


