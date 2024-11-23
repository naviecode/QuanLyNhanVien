using BusinessLogic.IService;
using BusinessLogic.IService.IClassService.Dto;
using BusinessLogic.IService.IRegistCourseService.Dto;
using Presentation.Forms.FormInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms.SubMenu
{
    public partial class Menu_Enrollment : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;
        private List<OptionItem> lstCourse = new List<OptionItem>();
        public Menu_Enrollment(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            InitializeComponent();
            this.mainForm = mainForm;
            this._serviceManager = serviceManager;
            mainForm.SearchButtonClicked += MainForm_SearchButtonClicked;
            this.mainForm.SetButtonVisibility(true, false, false, false);
        }

        private void MainForm_SearchButtonClicked(object? sender, EventArgs e)
        {
            this.OnSearch(GetSearchFilterInput());
        }

        private void Menu_Enrollment_Load(object sender, EventArgs e)
        {
            var resultLstCourse = _serviceManager.CourseService.GetComboboxWithClasses().Items;
            lstCourse = resultLstCourse.Select(x => new OptionItem
            {
                Value = x.CourseId.ToString(),
                Text = x.CourseId.ToString() + " - " + x.CourseId + " - " + x.ClassName + " - " + x.FacultyName + " - " + x.Semester + " - " + x.Year + " (Số tín chỉ " + x.Credits + ")",
            }).ToList();
            this.OnSearch(GetSearchFilterInput());
        }
        private void OnSearch(RegisteredFilterSearchDto filterInput)
        {
            var result = _serviceManager.RegistCourseService.GetRegisteredCourses(filterInput).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.CourseId.ToString() },
                { "STT", (index + 1).ToString() },
                { "Tên khóa học", e.CourseName },
                { "Tên giảng viên", e.FacultyName },
                { "Tên lớp", e.ClassName },
                { "Số tín chỉ", e.Credits.ToString() },
                { "Học kỳ", e.Semester },
                { "Năm", e.Year.ToString() },
                { "Trạng thái", e.Status },
            }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }
        private RegisteredFilterSearchDto GetSearchFilterInput()
        {
            var filterInput = new RegisteredFilterSearchDto
            {
                ClassName = txtClassName.Text.Trim(),
                CourseName = txtCourseName.Text.Trim(),
                FacultyName = txtFacultyName.Text.Trim(),
                Semester = txtSemester.Text.Trim(),
                Year = string.IsNullOrEmpty(txtYear.Text) ? 0 : int.Parse(txtYear.Text),
            };

            return filterInput;
        }
        private void customListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customListView1.SelectedItems.Count > 0)
            {
                var selectedItem = customListView1.SelectedItems[0];
                this.IdSelectListView = int.Parse(selectedItem.Tag.ToString());
            }
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            customListView1.PreviousPage();
            lblPageInfo.Text = customListView1.GetPageInfo();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            customListView1.NextPage();
            lblPageInfo.Text = customListView1.GetPageInfo();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            var fields = new List<InputField>
            {
                new InputField(label:"CourseId",type:"search_combobox", required: true, options: this.lstCourse),
            };

            var inputForm = new InputForm(fields, entity: new CourseRegistrationDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                CourseRegistrationDto data = (CourseRegistrationDto)inputForm.GetEntity();
                var result = _serviceManager.RegistCourseService.RegisterCourse(data);
                if (result.Code == 0)
                {
                    MessageBox.Show("Đăng kí thành công");
                    this.OnSearch(GetSearchFilterInput());
                }
                else
                {
                    MessageBox.Show(result.Message);
                }

            }
        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            if (this.IdSelectListView != 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn hủy khóa này?",
                                "Xác nhận hủy",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var delete = _serviceManager.RegistCourseService.CancelRegistration(this.IdSelectListView);
                    if (delete.Code == 0)
                    {
                        MessageBox.Show("Hủy khóa học thành công");
                        this.OnSearch(GetSearchFilterInput());
                    }
                    else
                    {
                        MessageBox.Show(delete.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khóa học cần hủy.");
            }
        }

        private void Menu_Enrollment_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
