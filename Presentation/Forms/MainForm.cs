using BusinessLogic.Helpers;
using BusinessLogic.IService;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms.SubMenu;

namespace Presentation.Forms
{
    public partial class MainForm : Form
    {
        public event EventHandler SearchButtonClicked;
        public event EventHandler AddButtonClicked;
        public event EventHandler EditButtonClicked;
        public event EventHandler DeleteButtonClicked;
        bool menuExpand = false;

        #region Form
        Dashboard dashboard;
        Settings settings;
        Menu_QLSV menuQLSV;
        Menu_Users menuUsers;
        #endregion

        #region Service
        private readonly IServiceManager _serviceManager;
        private IServiceProvider _serviceProvider;

        #endregion


        public MainForm(IServiceProvider serviceProvider, IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            OpenDashboard();
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 40;
                if (menuContainer.Height >= 430)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 40;
                if (menuContainer.Height <= 43)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void btnChucNang_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            UserSession.Clear();
            this.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UserSession.Username == null)
            {
                var loginForm = _serviceProvider.GetService<LoginScreen>();
                if (loginForm != null)
                {
                    loginForm.Show(); 
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private async void btnCaidat_Click(object sender, EventArgs e)
        {
            if (settings == null)
            {
                settings = new Settings();
                settings.FormClosed += Settings_FormClosed;
                settings.MdiParent = this;
                settings.Dock = DockStyle.Fill;
                settings.Show();
            }
            else
            {
                settings.Activate();
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            settings = null;
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            OpenDashboard();
        }

        private void OpenDashboard()
        {
            SetNavigation(false);
            if (dashboard == null)
            {
                dashboard = new Dashboard(this);
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }

        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }

        private void btnChucNang1_Click(object sender, EventArgs e)
        {

        }

        private void btnChucNang2_Click(object sender, EventArgs e)
        {

        }

        private void btnChucNang3_Click(object sender, EventArgs e)
        {

        }

        private void btnChucNang4_Click(object sender, EventArgs e)
        {

        }

        private void btnChucNang5_Click(object sender, EventArgs e)
        {

        }

        private void btnChucNang6_Click(object sender, EventArgs e)
        {

        }

        private void btnChucNang7_Click(object sender, EventArgs e)
        {

        }

        private void btnChucNang8_Click(object sender, EventArgs e)
        {

        }

        private void btnChucNang9_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý tài khoản";
            SetNavigation(true);
            if (menuUsers == null)
            {
                menuUsers = new Menu_Users(this);
                menuUsers.FormClosed += MenuUsers_FormClosed;
                menuUsers.MdiParent = this;
                menuUsers.Dock = DockStyle.Fill;
                menuUsers.Show();
            }
            else
            {
                menuUsers.Activate();
            }
        }
        private void MenuUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            SearchButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetNavigation(bool showNav)
        {
            palNav.Visible = showNav;
        }

        public void SetButtonVisibility(bool showSearch, bool showAdd, bool showEdit, bool showDelete)
        {
            btnTim.Visible = showSearch;
            btnThem.Visible = showAdd;
            btnSua.Visible = showEdit;
            btnXoa.Visible = showDelete;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
