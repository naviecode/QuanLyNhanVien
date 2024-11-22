namespace Presentation.Forms.SubMenu
{
    partial class Menu_QLSV
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
            lblUserName = new Label();
            lblGender = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            txtAddr = new TextBox();
            panel1 = new Panel();
            txtHomeTown = new TextBox();
            label5 = new Label();
            txtClassName = new TextBox();
            label4 = new Label();
            cbGender = new ComboBox();
            panel2 = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // customListView1
            // 
            customListView1.BorderStyle = BorderStyle.None;
            customListView1.Dock = DockStyle.Fill;
            customListView1.FullRowSelect = true;
            customListView1.GridLines = true;
            customListView1.Location = new Point(0, 115);
            customListView1.Name = "customListView1";
            customListView1.Size = new Size(928, 445);
            customListView1.TabIndex = 4;
            customListView1.UseCompatibleStateImageBehavior = false;
            customListView1.View = View.Details;
            customListView1.SelectedIndexChanged += customListView1_SelectedIndexChanged;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(12, 9);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(75, 15);
            lblUserName.TabIndex = 5;
            lblUserName.Text = "Tên sinh viên";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(12, 43);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(52, 15);
            lblGender.TabIndex = 6;
            lblGender.Text = "Giới tính";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 7;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 9);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 8;
            label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 43);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 9;
            label3.Text = "Địa chỉ";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(93, 6);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(193, 23);
            txtFullName.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(93, 72);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(193, 23);
            txtEmail.TabIndex = 14;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(424, 6);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(193, 23);
            txtPhoneNumber.TabIndex = 15;
            // 
            // txtAddr
            // 
            txtAddr.Location = new Point(424, 40);
            txtAddr.Name = "txtAddr";
            txtAddr.Size = new Size(193, 23);
            txtAddr.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtHomeTown);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtClassName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbGender);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtAddr);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(928, 115);
            panel1.TabIndex = 19;
            // 
            // txtHomeTown
            // 
            txtHomeTown.Location = new Point(725, 6);
            txtHomeTown.Name = "txtHomeTown";
            txtHomeTown.Size = new Size(193, 23);
            txtHomeTown.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(660, 9);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 25;
            label5.Text = "Quê quán";
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(424, 72);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(193, 23);
            txtClassName.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(342, 75);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 23;
            label4.Text = "Tên lớp";
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "<Tất cả>", "Nam", "Nữ" });
            cbGender.Location = new Point(93, 40);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(193, 23);
            cbGender.TabIndex = 22;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblPageInfo);
            panel2.Controls.Add(btnNext);
            panel2.Controls.Add(btnPrev);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 460);
            panel2.Name = "panel2";
            panel2.Size = new Size(928, 100);
            panel2.TabIndex = 20;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPageInfo.Location = new Point(772, 23);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(63, 23);
            lblPageInfo.TabIndex = 4;
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(841, 23);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 2;
            btnNext.Text = "Sau";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(691, 23);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(75, 23);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "Trước";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // Menu_QLSV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 560);
            Controls.Add(panel2);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblGender);
            Controls.Add(lblUserName);
            Controls.Add(customListView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu_QLSV";
            Text = "Menu_QLSV";
            FormClosed += Menu_QLSV_FormClosed;
            Load += Menu_Students_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomListView customListView1;
        private Label lblUserName;
        private Label lblGender;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtAddr;
        private Panel panel1;
        private Panel panel2;
        private ComboBox cbGender;
        private Label lblPageInfo;
        private Button btnNext;
        private Button btnPrev;
        private TextBox txtClassName;
        private Label label4;
        private Label label5;
        private TextBox txtHomeTown;
    }
}