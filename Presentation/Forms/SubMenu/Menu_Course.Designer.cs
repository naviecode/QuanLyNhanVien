namespace Presentation.Forms.SubMenu
{
    partial class Menu_Course
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
            panel2 = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            label1 = new Label();
            txtCourseName = new TextBox();
            label2 = new Label();
            dtpStartRegisterDate = new DateTimePicker();
            txtCredits = new TextBox();
            dtpEndRegisterDate = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
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
            customListView1.Location = new Point(0, 83);
            customListView1.Name = "customListView1";
            customListView1.Size = new Size(800, 320);
            customListView1.TabIndex = 6;
            customListView1.UseCompatibleStateImageBehavior = false;
            customListView1.View = View.Details;
            customListView1.SelectedIndexChanged += customListView1_SelectedIndexChanged;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 1;
            label1.Text = "Tên khóa học";
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(115, 6);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(193, 23);
            txtCourseName.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 35);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 2;
            label2.Text = "Số tín chỉ";
            // 
            // dtpStartRegisterDate
            // 
            dtpStartRegisterDate.Location = new Point(495, 6);
            dtpStartRegisterDate.Name = "dtpStartRegisterDate";
            dtpStartRegisterDate.Size = new Size(200, 23);
            dtpStartRegisterDate.TabIndex = 3;
            // 
            // txtCredits
            // 
            txtCredits.Location = new Point(115, 32);
            txtCredits.Name = "txtCredits";
            txtCredits.Size = new Size(193, 23);
            txtCredits.TabIndex = 4;
            // 
            // dtpEndRegisterDate
            // 
            dtpEndRegisterDate.Location = new Point(495, 32);
            dtpEndRegisterDate.Name = "dtpEndRegisterDate";
            dtpEndRegisterDate.Size = new Size(200, 23);
            dtpEndRegisterDate.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(369, 9);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 6;
            label3.Text = "Ngày bắt đầu đăng kí";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(369, 35);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 7;
            label4.Text = "Ngày hết hạn đăng kí";
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dtpEndRegisterDate);
            panel1.Controls.Add(txtCredits);
            panel1.Controls.Add(dtpStartRegisterDate);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCourseName);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 83);
            panel1.TabIndex = 5;
            // 
            // Menu_Course
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customListView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu_Course";
            Text = "Menu_Course";
            FormClosed += Menu_Course_FormClosed;
            Load += Menu_Course_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.CustomListView customListView1;
        private Panel panel2;
        private Label lblPageInfo;
        private Button btnNext;
        private Button btnPrev;
        private Label label1;
        private TextBox txtCourseName;
        private Label label2;
        private DateTimePicker dtpStartRegisterDate;
        private TextBox txtCredits;
        private DateTimePicker dtpEndRegisterDate;
        private Label label3;
        private Label label4;
        private Panel panel1;
    }
}