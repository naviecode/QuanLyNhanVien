using BusinessLogic.IService;
using BusinessLogic.IService.ICourseService.Dto;
using BusinessLogic.IService.IDepartmentService.Dto;
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
    public partial class Menu_Department : Form
    {
        private MainForm _mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;
        public Menu_Department(MainForm mainForm, IServiceManager serviceManager)
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
        private void Menu_Department_Load(object sender, EventArgs e)
        {
            this.OnSearch(GetSearchFilterInput());
        }
        private void OnSearch(DepartmentFilterSearchDto filterInput)
        {
            var result = _serviceManager.DepartmentService.Search(filterInput).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.DepartmentId.ToString() },
                { "STT", (index + 1).ToString() },
                { "Tên khóa học", e.DepartmentName },
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
                new InputField(label:"DepartmentName",type:"text", required: true),
            };

            var inputForm = new InputForm(fields, entity: new DepartmentAddDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                DepartmentAddDto courseCreate = (DepartmentAddDto)inputForm.GetEntity();
                var result = _serviceManager.DepartmentService.Create(courseCreate);
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
                var valueById = _serviceManager.DepartmentService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"DepartmentId",type:"text", value: valueById.Data.DepartmentId.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"DepartmentName",type:"text", value: valueById.Data.DepartmentName, required: true),
                };
                var inputForm = new InputForm(fields, entity: new DepartmentUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    DepartmentUpdateDto departmentUpdate = (DepartmentUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.DepartmentService.Update(departmentUpdate);
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
                    var delete = _serviceManager.DepartmentService.Delete(this.IdSelectListView);
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
        private DepartmentFilterSearchDto GetSearchFilterInput()
        {
            var filterInput = new DepartmentFilterSearchDto
            {
                DepartmentName = txtDepartmentName.Text.Trim(),
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

        private void Menu_Department_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.AddButtonClicked -= MainForm_AddButtonClicked;
            _mainForm.EditButtonClicked -= MainForm_EditButtonClicked;
            _mainForm.DeleteButtonClicked -= MainForm_DeleteButtonClicked;
            _mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
