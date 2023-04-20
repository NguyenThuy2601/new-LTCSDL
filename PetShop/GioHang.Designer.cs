namespace PetShop
{
    partial class GioHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThanhToan = new PetShop.buttonCustom();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new PetShop.buttonCustom();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblShip = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.buttonCustom1 = new PetShop.buttonCustom();
            this.buttonCustom2 = new PetShop.buttonCustom();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 301);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(825, 294);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 301);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 167);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(12, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phí vận chuyển:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tổng tiền:";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.GhostWhite;
            this.btnThanhToan.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.btnThanhToan.BorderColor = System.Drawing.Color.Indigo;
            this.btnThanhToan.BorderRadius = 40;
            this.btnThanhToan.BorderSize = 2;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnThanhToan.ForeColor = System.Drawing.Color.Indigo;
            this.btnThanhToan.Location = new System.Drawing.Point(605, 461);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(188, 40);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.TextColor = System.Drawing.Color.Indigo;
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(12, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên sản phẩm:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblName.Location = new System.Drawing.Point(150, 327);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 25);
            this.lblName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label5.Location = new System.Drawing.Point(440, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số lượng:";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.GhostWhite;
            this.btnDelete.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.btnDelete.BorderColor = System.Drawing.Color.Indigo;
            this.btnDelete.BorderRadius = 40;
            this.btnDelete.BorderSize = 2;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDelete.ForeColor = System.Drawing.Color.Indigo;
            this.btnDelete.Location = new System.Drawing.Point(702, 319);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 40);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextColor = System.Drawing.Color.Indigo;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotal.Location = new System.Drawing.Point(162, 423);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(22, 25);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "0";
            // 
            // lblShip
            // 
            this.lblShip.AutoSize = true;
            this.lblShip.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblShip.Location = new System.Drawing.Point(162, 380);
            this.lblShip.Name = "lblShip";
            this.lblShip.Size = new System.Drawing.Size(22, 25);
            this.lblShip.TabIndex = 11;
            this.lblShip.Text = "0";
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblQty2.Location = new System.Drawing.Point(546, 334);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(22, 25);
            this.lblQty2.TabIndex = 12;
            this.lblQty2.Text = "0";
            // 
            // buttonCustom1
            // 
            this.buttonCustom1.BackColor = System.Drawing.Color.GhostWhite;
            this.buttonCustom1.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.buttonCustom1.BorderColor = System.Drawing.Color.Indigo;
            this.buttonCustom1.BorderRadius = 40;
            this.buttonCustom1.BorderSize = 2;
            this.buttonCustom1.FlatAppearance.BorderSize = 0;
            this.buttonCustom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonCustom1.ForeColor = System.Drawing.Color.Indigo;
            this.buttonCustom1.Location = new System.Drawing.Point(587, 315);
            this.buttonCustom1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCustom1.Name = "buttonCustom1";
            this.buttonCustom1.Size = new System.Drawing.Size(45, 34);
            this.buttonCustom1.TabIndex = 13;
            this.buttonCustom1.Text = "+";
            this.buttonCustom1.TextColor = System.Drawing.Color.Indigo;
            this.buttonCustom1.UseVisualStyleBackColor = false;
            this.buttonCustom1.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // buttonCustom2
            // 
            this.buttonCustom2.BackColor = System.Drawing.Color.GhostWhite;
            this.buttonCustom2.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.buttonCustom2.BorderColor = System.Drawing.Color.Indigo;
            this.buttonCustom2.BorderRadius = 40;
            this.buttonCustom2.BorderSize = 2;
            this.buttonCustom2.FlatAppearance.BorderSize = 0;
            this.buttonCustom2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonCustom2.ForeColor = System.Drawing.Color.Indigo;
            this.buttonCustom2.Location = new System.Drawing.Point(587, 353);
            this.buttonCustom2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCustom2.Name = "buttonCustom2";
            this.buttonCustom2.Size = new System.Drawing.Size(45, 33);
            this.buttonCustom2.TabIndex = 14;
            this.buttonCustom2.Text = "-";
            this.buttonCustom2.TextColor = System.Drawing.Color.Indigo;
            this.buttonCustom2.UseVisualStyleBackColor = false;
            this.buttonCustom2.Click += new System.EventHandler(this.buttonCustom2_Click);
            // 
            // GioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 741);
            this.Controls.Add(this.buttonCustom2);
            this.Controls.Add(this.buttonCustom1);
            this.Controls.Add(this.lblQty2);
            this.Controls.Add(this.lblShip);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GioHang";
            this.Text = "GioHang";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GioHang_FormClosed);
            this.Load += new System.EventHandler(this.GioHang_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label3;
        private buttonCustom btnThanhToan;
        private DataGridView dataGridView1;
        private Label label4;
        private Label lblName;
        private Label label5;
        private buttonCustom btnDelete;
        private Label lblTotal;
        private Label lblShip;
        
        private Label lblQty2;
        private buttonCustom buttonCustom1;
        private buttonCustom buttonCustom2;
    }
}