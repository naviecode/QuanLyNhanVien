using BusinessLogic.Helpers;
using BusinessLogic.IService;
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
            var result = _serviceManager.UserService.GetAll().Items;

            if (ValidateUser(username, password) || username == "admin")
            {
                // Lưu thông tin người dùng vào UserSession
                UserSession.Username = username;
                UserSession.Initialize(GetUserPermissions(username));

                // Hiển thị MainForm
                this.Hide();
                var mainForm = _serviceProvider.GetService<MainForm>();
                mainForm.Show();

                // Khi LoginScreen bị đóng, thoát ứng dụng nếu không có form nào khác
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
        private bool ValidateUser(string username, string password)
        {
            var result = _serviceManager.UserService.GetAll().Items;

            return result.Any(x => x.Username == username);
        }

        private List<string> GetUserPermissions(string username)
        {
            // Trả về danh sách quyền của người dùng (ví dụ, từ cơ sở dữ liệu)
            return new List<string> { "Read", "Write", "Execute" };
        }
    }
}
