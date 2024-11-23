namespace Presentation.Forms.SubMenu
{
    partial class Menu_ClassSection
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
            txtClassName = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            panel1 = new Panel();
            txtYear = new TextBox();
            label5 = new Label();
            txtCourseName = new TextBox();
            txtFacultyName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            AddNewCourseForClass = new Button();
            txtSemester = new TextBox();
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
            customListView1.Location = new Point(0, 96);
            customListView1.Name = "customListView1";
            customListView1.Size = new Size(800, 307);
            customListView1.TabIndex = 6;
            customListView1.UseCompatibleStateImageBehavior = false;
            customListView1.View = View.Details;
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(92, 6);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(193, 23);
            txtClassName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Tên lớp";
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
            panel1.Controls.Add(txtYear);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtCourseName);
            panel1.Controls.Add(txtFacultyName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(AddNewCourseForClass);
            panel1.Controls.Add(txtSemester);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtClassName);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 96);
            panel1.TabIndex = 5;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(384, 38);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(193, 23);
            txtYear.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 41);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 13;
            label5.Text = "Năm học";
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(92, 68);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(193, 23);
            txtCourseName.TabIndex = 12;
            // 
            // txtFacultyName
            // 
            txtFacultyName.Location = new Point(92, 38);
            txtFacultyName.Name = "txtFacultyName";
            txtFacultyName.Size = new Size(193, 23);
            txtFacultyName.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 71);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 10;
            label4.Text = "Tên khóa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 41);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 9;
            label3.Text = "Tên giảng viên";
            // 
            // AddNewCourseForClass
            // 
            AddNewCourseForClass.Location = new Point(633, 29);
            AddNewCourseForClass.Name = "AddNewCourseForClass";
            AddNewCourseForClass.Size = new Size(125, 39);
            AddNewCourseForClass.TabIndex = 8;
            AddNewCourseForClass.Text = "Thêm học phần";
            AddNewCourseForClass.UseVisualStyleBackColor = true;
            AddNewCourseForClass.Click += AddNewCourseForClass_Click;
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(384, 6);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(193, 23);
            txtSemester.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(322, 9);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Học kì";
            // 
            // Menu_ClassSection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customListView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu_ClassSection";
            Text = "Menu_ClassSection";
            FormClosed += Menu_ClassSection_FormClosed;
            Load += Menu_ClassSection_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.CustomListView customListView1;
        private TextBox txtClassName;
        private Label label1;
        private Panel panel2;
        private Label lblPageInfo;
        private Button btnNext;
        private Button btnPrev;
        private Panel panel1;
        private TextBox txtSemester;
        private Label label2;
        private Button AddNewCourseForClass;
        private TextBox txtYear;
        private Label label5;
        private TextBox txtCourseName;
        private TextBox txtFacultyName;
        private Label label4;
        private Label label3;
    }
}