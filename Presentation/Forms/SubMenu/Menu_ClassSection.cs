using BusinessLogic.IService;
using BusinessLogic.IService.IClassService.Dto;
using BusinessLogic.IService.IFacultyService.Dto;
using BusinessLogic.Services;
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
    public partial class Menu_ClassSection : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;
        private List<OptionItem> lstClass = new List<OptionItem>();
        private List<OptionItem> lstCourse = new List<OptionItem>();
        private List<OptionItem> lstFaculty = new List<OptionItem>();
        public Menu_ClassSection(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this._serviceManager = serviceManager;
            mainForm.SearchButtonClicked += MainForm_SearchButtonClicked;
            this.mainForm.SetButtonVisibility(true, false, false, false);
        }
        private void Menu_ClassSection_Load(object sender, EventArgs e)
        {
            var resultLstClass = _serviceManager.ClassService.GetCombobox().Items;
            lstClass = resultLstClass.Select(x => new OptionItem
            {
                Value = x.ClassId.ToString(),
                Text = x.ClassId.ToString() + " - " + x.ClassName + " - " + x.ClassYear,
            }).ToList();
            var resultLstCourse = _serviceManager.CourseService.GetCombobox().Items;
            lstCourse = resultLstCourse.Select(x => new OptionItem
            {
                Value = x.Id.ToString(),
                Text = x.Id.ToString() + " - " + x.CourseName + " - " + x.Credits,
            }).ToList();
            var resultLstFaculty = _serviceManager.FacultyService.GetCombobox().Items;
            lstFaculty = resultLstFaculty.Select(x => new OptionItem
            {
                Value = x.FacultyId.ToString(),
                Text = x.FacultyId.ToString() + " - " + x.FullName + " - " + x.DepartmentName,
            }).ToList();
            this.OnSearch(GetSearchFilterInput());
        }
        private void OnSearch(ClassSectionFilterSearchDto filterInput)
        {
            var result = _serviceManager.ClassService.ClassSectionSearch(filterInput).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.ClassSectionId.ToString() },
                { "STT", (index + 1).ToString() },
                { "Tên lớp", e.ClassName },
                { "Tên khóa học", e.CourseName },
                { "Tên giảng viên", e.FacultyName },
                { "Học kỳ", e.Semester },
                { "Năm", e.Year.ToString() },
            }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }

        private void MainForm_SearchButtonClicked(object? sender, EventArgs e)
        {
            this.OnSearch(GetSearchFilterInput());
        }
        private ClassSectionFilterSearchDto GetSearchFilterInput()
        {
            var filterInput = new ClassSectionFilterSearchDto
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

        private void AddNewCourseForClass_Click(object sender, EventArgs e)
        {
            var fields = new List<InputField>
            {
                new InputField(label:"ClassId",type:"search_combobox", required: true, options: this.lstClass),
                new InputField(label:"CourseId",type:"search_combobox", required: true, options: this.lstCourse),
                new InputField(label:"FacultyId",type:"search_combobox", required: true, options: this.lstFaculty),
                new InputField(label:"Semester",type:"text", required: true),
                new InputField(label:"Year", type: "text", required: true),
            };

            var inputForm = new InputForm(fields, entity: new AddCourseToClassDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                AddCourseToClassDto data = (AddCourseToClassDto)inputForm.GetEntity();
                var result = _serviceManager.ClassService.AddCourseToClass(data);
                if (result.Code == 0)
                {
                    MessageBox.Show("Thêm mới thành công");
                    this.OnSearch(GetSearchFilterInput());
                }
                else
                {
                    MessageBox.Show(result.Message);
                }

            }
        }

        private void Menu_ClassSection_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }

        private void customListView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
