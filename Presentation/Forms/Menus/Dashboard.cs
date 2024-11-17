namespace Presentation.Forms
{
    public partial class Dashboard : Form
    {
        private MainForm mainForm;
        public Dashboard(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }
    }
}
