namespace Presentation.Forms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel2 = new Panel();
            lblUserCurrent = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnTongQuan = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            menuContainer = new FlowLayoutPanel();
            btnChucNang = new Button();
            btnChucNang1 = new Button();
            btnChucNang2 = new Button();
            btnChucNang3 = new Button();
            btnChucNang4 = new Button();
            btnChucNang5 = new Button();
            btnChucNang6 = new Button();
            btnChucNang7 = new Button();
            btnChucNang9 = new Button();
            btnChucNang10 = new Button();
            btnChucNang11 = new Button();
            btnChucNang8 = new Button();
            btnViewStudentInfo = new Button();
            btnViewGrades = new Button();
            btnThoiKhoaBieu = new Button();
            flpSettingContainer = new FlowLayoutPanel();
            btnSettings = new Button();
            btnRole = new Button();
            btnPermission = new Button();
            btnRolePermission = new Button();
            btnThoat = new Button();
            menuTransition = new System.Windows.Forms.Timer(components);
            palNav = new Panel();
            lblTitlePageCurrent = new Label();
            btnTim = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            settingsTransition = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            menuContainer.SuspendLayout();
            flpSettingContainer.SuspendLayout();
            palNav.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1030, 41);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblUserCurrent);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(853, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(177, 41);
            panel2.TabIndex = 5;
            // 
            // lblUserCurrent
            // 
            lblUserCurrent.AutoSize = true;
            lblUserCurrent.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblUserCurrent.Location = new Point(33, 14);
            lblUserCurrent.Name = "lblUserCurrent";
            lblUserCurrent.Size = new Size(40, 15);
            lblUserCurrent.TabIndex = 3;
            lblUserCurrent.Text = "label2";
            lblUserCurrent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user_login;
            pictureBox1.Location = new Point(7, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 22);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 6);
            label1.Name = "label1";
            label1.Size = new Size(203, 29);
            label1.TabIndex = 2;
            label1.Text = "QUẢN LÝ SINH VIÊN UTE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnTongQuan
            // 
            btnTongQuan.AccessibleRole = AccessibleRole.None;
            btnTongQuan.BackColor = Color.FromArgb(23, 24, 29);
            btnTongQuan.FlatAppearance.BorderSize = 0;
            btnTongQuan.FlatStyle = FlatStyle.Flat;
            btnTongQuan.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnTongQuan.ForeColor = Color.White;
            btnTongQuan.ImageAlign = ContentAlignment.MiddleLeft;
            btnTongQuan.Location = new Point(0, 0);
            btnTongQuan.Margin = new Padding(0);
            btnTongQuan.Name = "btnTongQuan";
            btnTongQuan.Size = new Size(200, 43);
            btnTongQuan.TabIndex = 2;
            btnTongQuan.Text = "Tổng quan";
            btnTongQuan.UseVisualStyleBackColor = false;
            btnTongQuan.Click += btnTongQuan_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(23, 24, 29);
            flowLayoutPanel1.Controls.Add(btnTongQuan);
            flowLayoutPanel1.Controls.Add(btnViewStudentInfo);
            flowLayoutPanel1.Controls.Add(btnViewGrades);
            flowLayoutPanel1.Controls.Add(btnThoiKhoaBieu);
            flowLayoutPanel1.Controls.Add(menuContainer);
            flowLayoutPanel1.Controls.Add(flpSettingContainer);
            flowLayoutPanel1.Controls.Add(btnThoat);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 41);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 660);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            // 
            // menuContainer
            // 
            menuContainer.BackColor = Color.FromArgb(32, 33, 36);
            menuContainer.Controls.Add(btnChucNang);
            menuContainer.Controls.Add(btnChucNang1);
            menuContainer.Controls.Add(btnChucNang2);
            menuContainer.Controls.Add(btnChucNang3);
            menuContainer.Controls.Add(btnChucNang4);
            menuContainer.Controls.Add(btnChucNang5);
            menuContainer.Controls.Add(btnChucNang6);
            menuContainer.Controls.Add(btnChucNang7);
            menuContainer.Controls.Add(btnChucNang9);
            menuContainer.Controls.Add(btnChucNang10);
            menuContainer.Controls.Add(btnChucNang11);
            menuContainer.Controls.Add(btnChucNang8);
            menuContainer.Location = new Point(3, 175);
            menuContainer.Name = "menuContainer";
            menuContainer.Size = new Size(200, 43);
            menuContainer.TabIndex = 6;
            // 
            // btnChucNang
            // 
            btnChucNang.AccessibleRole = AccessibleRole.None;
            btnChucNang.BackColor = Color.FromArgb(23, 24, 29);
            btnChucNang.FlatAppearance.BorderSize = 0;
            btnChucNang.FlatStyle = FlatStyle.Flat;
            btnChucNang.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang.ForeColor = Color.White;
            btnChucNang.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang.Location = new Point(0, 0);
            btnChucNang.Margin = new Padding(0);
            btnChucNang.Name = "btnChucNang";
            btnChucNang.Size = new Size(200, 43);
            btnChucNang.TabIndex = 5;
            btnChucNang.Text = "Chức năng";
            btnChucNang.UseVisualStyleBackColor = false;
            btnChucNang.Click += btnChucNang_Click;
            // 
            // btnChucNang1
            // 
            btnChucNang1.AccessibleRole = AccessibleRole.None;
            btnChucNang1.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang1.FlatAppearance.BorderSize = 0;
            btnChucNang1.FlatStyle = FlatStyle.Flat;
            btnChucNang1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang1.ForeColor = Color.White;
            btnChucNang1.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang1.Location = new Point(0, 43);
            btnChucNang1.Margin = new Padding(0);
            btnChucNang1.Name = "btnChucNang1";
            btnChucNang1.Size = new Size(200, 43);
            btnChucNang1.TabIndex = 6;
            btnChucNang1.Text = "Quản lý sinh viên";
            btnChucNang1.UseVisualStyleBackColor = false;
            btnChucNang1.Click += btnChucNang1_Click;
            // 
            // btnChucNang2
            // 
            btnChucNang2.AccessibleRole = AccessibleRole.None;
            btnChucNang2.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang2.FlatAppearance.BorderSize = 0;
            btnChucNang2.FlatStyle = FlatStyle.Flat;
            btnChucNang2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang2.ForeColor = Color.White;
            btnChucNang2.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang2.Location = new Point(0, 86);
            btnChucNang2.Margin = new Padding(0);
            btnChucNang2.Name = "btnChucNang2";
            btnChucNang2.Size = new Size(200, 43);
            btnChucNang2.TabIndex = 7;
            btnChucNang2.Text = "Quản lý khóa học";
            btnChucNang2.UseVisualStyleBackColor = false;
            btnChucNang2.Click += btnChucNang2_Click;
            // 
            // btnChucNang3
            // 
            btnChucNang3.AccessibleRole = AccessibleRole.None;
            btnChucNang3.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang3.FlatAppearance.BorderSize = 0;
            btnChucNang3.FlatStyle = FlatStyle.Flat;
            btnChucNang3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang3.ForeColor = Color.White;
            btnChucNang3.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang3.Location = new Point(0, 129);
            btnChucNang3.Margin = new Padding(0);
            btnChucNang3.Name = "btnChucNang3";
            btnChucNang3.Size = new Size(200, 43);
            btnChucNang3.TabIndex = 8;
            btnChucNang3.Text = "Đăng ký khóa học";
            btnChucNang3.UseVisualStyleBackColor = false;
            btnChucNang3.Click += btnChucNang3_Click;
            // 
            // btnChucNang4
            // 
            btnChucNang4.AccessibleRole = AccessibleRole.None;
            btnChucNang4.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang4.FlatAppearance.BorderSize = 0;
            btnChucNang4.FlatStyle = FlatStyle.Flat;
            btnChucNang4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang4.ForeColor = Color.White;
            btnChucNang4.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang4.Location = new Point(0, 172);
            btnChucNang4.Margin = new Padding(0);
            btnChucNang4.Name = "btnChucNang4";
            btnChucNang4.Size = new Size(200, 43);
            btnChucNang4.TabIndex = 9;
            btnChucNang4.Text = "Quản lý điểm";
            btnChucNang4.UseVisualStyleBackColor = false;
            btnChucNang4.Click += btnChucNang4_Click;
            // 
            // btnChucNang5
            // 
            btnChucNang5.AccessibleRole = AccessibleRole.None;
            btnChucNang5.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang5.FlatAppearance.BorderSize = 0;
            btnChucNang5.FlatStyle = FlatStyle.Flat;
            btnChucNang5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang5.ForeColor = Color.White;
            btnChucNang5.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang5.Location = new Point(0, 215);
            btnChucNang5.Margin = new Padding(0);
            btnChucNang5.Name = "btnChucNang5";
            btnChucNang5.Size = new Size(200, 43);
            btnChucNang5.TabIndex = 10;
            btnChucNang5.Text = "Quản lý giảng viên";
            btnChucNang5.UseVisualStyleBackColor = false;
            btnChucNang5.Click += btnChucNang5_Click;
            // 
            // btnChucNang6
            // 
            btnChucNang6.AccessibleRole = AccessibleRole.None;
            btnChucNang6.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang6.FlatAppearance.BorderSize = 0;
            btnChucNang6.FlatStyle = FlatStyle.Flat;
            btnChucNang6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang6.ForeColor = Color.White;
            btnChucNang6.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang6.Location = new Point(0, 258);
            btnChucNang6.Margin = new Padding(0);
            btnChucNang6.Name = "btnChucNang6";
            btnChucNang6.Size = new Size(200, 43);
            btnChucNang6.TabIndex = 11;
            btnChucNang6.Text = "Quản lý lớp học";
            btnChucNang6.UseVisualStyleBackColor = false;
            btnChucNang6.Click += btnChucNang6_Click;
            // 
            // btnChucNang7
            // 
            btnChucNang7.AccessibleRole = AccessibleRole.None;
            btnChucNang7.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang7.FlatAppearance.BorderSize = 0;
            btnChucNang7.FlatStyle = FlatStyle.Flat;
            btnChucNang7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang7.ForeColor = Color.White;
            btnChucNang7.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang7.Location = new Point(0, 301);
            btnChucNang7.Margin = new Padding(0);
            btnChucNang7.Name = "btnChucNang7";
            btnChucNang7.Size = new Size(200, 43);
            btnChucNang7.TabIndex = 12;
            btnChucNang7.Text = "Quản lý khoa";
            btnChucNang7.UseVisualStyleBackColor = false;
            btnChucNang7.Click += btnChucNang7_Click;
            // 
            // btnChucNang9
            // 
            btnChucNang9.AccessibleRole = AccessibleRole.None;
            btnChucNang9.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang9.FlatAppearance.BorderSize = 0;
            btnChucNang9.FlatStyle = FlatStyle.Flat;
            btnChucNang9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang9.ForeColor = Color.White;
            btnChucNang9.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang9.Location = new Point(0, 344);
            btnChucNang9.Margin = new Padding(0);
            btnChucNang9.Name = "btnChucNang9";
            btnChucNang9.Size = new Size(200, 43);
            btnChucNang9.TabIndex = 14;
            btnChucNang9.Text = "Quản lý tài khoản";
            btnChucNang9.UseVisualStyleBackColor = false;
            btnChucNang9.Click += btnChucNang9_Click;
            // 
            // btnChucNang10
            // 
            btnChucNang10.AccessibleRole = AccessibleRole.None;
            btnChucNang10.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang10.FlatAppearance.BorderSize = 0;
            btnChucNang10.FlatStyle = FlatStyle.Flat;
            btnChucNang10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang10.ForeColor = Color.White;
            btnChucNang10.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang10.Location = new Point(0, 387);
            btnChucNang10.Margin = new Padding(0);
            btnChucNang10.Name = "btnChucNang10";
            btnChucNang10.Size = new Size(200, 43);
            btnChucNang10.TabIndex = 15;
            btnChucNang10.Text = "Đăng ký lịch dạy";
            btnChucNang10.UseVisualStyleBackColor = false;
            btnChucNang10.Click += btnChucNang10_Click;
            // 
            // btnChucNang11
            // 
            btnChucNang11.AccessibleRole = AccessibleRole.None;
            btnChucNang11.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang11.FlatAppearance.BorderSize = 0;
            btnChucNang11.FlatStyle = FlatStyle.Flat;
            btnChucNang11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang11.ForeColor = Color.White;
            btnChucNang11.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang11.Location = new Point(0, 430);
            btnChucNang11.Margin = new Padding(0);
            btnChucNang11.Name = "btnChucNang11";
            btnChucNang11.Size = new Size(200, 43);
            btnChucNang11.TabIndex = 16;
            btnChucNang11.Text = "Quản lý khóa học cho lớp";
            btnChucNang11.UseVisualStyleBackColor = false;
            btnChucNang11.Click += btnChucNang11_Click;
            // 
            // btnChucNang8
            // 
            btnChucNang8.AccessibleRole = AccessibleRole.None;
            btnChucNang8.BackColor = Color.FromArgb(32, 33, 36);
            btnChucNang8.FlatAppearance.BorderSize = 0;
            btnChucNang8.FlatStyle = FlatStyle.Flat;
            btnChucNang8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnChucNang8.ForeColor = Color.White;
            btnChucNang8.ImageAlign = ContentAlignment.MiddleLeft;
            btnChucNang8.Location = new Point(0, 473);
            btnChucNang8.Margin = new Padding(0);
            btnChucNang8.Name = "btnChucNang8";
            btnChucNang8.Size = new Size(200, 43);
            btnChucNang8.TabIndex = 13;
            btnChucNang8.Text = "Báo cáo";
            btnChucNang8.UseVisualStyleBackColor = false;
            btnChucNang8.Click += btnChucNang8_Click;
            // 
            // btnViewStudentInfo
            // 
            btnViewStudentInfo.AccessibleRole = AccessibleRole.None;
            btnViewStudentInfo.BackColor = Color.FromArgb(23, 24, 29);
            btnViewStudentInfo.FlatAppearance.BorderSize = 0;
            btnViewStudentInfo.FlatStyle = FlatStyle.Flat;
            btnViewStudentInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewStudentInfo.ForeColor = Color.White;
            btnViewStudentInfo.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewStudentInfo.Location = new Point(0, 43);
            btnViewStudentInfo.Margin = new Padding(0);
            btnViewStudentInfo.Name = "btnViewStudentInfo";
            btnViewStudentInfo.Size = new Size(200, 43);
            btnViewStudentInfo.TabIndex = 7;
            btnViewStudentInfo.Text = "Thông tin sinh viên";
            btnViewStudentInfo.UseVisualStyleBackColor = false;
            btnViewStudentInfo.Click += btnViewStudentInfo_Click;
            // 
            // btnViewGrades
            // 
            btnViewGrades.AccessibleRole = AccessibleRole.None;
            btnViewGrades.BackColor = Color.FromArgb(23, 24, 29);
            btnViewGrades.FlatAppearance.BorderSize = 0;
            btnViewGrades.FlatStyle = FlatStyle.Flat;
            btnViewGrades.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewGrades.ForeColor = Color.White;
            btnViewGrades.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewGrades.Location = new Point(0, 86);
            btnViewGrades.Margin = new Padding(0);
            btnViewGrades.Name = "btnViewGrades";
            btnViewGrades.Size = new Size(200, 43);
            btnViewGrades.TabIndex = 8;
            btnViewGrades.Text = "Xem điểm";
            btnViewGrades.UseVisualStyleBackColor = false;
            btnViewGrades.Click += btnViewGrades_Click;
            // 
            // btnThoiKhoaBieu
            // 
            btnThoiKhoaBieu.AccessibleRole = AccessibleRole.None;
            btnThoiKhoaBieu.BackColor = Color.FromArgb(23, 24, 29);
            btnThoiKhoaBieu.FlatAppearance.BorderSize = 0;
            btnThoiKhoaBieu.FlatStyle = FlatStyle.Flat;
            btnThoiKhoaBieu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnThoiKhoaBieu.ForeColor = Color.White;
            btnThoiKhoaBieu.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoiKhoaBieu.Location = new Point(0, 129);
            btnThoiKhoaBieu.Margin = new Padding(0);
            btnThoiKhoaBieu.Name = "btnThoiKhoaBieu";
            btnThoiKhoaBieu.Size = new Size(200, 43);
            btnThoiKhoaBieu.TabIndex = 8;
            btnThoiKhoaBieu.Text = "Thời khóa biểu";
            btnThoiKhoaBieu.UseVisualStyleBackColor = false;
            btnThoiKhoaBieu.Click += btnThoiKhoaBieu_Click;
            // 
            // flpSettingContainer
            // 
            flpSettingContainer.BackColor = Color.FromArgb(32, 33, 36);
            flpSettingContainer.Controls.Add(btnSettings);
            flpSettingContainer.Controls.Add(btnRole);
            flpSettingContainer.Controls.Add(btnPermission);
            flpSettingContainer.Controls.Add(btnRolePermission);
            flpSettingContainer.ForeColor = Color.Black;
            flpSettingContainer.Location = new Point(3, 224);
            flpSettingContainer.Name = "flpSettingContainer";
            flpSettingContainer.Size = new Size(201, 43);
            flpSettingContainer.TabIndex = 7;
            // 
            // btnSettings
            // 
            btnSettings.AccessibleRole = AccessibleRole.None;
            btnSettings.BackColor = Color.FromArgb(23, 24, 29);
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSettings.ForeColor = Color.White;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(0, 0);
            btnSettings.Margin = new Padding(0);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(200, 43);
            btnSettings.TabIndex = 7;
            btnSettings.Text = "Cài đặt";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnRole
            // 
            btnRole.AccessibleRole = AccessibleRole.None;
            btnRole.BackColor = Color.FromArgb(32, 33, 36);
            btnRole.FlatAppearance.BorderSize = 0;
            btnRole.FlatStyle = FlatStyle.Flat;
            btnRole.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRole.ForeColor = Color.White;
            btnRole.ImageAlign = ContentAlignment.MiddleLeft;
            btnRole.Location = new Point(0, 43);
            btnRole.Margin = new Padding(0);
            btnRole.Name = "btnRole";
            btnRole.Size = new Size(200, 43);
            btnRole.TabIndex = 10;
            btnRole.Text = "Chức danh";
            btnRole.UseVisualStyleBackColor = false;
            btnRole.Click += btnRole_Click;
            // 
            // btnPermission
            // 
            btnPermission.AccessibleRole = AccessibleRole.None;
            btnPermission.BackColor = Color.FromArgb(32, 33, 36);
            btnPermission.FlatAppearance.BorderSize = 0;
            btnPermission.FlatStyle = FlatStyle.Flat;
            btnPermission.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPermission.ForeColor = Color.White;
            btnPermission.ImageAlign = ContentAlignment.MiddleLeft;
            btnPermission.Location = new Point(0, 86);
            btnPermission.Margin = new Padding(0);
            btnPermission.Name = "btnPermission";
            btnPermission.Size = new Size(200, 43);
            btnPermission.TabIndex = 8;
            btnPermission.Text = "Quyền hệ thống";
            btnPermission.UseVisualStyleBackColor = false;
            btnPermission.Click += btnPermission_Click;
            // 
            // btnRolePermission
            // 
            btnRolePermission.AccessibleRole = AccessibleRole.None;
            btnRolePermission.BackColor = Color.FromArgb(32, 33, 36);
            btnRolePermission.FlatAppearance.BorderSize = 0;
            btnRolePermission.FlatStyle = FlatStyle.Flat;
            btnRolePermission.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRolePermission.ForeColor = Color.White;
            btnRolePermission.ImageAlign = ContentAlignment.MiddleLeft;
            btnRolePermission.Location = new Point(0, 129);
            btnRolePermission.Margin = new Padding(0);
            btnRolePermission.Name = "btnRolePermission";
            btnRolePermission.Size = new Size(200, 43);
            btnRolePermission.TabIndex = 9;
            btnRolePermission.Text = "Cấp quyền";
            btnRolePermission.UseVisualStyleBackColor = false;
            btnRolePermission.Click += btnRolePermission_Click;
            // 
            // btnThoat
            // 
            btnThoat.AccessibleRole = AccessibleRole.None;
            btnThoat.BackColor = Color.FromArgb(23, 24, 29);
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnThoat.ForeColor = Color.White;
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(0, 270);
            btnThoat.Margin = new Padding(0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(200, 43);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // menuTransition
            // 
            menuTransition.Tick += menuTransition_Tick;
            // 
            // palNav
            // 
            palNav.Controls.Add(lblTitlePageCurrent);
            palNav.Controls.Add(btnTim);
            palNav.Controls.Add(btnThem);
            palNav.Controls.Add(btnSua);
            palNav.Controls.Add(btnXoa);
            palNav.Dock = DockStyle.Top;
            palNav.Location = new Point(200, 41);
            palNav.Name = "palNav";
            palNav.Size = new Size(830, 50);
            palNav.TabIndex = 5;
            // 
            // lblTitlePageCurrent
            // 
            lblTitlePageCurrent.AutoSize = true;
            lblTitlePageCurrent.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitlePageCurrent.Location = new Point(6, 12);
            lblTitlePageCurrent.Name = "lblTitlePageCurrent";
            lblTitlePageCurrent.Size = new Size(105, 20);
            lblTitlePageCurrent.TabIndex = 4;
            lblTitlePageCurrent.Text = "Trang hiện tại";
            // 
            // btnTim
            // 
            btnTim.Location = new Point(743, 7);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(75, 33);
            btnTim.TabIndex = 3;
            btnTim.Text = "Tìm kiếm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(500, 7);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 33);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(581, 7);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 33);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(662, 7);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 33);
            btnXoa.TabIndex = 0;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // settingsTransition
            // 
            settingsTransition.Tick += settingsTransition_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 701);
            Controls.Add(palNav);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IsMdiContainer = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "    ";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            menuContainer.ResumeLayout(false);
            flpSettingContainer.ResumeLayout(false);
            palNav.ResumeLayout(false);
            palNav.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnTongQuan;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnThoat;
        private Button btnChucNang;
        private FlowLayoutPanel menuContainer;
        private Button btnChucNang1;
        private Button btnChucNang2;
        private System.Windows.Forms.Timer menuTransition;
        private Label label1;
        private Button btnChucNang3;
        private Button btnChucNang4;
        private Button btnChucNang5;
        private Button btnChucNang6;
        private Button btnChucNang7;
        private Button btnChucNang8;
        private Button btnChucNang9;
        private Panel palNav;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Button btnTim;
        private Label lblTitlePageCurrent;
        private Label lblUserCurrent;
        private FlowLayoutPanel flpSettingContainer;
        private Button btnSettings;
        private Button btnPermission;
        private Button btnRolePermission;
        private Button btnRole;
        private System.Windows.Forms.Timer settingsTransition;
        private PictureBox pictureBox1;
        private Button btnViewStudentInfo;
        private Button btnViewGrades;
        private Panel panel2;
        private Button btnThoiKhoaBieu;
        private Button btnChucNang10;
        private Button btnChucNang11;
    }
}