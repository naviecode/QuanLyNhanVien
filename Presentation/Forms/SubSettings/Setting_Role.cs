using BusinessLogic.IService;
using BusinessLogic.IService.IRoleService.Dto;
using BusinessLogic.IService.IUserService.Dto;
using Presentation.Forms.FormInput;

namespace Presentation.Forms.SubSettings
{
    public partial class Setting_Role : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView;

        public Setting_Role(MainForm mainForm, IServiceManager serviceManager)
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
            this.OnSearch();
        }

        private void OnSearch()
        {
            var result = _serviceManager.RoleService.GetAll().Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.Id.ToString() },
                { "STT", (index + 1).ToString() },
                { "RoleName", e.RoleName }
            }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }

        private void MainForm_AddButtonClicked(object sender, EventArgs e)
        {
            var fields = new List<InputField>
            {
                new InputField(label:"RoleName",type:"text", required: true)
            };

            var inputForm = new InputForm(fields, entity: new RoleCreateDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                RoleCreateDto roleCreate = (RoleCreateDto)inputForm.GetEntity();
                var result = _serviceManager.RoleService.Create(roleCreate);
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
                var valueById = _serviceManager.RoleService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"Id",type:"text", value: valueById.Data.Id.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"RoleName",type:"text", value: valueById.Data.RoleName, required: true, isReadOnly: false)
                };
                var inputForm = new InputForm(fields, entity: new RoleUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    RoleUpdateDto roleUpdate = (RoleUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.RoleService.Update(roleUpdate);
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
                    var delete = _serviceManager.RoleService.Delete(this.IdSelectListView);
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

        private void Setting_Role_Load(object sender, EventArgs e)
        {
            this.OnSearch();
        }

        private void Setting_Role_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.AddButtonClicked -= MainForm_AddButtonClicked;
            mainForm.EditButtonClicked -= MainForm_EditButtonClicked;
            mainForm.DeleteButtonClicked -= MainForm_DeleteButtonClicked;
            mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
