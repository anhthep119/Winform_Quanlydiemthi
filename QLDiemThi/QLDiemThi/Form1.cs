using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Ex11_QLDiemThi
{
    public partial class Form1 : Form
    {
        ketnoiDB db = new ketnoiDB();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void quảnLýĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaSV.Text == "123")
            {
                txtHoTen.Text = "NVC";
            }
            if (cbMaSV.Text == "234")
            {
                txtHoTen.Text = "NVn";
            }
            if (cbMaSV.Text == "345")
            {
                txtHoTen.Text = "NVb";
            }
            if (cbMaSV.Text == "456")
            {
                txtHoTen.Text = "NVh";
            }
        }

        private void txtToan_Leave(object sender, EventArgs e)
        {
            
            try
            {
                double a = double.Parse(txtToan.Text);
                if (a < 0 || a > 10)
                {
                    MessageBox.Show("Bạn nhập số từ 0->10");
                }
            }
            catch
            {
                MessageBox.Show("lỗi bạn nhập lại số");
            }
            finally
            {

            }

        
        }

        private void txtVan_Leave(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtVan.Text);
                if (a < 0 || a > 10)
                {
                    MessageBox.Show("Bạn nhập số từ 0->10");
                }
                
            }
            catch
            {
                MessageBox.Show("lỗi bạn nhập lại số");
            }
            finally
            {

            }
        }

        private void TxtNgoaingu_Leave(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(TxtNgoaingu.Text);
                if(a<0 || a > 10)
                {
                    MessageBox.Show("Bạn nhập số từ 0->10");
                }
            }
            catch
            {
                MessageBox.Show("lỗi bạn nhập lại số");
            }
            finally
            {

            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            double tb = (double.Parse(txtToan.Text)+ double.Parse(txtVan.Text)+ double.Parse(TxtNgoaingu.Text))/3;
            db.update("insert into QuanLyDiem(MaSV,TenSV, DiemToan, DiemVan,DiemNgoaiNgu,DiemTrungBinh) values('"+cbMaSV.Text+"',N'"+txtHoTen.Text+"',"+ double.Parse(txtToan.Text) + ","+ double.Parse(txtVan.Text) + ","+ double.Parse(TxtNgoaingu.Text) + ",'"+tb.ToString()+"')");
            //db.update("insert into QuanLyDiem(MaSV,TenSV, DiemToan, DiemVan,DiemNgoaiNgu,DiemTrungBinh) values('888',N'Nguyễn Văn Biêu',9,9,9,9)");
            DataTable listDiem = db.QLDiemThi("select Ma, MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm Văn',DiemNgoaiNgu as 'Điểm Ngoại Ngữ', DiemTrungBinh as 'Điểm TB' from QuanLyDiem");
            dataGridView1.DataSource= listDiem;
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cbMaSV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtHoTen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtToan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtVan.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            TxtNgoaingu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            double tb = (double.Parse(txtToan.Text) + double.Parse(txtVan.Text) + double.Parse(TxtNgoaingu.Text)) / 3;
            db.update("update QuanLyDiem set MaSV = N'" + cbMaSV.Text + "',DiemToan = '" + txtToan.Text + "',DiemVan = '" + txtVan.Text + "',DiemNgoaiNgu = '" + TxtNgoaingu.Text + "',DiemTrungBinh='"+tb+"' where Ma ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'");
            DataTable listDiem = db.QLDiemThi("select Ma, MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm Văn',DiemNgoaiNgu as 'Điểm Ngoại Ngữ', DiemTrungBinh as 'Điểm TB' from QuanLyDiem");
            dataGridView1.DataSource = listDiem;
            dataGridView1.Columns[0].Visible = false;
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            if (cbThongKe.Text == "giỏi")
            {
                DataTable listDiem = db.QLDiemThi("select Ma, MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm Văn',DiemNgoaiNgu as 'Điểm Ngoại Ngữ', DiemTrungBinh as 'Điểm TB' from QuanLyDiem where DiemTrungBinh>=8");
                dataGridView2.DataSource = listDiem;
                dataGridView2.Columns[0].Visible = false;
            }
            else if (cbThongKe.Text == "khá")
            {
                DataTable listDiem = db.QLDiemThi("select Ma, MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm Văn',DiemNgoaiNgu as 'Điểm Ngoại Ngữ', DiemTrungBinh as 'Điểm TB' from QuanLyDiem where DiemTrungBinh < 8 and DiemTrungBinh >=6.5");
                dataGridView2.DataSource = listDiem;
                dataGridView2.Columns[0].Visible = false;
            }
            else
            {
                DataTable listDiem = db.QLDiemThi("select Ma, MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm Văn',DiemNgoaiNgu as 'Điểm Ngoại Ngữ', DiemTrungBinh as 'Điểm TB' from QuanLyDiem where DiemTrungBinh < 6.5");
                dataGridView2.DataSource = listDiem;
                dataGridView2.Columns[0].Visible = false;
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            double tb = (double.Parse(txtToan.Text) + double.Parse(txtVan.Text) + double.Parse(TxtNgoaingu.Text)) / 3;
            db.update("delete from QuanLyDiem where Ma='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            DataTable listDiem = db.QLDiemThi("select Ma, MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm Văn',DiemNgoaiNgu as 'Điểm Ngoại Ngữ', DiemTrungBinh as 'Điểm TB' from QuanLyDiem");
            dataGridView1.DataSource = listDiem;
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
