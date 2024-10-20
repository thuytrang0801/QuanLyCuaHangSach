namespace BTL_QLCuaHangSach
{
    partial class FormChiTietHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChiTietHoaDon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbGiaBan = new System.Windows.Forms.TextBox();
            this.cbTenSach = new System.Windows.Forms.ComboBox();
            this.numSoLg = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.btXoaHoaDon = new System.Windows.Forms.Button();
            this.btSuaHoaDon = new System.Windows.Forms.Button();
            this.btThemHoaDon = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCtHoaDon = new System.Windows.Forms.DataGridView();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.tbGiaBan);
            this.panel1.Controls.Add(this.cbTenSach);
            this.panel1.Controls.Add(this.numSoLg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.btXoaHoaDon);
            this.panel1.Controls.Add(this.btSuaHoaDon);
            this.panel1.Controls.Add(this.btThemHoaDon);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 215);
            this.panel1.TabIndex = 3;
            // 
            // tbGiaBan
            // 
            this.tbGiaBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGiaBan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbGiaBan.Location = new System.Drawing.Point(459, 86);
            this.tbGiaBan.Multiline = true;
            this.tbGiaBan.Name = "tbGiaBan";
            this.tbGiaBan.ReadOnly = true;
            this.tbGiaBan.Size = new System.Drawing.Size(140, 27);
            this.tbGiaBan.TabIndex = 3;
            this.tbGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbTenSach
            // 
            this.cbTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTenSach.FormattingEnabled = true;
            this.cbTenSach.Location = new System.Drawing.Point(132, 36);
            this.cbTenSach.Name = "cbTenSach";
            this.cbTenSach.Size = new System.Drawing.Size(468, 24);
            this.cbTenSach.TabIndex = 1;
            this.cbTenSach.SelectedIndexChanged += new System.EventHandler(this.cbTenSach_SelectedIndexChanged);
            // 
            // numSoLg
            // 
            this.numSoLg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSoLg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoLg.Location = new System.Drawing.Point(132, 86);
            this.numSoLg.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSoLg.Name = "numSoLg";
            this.numSoLg.Size = new System.Drawing.Size(162, 27);
            this.numSoLg.TabIndex = 2;
            this.numSoLg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Số lượng";
            // 
            // lbTongTien
            // 
            this.lbTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.BackColor = System.Drawing.Color.Cyan;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.Location = new System.Drawing.Point(657, 87);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(137, 26);
            this.lbTongTien.TabIndex = 19;
            this.lbTongTien.Text = "Tổng tiền: 0";
            
            // 
            // btXoaHoaDon
            // 
            this.btXoaHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btXoaHoaDon.BackColor = System.Drawing.Color.Red;
            this.btXoaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoaHoaDon.Location = new System.Drawing.Point(485, 131);
            this.btXoaHoaDon.Name = "btXoaHoaDon";
            this.btXoaHoaDon.Size = new System.Drawing.Size(115, 39);
            this.btXoaHoaDon.TabIndex = 18;
            this.btXoaHoaDon.Text = "Xóa";
            this.btXoaHoaDon.UseVisualStyleBackColor = false;
            this.btXoaHoaDon.Click += new System.EventHandler(this.btXoaHoaDon_Click);
            // 
            // btSuaHoaDon
            // 
            this.btSuaHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btSuaHoaDon.BackColor = System.Drawing.Color.Yellow;
            this.btSuaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSuaHoaDon.Location = new System.Drawing.Point(306, 131);
            this.btSuaHoaDon.Name = "btSuaHoaDon";
            this.btSuaHoaDon.Size = new System.Drawing.Size(117, 39);
            this.btSuaHoaDon.TabIndex = 17;
            this.btSuaHoaDon.Text = "Sửa";
            this.btSuaHoaDon.UseVisualStyleBackColor = false;
            this.btSuaHoaDon.Click += new System.EventHandler(this.btSuaHoaDon_Click);
            // 
            // btThemHoaDon
            // 
            this.btThemHoaDon.BackColor = System.Drawing.Color.Lime;
            this.btThemHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThemHoaDon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btThemHoaDon.Location = new System.Drawing.Point(132, 130);
            this.btThemHoaDon.Name = "btThemHoaDon";
            this.btThemHoaDon.Size = new System.Drawing.Size(111, 40);
            this.btThemHoaDon.TabIndex = 16;
            this.btThemHoaDon.Text = "Thêm";
            this.btThemHoaDon.UseVisualStyleBackColor = false;
            this.btThemHoaDon.Click += new System.EventHandler(this.btThemHoaDon_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(348, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Giá bán";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên sách";
            // 
            // dgvCtHoaDon
            // 
            this.dgvCtHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCtHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCtHoaDon.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvCtHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtHoaDon.Location = new System.Drawing.Point(12, 56);
            this.dgvCtHoaDon.Name = "dgvCtHoaDon";
            this.dgvCtHoaDon.ReadOnly = true;
            this.dgvCtHoaDon.RowHeadersWidth = 51;
            this.dgvCtHoaDon.RowTemplate.Height = 24;
            this.dgvCtHoaDon.Size = new System.Drawing.Size(902, 323);
            this.dgvCtHoaDon.TabIndex = 4;
            this.dgvCtHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCtHoaDon_CellClick);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(350, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(229, 32);
            this.lbTitle.TabIndex = 21;
            this.lbTitle.Text = "Chi tiết hóa đơn";
            // 
            // FormChiTietHoaDon
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(926, 588);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dgvCtHoaDon);
            this.Controls.Add(this.panel1);
            this.Name = "FormChiTietHoaDon";
            this.Text = "Chi tiết hóa đơn";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCtHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btThemHoaDon;
        private System.Windows.Forms.Button btSuaHoaDon;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Button btXoaHoaDon;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSoLg;
        private System.Windows.Forms.ComboBox cbTenSach;
        private System.Windows.Forms.TextBox tbGiaBan;
    }
}