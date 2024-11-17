using BusinessLogic.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Forms
{
    public partial class HostForm : Form
    {
        private IServiceProvider _serviceProvider;

        public HostForm()
        {
            this.Load += HostForm_Load;

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
        private void HostForm_Load(object sender, EventArgs e)
        {
            _serviceProvider = Program.ServiceProvider;

            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            var loginForm = _serviceProvider.GetService<LoginScreen>();
            loginForm.FormClosed += (s, e) =>
            {
                if (UserSession.Username != null)
                {
                    ShowMainForm(); 
                }
                else
                {
                    Application.Exit(); 
                }
            };
            loginForm.ShowDialog();
        }

        private void ShowMainForm()
        {
            var mainForm = _serviceProvider.GetService<MainForm>();
            mainForm.Show();
        }

       
    }
}
