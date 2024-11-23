using BusinessLogic.Helpers;
using BusinessLogic.IService;
using BusinessLogic.IService.ITeachingScheduleService.Dto;

namespace Presentation.Forms.Menus
{
    public partial class ViewTimeTable : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        public ViewTimeTable(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this._serviceManager = serviceManager;
        }
        public class Schedule
        {
            public string Room { get; set; }
            public string Day { get; set; }
            public string CourseName { get; set; }
            public string Time { get; set; }
            public string Teacher { get; set; }
        }
        private void ViewTimeTable_Load(object sender, EventArgs e)
        {
            
            var resultSchedules = _serviceManager.TeachingScheduleService.GetTimeTable(UserSession.UserId).Items;
            tableLayoutPanel1.ColumnCount = 8; 
            tableLayoutPanel1.RowCount = 6;    

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            AddCell("Phòng", 0, 0, true);
            AddCell("Thứ 2", 1, 0, true);
            AddCell("Thứ 3", 2, 0, true);
            AddCell("Thứ 4", 3, 0, true);
            AddCell("Thứ 5", 4, 0, true);
            AddCell("Thứ 6", 5, 0, true);
            AddCell("Thứ 7", 6, 0, true);
            AddCell("Chủ nhật", 7, 0, true);

            for (int i = 1; i <= 5; i++)
            {
                AddCell($"Phòng {i}", 0, i, false);
            }

            // Gọi hàm đổ dữ liệu
            PopulateSchedule(resultSchedules);
        }
        private void PopulateSchedule(List<TeachingScheduleReadDto> schedules)
        {
            foreach (var schedule in schedules)
            {
                // Xác định cột dựa trên `Day`
                int column = GetColumnIndex(GetVietnameseDayOfWeek(schedule.Date));
                if (column == -1) continue;

                // Tìm hàng dựa trên Room
                int row = GetRowIndex(schedule.Room);
                if (row == -1) continue;

                // Thêm nội dung vào ô
                string text = $"{schedule.CourseName}\n{schedule.StartAndEndTime}\n{schedule.FactlyName}";
                AddCell(text, column, row, false);
            }
        }
        static string GetVietnameseDayOfWeek(DateTime date)
        {
            // Dùng DayOfWeek để lấy thứ
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Thứ 2";
                case DayOfWeek.Tuesday: return "Thứ 3";
                case DayOfWeek.Wednesday: return "Thứ 4";
                case DayOfWeek.Thursday: return "Thứ 5";
                case DayOfWeek.Friday: return "Thứ 6";
                case DayOfWeek.Saturday: return "Thứ 7";
                case DayOfWeek.Sunday: return "Chủ nhật";
                default: return "";
            }
        }
        private int GetColumnIndex(string day)
        {
            switch (day)
            {
                case "Thứ 2": return 1;
                case "Thứ 3": return 2;
                case "Thứ 4": return 3;
                case "Thứ 5": return 4;
                case "Thứ 6": return 5;
                case "Thứ 7": return 6;
                case "Chủ nhật": return 7;
                default: return -1;
            }
        }
        private int GetRowIndex(string room)
        {
            switch (room)
            {
                case "101": return 1;
                case "102": return 2;
                case "103": return 3;
                case "104": return 4;
                case "105": return 5;
                default: return -1;
            }
        }
        private void AddCell(string text, int column, int row, bool isHeader)
        {
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.None, 
                Dock = DockStyle.Fill
            };

            Label label = new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Font = isHeader ? new Font("Arial", 10, FontStyle.Bold) : new Font("Arial", 10, FontStyle.Regular),
                BackColor = isHeader ? Color.LightGray : Color.White
            };
            panel.Controls.Add(label);

            tableLayoutPanel1.Controls.Add(panel, column, row);
        }

    }

}
