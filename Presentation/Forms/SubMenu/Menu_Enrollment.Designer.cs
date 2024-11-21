﻿namespace Presentation.Forms.SubMenu
{
    partial class Menu_Enrollment
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
            customListView1 = new CustomControls.CustomListView();
            txtKhoaHoc = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            panel1 = new Panel();
            btnHuyDangKy = new Button();
            btnDangky = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // customListView1
            // 
            customListView1.BorderStyle = BorderStyle.None;
            customListView1.Dock = DockStyle.Fill;
            customListView1.FullRowSelect = true;
            customListView1.GridLines = true;
            customListView1.Location = new Point(0, 64);
            customListView1.Name = "customListView1";
            customListView1.Size = new Size(800, 339);
            customListView1.TabIndex = 6;
            customListView1.UseCompatibleStateImageBehavior = false;
            customListView1.View = View.Details;
            // 
            // txtKhoaHoc
            // 
            txtKhoaHoc.Location = new Point(116, 12);
            txtKhoaHoc.Name = "txtKhoaHoc";
            txtKhoaHoc.Size = new Size(193, 23);
            txtKhoaHoc.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 16);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 1;
            label1.Text = "Tên khóa học";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblPageInfo);
            panel2.Controls.Add(btnNext);
            panel2.Controls.Add(btnPrev);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 403);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 47);
            panel2.TabIndex = 7;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPageInfo.Location = new Point(644, 12);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(63, 23);
            lblPageInfo.TabIndex = 1;
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(713, 12);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 0;
            btnNext.Text = "Sau";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(563, 12);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(75, 23);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "Trước";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnHuyDangKy);
            panel1.Controls.Add(btnDangky);
            panel1.Controls.Add(txtKhoaHoc);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 64);
            panel1.TabIndex = 5;
            // 
            // btnHuyDangKy
            // 
            btnHuyDangKy.Location = new Point(685, 12);
            btnHuyDangKy.Name = "btnHuyDangKy";
            btnHuyDangKy.Size = new Size(103, 23);
            btnHuyDangKy.TabIndex = 2;
            btnHuyDangKy.Text = "Hủy đăng ký";
            btnHuyDangKy.UseVisualStyleBackColor = true;
            // 
            // btnDangky
            // 
            btnDangky.Location = new Point(567, 12);
            btnDangky.Name = "btnDangky";
            btnDangky.Size = new Size(103, 23);
            btnDangky.TabIndex = 2;
            btnDangky.Text = "Đăng ký";
            btnDangky.UseVisualStyleBackColor = true;
            // 
            // Menu_Enrollment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customListView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu_Enrollment";
            Text = "Menu_Enrollment";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.CustomListView customListView1;
        private TextBox txtKhoaHoc;
        private Label label1;
        private Panel panel2;
        private Label lblPageInfo;
        private Button btnNext;
        private Button btnPrev;
        private Panel panel1;
        private Button btnHuyDangKy;
        private Button btnDangky;
    }
}