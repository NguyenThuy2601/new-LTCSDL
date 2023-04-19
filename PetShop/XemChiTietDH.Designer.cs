namespace PetShop
{
    partial class XemChiTietDH
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
            this.lbKH = new System.Windows.Forms.Label();
            this.pnNhapTTNhanVien = new System.Windows.Forms.Panel();
            this.dgvDH = new System.Windows.Forms.DataGridView();
            this.lbltemp = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblShip = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.pnNhapTTNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDH)).BeginInit();
            this.lbltemp.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // lbKH
            // 
            this.lbKH.AutoSize = true;
            this.lbKH.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbKH.ForeColor = System.Drawing.Color.Indigo;
            this.lbKH.Location = new System.Drawing.Point(12, 9);
            this.lbKH.Name = "lbKH";
            this.lbKH.Size = new System.Drawing.Size(227, 26);
            this.lbKH.TabIndex = 23;
            this.lbKH.Text = "Danh sách đơn hàng:";
            // 
            // pnNhapTTNhanVien
            // 
            this.pnNhapTTNhanVien.BackColor = System.Drawing.SystemColors.Control;
            this.pnNhapTTNhanVien.Controls.Add(this.dgvDH);
            this.pnNhapTTNhanVien.Controls.Add(this.lbKH);
            this.pnNhapTTNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnNhapTTNhanVien.Location = new System.Drawing.Point(0, 0);
            this.pnNhapTTNhanVien.Name = "pnNhapTTNhanVien";
            this.pnNhapTTNhanVien.Size = new System.Drawing.Size(1074, 274);
            this.pnNhapTTNhanVien.TabIndex = 9;
            // 
            // dgvDH
            // 
            this.dgvDH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDH.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDH.Location = new System.Drawing.Point(8, 53);
            this.dgvDH.Name = "dgvDH";
            this.dgvDH.RowHeadersWidth = 51;
            this.dgvDH.RowTemplate.Height = 24;
            this.dgvDH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDH.Size = new System.Drawing.Size(1043, 215);
            this.dgvDH.TabIndex = 24;
            this.dgvDH.Click += new System.EventHandler(this.dgvDH_Click);
            // 
            // lbltemp
            // 
            this.lbltemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltemp.BackColor = System.Drawing.SystemColors.Control;
            this.lbltemp.Controls.Add(this.lblStatus);
            this.lbltemp.Controls.Add(this.label2);
            this.lbltemp.Controls.Add(this.lblAddress);
            this.lbltemp.Controls.Add(this.lblTotal);
            this.lbltemp.Controls.Add(this.label7);
            this.lbltemp.Controls.Add(this.lblShip);
            this.lbltemp.Controls.Add(this.label5);
            this.lbltemp.Controls.Add(this.lblThanhTien);
            this.lbltemp.Controls.Add(this.label1);
            this.lbltemp.Controls.Add(this.label4);
            this.lbltemp.Controls.Add(this.label3);
            this.lbltemp.ForeColor = System.Drawing.Color.MediumPurple;
            this.lbltemp.Location = new System.Drawing.Point(0, 274);
            this.lbltemp.Name = "lbltemp";
            this.lbltemp.Size = new System.Drawing.Size(1051, 189);
            this.lbltemp.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Indigo;
            this.lblStatus.Location = new System.Drawing.Point(814, 36);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(135, 25);
            this.lblStatus.TabIndex = 76;
            this.lblStatus.Text = "Thành tiền: ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(736, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 65);
            this.label2.TabIndex = 75;
            this.label2.Text = "Tình trạng:";
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Indigo;
            this.lblAddress.Location = new System.Drawing.Point(143, 28);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(505, 30);
            this.lblAddress.TabIndex = 74;
            this.lblAddress.Text = "Thành tiền: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Indigo;
            this.lblTotal.Location = new System.Drawing.Point(814, 101);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(135, 25);
            this.lblTotal.TabIndex = 73;
            this.lblTotal.Text = "Thành tiền: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Indigo;
            this.label7.Location = new System.Drawing.Point(736, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 25);
            this.label7.TabIndex = 72;
            this.label7.Text = "Tổng:";
            // 
            // lblShip
            // 
            this.lblShip.AutoSize = true;
            this.lblShip.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShip.ForeColor = System.Drawing.Color.Indigo;
            this.lblShip.Location = new System.Drawing.Point(514, 101);
            this.lblShip.Name = "lblShip";
            this.lblShip.Size = new System.Drawing.Size(135, 25);
            this.lblShip.TabIndex = 71;
            this.lblShip.Text = "Thành tiền: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(396, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 70;
            this.label5.Text = "Phí ship:";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.ForeColor = System.Drawing.Color.Indigo;
            this.lblThanhTien.Location = new System.Drawing.Point(144, 101);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(135, 25);
            this.lblThanhTien.TabIndex = 69;
            this.lblThanhTien.Text = "Thành tiền: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(3, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 68;
            this.label1.Text = "Thành tiền: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(3, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 26);
            this.label4.TabIndex = 67;
            this.label4.Text = "Chi tiết đơn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 66;
            this.label3.Text = "Địa chỉ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDetail);
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1073, 291);
            this.panel2.TabIndex = 11;
            // 
            // dgvDetail
            // 
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(8, -4);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 24;
            this.dgvDetail.Size = new System.Drawing.Size(1042, 281);
            this.dgvDetail.TabIndex = 1;
            // 
            // XemChiTietDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 758);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbltemp);
            this.Controls.Add(this.pnNhapTTNhanVien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XemChiTietDH";
            this.Text = "XemChiTietDH";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XemChiTietDH_FormClosed);
            this.Load += new System.EventHandler(this.XemChiTietDH_Load);
            this.pnNhapTTNhanVien.ResumeLayout(false);
            this.pnNhapTTNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDH)).EndInit();
            this.lbltemp.ResumeLayout(false);
            this.lbltemp.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label lbKH;
        private Panel pnNhapTTNhanVien;
        private DataGridView dgvDH;
        private Panel lbltemp;
        private Label label4;
        private Label label3;
        private Label lblTotal;
        private Label label7;
        private Label lblShip;
        private Label label5;
        private Label lblThanhTien;
        private Label label1;
        private Label lblAddress;
        private Panel panel2;
        private DataGridView dgvDetail;
        private Label lblStatus;
        private Label label2;
    }
}