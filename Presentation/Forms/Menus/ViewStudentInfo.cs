using BusinessLogic.Helpers;
using BusinessLogic.IService;
using BusinessLogic.IService.IDepartmentService.Dto;
using BusinessLogic.IService.IStudentService.Dto;
using BusinessLogic.IService.IUserService.Dto;
using Presentation.Forms.FormInput;

namespace Presentation.Forms.Menus
{
    public partial class ViewStudentInfo : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;

        public ViewStudentInfo(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this._serviceManager = serviceManager;
            mainForm.SetButtonVisibility(false, false, false, false);

        }
        private void ViewStudentInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void ViewStudentInfo_Load(object sender, EventArgs e)
        {
            this.onPermission();
        }

        private void onPermission()
        {
            if (UserSession.RoleName.ToUpper().ToString() == Role.SINHVIEN.ToString())
            {
                var filterInput = new StudentGetInfoFilterDto();
                filterInput.UserCurrentId = UserSession.UserId;
                GetInfo(filterInput);
                btnCapNhap.Enabled = true;
                btnDoiMatKhau.Enabled = true;
            }
        }

        private void GetInfo(StudentGetInfoFilterDto filterInput)
        {
            var student = _serviceManager.StudentService.GetInfoUser(filterInput).Data;
            ////showinfo
            txtMaSv.Text = student.StudentId.ToString();
            txtTenSv.Text = student.FullName.ToString();
            txtGioiTinh.Text = student.Gender.ToString();
            txtNgayNhapHoc.Text = student.EnrollmentDate.ToShortDateString();
            txtQueQuan.Text = "HCM";
            txtNgaySinh.Text = student.DateOfBirth.ToShortDateString();
            txtKhoa.Text = student.DepartmentName;
            txtMaLop.Text = student.ClassName;
            txtSDT.Text = student.PhoneNumber;
            txtEmail.Text = student.Email;
            txtAddress.Text = student.Address;

        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            var valueById = _serviceManager.StudentService.GetById(int.Parse(txtMaSv.Text));
            var fields = new List<InputField>
                {
                    new InputField(label:"Id",type:"text", value: valueById.Data.Id.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"Email",type:"text", value: valueById.Data.Email, required: true),
                    new InputField(label:"Address",type: "text",value: valueById.Data.Address, required : true),
                    new InputField(label:"PhoneNumber",type: "text",value: valueById.Data.PhoneNumber, required : true)
                };
            var inputForm = new InputForm(fields, entity: new StudentUpdateDto());
            
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                StudentUpdateDto input = (StudentUpdateDto)inputForm.GetEntity();
                input.UserId = valueById.Data.UserId;
                input.PasswordHash =  valueById.Data.PasswordHash;
                input.Username = valueById.Data.Username;
                input.FirstName = valueById.Data.FirstName;
                input.LastName = valueById.Data.LastName;
                input.DateOfBirth = valueById.Data.DateOfBirth; ;
                input.Gender = valueById.Data.Gender;
                input.Email = input.Email;
                input.PhoneNumber = input.PhoneNumber;
                input.Address = input.Address;
                input.EnrollmentDate = valueById.Data.EnrollmentDate;
                var result = _serviceManager.StudentService.Update(input);
                if (result.Code == 0)
                {
                    MessageBox.Show("Cập nhập thành công");
                    this.onPermission();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            var valueById = _serviceManager.UserService.GetById(UserSession.UserId);
            var fields = new List<InputField>
                {
                    new InputField(label:"Id",type:"text", value: valueById.Data.Id.ToString(), required: true, isReadOnly: true),
                    new InputField(label:"PassOld",type:"text_password", value: "", required: true),
                    new InputField(label:"PassNew",type:"text_password", value: "", required: true)
                };
            var inputForm = new InputForm(fields, entity: new UserChangePassDto());

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                UserChangePassDto input = (UserChangePassDto)inputForm.GetEntity();

                var result = _serviceManager.UserService.ChangePassword(input.Id, input.PassOld, input.PassNew);
                if (result.Code == 0)
                {
                    MessageBox.Show("Cập nhập thành công");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }
    }
}
