namespace Presentation.Forms
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            chartStudent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartStudentTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox1 = new GroupBox();
            dgvDataCourse = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)chartStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartStudentTrend).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataCourse).BeginInit();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // chartStudent
            // 
            chartArea1.Name = "ChartArea1";
            chartStudent.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartStudent.Legends.Add(legend1);
            chartStudent.Location = new Point(492, 12);
            chartStudent.Name = "chartStudent";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartStudent.Series.Add(series1);
            chartStudent.Size = new Size(339, 244);
            chartStudent.TabIndex = 0;
            chartStudent.Text = "chart1";
            // 
            // chartStudentTrend
            // 
            chartArea2.Name = "ChartArea1";
            chartStudentTrend.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartStudentTrend.Legends.Add(legend2);
            chartStudentTrend.Location = new Point(12, 262);
            chartStudentTrend.Name = "chartStudentTrend";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartStudentTrend.Series.Add(series2);
            chartStudentTrend.Size = new Size(819, 311);
            chartStudentTrend.TabIndex = 0;
            chartStudentTrend.Text = "chart1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvDataCourse);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(474, 244);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách khóa đang mở";
            // 
            // dgvDataCourse
            // 
            dgvDataCourse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataCourse.Location = new Point(6, 22);
            dgvDataCourse.Name = "dgvDataCourse";
            dgvDataCourse.RowTemplate.Height = 25;
            dgvDataCourse.Size = new Size(461, 216);
            dgvDataCourse.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(835, 585);
            Controls.Add(groupBox1);
            Controls.Add(chartStudentTrend);
            Controls.Add(chartStudent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)chartStudent).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartStudentTrend).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDataCourse).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStudent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStudentTrend;
        private GroupBox groupBox1;
        private DataGridView dgvDataCourse;
    }
}