using Presentation.Forms.FormInput;

namespace Presentation.Forms.SubMenu
{
    public partial class Menu_Users : Form
    {
        private MainForm mainForm;
        public Menu_Users(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            mainForm.AddButtonClicked += MainForm_AddButtonClicked;
            mainForm.EditButtonClicked += MainForm_EditButtonClicked;
            mainForm.DeleteButtonClicked += MainForm_DeleteButtonClicked;
            mainForm.SearchButtonClicked += MainForm_SearchButtonClicked;
        }

        private void Menu_Users_Load(object sender, EventArgs e)
        {
            var data = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "ID", "1" },
                    {"STT", "1" },
                    { "Name", "John Doe" },
                    { "Age", "30" },
                    { "Position", "Developer" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "2" },
                    {"STT", "2" },
                    { "Name", "Jane Smith" },
                    { "Age", "28" },
                    { "Position", "Designer" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
                new Dictionary<string, string>
                {
                    { "ID", "3" },
                    {"STT", "3" },
                    { "Name", "Alice Johnson" },
                    { "Age", "35" },
                    { "Position", "Manager" }
                },
            };

            customListView1.SetData(data);
            lblPageInfo.Text = customListView1.GetPageInfo();
        }

        private void MainForm_SearchButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Search button clicked in ChildForm");
        }

        private void MainForm_AddButtonClicked(object sender, EventArgs e)
        {
            OpenInputForm();
        }

        private void MainForm_EditButtonClicked(object sender, EventArgs e)
        {
            OpenInputForm();

            MessageBox.Show("Edit button clicked in ChildForm");
        }

        private void MainForm_DeleteButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Delete button clicked in ChildForm");
        }
        private void OpenInputForm()
        {
            var fields = new List<InputField>
            {
                new InputField(label:"Tên người dùng",type:"text", required: true),
                new InputField(label:"Mật khẩu",type: "text_password", required : true),
                new InputField(label: "Quyền hạn", type: "combobox", value: "Quản lý", options: new List<OptionItem>
                    {
                        new OptionItem { Text = "Nhân viên", Value = "1" },
                        new OptionItem { Text = "Quản lý", Value = "2" },
                        new OptionItem { Text = "Giám đốc", Value = "3" }
                    })
            };

            var inputForm = new InputForm(fields);
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Dữ liệu đã được lưu!");
            }
        }

        private void customListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customListView1.SelectedItems.Count > 0)
            {
                var selectedItem = customListView1.SelectedItems[0];

                // Lấy giá trị ẩn từ Tag
                string hiddenId = selectedItem.Tag.ToString();


                // Lấy thông tin hiển thị khác
                string name = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                MessageBox.Show($"Hidden ID: {hiddenId}, Name: {name}", "Dòng được chọn");
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
    }
}
