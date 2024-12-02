namespace Presentation.Forms.SubMenu
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
            txtCourseName = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            panel1 = new Panel();
            txtYear = new TextBox();
            txtSemester = new TextBox();
            txtFacultyName = new TextBox();
            txtClassName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
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
            customListView1.Location = new Point(0, 92);
            customListView1.Name = "customListView1";
            customListView1.Size = new Size(800, 311);
            customListView1.TabIndex = 6;
            customListView1.UseCompatibleStateImageBehavior = false;
            customListView1.View = View.Details;
            customListView1.SelectedIndexChanged += customListView1_SelectedIndexChanged;
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(115, 6);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(193, 23);
            txtCourseName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
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
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(563, 12);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(75, 23);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "Trước";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtYear);
            panel1.Controls.Add(txtSemester);
            panel1.Controls.Add(txtFacultyName);
            panel1.Controls.Add(txtClassName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnHuyDangKy);
            panel1.Controls.Add(btnDangky);
            panel1.Controls.Add(txtCourseName);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 92);
            panel1.TabIndex = 5;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(404, 34);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(193, 23);
            txtYear.TabIndex = 10;
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(404, 6);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(193, 23);
            txtSemester.TabIndex = 9;
            // 
            // txtFacultyName
            // 
            txtFacultyName.Location = new Point(115, 60);
            txtFacultyName.Name = "txtFacultyName";
            txtFacultyName.Size = new Size(193, 23);
            txtFacultyName.TabIndex = 8;
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(115, 34);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(193, 23);
            txtClassName.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(354, 37);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 6;
            label5.Text = "Năm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(354, 12);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 5;
            label4.Text = "Học kỳ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 4;
            label3.Text = "Tên giảng viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 37);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 3;
            label2.Text = "Tên lớp";
            // 
            // btnHuyDangKy
            // 
            btnHuyDangKy.Location = new Point(644, 49);
            btnHuyDangKy.Name = "btnHuyDangKy";
            btnHuyDangKy.Size = new Size(122, 34);
            btnHuyDangKy.TabIndex = 2;
            btnHuyDangKy.Text = "Hủy đăng ký";
            btnHuyDangKy.UseVisualStyleBackColor = true;
            btnHuyDangKy.Click += btnHuyDangKy_Click;
            // 
            // btnDangky
            // 
            btnDangky.Location = new Point(644, 6);
            btnDangky.Name = "btnDangky";
            btnDangky.Size = new Size(122, 37);
            btnDangky.TabIndex = 2;
            btnDangky.Text = "Đăng ký khóa mới";
            btnDangky.UseVisualStyleBackColor = true;
            btnDangky.Click += btnDangky_Click;
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
            FormClosed += Menu_Enrollment_FormClosed;
            Load += Menu_Enrollment_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.CustomListView customListView1;
        private TextBox txtCourseName;
        private Label label1;
        private Panel panel2;
        private Label lblPageInfo;
        private Button btnNext;
        private Button btnPrev;
        private Panel panel1;
        private Button btnHuyDangKy;
        private Button btnDangky;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label4;
        private TextBox txtClassName;
        private TextBox txtSemester;
        private TextBox txtFacultyName;
        private TextBox txtYear;
    }
}