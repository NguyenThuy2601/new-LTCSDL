namespace PetShop
{
    partial class DHDoiXacNhan
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
            this.pnTTDonHang = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btHuy = new System.Windows.Forms.Button();
            this.btXacNhan = new System.Windows.Forms.Button();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.lbMaDon = new System.Windows.Forms.Label();
            this.lbDHDoiXacNhan = new System.Windows.Forms.Label();
            this.gbTimMaDH = new System.Windows.Forms.GroupBox();
            this.btTim = new System.Windows.Forms.Button();
            this.txtMaDH = new System.Windows.Forms.TextBox();
            this.lbMaDH = new System.Windows.Forms.Label();
            this.lbListDH = new System.Windows.Forms.Label();
            this.dgvListDH = new System.Windows.Forms.DataGridView();
            this.lbChiTietDH = new System.Windows.Forms.Label();
            this.dgvListCTDH = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.pnTTDonHang.SuspendLayout();
            this.gbTimMaDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCTDH)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTTDonHang
            // 
            this.pnTTDonHang.Controls.Add(this.txtGhiChu);
            this.pnTTDonHang.Controls.Add(this.label1);
            this.pnTTDonHang.Controls.Add(this.panel1);
            this.pnTTDonHang.Controls.Add(this.btHuy);
            this.pnTTDonHang.Controls.Add(this.btXacNhan);
            this.pnTTDonHang.Controls.Add(this.txtMaDon);
            this.pnTTDonHang.Controls.Add(this.lbMaDon);
            this.pnTTDonHang.Controls.Add(this.lbDHDoiXacNhan);
            this.pnTTDonHang.Controls.Add(this.gbTimMaDH);
            this.pnTTDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTTDonHang.Location = new System.Drawing.Point(0, 0);
            this.pnTTDonHang.Margin = new System.Windows.Forms.Padding(4);
            this.pnTTDonHang.Name = "pnTTDonHang";
            this.pnTTDonHang.Size = new System.Drawing.Size(1114, 172);
            this.pnTTDonHang.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1114, 496);
            this.panel1.TabIndex = 1;
            // 
            // btHuy
            // 
            this.btHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btHuy.Location = new System.Drawing.Point(956, 131);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(126, 33);
            this.btHuy.TabIndex = 27;
            this.btHuy.Text = "Huỷ";
            this.btHuy.UseVisualStyleBackColor = true;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // btXacNhan
            // 
            this.btXacNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btXacNhan.Location = new System.Drawing.Point(762, 131);
            this.btXacNhan.Name = "btXacNhan";
            this.btXacNhan.Size = new System.Drawing.Size(126, 33);
            this.btXacNhan.TabIndex = 27;
            this.btXacNhan.Text = "Xác nhận";
            this.btXacNhan.UseVisualStyleBackColor = true;
            this.btXacNhan.Click += new System.EventHandler(this.btXacNhan_Click);
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(730, 18);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(263, 30);
            this.txtMaDon.TabIndex = 26;
            // 
            // lbMaDon
            // 
            this.lbMaDon.AutoSize = true;
            this.lbMaDon.Location = new System.Drawing.Point(606, 26);
            this.lbMaDon.Name = "lbMaDon";
            this.lbMaDon.Size = new System.Drawing.Size(118, 22);
            this.lbMaDon.TabIndex = 25;
            this.lbMaDon.Text = "Mã đơn hàng:";
            // 
            // lbDHDoiXacNhan
            // 
            this.lbDHDoiXacNhan.AutoSize = true;
            this.lbDHDoiXacNhan.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbDHDoiXacNhan.Location = new System.Drawing.Point(12, 9);
            this.lbDHDoiXacNhan.Name = "lbDHDoiXacNhan";
            this.lbDHDoiXacNhan.Size = new System.Drawing.Size(274, 26);
            this.lbDHDoiXacNhan.TabIndex = 24;
            this.lbDHDoiXacNhan.Text = "Đơn Hàng Đợi Xác Nhận:";
            // 
            // gbTimMaDH
            // 
            this.gbTimMaDH.Controls.Add(this.btTim);
            this.gbTimMaDH.Controls.Add(this.txtMaDH);
            this.gbTimMaDH.Controls.Add(this.lbMaDH);
            this.gbTimMaDH.Location = new System.Drawing.Point(8, 45);
            this.gbTimMaDH.Margin = new System.Windows.Forms.Padding(4);
            this.gbTimMaDH.Name = "gbTimMaDH";
            this.gbTimMaDH.Padding = new System.Windows.Forms.Padding(4);
            this.gbTimMaDH.Size = new System.Drawing.Size(556, 82);
            this.gbTimMaDH.TabIndex = 0;
            this.gbTimMaDH.TabStop = false;
            this.gbTimMaDH.Text = "Tìm đơn hàng theo:";
            // 
            // btTim
            // 
            this.btTim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btTim.Location = new System.Drawing.Point(437, 27);
            this.btTim.Name = "btTim";
            this.btTim.Size = new System.Drawing.Size(80, 36);
            this.btTim.TabIndex = 2;
            this.btTim.Text = "Tìm";
            this.btTim.UseVisualStyleBackColor = true;
            this.btTim.Click += new System.EventHandler(this.btTim_Click);
            // 
            // txtMaDH
            // 
            this.txtMaDH.Location = new System.Drawing.Point(150, 29);
            this.txtMaDH.Name = "txtMaDH";
            this.txtMaDH.Size = new System.Drawing.Size(250, 30);
            this.txtMaDH.TabIndex = 1;
            // 
            // lbMaDH
            // 
            this.lbMaDH.AutoSize = true;
            this.lbMaDH.Location = new System.Drawing.Point(26, 32);
            this.lbMaDH.Name = "lbMaDH";
            this.lbMaDH.Size = new System.Drawing.Size(118, 22);
            this.lbMaDH.TabIndex = 0;
            this.lbMaDH.Text = "Mã đơn hàng:";
            // 
            // lbListDH
            // 
            this.lbListDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbListDH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbListDH.ForeColor = System.Drawing.Color.Firebrick;
            this.lbListDH.Location = new System.Drawing.Point(0, 172);
            this.lbListDH.Name = "lbListDH";
            this.lbListDH.Size = new System.Drawing.Size(1114, 39);
            this.lbListDH.TabIndex = 1;
            this.lbListDH.Text = "DANH SÁCH ĐƠN HÀNG";
            this.lbListDH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvListDH
            // 
            this.dgvListDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvListDH.Location = new System.Drawing.Point(0, 211);
            this.dgvListDH.Name = "dgvListDH";
            this.dgvListDH.RowHeadersWidth = 51;
            this.dgvListDH.RowTemplate.Height = 24;
            this.dgvListDH.Size = new System.Drawing.Size(1114, 200);
            this.dgvListDH.TabIndex = 2;
            this.dgvListDH.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListDH_CellMouseClick);
            // 
            // lbChiTietDH
            // 
            this.lbChiTietDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbChiTietDH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbChiTietDH.ForeColor = System.Drawing.Color.Firebrick;
            this.lbChiTietDH.Location = new System.Drawing.Point(0, 411);
            this.lbChiTietDH.Name = "lbChiTietDH";
            this.lbChiTietDH.Size = new System.Drawing.Size(1114, 39);
            this.lbChiTietDH.TabIndex = 3;
            this.lbChiTietDH.Text = "CHI TIẾT ĐƠN HÀNG";
            this.lbChiTietDH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvListCTDH
            // 
            this.dgvListCTDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCTDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvListCTDH.Location = new System.Drawing.Point(0, 450);
            this.dgvListCTDH.Name = "dgvListCTDH";
            this.dgvListCTDH.RowHeadersWidth = 51;
            this.dgvListCTDH.RowTemplate.Height = 24;
            this.dgvListCTDH.Size = new System.Drawing.Size(1114, 220);
            this.dgvListCTDH.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(595, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lý do hủy đơn:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(730, 72);
            this.txtGhiChu.MaxLength = 100;
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(352, 36);
            this.txtGhiChu.TabIndex = 29;
            // 
            // DHDoiXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 667);
            this.Controls.Add(this.dgvListCTDH);
            this.Controls.Add(this.lbChiTietDH);
            this.Controls.Add(this.dgvListDH);
            this.Controls.Add(this.lbListDH);
            this.Controls.Add(this.pnTTDonHang);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DHDoiXacNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DHChuaXacNhan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DHDoiXacNhan_FormClosed);
            this.Load += new System.EventHandler(this.DHDoiXacNhan_Load);
            this.pnTTDonHang.ResumeLayout(false);
            this.pnTTDonHang.PerformLayout();
            this.gbTimMaDH.ResumeLayout(false);
            this.gbTimMaDH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCTDH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnTTDonHang;
        private GroupBox gbTimMaDH;
        private TextBox txtMaDH;
        private Label lbMaDH;
        private Label lbDHDoiXacNhan;
        private TextBox txtMaDon;
        private Label lbMaDon;
        private Button btHuy;
        private Button btXacNhan;
        private Button btTim;
        private Panel panel1;
        private Label lbListDH;
        private DataGridView dgvListDH;
        private Label lbChiTietDH;
        private DataGridView dgvListCTDH;
        private TextBox txtGhiChu;
        private Label label1;
    }
}