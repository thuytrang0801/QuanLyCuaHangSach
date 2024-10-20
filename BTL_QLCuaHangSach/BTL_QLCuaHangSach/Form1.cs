using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_QLCuaHangSach
{
    public partial class Form1 : Form
    {
        private DataProvider dataProvider = new DataProvider();
        private int maLoaiSach_K;
        private int maSach_K;
        private int maLoaiSach_L;
        private int maHoaDon_H;
        private int maPhieuNhap_P;
        public Form1()
        {
            InitializeComponent();
            init();
            dateThongke_Ngay.MaxDate = DateTime.Now;
            dateNgayLapPhieu.MaxDate = DateTime.Now;
            dateNgayLapHoaDon.MaxDate = DateTime.Now;
        }

        private void init()
        {
            initKhoSach();
            initLoaiSach();
            initHoaDon();
            initPhieunhap();
        }
        //xử lý Kho sách
        private void initKhoSach()
        {
            loadDgvKhosach();
            loadcbLoaisach_K();
        }
        public void loadDgvKhosach()
        {
            DataTable dt = new DataTable();
            //StringBuilder query = new StringBuilder("select * from KhoSach");
            StringBuilder query = new StringBuilder("select masach as [Mã sách]");
            query.Append(",tensach as [Tên sách]");
            query.Append(",tacgia as [Tác giả]");
            query.Append(",soluong as [Số lượng]");
            query.Append(",giaban as [Giá bán]");
            query.Append(",tenloaisach as [Tên loại sách]");
            query.Append(" from KhoSach, LoaiSach");
            query.Append(" where KhoSach.maloaisach = LoaiSach.maloaisach;");
            dt = dataProvider.execQuery(query.ToString());
            dgvKhosach.DataSource = dt;
        }
        private void loadcbLoaisach_K()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.execQuery("select * from LoaiSach");
            cbLoaiSach_K.DisplayMember = "tenloaisach";
            cbLoaiSach_K.ValueMember = "maloaisach";
            cbLoaiSach_K.DataSource = dt;
        }

        private void dgvKhosach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < dgvKhosach.RowCount - 1 && i >= 0)
            {
                DataGridViewRow row = dgvKhosach.Rows[i];
                maSach_K = (int)row.Cells[0].Value;
                tbTenSach_K.Text = row.Cells[1].Value.ToString();
                tbTacGia_K.Text = row.Cells[2].Value.ToString();
                numSoLg_K.Value = (int)row.Cells[3].Value;
                numGiaBan_K.Value = Convert.ToInt32(row.Cells[4].Value);
                cbLoaiSach_K.Text = row.Cells[5].Value.ToString();
                //maLoaiSach = (int)DataProvider.execScaler("select maloaisach from KhoSach where tenloaisach = N'" + cbLoaiSach_K.Text+"'");
                maLoaiSach_K = (int)dataProvider.execScaler("select maloaisach from LoaiSach where tenloaisach = N'" + cbLoaiSach_K.Text + "'");
            }
            

        }

        private void btThemKhosach_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec proc_themsach");

            query.Append(" @tenSach = N'" + tbTenSach_K.Text + "'");
            query.Append(",@tacGia = N'" + tbTacGia_K.Text + "'");
            query.Append(",@soLuong = " + numSoLg_K.Value);
            query.Append(",@giaBan = " + numGiaBan_K.Value);
            query.Append(",@maLoaiSach = " + maLoaiSach_K);


            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvKhosach();
                MessageBox.Show("Thêm sách thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSuaKhosach_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec proc_capnhatsach");
            query.Append(" @maSach = " + maSach_K);
            query.Append(",@tenSach = N'" + tbTenSach_K.Text + "'");
            query.Append(",@tacGia = N'" + tbTacGia_K.Text + "'");
            query.Append(",@soLuong = " + numSoLg_K.Value);
            query.Append(",@giaBan = " + numGiaBan_K.Value);
            query.Append(",@maLoaiSach = " + maLoaiSach_K);


            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvKhosach();
                MessageBox.Show("Cập nhật sách thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoaKhosach_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + tbTenSach_K.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "delete from KhoSach where masach = " + maSach_K;
                int result = dataProvider.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadDgvKhosach();
                    MessageBox.Show("Xóa sách thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 

        }

        private void cbLoaiSach_K_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            maLoaiSach_K = (int)comboBox.SelectedValue;
        }

        //xử lý Loại sách
        private void initLoaiSach()
        {
            loadDgvLoaiSach();
        }
        private void loadDgvLoaiSach()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select maloaisach as [Mã loại sách]");
            //query.Append(",maloaisach as [Mã loại sách");
            query.Append(",tenloaisach as [Tên loại sách]");
            query.Append(" from LoaiSach");
            dt = dataProvider.execQuery(query.ToString());
            dgvLoaiSach.DataSource = dt;
        }

        private void dgvLoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < dgvLoaiSach.RowCount - 1 && i >= 0)
            {
                DataGridViewRow row = dgvLoaiSach.Rows[i];
                maLoaiSach_L = (int)row.Cells[0].Value;
                tbTenLoaiSach.Text = row.Cells[1].Value.ToString();
            }

            //maLoaiSach = (int)DataProvider.execScaler("select maloaisach from KhoSach where tenloaisach = N'" + cbLoaiSach_K.Text+"'");
            //maLoaiSach_L = (int)dataProvider.execScaler("select maloaisach from LoaiSach where tenloaisach = N'" + cbLoaiSach_K.Text + "'");
        }

        private void btThemLoaisach_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec proc_themloaisach");

            query.Append(" @tenLoaiSach = N'" + tbTenLoaiSach.Text + "'");

            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvLoaiSach();
                loadcbLoaisach_K();
                MessageBox.Show("Thêm loại sách thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm loại sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSuaLoaisach_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec proc_capnhatloaisach");
            query.Append(" @maLoaiSach = " + maLoaiSach_L );
            query.Append(",@tenLoaiSach = N'" + tbTenLoaiSach.Text + "'");

            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvLoaiSach();
                loadcbLoaisach_K();
                loadDgvKhosach();
                MessageBox.Show("Cập nhật loại sách thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật loại sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoaLoaisach_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sách " + tbTenLoaiSach.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "delete from LoaiSach where maloaisach = " + maLoaiSach_L;
                int result = dataProvider.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadDgvLoaiSach();
                    loadcbLoaisach_K();
                    MessageBox.Show("Xóa loại sách thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa loại sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //xử lý Hóa đơn
        private void initHoaDon()
        {
            loadDgvHoaDon();
        }
        private void loadDgvHoaDon()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select mahoadon as [Mã hóa đơn]");
            //query.Append(",maloaisach as [Mã loại sách");
            query.Append(",tenkhachhang as [Tên khách hàng]");
            query.Append(",sdtkhachhang as [SĐT khách hàng]");
            query.Append(",ngaylaphoadon as [Ngày lập hóa đơn]");
            query.Append(" from HoaDon");
            dt = dataProvider.execQuery(query.ToString());
            dgvHoaDon.DataSource = dt;
            maHoaDon_H = (int)dt.Rows[0][0];
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < dgvHoaDon.RowCount - 1 && i>=0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[i];
                maHoaDon_H = (int)row.Cells[0].Value;
                tbTenKhachhang.Text = row.Cells[1].Value.ToString();
                tbSĐTKhachhang.Text = row.Cells[2].Value.ToString();
                dateNgayLapHoaDon.Value = DateTime.Parse(row.Cells[3].Value.ToString());
            }

        }

        private void btThemHoadon_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec proc_themhoadon");
           
            query.Append(" @tenKhachHang = N'" + tbTenKhachhang.Text + "'");
            query.Append(", @sdtKhachHang = '" + tbSĐTKhachhang.Text + "'");
            query.Append(", @ngayLapHoaDon = '" + dateNgayLapHoaDon.Value + "'");

            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvHoaDon();
                MessageBox.Show("Thêm hóa đơn thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSuaHoadon_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec proc_capnhathoadon");
            query.Append(" @maHoaDon = " + maHoaDon_H );
            query.Append(",@tenKhachHang = N'" + tbTenKhachhang.Text + "'");
            query.Append(",@sdtKhachHang = '" + tbSĐTKhachhang.Text + "'" );
            query.Append(",@ngayLapHoaDon = '" + dateNgayLapHoaDon.Value + "'");

            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvHoaDon();
                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoaHoadon_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn của khách hàng " + tbTenKhachhang.Text + " không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "delete from HoaDon where mahoadon = " + maHoaDon_H;
                int result = dataProvider.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadDgvHoaDon();
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //chỉ nhập số vào textbox SĐT
        private void tbSĐTKhachhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }  
            
            if((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') >-1 ))
            {
                e.Handled = true;
            }    
        }

        //xử lý Phiếu nhập
        private void initPhieunhap()
        {
            loadDgvPhieuNhap();
        }
        private void loadDgvPhieuNhap()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select maphieunhap as [Mã phiếu nhập]");

            query.Append(",tennhacungcap as [Tên nhà cung cấp]");
            query.Append(",ngaylapphieu as [Ngày lập phiếu nhập]");
            query.Append(" from PhieuNhap");

            dt = dataProvider.execQuery(query.ToString());
            dgvPhieuNhap.DataSource = dt;
            maPhieuNhap_P = (int)dt.Rows[0][0];
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < dgvPhieuNhap.RowCount - 1 && i >= 0)
            {
                DataGridViewRow row = dgvPhieuNhap.Rows[i];
                maPhieuNhap_P = (int)row.Cells[0].Value;
                tbTenNCC.Text = row.Cells[1].Value.ToString();
                dateNgayLapPhieu.Value = DateTime.Parse(row.Cells[2].Value.ToString());
            }
            
        }

        private void btThemPhieuNhap_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec proc_themphieunhap");

            query.Append(" @tenNhaCungCap = N'" + tbTenNCC.Text + "'");
            query.Append(", @ngayLapPhieuNhap = '" + dateNgayLapPhieu.Value + "'");

            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvPhieuNhap();
                MessageBox.Show("Thêm phiếu nhập thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSuaPhieuNhap_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec proc_capnhatphieunhap");
            query.Append(" @maPhieuNhap = " + maPhieuNhap_P );
            query.Append(", @tenNhaCungCap = N'" + tbTenNCC.Text + "'");
            query.Append(", @ngayLapPhieuNhap = '" + dateNgayLapPhieu.Value + "'");

            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgvPhieuNhap();
                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btXoaPhieuNhap_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập của nhà cung cấp " + tbTenNCC.Text + " không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "delete from PhieuNhap where maphieunhap = " + maPhieuNhap_P;
                int result = dataProvider.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadDgvPhieuNhap();
                    MessageBox.Show("Xóa phiếu nhập thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btChiTietHD_Click(object sender, EventArgs e)
        {
            FormChiTietHoaDon form = new FormChiTietHoaDon(maHoaDon_H);
            form.ShowDialog();
            
        }

        private void btChiTiet_Click(object sender, EventArgs e)
        {
            FormChiTietPhieuNhap form = new FormChiTietPhieuNhap(maPhieuNhap_P);
            form.ShowDialog();
        }
        public void loadKeyWord()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select masach as [Mã sách]");
            query.Append(",tensach as [Tên sách]");
            query.Append(",tacgia as [Tác giả]");
            query.Append(",soluong as [Số lượng]");
            query.Append(",giaban as [Giá bán]");
            query.Append(",tenloaisach as [Tên loại sách]");
            query.Append(" from KhoSach, LoaiSach");
            query.Append(" where KhoSach.maloaisach = LoaiSach.maloaisach and tensach like N'%"+tbTimKiem.Text+"%';");
            dt = dataProvider.execQuery(query.ToString());
            dgvKhosach.DataSource = dt;
        }
        private void btTim_Click(object sender, EventArgs e)
        {
            loadKeyWord();
        }

        private void btAll_Click(object sender, EventArgs e)
        {
            loadDgvKhosach();
            tbTimKiem.Text = "";
        }

        private void btThongke_L_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select LoaiSach.tenloaisach as N'Tên loại sách'");
            query.Append(",sum(ChiTietHoaDon.thanhtien) as N'Tổng tiền'");
            query.Append("from ChiTietHoaDon, LoaiSach, KhoSach");
            query.Append("  where LoaiSach.maloaisach = KhoSach.maloaisach");
            query.Append("  and KhoSach.masach = ChiTietHoaDon.masach");
            query.Append(" group by LoaiSach.tenloaisach;");
            dt = dataProvider.execQuery(query.ToString());
            dgvThongKe.DataSource = dt;
        }

        private void btThongke_N_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select KhoSach.tensach as N'Tên sách' ");
            query.Append(" ,ChiTietHoaDon.thanhtien as N'Giá'");
            query.Append(" ,sum(ChiTietHoaDon.soluong) as N'Số lượng bán ra'");
            query.Append(" ,sum(ChiTietHoaDon.thanhtien) as N'Tổng tiền'");
            query.Append(" from ChiTietHoaDon, KhoSach");
            query.Append(" where KhoSach.masach=ChiTietHoaDon.masach and mahoadon in ");
            query.Append("(select mahoadon from HoaDon");
            query.Append(" where ngaylaphoadon = '"+ dateThongke_Ngay.Value.ToShortDateString() + "' )");
            query.Append(" group by KhoSach.tensach, ChiTietHoaDon.thanhtien;");

            dt = dataProvider.execQuery(query.ToString());
            dgvThongKe.DataSource = dt;

            if (dgvThongKe.RowCount > 1)
            {
                double Tongtien = (double)dataProvider.execScaler("select sum(thanhtien) from ChiTietHoaDon where mahoadon in (select mahoadon from HoaDon where ngaylaphoadon = '" + dateThongke_Ngay.Value.ToShortDateString() + "' )");
                lbTongtien.Text = "Tổng tiền thu được trong ngày " + dateThongke_Ngay.Value + ": " + Tongtien;
            }
        }

        DateTime dateTime = DateTime.Now;
        private void btThongke_T_Click(object sender, EventArgs e)
        {
            

            if (tbThang_Thang.Text == "" )
            {
                MessageBox.Show("Mời nhập tháng cần thống kê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbThang_Thang.Focus();

            }
            else if(tbNam_Thang.Text =="")
            {
                MessageBox.Show("Mời nhập năm cần thống kê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbNam_Thang.Focus();
            }    
            else if (tbThang_Thang.Text != "")
            {
                int nam = dateTime.Year;
                int Nam_Thang = Convert.ToInt32(tbNam_Thang.Text);
                int thang = dateTime.Month;
                int Thang_Thang = Convert.ToInt32(tbThang_Thang.Text);
                if (Nam_Thang == nam && Thang_Thang > thang)
                {
                    MessageBox.Show("Mời nhập lại.\n Tháng vừa nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbThang_Thang.Focus();
                }
                else if (Nam_Thang > nam)
                {
                    MessageBox.Show("Mời nhập lại.\n Năm vừa nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbNam_Thang.Focus();
                }
                else
                {
                    DataTable dt = new DataTable();
                    StringBuilder query = new StringBuilder("select KhoSach.tensach as N'Tên sách' ");
                    query.Append(" ,ChiTietHoaDon.thanhtien as N'Giá'");
                    query.Append(" ,sum(ChiTietHoaDon.soluong) as N'Số lượng bán ra'");
                    query.Append(" ,sum(ChiTietHoaDon.thanhtien) as N'Tổng tiền'");
                    query.Append(" from ChiTietHoaDon, KhoSach");
                    query.Append(" where KhoSach.masach=ChiTietHoaDon.masach and mahoadon in ");
                    query.Append("(select mahoadon from HoaDon");
                    query.Append(" where  MONTH(ngaylaphoadon)= " + tbThang_Thang.Text + "and year(ngaylaphoadon)= " + tbNam_Thang.Text + ")");
                    query.Append(" group by KhoSach.tensach, ChiTietHoaDon.thanhtien;");

                    dt = dataProvider.execQuery(query.ToString());
                    dgvThongKe.DataSource = dt;

                    if (dgvThongKe.RowCount > 1)
                    {
                        double Tongtien = (double)dataProvider.execScaler("select sum(thanhtien)  from ChiTietHoaDon where mahoadon in (select mahoadon from HoaDon where MONTH(ngaylaphoadon) = " + tbThang_Thang.Text + "and year(ngaylaphoadon)= " + tbNam_Thang.Text + ")");
                        lbTongtien.Text = "Tổng tiền thu được trong tháng " + tbThang_Thang.Text + "/" + tbNam_Thang.Text + ": " + Tongtien;
                    }
                }                        
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    }

