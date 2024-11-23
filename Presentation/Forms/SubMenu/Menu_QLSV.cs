using BusinessLogic.IService;
using BusinessLogic.IService.IStudentService.Dto;
using BusinessLogic.IService.IUserService.Dto;
using BusinessLogic.Services;
using Data.Entities;
using Data.IRepository;
using Data.Repository;
using Presentation.Forms.FormInput;
using System.Linq;

namespace Presentation.Forms.SubMenu
{

    public partial class Menu_QLSV : Form
    {
        private MainForm _mainForm;
        private readonly IServiceManager _serviceManager;
        private List<OptionItem> lstGender = new List<OptionItem>
        {
            new OptionItem { Text = "Nam", Value = "Nam" },
            new OptionItem { Text = "Nữ", Value = "Nữ" }
        };
        private int IdSelectListView;
        private List<OptionItem> lstClass = new List<OptionItem>();

        public Menu_QLSV(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _serviceManager = serviceManager;
            // Đăng ký sự kiện
            _mainForm.AddButtonClicked += MainForm_AddButtonClicked;
            _mainForm.EditButtonClicked += MainForm_EditButtonClicked;
            _mainForm.DeleteButtonClicked += MainForm_DeleteButtonClicked;
            _mainForm.SearchButtonClicked += MainForm_SearchButtonClicked;
            this._mainForm.SetButtonVisibility(true, true, true, true);
        }
        private void Menu_Students_Load(object sender, EventArgs e)
        {
            var resultLstClass = _serviceManager.ClassService.GetCombobox().Items;
            lstClass = resultLstClass.Select(x => new OptionItem
            {
                Value = x.ClassId.ToString(),
                Text = x.ClassName
            }).ToList();
            this.OnSearch(GetSearchFilterInput());
        }
        private void MainForm_SearchButtonClicked(object sender, EventArgs e)
        {
            var filterInput = GetSearchFilterInput();
            this.OnSearch(filterInput);
        }

        private void OnSearch(StudentSearchFilterDto filterInput)
        {
            var result = _serviceManager.StudentService.Search(filterInput).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.StudentId.ToString() },
                { "STT", (index + 1).ToString() },
                { "Họ và tên", e.FullName },
                { "Lớp", e.ClassName },
                { "Ngày sinh", e.DateOfBirth.ToString("dd/mm/yyyy") },
                { "Họ và tên", e.FullName },
                { "Giới tính", e.Gender },
                { "Email", e.Email },
                { "Số điện thoại", e.PhoneNumber },
                { "Địa chỉ", e.Address },
                { "Quê quán", e.HomeTown },
                { "Ngày vào học", e.EnrollmentDate.ToString("dd/mm/yyyy") },
            }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }
        private void MainForm_AddButtonClicked(object sender, EventArgs e)
        {
            var fields = new List<InputField>
            {
                new InputField(label:"LastName",type:"text", required: true),
                new InputField(label:"FirstName",type:"text", required: true),
                new InputField(label:"DateOfBirth",type:"date", required: true),
                new InputField(label:"Gender",type:"combobox", value: "", options: this.lstGender),
                new InputField(label:"Email",type:"text"),
                new InputField(label:"PhoneNumber",type:"text"),
                new InputField(label:"Address",type:"text"),
                new InputField(label:"HomeTown",type:"text"),
                new InputField(label:"ClassName", type: "combobox", value: "", options: this.lstClass),
                new InputField(label:"EnrollmentDate",type:"date", required: true),
                new InputField(label:"Username",type:"text", required: true),
                new InputField(label:"PasswordHash",type: "text_password", required : true),
            };

            var inputForm = new InputForm(fields, entity: new StudentAddDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                StudentAddDto studentCreate = (StudentAddDto)inputForm.GetEntity();
                var result = _serviceManager.StudentService.Create(studentCreate);
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

        private void MainForm_EditButtonClicked(object sender, EventArgs e)
        {
            if (this.IdSelectListView != 0)
            {
                var valueById = _serviceManager.StudentService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"Id",type:"text", value: valueById.Data.Id.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"LastName",type:"text", value: valueById.Data.LastName, required: true),
                    new InputField(label:"FirstName",type:"text", value: valueById.Data.FirstName, required: true),
                    new InputField(label:"DateOfBirth",type:"date", value: valueById.Data.DateOfBirth.ToString("dd/mm/yyyy"), required: true),
                    new InputField(label:"Gender",type:"combobox", value: valueById.Data.Gender, options: this.lstGender),
                    new InputField(label:"Email",type:"text", value: valueById.Data.Email),
                    new InputField(label:"PhoneNumber",type:"text", value: valueById.Data.PhoneNumber),
                    new InputField(label:"Address",type:"text", value : valueById.Data.Address),
                    new InputField(label:"HomeTown",type:"text", value : valueById.Data.HomeTown),
                    new InputField(label:"ClassName", type: "combobox", value: valueById.Data.ClassId.ToString(), options: this.lstClass, isReadOnly: true),
                    new InputField(label:"EnrollmentDate",type:"date", value: valueById.Data.EnrollmentDate.ToString("dd/mm/yyyy"), required: true),
                    new InputField(label:"Username",type:"text",value: valueById.Data.Username, required: true, isReadOnly: true),
                    new InputField(label:"PasswordHash",type: "text_password", value: valueById.Data.PasswordHash, required : true),
                };
                var inputForm = new InputForm(fields, entity: new StudentUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    StudentUpdateDto userUpdate = (StudentUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.StudentService.Update(userUpdate);
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

        private void MainForm_DeleteButtonClicked(object sender, EventArgs e)
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
                    var delete = _serviceManager.StudentService.Delete(this.IdSelectListView);
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
        private StudentSearchFilterDto GetSearchFilterInput()
        {
            var filterInput = new StudentSearchFilterDto
            {
                FullName = txtFullName.Text.Trim(),
                Gender = cbGender.SelectedItem?.ToString()?.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddr.Text.Trim(),
                ClassName = txtClassName.Text.Trim(),
                HomeTown = txtHomeTown.Text.Trim(),
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

        private void Menu_QLSV_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.AddButtonClicked -= MainForm_AddButtonClicked;
            _mainForm.EditButtonClicked -= MainForm_EditButtonClicked;
            _mainForm.DeleteButtonClicked -= MainForm_DeleteButtonClicked;
            _mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
