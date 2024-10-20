using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLCuaHangSach
{
    public partial class FormChiTietPhieuNhap : Form
    {
        DataProvider dataProvider = new DataProvider();
        private int maSach;
        private int maPhieuNhap;
        private string TenSach;
        public FormChiTietPhieuNhap(int maPhieuNhap)
        {
            InitializeComponent();
            this.maPhieuNhap = maPhieuNhap;
            init();
        }
        private void init()
        {
            lbTitle.Text = "Chi tiết phiếu nhập " + maPhieuNhap;
            loadDgvCTPhieunhap();
            loadCbSach();
            loadTongTien();
        }
        private void loadDgvCTPhieunhap()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select KhoSach.tensach as [Tên sách]");
            //query.Append(", ");
            query.Append(",ChiTietPhieuNhap.soluong as [Số lượng]");
            query.Append(",ChiTietPhieuNhap.gianhap as [Giá nhập]");
            query.Append(",ChiTietPhieuNhap.gianhap*ChiTietPhieuNhap.soluong as [Thành tiền]");
            query.Append(" from KhoSach, ChiTietPhieuNhap");
            query.Append(" where KhoSach.masach = ChiTietPhieuNhap.masach and ChiTietPhieuNhap.maphieunhap =" + maPhieuNhap);
            dt = dataProvider.execQuery(query.ToString());
            dgvCtPhieuNhap.DataSource = dt;

            if (dgvCtPhieuNhap.RowCount > 1) loadTongTien();
        }
        private void loadCbSach()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.execQuery("select * from KhoSach");
            cbTenSach.DisplayMember = "tensach";
            cbTenSach.ValueMember = "masach";
            cbTenSach.DataSource = dt;
        }
        private void loadTongTien()
        {
            if((int)dataProvider.execScaler("select count(*) from ChiTietPhieuNhap where maphieunhap = "+maPhieuNhap)>0)
            {
                double Tongtien = (double)dataProvider.execScaler("select sum(soluong*gianhap) from ChiTietPhieuNhap where maphieunhap=  " + maPhieuNhap);
                lbTongTien.Text = "Tổng tiền: " + Tongtien;
            }
        }
        private void cbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            maSach = (int)cb.SelectedValue;
            TenSach = cb.Text;
        }

        

        private void btThemPhieu_Click(object sender, EventArgs e)
        {
           // int dem = (int)dataProvider.execScaler("select count(*) from ChiTietPhieuNhap where maphieunhap = " + maPhieuNhap + "and masach" + maTenSach);
            //if (dem == 0)
           // {
                StringBuilder query = new StringBuilder("exec proc_themchitietphieunhap");

                query.Append(" @maPhieuNhap = " + maPhieuNhap);
                query.Append(",@maSach = " + maSach);
                query.Append(",@soLuong = " + numSoLg.Value);
                query.Append(",@giaNhap = " + numGiaNhap.Value);


                int result = dataProvider.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadDgvCTPhieunhap();
                    loadTongTien();
                    MessageBox.Show("Thêm sách vào phiếu thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm sách vào phiếu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            //}
           // else
           // {
             //   dem = (int)dataProvider.execScaler("select sum(soluong) from ChiTietPhieuNhap where maphieunhap = " + maPhieuNhap + "and masach" + maTenSach);
            //    update(dem);
         //   }
        }
        private void btSuaPhieu_Click(object sender, EventArgs e)
        {
            update(0);
        }
        private void update(int soluong)
        {
            StringBuilder query = new StringBuilder("exec proc_capnhatchitietphieunhap");

            query.Append(" @maPhieuNhap = " + maPhieuNhap);
            query.Append(",@maSach = " + maSach);
            query.Append(",@soLuong = " + (numSoLg.Value + soluong));
            query.Append(",@giaNhap = " + numGiaNhap.Value);


            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvCTPhieunhap();
                loadTongTien();
                MessageBox.Show("Sửa phiếu thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Sửa phiếu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void btXoaPhieu_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + TenSach + " khỏi phiếu nhập không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ////string query = "delete from ChiTietPhieuNhap where maphieunhap = " + maPhieuNhap+ "and masach = "+ maSach;
                StringBuilder query = new StringBuilder("proc_xoachitietphieunhap");
                query.Append(" @maPhieuNhap = " + maPhieuNhap);
                query.Append(",@maSach = " + maSach);
                query.Append(",@soLuong = " + numSoLg.Value);
                query.Append(",@giaNhap = " + numGiaNhap.Value);
                int result = dataProvider.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadDgvCTPhieunhap();
                    loadTongTien();
                    MessageBox.Show("Xóa sách khỏi phiếu nhập thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa sách khỏi phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvCtPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < dgvCtPhieuNhap.RowCount - 1 && i >= 0)
            {
                DataGridViewRow row = dgvCtPhieuNhap.Rows[i];

                TenSach = row.Cells[0].Value.ToString();
                cbTenSach.Text = TenSach;
                numSoLg.Value = (int)row.Cells[1].Value;
                numGiaNhap.Value = Convert.ToInt32(row.Cells[2].Value);
                maSach = (int)dataProvider.execScaler("select masach from KhoSach where tensach = N'" + TenSach + "'");
            } 
                
            
        }

        private void FormChiTietPhieuNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
