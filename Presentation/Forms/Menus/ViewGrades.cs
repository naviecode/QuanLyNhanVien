using BusinessLogic.IService;
using BusinessLogic.Services;

namespace Presentation.Forms.Menus
{
    public partial class ViewGrades : Form
    {
        private MainForm mainForm;
        private readonly IServiceManager _serviceManager;
        public ViewGrades(MainForm mainForm, IServiceManager serviceManager)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this._serviceManager = serviceManager;
        }
    }
}
