namespace Presentation.Forms.Menus
{
    partial class ViewTimeTable
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            cboNamHoc = new ComboBox();
            label2 = new Label();
            cboHocKy = new ComboBox();
            label3 = new Label();
            dtpFromDate = new DateTimePicker();
            label4 = new Label();
            dtpToDate = new DateTimePicker();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(886, 417);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Năm học";
            // 
            // cboNamHoc
            // 
            cboNamHoc.FormattingEnabled = true;
            cboNamHoc.Location = new Point(74, 17);
            cboNamHoc.Name = "cboNamHoc";
            cboNamHoc.Size = new Size(200, 23);
            cboNamHoc.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(298, 20);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Học kỳ";
            // 
            // cboHocKy
            // 
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(363, 17);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(198, 23);
            cboHocKy.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 59);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 1;
            label3.Text = "Từ ngày";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Location = new Point(74, 55);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(200, 23);
            dtpFromDate.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(298, 59);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 1;
            label4.Text = "Đến ngày";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(361, 55);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(200, 23);
            dtpToDate.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 84);
            panel1.Name = "panel1";
            panel1.Size = new Size(886, 417);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 324);
            panel2.Name = "panel2";
            panel2.Size = new Size(886, 93);
            panel2.TabIndex = 1;
            // 
            // ViewTimeTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 501);
            Controls.Add(panel1);
            Controls.Add(dtpToDate);
            Controls.Add(dtpFromDate);
            Controls.Add(label4);
            Controls.Add(cboHocKy);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboNamHoc);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewTimeTable";
            Text = "ViewTimeTable";
            Load += ViewTimeTable_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ComboBox cboNamHoc;
        private Label label2;
        private ComboBox cboHocKy;
        private Label label3;
        private DateTimePicker dtpFromDate;
        private Label label4;
        private DateTimePicker dtpToDate;
        private Panel panel1;
        private Panel panel2;
    }
}