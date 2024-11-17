namespace Presentation.Forms.SubMenu
{

    public partial class Menu_QLSV : Form
    {
        private MainForm _mainForm;

        public Menu_QLSV(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            // Đăng ký sự kiện
            _mainForm.AddButtonClicked += MainForm_AddButtonClicked;
            _mainForm.EditButtonClicked += MainForm_EditButtonClicked;
            _mainForm.DeleteButtonClicked += MainForm_DeleteButtonClicked;
        }

        private void MainForm_AddButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Add button clicked in ChildForm");
        }

        private void MainForm_EditButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Edit button clicked in ChildForm");
        }

        private void MainForm_DeleteButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Delete button clicked in ChildForm");
        }
    }
}
