namespace Presentation.Forms.SubMenu
{
    partial class Menu_Grade
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
            txtStudentName = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            panel1 = new Panel();
            btnCapNhatDiem = new Button();
            txtYear = new TextBox();
            label5 = new Label();
            txtSemester = new TextBox();
            label4 = new Label();
            txtCourseName = new TextBox();
            txtGrade = new TextBox();
            label3 = new Label();
            label2 = new Label();
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
            customListView1.Location = new Point(0, 78);
            customListView1.Name = "customListView1";
            customListView1.Size = new Size(800, 325);
            customListView1.TabIndex = 6;
            customListView1.UseCompatibleStateImageBehavior = false;
            customListView1.View = View.Details;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(116, 12);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(193, 23);
            txtStudentName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 16);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Tên sinh viên";
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
            panel1.Controls.Add(btnCapNhatDiem);
            panel1.Controls.Add(txtYear);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtSemester);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtCourseName);
            panel1.Controls.Add(txtGrade);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtStudentName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 78);
            panel1.TabIndex = 5;
            // 
            // btnCapNhatDiem
            // 
            btnCapNhatDiem.Location = new Point(618, 41);
            btnCapNhatDiem.Name = "btnCapNhatDiem";
            btnCapNhatDiem.Size = new Size(132, 25);
            btnCapNhatDiem.TabIndex = 8;
            btnCapNhatDiem.Text = "Cập nhật điểm";
            btnCapNhatDiem.UseVisualStyleBackColor = true;
            btnCapNhatDiem.Click += btnCapNhatDiem_Click;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(657, 12);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(93, 23);
            txtYear.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(618, 16);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 8;
            label5.Text = "Năm";
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(390, 43);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(193, 23);
            txtSemester.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(337, 46);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 6;
            label4.Text = "Học kỳ";
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(116, 43);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(193, 23);
            txtCourseName.TabIndex = 5;
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(390, 12);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(193, 23);
            txtGrade.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 46);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 3;
            label3.Text = "Tên khóa học";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(337, 15);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 1;
            label2.Text = "Điểm";
            // 
            // Menu_Grade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customListView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu_Grade";
            Text = "Menu_Grade";
            FormClosed += Menu_Grade_FormClosed;
            Load += Menu_Grade_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.CustomListView customListView1;
        private TextBox txtUserName;
        private Label label1;
        private Panel panel2;
        private Label lblPageInfo;
        private Button btnNext;
        private Button btnPrev;
        private Panel panel1;
        private ComboBox cboLopHoc;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private TextBox txtStudentName;
        private Button btnHuyDangKy;
        private Button btnCapNhatDiem;
        private TextBox txtYear;
        private TextBox txtSemester;
        private TextBox txtCourseName;
        private TextBox txtGrade;
    }
}