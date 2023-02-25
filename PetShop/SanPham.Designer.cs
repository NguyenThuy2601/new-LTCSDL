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
            this.lbTenSp = new System.Windows.Forms.Label();
            this.lbGiaTien = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lbTonKho = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // picSP
            // 
            this.picSP.Location = new System.Drawing.Point(72, 11);
            this.picSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picSP.Name = "picSP";
            this.picSP.Size = new System.Drawing.Size(270, 137);
            this.picSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSP.TabIndex = 0;
            this.picSP.TabStop = false;
            // 
            // lbTenSp
            // 
            this.lbTenSp.AutoSize = true;
            this.lbTenSp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbTenSp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTenSp.Location = new System.Drawing.Point(70, 167);
            this.lbTenSp.Name = "lbTenSp";
            this.lbTenSp.Size = new System.Drawing.Size(2, 18);
            this.lbTenSp.TabIndex = 2;
            this.lbTenSp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTenSp.Click += new System.EventHandler(this.lbTenSp_Click);
            // 
            // lbGiaTien
            // 
            this.lbGiaTien.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbGiaTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGiaTien.Location = new System.Drawing.Point(138, 214);
            this.lbGiaTien.Name = "lbGiaTien";
            this.lbGiaTien.Size = new System.Drawing.Size(174, 26);
            this.lbGiaTien.TabIndex = 4;
            this.lbGiaTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Red;
            this.lblDiscount.Location = new System.Drawing.Point(318, 224);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(24, 16);
            this.lblDiscount.TabIndex = 5;
            this.lblDiscount.Text = "lbl";
            // 
            // lbTonKho
            // 
            this.lbTonKho.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbTonKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTonKho.Location = new System.Drawing.Point(150, 298);
            this.lbTonKho.Name = "lbTonKho";
            this.lbTonKho.Size = new System.Drawing.Size(72, 26);
            this.lbTonKho.TabIndex = 7;
            this.lbTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 343);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thêm vào giỏ hàng";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(81, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 39);
            this.label2.TabIndex = 9;
            this.label2.Text = "Số lượng hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Màu:";
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor.Location = new System.Drawing.Point(150, 255);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(72, 26);
            this.lblColor.TabIndex = 11;
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(84, 357);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(72, 22);
            this.numericUpDown1.TabIndex = 12;
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(374, 410);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbTonKho);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lbGiaTien);
            this.Controls.Add(this.lbTenSp);
            this.Controls.Add(this.picSP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SanPham";
            this.Text = "SanPham";
            ((System.ComponentModel.ISupportInitialize)(this.picSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picSP;
        private Label lbTenSp;
        private Label lbGiaTien;
        private Label lblDiscount;
        private Label lbTonKho;
        private Button button1;
        private Label label2;
        private Label label4;
        private Label lblColor;
        private NumericUpDown numericUpDown1;
    }
}