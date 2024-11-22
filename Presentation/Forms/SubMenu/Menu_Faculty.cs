using BusinessLogic.IService;
using BusinessLogic.IService.IDepartmentService.Dto;
using BusinessLogic.IService.IFacultyService.Dto;
using BusinessLogic.IService.IUserService.Dto;
using Presentation.Forms.FormInput;
using System.Data;

namespace Presentation.Forms.SubMenu
{
    public partial class Menu_Faculty : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;
        private List<OptionItem> lstDepartment = new List<OptionItem>();

        public Menu_Faculty(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this._serviceManager = serviceManager;
            mainForm.AddButtonClicked += MainForm_AddButtonClicked;
            mainForm.EditButtonClicked += MainForm_EditButtonClicked;
            mainForm.DeleteButtonClicked += MainForm_DeleteButtonClicked;
            mainForm.SearchButtonClicked += MainForm_SearchButtonClicked;
        }
        private void MainForm_SearchButtonClicked(object sender, EventArgs e)
        {
            this.OnSearch(GetSearchFilterInput());
        }

        private void OnSearch(FacultyFilterSearchDto filterInput)
        {
            var result = _serviceManager.FacultyService.Search(filterInput).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.FacultyId.ToString() },
                { "STT", (index + 1).ToString() },
                { "Tên giảng viên", e.FullName },
                { "Email", e.Email },
                { "Số điện thoại", e.PhoneNumber },
                { "Khoa", e.DepartmentName },
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
                new InputField(label:"Email",type:"text"),
                new InputField(label:"PhoneNumber",type:"text"),
                new InputField(label:"DepartmentId", type: "combobox", value: "", options: this.lstDepartment),
                new InputField(label:"Username",type:"text", required: true),
                new InputField(label:"PasswordHash",type: "text_password", required : true),
            };

            var inputForm = new InputForm(fields, entity: new FacultyAddDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                FacultyAddDto facultyCreate = (FacultyAddDto)inputForm.GetEntity();
                var result = _serviceManager.FacultyService.Create(facultyCreate);
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
                var valueById = _serviceManager.FacultyService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"FacultyId",type:"text", required: true, isReadOnly: true),
                    new InputField(label:"LastName",type:"text", required: true),
                    new InputField(label:"FirstName",type:"text", required: true),
                    new InputField(label:"Email",type:"text"),
                    new InputField(label:"PhoneNumber",type:"text"),
                    new InputField(label:"DepartmentId", type: "combobox", value: "", options: this.lstDepartment),
                    new InputField(label:"UserId",type:"text", required: true, isReadOnly: true),
                    new InputField(label:"Username",type:"text", required: true),
                    new InputField(label:"PasswordHash",type: "text_password", required : true),
                };
                var inputForm = new InputForm(fields, entity: new FacultyUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    FacultyUpdateDto facultyCreate = (FacultyUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.FacultyService.Update(facultyCreate);
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
                    var delete = _serviceManager.FacultyService.Delete(this.IdSelectListView);
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
        private FacultyFilterSearchDto GetSearchFilterInput()
        {
            var filterInput = new FacultyFilterSearchDto
            {
                FullName = txtFacultyName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
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

        private void Menu_Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.AddButtonClicked -= MainForm_AddButtonClicked;
            mainForm.EditButtonClicked -= MainForm_EditButtonClicked;
            mainForm.DeleteButtonClicked -= MainForm_DeleteButtonClicked;
            mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }

        private void Menu_Faculty_Load(object sender, EventArgs e)
        {
            var resultLstDepartment = _serviceManager.DepartmentService.GetCombobox().Items;
            lstDepartment = resultLstDepartment.Select(x => new OptionItem
            {
                Value = x.DepartmentId.ToString(),
                Text = x.DepartmentName
            }).ToList();
            this.OnSearch(GetSearchFilterInput());
        }
    }
}
