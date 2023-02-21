namespace PetShop
{
    partial class SanPham
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
            this.picSP = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTenSp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbGiaTien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbGiaGiam = new System.Windows.Forms.Label();
            this.lbTonKho = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSP)).BeginInit();
            this.SuspendLayout();
            // 
            // picSP
            // 
            this.picSP.Location = new System.Drawing.Point(12, 12);
            this.picSP.Name = "picSP";
            this.picSP.Size = new System.Drawing.Size(284, 171);
            this.picSP.TabIndex = 0;
            this.picSP.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // lbTenSp
            // 
            this.lbTenSp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbTenSp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTenSp.Location = new System.Drawing.Point(121, 194);
            this.lbTenSp.Name = "lbTenSp";
            this.lbTenSp.Size = new System.Drawing.Size(175, 32);
            this.lbTenSp.TabIndex = 2;
            this.lbTenSp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giá tiền:";
            // 
            // lbGiaTien
            // 
            this.lbGiaTien.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbGiaTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGiaTien.Location = new System.Drawing.Point(121, 238);
            this.lbGiaTien.Name = "lbGiaTien";
            this.lbGiaTien.Size = new System.Drawing.Size(175, 32);
            this.lbGiaTien.TabIndex = 4;
            this.lbGiaTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Giảm giá:";
            // 
            // lbGiaGiam
            // 
            this.lbGiaGiam.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbGiaGiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGiaGiam.Location = new System.Drawing.Point(121, 282);
            this.lbGiaGiam.Name = "lbGiaGiam";
            this.lbGiaGiam.Size = new System.Drawing.Size(175, 32);
            this.lbGiaGiam.TabIndex = 6;
            this.lbGiaGiam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTonKho
            // 
            this.lbTonKho.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbTonKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTonKho.Location = new System.Drawing.Point(12, 326);
            this.lbTonKho.Name = "lbTonKho";
            this.lbTonKho.Size = new System.Drawing.Size(72, 32);
            this.lbTonKho.TabIndex = 7;
            this.lbTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thêm vào giỏ hàng";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(308, 367);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbTonKho);
            this.Controls.Add(this.lbGiaGiam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbGiaTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTenSp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picSP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SanPham";
            this.Text = "SanPham";
            ((System.ComponentModel.ISupportInitialize)(this.picSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picSP;
        private Label label1;
        private Label lbTenSp;
        private Label label3;
        private Label lbGiaTien;
        private Label label5;
        private Label lbGiaGiam;
        private Label lbTonKho;
        private Button button1;
    }
}