using BusinessLogic.IService;
using System.Windows.Forms.DataVisualization.Charting;

namespace Presentation.Forms
{
    public partial class Dashboard : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;

        public Dashboard(MainForm mainForm, IServiceManager serviceManager)
        {
            this.mainForm = mainForm;
            this._serviceManager = serviceManager;
            InitializeComponent();
            chartStudent.Series["Series1"].Points.AddXY("Tháng 1", 500);
            chartStudent.Series["Series1"].Points.AddXY("Tháng 2", 700);
            chartStudent.Series["Series1"].Points.AddXY("Tháng 3", 1000);

            chartStudent.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

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
  
            var course = _serviceManager.CourseService.CourseNearClose();
            var students = _serviceManager.DepartmentService.DepartmentCountStudent().Items;
            var studentTrend = _serviceManager.StudentService.StudentTrend().Items;

            dgvDataCourse.DataSource = course.Items;
            dgvDataCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDataCourse.Columns["EndRegisterDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDataCourse.Columns["CourseName"].HeaderText = "Tên khóa học";
            dgvDataCourse.Columns["EndRegisterDate"].HeaderText = "Ngày đóng đăng ký";
            dgvDataCourse.Columns["MaxAmountRegist"].HeaderText = "Số SV có thể đăng ký";
            dgvDataCourse.Columns["Status"].HeaderText = "Trạng thái";



             DisplayLineChart(chartStudentTrend, "Sinh vien nhập học theo từng năm", studentTrend.Select(x => x.Year).ToArray(), studentTrend.Select(x => x.CountStudent).ToArray());
             DisplayPieChart(chartStudent, "Sinh viên theo khoa", students.Select(x => x.DepartmentName).ToArray(), students.Select(x => x.StudentCount).ToArray());
        }
        private void DisplayPieChart(Chart chart, string title, string[] labels, int[] values)
        {
            chart.Series.Clear();

            Series series = new Series
            {
                Name = "PieSeries",
                ChartType = SeriesChartType.Pie
            };

            chart.Series.Add(series);

            for (int i = 0; i < labels.Length; i++)
            {
                series.Points.Add(values[i]);
                series.Points[i].LegendText = labels[i];
                series.Points[i].Label = $"{labels[i]}: {values[i]}";
            }

            chart.Titles.Clear();
            chart.Titles.Add(title);
            chart.Legends[0].Enabled = true;
        }

        private void DisplayLineChart(Chart chart, string title, int[] years, int[] studentCounts)
        {
            chart.Series.Clear();

            Series series = new Series
            {
                Name = "Sinh vien nhập học theo từng năm",
                ChartType = SeriesChartType.Line,
                BorderWidth = 3, 
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8 
            };

            chart.Series.Add(series);

            for (int i = 0; i < years.Length; i++)
            {
                series.Points.AddXY(years[i], studentCounts[i]);
            }

            chart.Titles.Clear();
            chart.Titles.Add(title);

            chart.ChartAreas[0].AxisX.Title = "Năm";
            chart.ChartAreas[0].AxisY.Title = "Số lượng sinh viên";

            chart.ChartAreas[0].AxisX.Interval = 1; 
            chart.ChartAreas[0].AxisY.Interval = 50; 

            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
        }
    }
}
