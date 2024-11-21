using BusinessLogic.IService;

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
            mainForm.SearchButtonClicked += MainForm_SearchButtonClicked;
            mainForm.SetButtonVisibility(true, false,false,false);
        }

        private void MainForm_SearchButtonClicked(object sender, EventArgs e)
        {
        }

        private void ViewStudentInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.SearchButtonClicked -= MainForm_SearchButtonClicked;
        }
    }
}
