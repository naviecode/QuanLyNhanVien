using System.Windows.Forms.DataVisualization.Charting;

namespace Presentation.Forms
{
    public partial class Dashboard : Form
    {
        private MainForm mainForm;
        public Dashboard(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            chartStudent.Series["Series1"].Points.AddXY("Tháng 1", 500);
            chartStudent.Series["Series1"].Points.AddXY("Tháng 2", 700);
            chartStudent.Series["Series1"].Points.AddXY("Tháng 3", 1000);

            // Định dạng Series
            chartStudent.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //DrawChart();

        }
        public class Course
        {
            public string Name { get; set; }
            public DateTime CloseDate { get; set; }
            public int CurrentStudents { get; set; }
            public string Status { get; set; }
        }
        private void Dashboard_Load(object sender, EventArgs e)
        { 
            // Dữ liệu mẫu
          // Dữ liệu mẫu
            var courses1 = new List<Course>
            {
                new Course { Name = "Math 101", CloseDate = DateTime.Now.AddDays(2), CurrentStudents = 50, Status = "Sắp đóng" },
                new Course { Name = "Physics 202", CloseDate = DateTime.Now.AddDays(10), CurrentStudents = 60, Status = "Còn mở" },
                new Course { Name = "Chemistry 303", CloseDate = DateTime.Now.AddDays(-1), CurrentStudents = 45, Status = "Đã đóng" },
                new Course { Name = "Biology 404", CloseDate = DateTime.Now.AddDays(1), CurrentStudents = 30, Status = "Sắp đóng" }
            };

            // Hiển thị dữ liệu trong DataGridView
            dgvDataCourse.DataSource = courses1;
            dgvDataCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tùy chỉnh cột
            dgvDataCourse.Columns["CloseDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDataCourse.Columns["Name"].HeaderText = "Tên khóa học";
            dgvDataCourse.Columns["CloseDate"].HeaderText = "Ngày đóng đăng ký";
            dgvDataCourse.Columns["CurrentStudents"].HeaderText = "Số sinh viên";
            dgvDataCourse.Columns["Status"].HeaderText = "Trạng thái";

            var totalStudents = 1000;
            var studentsByClass = new[]
            {
                new { Class = "Class A", Count = 250 },
                new { Class = "Class B", Count = 300 },
                new { Class = "Class C", Count = 450 }
            };

            var studentsByDepartment = new[]
            {
                new { Department = "IT", Count = 400 },
                new { Department = "Business", Count = 350 },
                new { Department = "Engineering", Count = 250 }
            };

            var courses = new[]
            {
                new { CourseName = "Math 101", Registrations = 150 },
                new { CourseName = "Physics 202", Registrations = 120 },
                new { CourseName = "Chemistry 303", Registrations = 180 },
                new { CourseName = "Biology 404", Registrations = 90 },
                new { CourseName = "Computer Science 505", Registrations = 200 }
            };// Dữ liệu mẫu
            var studentTrends = new[]
            {
                new { Year = 2018, StudentCount = 500 },
                new { Year = 2019, StudentCount = 520 },
                new { Year = 2020, StudentCount = 480 },
                new { Year = 2021, StudentCount = 530 },
                new { Year = 2022, StudentCount = 550 },
                new { Year = 2023, StudentCount = 600 }
            };

            // Hiển thị biểu đồ đường
            DisplayLineChart(chartStudentTrend, "Student Count Trend", studentTrends.Select(x => x.Year).ToArray(), studentTrends.Select(x => x.StudentCount).ToArray());

           
             DisplayPieChart(chartStudent, "Students by Department", studentsByDepartment.Select(x => x.Department).ToArray(), studentsByDepartment.Select(x => x.Count).ToArray());
        }
        private void DisplayPieChart(Chart chart, string title, string[] labels, int[] values)
        {
            // Xóa series cũ nếu có
            chart.Series.Clear();

            // Thêm series mới
            Series series = new Series
            {
                Name = "PieSeries",
                ChartType = SeriesChartType.Pie
            };

            chart.Series.Add(series);

            // Thêm dữ liệu
            for (int i = 0; i < labels.Length; i++)
            {
                series.Points.Add(values[i]);
                series.Points[i].LegendText = labels[i];
                series.Points[i].Label = $"{labels[i]}: {values[i]}";
            }

            // Cấu hình chart
            chart.Titles.Clear();
            chart.Titles.Add(title);
            chart.Legends[0].Enabled = true;
        }

        private void DisplayLineChart(Chart chart, string title, int[] years, int[] studentCounts)
        {
            // Xóa series cũ nếu có
            chart.Series.Clear();

            // Tạo series mới
            Series series = new Series
            {
                Name = "StudentTrend",
                ChartType = SeriesChartType.Line,
                BorderWidth = 3, // Độ dày của đường
                MarkerStyle = MarkerStyle.Circle, // Thêm các điểm trên đường
                MarkerSize = 8 // Kích thước điểm
            };

            chart.Series.Add(series);

            // Thêm dữ liệu vào series
            for (int i = 0; i < years.Length; i++)
            {
                series.Points.AddXY(years[i], studentCounts[i]);
            }

            // Cấu hình biểu đồ
            chart.Titles.Clear();
            chart.Titles.Add(title);

            chart.ChartAreas[0].AxisX.Title = "Year";
            chart.ChartAreas[0].AxisY.Title = "Student Count";

            chart.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả năm
            chart.ChartAreas[0].AxisY.Interval = 50; // Đặt khoảng cách trục Y

            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
        }
    }
}
