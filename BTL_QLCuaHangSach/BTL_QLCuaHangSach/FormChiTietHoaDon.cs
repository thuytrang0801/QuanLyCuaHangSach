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
    public partial class FormChiTietHoaDon : Form
    {
        DataProvider dataProvider = new DataProvider();
        private int maHoaDon;
        private int maSach;
        private string tenSach;
        public FormChiTietHoaDon(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
            init();
            
        }

        private void init()
        {
            lbTitle.Text = "Chi tiết hóa đơn " + maHoaDon;
            loadDgvCTHoaDon();
            loadCbSach();
            loadTongTien();
        }

        private void cbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            maSach = (int)cb.SelectedValue;
            tenSach = cb.Text;
            string ten_sach = (string)dataProvider.execScaler("select tensach from KhoSach where masach = " + maSach);
            if (ten_sach == tenSach)
            {
                double gia = (double)dataProvider.execScaler("select giaban from KhoSach where masach = " + maSach);
                tbGiaBan.Text = Convert.ToString(gia);
            }

        }
        private void loadDgvCTHoaDon()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select KhoSach.tensach as [Tên sách]");
            //query.Append(", ");
            query.Append(",ChiTietHoaDon.soluong as [Số lượng]");
            query.Append(",KhoSach.giaban as [Giá bán]");
            query.Append(",ChiTietHoaDon.thanhtien as [Thành tiền]");
            query.Append(" from KhoSach, ChiTietHoaDon");
            query.Append(" where KhoSach.masach = ChiTietHoaDon.masach and ChiTietHoaDon.mahoadon =" + maHoaDon);
            dt = dataProvider.execQuery(query.ToString());
            dgvCtHoaDon.DataSource = dt;

            //if (dgvCtHoaDon.RowCount > 1) loadTongTien();
        }

        private void loadCbSach()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.execQuery("select * from KhoSach");
            cbTenSach.DisplayMember = "tensach";
            cbTenSach.ValueMember = "masach";
            cbTenSach.DataSource = dt;
        }

        private void dgvCtHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < dgvCtHoaDon.RowCount - 1 && i >= 0)
            {
                DataGridViewRow row = dgvCtHoaDon.Rows[i];

                tenSach = row.Cells[0].Value.ToString();
                cbTenSach.Text = tenSach;
                numSoLg.Value = (int)row.Cells[1].Value;
                tbGiaBan.Text = row.Cells[2].Value.ToString();
                //numGiaBan.Value = Convert.ToInt32(row.Cells[2].Value);
                maSach = (int)dataProvider.execScaler("select masach from KhoSach where tensach = N'" + tenSach + "'");
            }
        }

        private void loadTongTien()
        {
            if ((int)dataProvider.execScaler("select count(*) from ChiTietHoaDon where mahoadon = " + maHoaDon) > 0)
            {
                //double Tongtien = (double)dataProvider.execScaler("select sum(soluong*giaban) from ChiTietHoaDon where mahoadon =  " + maHoaDon);
                double Tongtien = (double)dataProvider.execScaler("select tongtien from hoadon where mahoadon = "+ maHoaDon);
                lbTongTien.Text = "Tổng tiền: " + Tongtien;
            }
        }

        private void btThemHoaDon_Click(object sender, EventArgs e)
        {
            
            //query.Append(",@giaBan = " + numGiaBan.Value);
            //int solg = (int)dataProvider.execScaler("select soluong from KhoSach where masach = " + maSach);
           /* if(solg==0)
            {
                MessageBox.Show("Sách đã hết. \n Mời chọn sách khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else*/
            {
                StringBuilder query = new StringBuilder("exec proc_themchitiethoadon");

                query.Append(" @maHoaDon = " + maHoaDon);
                query.Append(",@maSach = " + maSach);
                query.Append(",@soLuong = " + numSoLg.Value);
                query.Append(",@giaBan = " + tbGiaBan.Text);
                int result = dataProvider.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadDgvCTHoaDon();
                    loadTongTien();

                    MessageBox.Show("Thêm sách vào hóa đơn thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm sách vào hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btSuaHoaDon_Click(object sender, EventArgs e)
        {
            update(0);
            
        }

        private void update(int soluong)
        {
            int solg = (int)dataProvider.execScaler("select soluong from KhoSach where masach = " + maSach);
           // if (solg == 0)
            {
                //MessageBox.Show("Số lượng sách không đủ. \n Mời chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //else 
            {
                StringBuilder up = new StringBuilder("exec proc_loadslgsach");
                up.Append(",@maSach = " + maSach);
                up.Append(",@soLuong = " + (numSoLg.Value + soluong));

                StringBuilder query = new StringBuilder("exec proc_capnhatchitiethoadon");

                query.Append(" @maHoaDon = " + maHoaDon);
                query.Append(",@maSach = " + maSach);
                query.Append(",@soLuong = " + (numSoLg.Value + soluong));
                //query.Append(",@giaBan = " + tbGiaBan.Text);
                //query.Append(",@giaBan = " + numGiaBan.Value);
                //MessageBox.Show(dem.ToString(), "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                int result = dataProvider.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadDgvCTHoaDon();
                    loadTongTien();
                    MessageBox.Show("Sửa hóa đơn thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Sửa hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        private void btXoaHoaDon_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + tenSach + " khỏi hóa đơn không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                StringBuilder up = new StringBuilder("proc_xoachitiethoadon");
                up.Append(" @maHoaDon = " + maHoaDon);
                up.Append(",@maSach = " + maSach);
                up.Append(",@soLuong = " + numSoLg.Value);
                up.Append(",@giaBan = " + tbGiaBan.Text);
                int result = dataProvider.execNonQuery(up.ToString());
                if (result > 0)
                {
                    loadDgvCTHoaDon();
                    loadTongTien();
                    MessageBox.Show("Xóa sách khỏi hóa đơn thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {
                    MessageBox.Show("Xóa sách khỏi hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
