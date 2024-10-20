namespace BTL_QLCuaHangSach
{
    partial class FormChiTietPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChiTietPhieuNhap));
            this.dgvCtPhieuNhap = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTenSach = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numSoLg = new System.Windows.Forms.NumericUpDown();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.btXoaPhieu = new System.Windows.Forms.Button();
            this.btSuaPhieu = new System.Windows.Forms.Button();
            this.btThemPhieu = new System.Windows.Forms.Button();
            this.numGiaNhap = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtPhieuNhap)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCtPhieuNhap
            // 
            this.dgvCtPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCtPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCtPhieuNhap.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCtPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtPhieuNhap.Location = new System.Drawing.Point(12, 55);
            this.dgvCtPhieuNhap.Name = "dgvCtPhieuNhap";
            this.dgvCtPhieuNhap.ReadOnly = true;
            this.dgvCtPhieuNhap.RowHeadersWidth = 51;
            this.dgvCtPhieuNhap.RowTemplate.Height = 24;
            this.dgvCtPhieuNhap.Size = new System.Drawing.Size(867, 290);
            this.dgvCtPhieuNhap.TabIndex = 6;
            this.dgvCtPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCtPhieuNhap_CellClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cbTenSach);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numSoLg);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.btXoaPhieu);
            this.panel1.Controls.Add(this.btSuaPhieu);
            this.panel1.Controls.Add(this.btThemPhieu);
            this.panel1.Controls.Add(this.numGiaNhap);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 184);
            this.panel1.TabIndex = 5;
            // 
            // cbTenSach
            // 
            this.cbTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTenSach.FormattingEnabled = true;
            this.cbTenSach.Location = new System.Drawing.Point(128, 25);
            this.cbTenSach.Name = "cbTenSach";
            this.cbTenSach.Size = new System.Drawing.Size(434, 24);
            this.cbTenSach.TabIndex = 1;
            this.cbTenSach.SelectedIndexChanged += new System.EventHandler(this.cbTenSach_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Số lượng";
            // 
            // numSoLg
            // 
            this.numSoLg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSoLg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoLg.Location = new System.Drawing.Point(128, 73);
            this.numSoLg.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSoLg.Name = "numSoLg";
            this.numSoLg.Size = new System.Drawing.Size(121, 27);
            this.numSoLg.TabIndex = 2;
            this.numSoLg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTongTien
            // 
            this.lbTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.BackColor = System.Drawing.Color.Cyan;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.Location = new System.Drawing.Point(602, 73);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(124, 22);
            this.lbTongTien.TabIndex = 19;
            this.lbTongTien.Text = "Tổng tiền:  0";
            // 
            // btXoaPhieu
            // 
            this.btXoaPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btXoaPhieu.BackColor = System.Drawing.Color.Red;
            this.btXoaPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoaPhieu.Location = new System.Drawing.Point(473, 133);
            this.btXoaPhieu.Name = "btXoaPhieu";
            this.btXoaPhieu.Size = new System.Drawing.Size(89, 34);
            this.btXoaPhieu.TabIndex = 18;
            this.btXoaPhieu.Text = "Xóa";
            this.btXoaPhieu.UseVisualStyleBackColor = false;
            this.btXoaPhieu.Click += new System.EventHandler(this.btXoaPhieu_Click);
            // 
            // btSuaPhieu
            // 
            this.btSuaPhieu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btSuaPhieu.BackColor = System.Drawing.Color.Yellow;
            this.btSuaPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSuaPhieu.Location = new System.Drawing.Point(306, 135);
            this.btSuaPhieu.Name = "btSuaPhieu";
            this.btSuaPhieu.Size = new System.Drawing.Size(86, 32);
            this.btSuaPhieu.TabIndex = 17;
            this.btSuaPhieu.Text = "Sửa";
            this.btSuaPhieu.UseVisualStyleBackColor = false;
            this.btSuaPhieu.Click += new System.EventHandler(this.btSuaPhieu_Click);
            // 
            // btThemPhieu
            // 
            this.btThemPhieu.BackColor = System.Drawing.Color.Lime;
            this.btThemPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThemPhieu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btThemPhieu.Location = new System.Drawing.Point(125, 133);
            this.btThemPhieu.Name = "btThemPhieu";
            this.btThemPhieu.Size = new System.Drawing.Size(89, 34);
            this.btThemPhieu.TabIndex = 16;
            this.btThemPhieu.Text = "Thêm";
            this.btThemPhieu.UseVisualStyleBackColor = false;
            this.btThemPhieu.Click += new System.EventHandler(this.btThemPhieu_Click);
            // 
            // numGiaNhap
            // 
            this.numGiaNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGiaNhap.Location = new System.Drawing.Point(393, 68);
            this.numGiaNhap.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numGiaNhap.Name = "numGiaNhap";
            this.numGiaNhap.Size = new System.Drawing.Size(169, 27);
            this.numGiaNhap.TabIndex = 3;
            this.numGiaNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(291, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Giá nhập";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên sách";
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(301, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(279, 32);
            this.lbTitle.TabIndex = 20;
            this.lbTitle.Text = "Chi tiết phiếu nhập ";
            // 
            // FormChiTietPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 548);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dgvCtPhieuNhap);
            this.Controls.Add(this.panel1);
            this.Name = "FormChiTietPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết phiếu nhập";
            this.Load += new System.EventHandler(this.FormChiTietPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtPhieuNhap)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCtPhieuNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Button btXoaPhieu;
        private System.Windows.Forms.Button btSuaPhieu;
        private System.Windows.Forms.Button btThemPhieu;
        private System.Windows.Forms.NumericUpDown numGiaNhap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.NumericUpDown numSoLg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTenSach;
    }
}