using BusinessLogic.IService;
using BusinessLogic.IService.IUserService.Dto;
using Presentation.Forms.FormInput;

namespace Presentation.Forms.SubMenu
{
    public partial class Menu_TeachingSchedule : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;
        //private List<OptionItem> lstRole = new List<OptionItem>();
        private List<OptionItem> lstFactly = new List<OptionItem>();
        private List<OptionItem> lstCourse = new List<OptionItem>();

        public Menu_TeachingSchedule(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this._serviceManager = serviceManager;
            mainForm.AddButtonClicked += MainForm_AddButtonClicked;
            mainForm.EditButtonClicked += MainForm_EditButtonClicked;
            mainForm.DeleteButtonClicked += MainForm_DeleteButtonClicked;
            mainForm.SearchButtonClicked += MainForm_SearchButtonClicked;
            mainForm.SetButtonVisibility(true, true, true, true);
        }

        private void Menu_TeachingSchedule_Load(object sender, EventArgs e)
        {
            var resultLstFactly = _serviceManager.FacultyService.GetCombobox().Items;
            lstFactly = resultLstFactly.Select(x => new OptionItem
            {
                Value = x.FacultyId.ToString(),
                Text = x.FullName
            }).ToList();

            var resultLstCourse = _serviceManager.CourseService.GetCombobox().Items;
            lstCourse = resultLstCourse.Select(x => new OptionItem
            {
                Value = x.Id.ToString(),
                Text = x.CourseName
            }).ToList();

            this.OnSearch();
        }

        private void MainForm_SearchButtonClicked(object sender, EventArgs e)
        {
            this.OnSearch();
        }

        private void OnSearch()
        {
            var result = _serviceManager.TeachingScheduleService.Search("test").Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
                {
                    { "ID", e.Id.ToString() },
                    { "STT", (index + 1).ToString() },
                    { "FacultyName", e.Faculty.FirstName + ' ' + e.Faculty.LastName },
                    { "CourseName", e.Course.CourseName},
                    { "Time", e.StartAndEndTime},
                    { "Date", e.Date.ToShortDateString()},
                }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();

        }

        private void MainForm_AddButtonClicked(object sender, EventArgs e)
        {
            var fields = new List<InputField>
            {
                new InputField(label:"Username",type:"text", required: true),
                new InputField(label:"PasswordHash",type: "text_password", required : true),
                //new InputField(label: "RoleID", type: "combobox", value: "", options: this.lstRole)
            };

            var inputForm = new InputForm(fields, entity: new UserCreateDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                UserCreateDto userCreate = (UserCreateDto)inputForm.GetEntity();
                var result = _serviceManager.UserService.Create(userCreate);
                if (result.Code == 0)
                {
                    MessageBox.Show("Thêm mới thành công");
                    this.OnSearch();
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
                var valueById = _serviceManager.UserService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"Id",type:"text", value: valueById.Data.Id.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"Username",type:"text", value: valueById.Data.Username, required: true, isReadOnly: true),
                    new InputField(label:"PasswordHash",type: "text_password",value: valueById.Data.PasswordHash, required : true),
                    //new InputField(label: "RoleID", type: "combobox", value: valueById.Data.RoleID.ToString(), options: this.lstRole)
                };
                var inputForm = new InputForm(fields, entity: new UserUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    UserUpdateDto userCreate = (UserUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.UserService.Update(userCreate);
                    if (result.Code == 0)
                    {
                        MessageBox.Show("Cập nhập thành công");
                        this.OnSearch();
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
                    var delete = _serviceManager.UserService.Delete(this.IdSelectListView);
                    if (delete.Code == 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        this.OnSearch();
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

        private void Menu_TeachingSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.AddButtonClicked -= MainForm_AddButtonClicked;
            mainForm.EditButtonClicked -= MainForm_EditButtonClicked;
            mainForm.DeleteButtonClicked -= MainForm_DeleteButtonClicked;
            mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
