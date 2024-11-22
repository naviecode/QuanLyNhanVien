using BusinessLogic.IService;
using BusinessLogic.IService.IClassService.Dto;
using BusinessLogic.IService.IDepartmentService.Dto;
using BusinessLogic.IService.IStudentService.Dto;
using Data.Repository;
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
    public partial class Menu_Class : Form
    {
        private MainForm _mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;
        private List<OptionItem> lstDepartment = new List<OptionItem>();

        public Menu_Class(MainForm mainForm, IServiceManager serviceManager)
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
        private void Menu_Class_Load(object sender, EventArgs e)
        {
            var resultLstDepartment = _serviceManager.DepartmentService.GetCombobox().Items;
            lstDepartment = resultLstDepartment.Select(x => new OptionItem
            {
                Value = x.DepartmentId.ToString(),
                Text = x.DepartmentName
            }).ToList();
            this.OnSearch(GetSearchFilterInput());
        }
        private void OnSearch(ClassFilterSearchDto filterInput)
        {
            var result = _serviceManager.ClassService.Search(filterInput).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.ClassId.ToString() },
                { "STT", (index + 1).ToString() },
                { "Tên lớp", e.ClassName },
                { "Niên khóa", e.ClassYear },
                { "Tên khoa", e.DepartmentName },
            }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }

        private void MainForm_SearchButtonClicked(object? sender, EventArgs e)
        {
            this.OnSearch(GetSearchFilterInput());
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
                    var delete = _serviceManager.ClassService.Delete(this.IdSelectListView);
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

        private void MainForm_EditButtonClicked(object? sender, EventArgs e)
        {
            if (this.IdSelectListView != 0)
            {
                var valueById = _serviceManager.ClassService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"ClassId",type:"text", value: valueById.Data.ClassId.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"ClassName",type:"text", value: valueById.Data.ClassName, required: true),
                    new InputField(label:"ClassYear",type:"text", value: valueById.Data.ClassYear, required: true),
                    new InputField(label:"DepartmentId",type:"combobox", value: valueById.Data.DepartmentId.ToString(), options: this.lstDepartment, required: true),
                };
                var inputForm = new InputForm(fields, entity: new ClassUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    ClassUpdateDto classUpdate = (ClassUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.ClassService.Update(classUpdate);
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

        private void MainForm_AddButtonClicked(object? sender, EventArgs e)
        {
            var fields = new List<InputField>
            {
                new InputField(label:"ClassName",type:"text", required: true),
                new InputField(label:"ClassYear",type:"text", required: true),
                new InputField(label:"DepartmentId",type:"combobox", value: "", options: this.lstDepartment, required: true),
            };

            var inputForm = new InputForm(fields, entity: new ClassAddDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                ClassAddDto classCreate = (ClassAddDto)inputForm.GetEntity();
                var result = _serviceManager.ClassService.Create(classCreate);
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
        private ClassFilterSearchDto GetSearchFilterInput()
        {
            var filterInput = new ClassFilterSearchDto
            {
                ClassName = txtLopHoc.Text.Trim(),
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

        private void Menu_Class_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.AddButtonClicked -= MainForm_AddButtonClicked;
            _mainForm.EditButtonClicked -= MainForm_EditButtonClicked;
            _mainForm.DeleteButtonClicked -= MainForm_DeleteButtonClicked;
            _mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
