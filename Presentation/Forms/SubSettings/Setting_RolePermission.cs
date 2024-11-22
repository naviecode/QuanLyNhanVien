using BusinessLogic.IService;
using BusinessLogic.IService.IRolePermissions.Dto;
using BusinessLogic.IService.IUserService.Dto;
using Presentation.Forms.FormInput;
using System.Data;

namespace Presentation.Forms.SubSettings
{
    public partial class Setting_RolePermission : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        private int IdSelectListView; 
        private List<OptionItem> lstRole = new List<OptionItem>();
        private List<OptionItem> lstPermission = new List<OptionItem>();


        public Setting_RolePermission(MainForm mainForm, IServiceManager serviceManager)
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


        private void Setting_RolePermission_Load(object sender, EventArgs e)
        {
            var resultLstRole = _serviceManager.RoleService.GetCombobox().Items;
            lstRole = resultLstRole.Select(x => new OptionItem
            {
                Value = x.Id.ToString(),
                Text = x.RoleName
            }).ToList();
            var resultLstPermission = _serviceManager.PermissionService.GetCombobox().Items;
            lstPermission = resultLstPermission.Select(x => new OptionItem
            {
                Value = x.Id.ToString(),
                Text = x.PermissionName
            }).ToList();
            this.OnSearch();
        }

        private void MainForm_SearchButtonClicked(object sender, EventArgs e)
        {
            this.OnSearch();
        }

        private void OnSearch()
        {
            var result = _serviceManager.RolePermissionService.Search(txtChucDanh.Text, txtQuyen.Text).Items;
            List<Dictionary<string, string>> data = result.Select((e, index) => new Dictionary<string, string>
            {
                { "ID", e.Id.ToString() },
                { "STT", (index + 1).ToString() },
                { "RoleName", e.Role.RoleName },
                { "PermissionName", e.Permission.PermissionName.ToString() }
            }).ToList();

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }

        private void MainForm_AddButtonClicked(object sender, EventArgs e)
        {
            var fields = new List<InputField>
            {
                new InputField(label: "RoleID", type: "combobox", value: "", options: this.lstRole, required: true),
                new InputField(label: "PermissionID", type: "combobox", value: "", options: this.lstPermission, required: true)
            };

            var inputForm = new InputForm(fields, entity: new RolePermissionsCreateDto());
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                RolePermissionsCreateDto input = (RolePermissionsCreateDto)inputForm.GetEntity();
                var result = _serviceManager.RolePermissionService.Create(input);
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
                var valueById = _serviceManager.RolePermissionService.GetById(this.IdSelectListView);
                var fields = new List<InputField>
                {
                    new InputField(label:"Id",type:"text", value: valueById.Data.Id.ToString(), required: true, isReadOnly: true),
                    new InputField(label: "RoleID", type: "combobox", value: valueById.Data.RoleID.ToString(), options: this.lstRole , required: true),
                    new InputField(label: "PermissionID", type: "combobox", value: valueById.Data.PermissionID.ToString(), options: this.lstPermission, required: true)
                };
                var inputForm = new InputForm(fields, entity: new RolePermissionsUpdateDto());

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    RolePermissionsUpdateDto input = (RolePermissionsUpdateDto)inputForm.GetEntity();
                    var result = _serviceManager.RolePermissionService.Update(input);
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
                    var delete = _serviceManager.RolePermissionService.Delete(this.IdSelectListView);
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

        private void Setting_RolePermission_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.AddButtonClicked -= MainForm_AddButtonClicked;
            mainForm.EditButtonClicked -= MainForm_EditButtonClicked;
            mainForm.DeleteButtonClicked -= MainForm_DeleteButtonClicked;
            mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }

       
    }
}
