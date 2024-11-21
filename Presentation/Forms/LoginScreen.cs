using BusinessLogic.Helpers;
using BusinessLogic.IService;
using BusinessLogic.IService.IUserService.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Forms
{
    public partial class LoginScreen : BaseForm
    {
        private readonly IServiceManager _serviceManager; 
        private IServiceProvider _serviceProvider;

        public LoginScreen(IServiceProvider serviceProvider, IServiceManager serviceManager)
        {
            InitializeComponent();
            _serviceManager = serviceManager;
            _serviceProvider = serviceProvider;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;
            var permission = _serviceManager.PermissionService.GetAll().Items;
            var role = _serviceManager.RoleService.GetAll().Items;

            //validation
            var result = _serviceManager.UserService.Login(username, password).Data;

            if (result != null)
            {
                UserSession.Username =  result.Username;
                UserSession.RoleName = result.Role.RoleName;
                UserSession.UserId = result.Id;
                var lstPermission = _serviceManager.RolePermissionService.GetAll().Items.Where(x=>x.RoleID == result.RoleID).ToList();
                UserSession.Initialize(lstPermission);
                
                this.Hide();
                var mainForm = _serviceProvider.GetService<MainForm>();
                mainForm.Show();

                this.FormClosed += (s, args) => Application.Exit();

            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
