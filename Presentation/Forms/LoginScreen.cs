using BusinessLogic.IService;

namespace Presentation.Forms
{
    public partial class LoginScreen : BaseForm
    {
        private readonly IServiceManager _serviceManager;
        public LoginScreen(IServiceManager serviceManager)
        {
            InitializeComponent();
            _serviceManager = serviceManager;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var abc = _serviceManager.UserService.GetAll();
            if(txtUserName.Text == "admin" && txtPassWord.Text.Length > 0)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Username or password is correct, try again");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
