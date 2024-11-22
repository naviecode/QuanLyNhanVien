using BusinessLogic.IService;
using BusinessLogic.IService.IClassService.Dto;
using BusinessLogic.IService.ICourseService.Dto;
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
    public partial class Menu_Course : Form
    {
        private MainForm _mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;
        public Menu_Course(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _serviceManager = serviceManager;
            // Đăng ký sự kiện
            _mainForm.AddButtonClicked += MainForm_AddButtonClicked;
            _mainForm.EditButtonClicked += MainForm_EditButtonClicked;
            _mainForm.DeleteButtonClicked += MainForm_DeleteButtonClicked;
            _mainForm.SearchButtonClicked += MainForm_SearchButtonClicked;
        }
        private void Menu_Course_Load(object sender, EventArgs e)
        {
            this.OnSearch(GetSearchFilterInput());
        }

        private void OnSearch(CourseSearchFilterDto filterInput)
        {
            var result = _serviceManager.CourseService.Search(filterInput).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.Id.ToString() },
                { "STT", (index + 1).ToString() },
                { "Tên khóa học", e.CourseName },
                { "Số tín chỉ", e.Credits.ToString() },
                { "Ngày bắt đầu đăng kí", e.StartRegisterDate.ToString("dd/mm/yyyy") },
                { "Ngày hết hạn đăng kí", e.EndRegisterDate.ToString("dd/mm/yyyy") },
                { "Số lượng đăng kí còn lại", e.MaxAmountRegist.ToString() },
            }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }

        private void MainForm_SearchButtonClicked(object? sender, EventArgs e)
        {
            this.OnSearch(GetSearchFilterInput());
        }

        private void MainForm_AddButtonClicked(object? sender, EventArgs e)
        {
            var fields = new List<InputField>
            {
                new InputField(label:"CourseName",type:"text", required: true),
                new InputField(label:"Credits",type:"text", required: true),
                new InputField(label:"StartRegisterDate",type:"date", required: true),
                new InputField(label:"EndRegisterDate",type:"date", required: true),
                new InputField(label:"MaxAmountRegist",type:"text", required: true),
            };

            var inputForm = new InputForm(fields, entity: new CourseAddDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                CourseAddDto courseCreate = (CourseAddDto)inputForm.GetEntity();
                var result = _serviceManager.CourseService.Create(courseCreate);
                if (result.Code == 0)
                {
                    MessageBox.Show("Thêm mới thành công");
                    this.OnSearch(GetSearchFilterInput());
                }
                else
                {
                    MessageBox.Show(result.Message);
                }

            };
        }

        private void MainForm_EditButtonClicked(object? sender, EventArgs e)
        {
            if (this.IdSelectListView != 0)
            {
                var valueById = _serviceManager.CourseService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"CourseId",type:"text", value: valueById.Data.CourseId.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"CourseName",type:"text", value: valueById.Data.CourseName, required: true),
                    new InputField(label:"Credits",type:"text", value: valueById.Data.Credits.ToString(), required: true),
                    new InputField(label:"StartRegisterDate", value: valueById.Data.StartRegisterDate.ToString("dd/mm/yyyy"),type:"date", required: true),
                    new InputField(label:"EndRegisterDate", value: valueById.Data.EndRegisterDate.ToString("dd/mm/yyyy"),type:"date", required: true),
                    new InputField(label:"MaxAmountRegist",type:"text", value: valueById.Data.MaxAmountRegist.ToString(""), required: true),
                };
                var inputForm = new InputForm(fields, entity: new CourseUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    CourseUpdateDto courseUpdate = (CourseUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.CourseService.Update(courseUpdate);
                    if (result.Code == 0)
                    {
                        MessageBox.Show("Cập nhập thành công");
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

        private void MainForm_DeleteButtonClicked(object? sender, EventArgs e)
        {
            if (this.IdSelectListView != 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?",
                                "Xác nhận xóa",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Nếu người dùng chọn "Yes", thực hiện hành động xóa
                    var delete = _serviceManager.CourseService.Delete(this.IdSelectListView);
                    if (delete.Code == 0)
                    {
                        MessageBox.Show("Xóa thành công");
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
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
            }
        }
        private CourseSearchFilterDto GetSearchFilterInput()
        {
            var filterInput = new CourseSearchFilterDto
            {
                CourseName = txtCourseName.Text.Trim(),
                Credits = string.IsNullOrEmpty(txtCredits.Text) ? 0 : int.Parse(txtCredits.Text),
                StartRegisterDate = dtpStartRegisterDate.Value != DateTimePicker.MinimumDateTime
                                    ? dtpStartRegisterDate.Value
                                    : DateTime.MinValue,
                EndRegisterDate = dtpEndRegisterDate.Value != DateTimePicker.MinimumDateTime
                                    ? dtpEndRegisterDate.Value
                                    : DateTime.MaxValue

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

        private void Menu_Course_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.AddButtonClicked -= MainForm_AddButtonClicked;
            _mainForm.EditButtonClicked -= MainForm_EditButtonClicked;
            _mainForm.DeleteButtonClicked -= MainForm_DeleteButtonClicked;
            _mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
