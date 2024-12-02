using BusinessLogic.IService;
using BusinessLogic.IService.IFacultyService.Dto;
using BusinessLogic.IService.IGradeService.Dto;
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
    public partial class Menu_Grade : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;
        private int courseId;
        public Menu_Grade(MainForm mainForm, IServiceManager serviceManager)
        {
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
        private void OnSearch(StudentGradeFilterSearchDto filterInput)
        {
            var result = _serviceManager.GradeService.SearchGrades(filterInput).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.EnrollmentId.ToString() },
                { "STT", (index + 1).ToString() },
                { "Tên sinh viên", e.StudentName },
                { "Tên khóa học", e.CourseName },
                { "Điểm", e.Grade.ToString() },
                { "Học kỳ", e.Semester },
                { "Năm", e.Year.ToString() },
            }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }
        private StudentGradeFilterSearchDto GetSearchFilterInput()
        {
            var filterInput = new StudentGradeFilterSearchDto
            {
                StudentName = txtStudentName.Text.Trim(),
                CourseName = txtCourseName.Text.Trim(),
                Grade = string.IsNullOrEmpty(txtGrade.Text) ? null : int.Parse(txtGrade.Text),
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
                this.courseId = int.Parse(selectedItem.ToString());
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

        private void btnCapNhatDiem_Click(object sender, EventArgs e)
        {
            if (this.IdSelectListView != 0)
            {
                var valueById = _serviceManager.GradeService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"StudentId",type:"text", value: valueById.Data.StudentId.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"StudentName",type:"text", value: valueById.Data.StudentName, required: true, isReadOnly: true),
                    new InputField(label:"CourseId",type:"text", value: valueById.Data.CourseId.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"CourseName",type:"text", value: valueById.Data.CourseName, required: true, isReadOnly: true),
                    new InputField(label:"Grade",type:"text",value: valueById.Data.Grade.ToString()),
                    new InputField(label:"Semester",type:"text",value: valueById.Data.Semester, isReadOnly: true),
                    new InputField(label:"Year",type:"text", required: true,value: valueById.Data.Year.ToString(), isReadOnly: true),
                };
                var inputForm = new InputForm(fields, entity: new GradeAddOrUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    GradeAddOrUpdateDto gradeCreateOrUpdate = (GradeAddOrUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.GradeService.AddOrUpdateGrade(gradeCreateOrUpdate);
                    if (result.Code == 0)
                    {
                        MessageBox.Show("Cập nhập điểm thành công");
                        this.OnSearch(GetSearchFilterInput());
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần điều chỉnh");
            }
        }

        private void Menu_Grade_Load(object sender, EventArgs e)
        {
            this.OnSearch(GetSearchFilterInput());
        }

        private void Menu_Grade_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
