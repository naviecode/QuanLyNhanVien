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
        }
    }
}
