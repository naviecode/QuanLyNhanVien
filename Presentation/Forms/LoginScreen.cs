using BusinessLogic.IService.IUserService;

namespace Presentation.Forms
{
    public partial class LoginScreen : BaseForm
    {
        private readonly IUserService _userService;
        public LoginScreen(IUserService userSerivce)
        {
            InitializeComponent();
            _userService = userSerivce;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var abc = _userService.Delete(1);
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
