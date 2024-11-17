namespace Presentation.Forms
{
    public partial class BaseForm : Form
    {
        private Panel loadingPanel;
        private Label loadingLabel;

        public BaseForm()
        {
            InitializeComponent();
            InitializeLoading();
        }

        private void InitializeLoading()
        {
            loadingPanel = new Panel
            {
                BackColor = System.Drawing.Color.Black,
                Size = new System.Drawing.Size(200, 100),
                Visible = false
            };

            loadingLabel = new Label
            {
                Text = "Loading...",
                ForeColor = System.Drawing.Color.White,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            loadingPanel.Controls.Add(loadingLabel);
            loadingPanel.Location = new System.Drawing.Point((this.Width - loadingPanel.Width) / 2, (this.Height - loadingPanel.Height) / 2);

            this.Controls.Add(loadingPanel);
        }

        protected void ShowLoading(string message = "Loading...")
        {
            loadingLabel.Text = message;
            loadingPanel.Visible = true;
            loadingPanel.BringToFront();
            this.Enabled = false;
        }

        protected void HideLoading()
        {
            loadingPanel.Visible = false;
            this.Enabled = true;
        }

        protected string GetCurrentUser()
        {
            return "CurrentUser: admin";
        }
    }
}
