using BusinessLogic.Helpers;
using BusinessLogic.IService;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms.Menus;
using Presentation.Forms.SubMenu;
using Presentation.Forms.SubSettings;

namespace Presentation.Forms
{
    public partial class MainForm : Form
    {
        public event EventHandler SearchButtonClicked;
        public event EventHandler AddButtonClicked;
        public event EventHandler EditButtonClicked;
        public event EventHandler DeleteButtonClicked;
        bool menuExpand = false;
        private int heightMenuExpand = 500;
        private int heightButton = 35;
        bool settingExpand = false;

        #region Form
        Dashboard dashboard;
        ViewGrades viewGrades;
        ViewStudentInfo viewStudentInfo;
        Menu_QLSV menuQLSV;
        Menu_Grade menuGrade;
        Menu_Class menuClass;
        Menu_ClassSection menuClassSection;
        Menu_TeachingSchedule menuTeachingSchedule;
        Menu_Course menuCourse;
        Menu_Department menuDepartment;
        Menu_Enrollment menuEnroollment;
        Menu_Faculty menuFaclty;
        Menu_Users menuUsers;
        Menu_Report menuReport;
        ViewTimeTable viewTimeTable;
        Setting_Role settingRole;
        Setting_Permission settingPermission;
        Setting_RolePermission settingRolePermission;
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
            ConfigureMenu();
        }

        private void ConfigureMenu()
        {
            if (!UserSession.HasPermissionName("ViewDashBoard"))
            {
                btnTongQuan.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("ManageStudents"))
            {
                btnChucNang1.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("ManageCourses"))
            {
                btnChucNang2.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("EnrollCourses"))
            {
                btnChucNang3.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("ManageGrade"))
            {
                btnChucNang4.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("ViewGrades"))
            {
                btnViewGrades.Visible = false;
            }
            if (!UserSession.HasPermissionName("ManageFaculty"))
            {
                btnChucNang5.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("ManageClasses"))
            {
                btnChucNang6.Visible = false;
            }
            if (!UserSession.HasPermissionName("ManageDepartments"))
            {
                btnChucNang7.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("GenerateReports"))
            {
                btnChucNang8.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("ViewStudentInfo"))
            {
                btnViewStudentInfo.Visible = false;
            }
            if (!UserSession.HasPermissionName("ManageAccounts"))
            {
                btnChucNang9.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("ManageTeachingSchedule"))
            {
                btnChucNang10.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("ManageClassSection"))
            {
                btnChucNang11.Visible = false;
                heightMenuExpand -= heightButton;
            }
            if (!UserSession.HasPermissionName("AssignPermissions"))
            {
                flpSettingContainer.Visible = false;
            }
            if (!UserSession.HasPermissionName("ViewTimeTable"))
            {
                btnThoiKhoaBieu.Visible = false;
            }
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 40;
                if (menuContainer.Height >= this.heightMenuExpand)
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


        private void settingsTransition_Tick(object sender, EventArgs e)
        {
            if (settingExpand == false)
            {
                flpSettingContainer.Height += 20;
                if (flpSettingContainer.Height >= 170)
                {
                    settingsTransition.Stop();
                    settingExpand = true;
                }
            }
            else
            {
                flpSettingContainer.Height -= 20;
                if (flpSettingContainer.Height <= 43)
                {
                    settingsTransition.Stop();
                    settingExpand = false;
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsTransition.Start();
        }
        private void btnChucNang_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                                "Xác nhận thoát",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserSession.Clear();
                this.Close();
            }
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

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            OpenDashboard();
        }

        private void OpenDashboard()
        {
            SetNavigation(false);
            CloseAllChildForms();
            if (dashboard == null)
            {
                dashboard = new Dashboard(this, _serviceManager);
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
            lblTitlePageCurrent.Text = "Quản lý sinh viên";

        }


        private void btnChucNang2_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý khóa học";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuCourse == null)
            {
                menuCourse = new Menu_Course(this, _serviceManager);
                menuCourse.FormClosed += Course_FormClosed;
                menuCourse.MdiParent = this;
                menuCourse.Dock = DockStyle.Fill;
                menuCourse.Show();
            }
            else
            {
                menuCourse.Activate();
            }

        }

        private void Course_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuCourse = null;
        }

        private void btnChucNang3_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Đăng ký khóa học";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuEnroollment == null)
            {
                menuEnroollment = new Menu_Enrollment();
                menuEnroollment.FormClosed += Enrollment_FormClosed;
                menuEnroollment.MdiParent = this;
                menuEnroollment.Dock = DockStyle.Fill;
                menuEnroollment.Show();
            }
            else
            {
                menuEnroollment.Activate();
            }

        }
        private void Enrollment_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuEnroollment = null;
        }

        private void btnChucNang4_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý điểm";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuGrade == null)
            {
                menuGrade = new Menu_Grade();
                menuGrade.FormClosed += Grade_FormClosed;
                menuGrade.MdiParent = this;
                menuGrade.Dock = DockStyle.Fill;
                menuGrade.Show();
            }
            else
            {
                menuGrade.Activate();
            }

        }
        private void Grade_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuGrade = null;
        }


        private void btnChucNang5_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý giảng viên";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuFaclty == null)
            {
                menuFaclty = new Menu_Faculty(this, _serviceManager);
                menuFaclty.FormClosed += Faculty_FormClosed;
                menuFaclty.MdiParent = this;
                menuFaclty.Dock = DockStyle.Fill;
                menuFaclty.Show();
            }
            else
            {
                menuFaclty.Activate();
            }

        }
        private void Faculty_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuFaclty = null;
        }

        private void btnChucNang6_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý lớp học";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuClass == null)
            {
                menuClass = new Menu_Class(this, _serviceManager);
                menuClass.FormClosed += Class_FormClosed;
                menuClass.MdiParent = this;
                menuClass.Dock = DockStyle.Fill;
                menuClass.Show();
            }
            else
            {
                menuClass.Activate();
            }

        }
        private void Class_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuClass = null;
        }

        private void btnChucNang7_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý khoa";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuDepartment == null)
            {
                menuDepartment = new Menu_Department(this, _serviceManager);
                menuDepartment.FormClosed += Department_FormClosed;
                menuDepartment.MdiParent = this;
                menuDepartment.Dock = DockStyle.Fill;
                menuDepartment.Show();
            }
            else
            {
                menuDepartment.Activate();
            }

        }
        private void Department_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuDepartment = null;
        }
        private void btnChucNang8_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Báo cáo";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuReport == null)
            {
                menuReport = new Menu_Report();
                menuReport.FormClosed += Report_FormClosed;
                menuReport.MdiParent = this;
                menuReport.Dock = DockStyle.Fill;
                menuReport.Show();
            }
            else
            {
                menuReport.Activate();
            }
        }
        private void Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuReport = null;
        }
        private void btnChucNang9_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý tài khoản";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuUsers == null)
            {
                menuUsers = new Menu_Users(this, _serviceManager);
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
            menuUsers = null;
        }

        private void btnChucNang10_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý lịch dạy học";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuTeachingSchedule == null)
            {
                menuTeachingSchedule = new Menu_TeachingSchedule(this, _serviceManager);
                menuTeachingSchedule.FormClosed += MenuTeachingSchedule_FormClosed;
                menuTeachingSchedule.MdiParent = this;
                menuTeachingSchedule.Dock = DockStyle.Fill;
                menuTeachingSchedule.Show();
            }
            else
            {
                menuTeachingSchedule.Activate();
            }
        }
        private void MenuTeachingSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuTeachingSchedule = null;
        }

        private void btnChucNang11_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý khóa học cho lớp";
            SetNavigation(true);
            CloseAllChildForms();
            if (menuClassSection == null)
            {
                menuClassSection = new Menu_ClassSection(this, _serviceManager);
                menuClassSection.FormClosed += MenuClassSection_FormClosed;
                menuClassSection.MdiParent = this;
                menuClassSection.Dock = DockStyle.Fill;
                menuClassSection.Show();
            }
            else
            {
                menuClassSection.Activate();
            }
        }
        private void MenuClassSection_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuClassSection = null;
        }


        private void btnRole_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý chức danh";
            SetNavigation(true);
            CloseAllChildForms();

            if (settingRole == null)
            {
                settingRole = new Setting_Role(this, _serviceManager);
                settingRole.FormClosed += SettingRole_FormClosed;
                settingRole.MdiParent = this;
                settingRole.Dock = DockStyle.Fill;
                settingRole.Show();
            }
            else
            {
                settingRole.Activate();
            }
        }

        private void SettingRole_FormClosed(object sender, FormClosedEventArgs e)
        {
            settingRole = null;
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý quyền hệ thống";
            SetNavigation(true);
            CloseAllChildForms();

            if (settingPermission == null)
            {
                settingPermission = new Setting_Permission(this, _serviceManager);
                settingPermission.FormClosed += SettingPermission_FormClosed;
                settingPermission.MdiParent = this;
                settingPermission.Dock = DockStyle.Fill;
                settingPermission.Show();
            }
            else
            {
                settingPermission.Activate();
            }
        }

        private void SettingPermission_FormClosed(object sender, FormClosedEventArgs e)
        {
            settingPermission = null;
        }

        private void btnRolePermission_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Quản lý cấp quyền cho chức danh";
            SetNavigation(true);
            CloseAllChildForms();

            if (settingRolePermission == null)
            {
                settingRolePermission = new Setting_RolePermission(this, _serviceManager);
                settingRolePermission.FormClosed += SettingRolePermission_FormClosed;
                settingRolePermission.MdiParent = this;
                settingRolePermission.Dock = DockStyle.Fill;
                settingRolePermission.Show();
            }
            else
            {
                settingRolePermission.Activate();
            }
        }

        private void SettingRolePermission_FormClosed(object sender, FormClosedEventArgs e)
        {
            settingRolePermission = null;
        }

        private void btnViewStudentInfo_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Thông tin cá nhân sinh viên";
            SetNavigation(true);
            CloseAllChildForms();

            if (viewStudentInfo == null)
            {
                viewStudentInfo = new ViewStudentInfo(this, _serviceManager);
                viewStudentInfo.FormClosed += ViewStudentInfo_FormClosed;
                viewStudentInfo.MdiParent = this;
                viewStudentInfo.Dock = DockStyle.Fill;
                viewStudentInfo.Show();
            }
            else
            {
                viewStudentInfo.Activate();
            }
        }

        private void ViewStudentInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewStudentInfo = null;
        }

        private void btnViewGrades_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Thông tin điểm số của sinh viên";
            SetNavigation(false);
            CloseAllChildForms();

            if (viewGrades == null)
            {
                viewGrades = new ViewGrades(this, _serviceManager);
                viewGrades.FormClosed += ViewGrades_FormClosed;
                viewGrades.MdiParent = this;
                viewGrades.Dock = DockStyle.Fill;
                viewGrades.Show();
            }
            else
            {
                viewGrades.Activate();
            }
        }

        private void ViewGrades_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewGrades = null;
        }


        private void btnThoiKhoaBieu_Click(object sender, EventArgs e)
        {
            lblTitlePageCurrent.Text = "Thời khóa biểu";
            SetNavigation(true);
            CloseAllChildForms();

            if (viewTimeTable == null)
            {
                viewTimeTable = new ViewTimeTable(this, _serviceManager);
                viewTimeTable.FormClosed += ViewTimeTable_FormClosed;
                viewTimeTable.MdiParent = this;
                viewTimeTable.Dock = DockStyle.Fill;
                viewTimeTable.Show();
            }
            else
            {
                viewTimeTable.Activate();
            }
        }
        private void ViewTimeTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewTimeTable = null;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserCurrent.Text = $"Xin chào bạn: {UserSession.Username}";

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


        public void SetMenuVisibility()
        {

        }



        private void CloseAllChildForms()
        {
            foreach (var childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }


    }
}
