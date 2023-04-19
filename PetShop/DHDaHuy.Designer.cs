namespace PetShop
{
    partial class frmDHDaHuy
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
            this.gbTimMaDH = new System.Windows.Forms.GroupBox();
            this.btTim = new System.Windows.Forms.Button();
            this.txtMaDH = new System.Windows.Forms.TextBox();
            this.lbMaDH = new System.Windows.Forms.Label();
            this.lbDHDoiXacNhan = new System.Windows.Forms.Label();
            this.pnTTDonHang = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvListCTDH = new System.Windows.Forms.DataGridView();
            this.lbChiTietDH = new System.Windows.Forms.Label();
            this.dgvListDH = new System.Windows.Forms.DataGridView();
            this.lbListDH = new System.Windows.Forms.Label();
            this.gbTimMaDH.SuspendLayout();
            this.pnTTDonHang.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCTDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDH)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTimMaDH
            // 
            this.gbTimMaDH.Controls.Add(this.btTim);
            this.gbTimMaDH.Controls.Add(this.txtMaDH);
            this.gbTimMaDH.Controls.Add(this.lbMaDH);
            this.gbTimMaDH.Location = new System.Drawing.Point(47, 45);
            this.gbTimMaDH.Margin = new System.Windows.Forms.Padding(4);
            this.gbTimMaDH.Name = "gbTimMaDH";
            this.gbTimMaDH.Padding = new System.Windows.Forms.Padding(4);
            this.gbTimMaDH.Size = new System.Drawing.Size(517, 67);
            this.gbTimMaDH.TabIndex = 0;
            this.gbTimMaDH.TabStop = false;
            this.gbTimMaDH.Text = "Tìm đơn hàng theo:";
            // 
            // btTim
            // 
            this.btTim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btTim.Location = new System.Drawing.Point(398, 29);
            this.btTim.Name = "btTim";
            this.btTim.Size = new System.Drawing.Size(80, 26);
            this.btTim.TabIndex = 2;
            this.btTim.Text = "Tìm";
            this.btTim.UseVisualStyleBackColor = true;
            this.btTim.Click += new System.EventHandler(this.btTim_Click);
            // 
            // txtMaDH
            // 
            this.txtMaDH.Location = new System.Drawing.Point(124, 29);
            this.txtMaDH.Name = "txtMaDH";
            this.txtMaDH.Size = new System.Drawing.Size(250, 22);
            this.txtMaDH.TabIndex = 1;
            // 
            // lbMaDH
            // 
            this.lbMaDH.AutoSize = true;
            this.lbMaDH.Location = new System.Drawing.Point(26, 32);
            this.lbMaDH.Name = "lbMaDH";
            this.lbMaDH.Size = new System.Drawing.Size(88, 16);
            this.lbMaDH.TabIndex = 0;
            this.lbMaDH.Text = "Mã đơn hàng:";
            // 
            // lbDHDoiXacNhan
            // 
            this.lbDHDoiXacNhan.AutoSize = true;
            this.lbDHDoiXacNhan.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbDHDoiXacNhan.Location = new System.Drawing.Point(12, 9);
            this.lbDHDoiXacNhan.Name = "lbDHDoiXacNhan";
            this.lbDHDoiXacNhan.Size = new System.Drawing.Size(210, 26);
            this.lbDHDoiXacNhan.TabIndex = 24;
            this.lbDHDoiXacNhan.Text = "Đơn Hàng Đã Hủy:";
            // 
            // pnTTDonHang
            // 
            this.pnTTDonHang.Controls.Add(this.lbDHDoiXacNhan);
            this.pnTTDonHang.Controls.Add(this.gbTimMaDH);
            this.pnTTDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTTDonHang.Location = new System.Drawing.Point(0, 0);
            this.pnTTDonHang.Margin = new System.Windows.Forms.Padding(4);
            this.pnTTDonHang.Name = "pnTTDonHang";
            this.pnTTDonHang.Size = new System.Drawing.Size(1182, 172);
            this.pnTTDonHang.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvListCTDH);
            this.panel1.Controls.Add(this.lbChiTietDH);
            this.panel1.Controls.Add(this.dgvListDH);
            this.panel1.Controls.Add(this.lbListDH);
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 510);
            this.panel1.TabIndex = 4;
            // 
            // dgvListCTDH
            // 
            this.dgvListCTDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCTDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvListCTDH.Location = new System.Drawing.Point(0, 278);
            this.dgvListCTDH.Name = "dgvListCTDH";
            this.dgvListCTDH.ReadOnly = true;
            this.dgvListCTDH.RowHeadersWidth = 51;
            this.dgvListCTDH.RowTemplate.Height = 24;
            this.dgvListCTDH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListCTDH.Size = new System.Drawing.Size(1182, 220);
            this.dgvListCTDH.TabIndex = 5;
            // 
            // lbChiTietDH
            // 
            this.lbChiTietDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbChiTietDH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbChiTietDH.ForeColor = System.Drawing.Color.Firebrick;
            this.lbChiTietDH.Location = new System.Drawing.Point(0, 239);
            this.lbChiTietDH.Name = "lbChiTietDH";
            this.lbChiTietDH.Size = new System.Drawing.Size(1182, 39);
            this.lbChiTietDH.TabIndex = 4;
            this.lbChiTietDH.Text = "CHI TIẾT ĐƠN HÀNG";
            this.lbChiTietDH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvListDH
            // 
            this.dgvListDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvListDH.Location = new System.Drawing.Point(0, 39);
            this.dgvListDH.Name = "dgvListDH";
            this.dgvListDH.RowHeadersWidth = 51;
            this.dgvListDH.RowTemplate.Height = 24;
            this.dgvListDH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListDH.Size = new System.Drawing.Size(1182, 200);
            this.dgvListDH.TabIndex = 3;
            this.dgvListDH.Click += new System.EventHandler(this.dgvListDH_Click);
            // 
            // lbListDH
            // 
            this.lbListDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbListDH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbListDH.ForeColor = System.Drawing.Color.Firebrick;
            this.lbListDH.Location = new System.Drawing.Point(0, 0);
            this.lbListDH.Name = "lbListDH";
            this.lbListDH.Size = new System.Drawing.Size(1182, 39);
            this.lbListDH.TabIndex = 2;
            this.lbListDH.Text = "DANH SÁCH ĐƠN HÀNG";
            this.lbListDH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDHDaHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnTTDonHang);
            this.Name = "frmDHDaHuy";
            this.Text = "ĐƠN HÀNG ĐÃ HỦY";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDHDaHuy_FormClosed);
            this.Load += new System.EventHandler(this.frmDHDaHuy_Load);
            this.gbTimMaDH.ResumeLayout(false);
            this.gbTimMaDH.PerformLayout();
            this.pnTTDonHang.ResumeLayout(false);
            this.pnTTDonHang.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCTDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox gbTimMaDH;
        private Button btTim;
        private TextBox txtMaDH;
        private Label lbMaDH;
        private Label lbDHDoiXacNhan;
        private Panel pnTTDonHang;
        private Panel panel1;
        private Label lbListDH;
        private DataGridView dgvListDH;
        private Label lbChiTietDH;
        private DataGridView dgvListCTDH;
    }
}