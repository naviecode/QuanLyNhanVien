namespace Presentation.Forms.FormInput
{
    public partial class InputForm : BaseForm
    {
        private List<InputField> _fields;
        private Dictionary<string, Control> _inputControls;

        public InputForm(List<InputField> fields)
        {
            InitializeComponent();
            _fields = fields;
            _inputControls = new Dictionary<string, Control>();
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeDynamicInputs();
        }

        private void InitializeDynamicInputs()
        {
            int y = 20; 
            int radioBtnHTotal = 0;
            foreach (var field in _fields)
            {
                var lbl = new Label
                {
                    AutoSize = true,
                    Location = new Point(20, y + 5)
                };

                if (field.IsRequired)
                {
                    lbl.Text = $"{field.Label} *";  
                    lbl.ForeColor = Color.Red;      
                }
                else
                {
                    lbl.Text = field.Label;
                    lbl.ForeColor = Color.Black; 
                }

                Controls.Add(lbl);

                Control inputControl = null;
                switch (field.Type.ToLower())
                {
                    case "text":
                        inputControl = new TextBox
                        {
                            Width = 200,
                            Text = field.Value,
                            Location = new Point(150, y),
                            ReadOnly = field.IsReadOnly
                        };
                        break;
                    case "text_password":
                        inputControl = new TextBox
                        {
                            Width = 200,
                            Text = field.Value,
                            Location = new Point(150, y),
                            UseSystemPasswordChar = true,
                            ReadOnly = field.IsReadOnly
                        };
                        break;

                    case "date":
                        inputControl = new DateTimePicker
                        {
                            Width = 200,
                            Value = DateTime.TryParse(field.Value, out var dateValue) ? dateValue : DateTime.Now,
                            Location = new Point(150, y),
                            Format = DateTimePickerFormat.Custom, 
                            CustomFormat = "dd/MM/yyyy",
                            Enabled = !field.IsReadOnly
                        };
                        break;

                    case "checkbox":
                        inputControl = new CheckBox
                        {
                            Checked = field.Value.ToLower() == "true",
                            Location = new Point(150, y),
                            Enabled = !field.IsReadOnly
                        };
                        break;

                    case "combobox":
                        inputControl = new ComboBox
                        {
                            Width = 200,
                            DataSource = field.Options,
                            SelectedItem = field.Options.FirstOrDefault(option => option.Value == field.Value),
                            DisplayMember = "Text",
                            ValueMember = "Value",
                            Location = new Point(150, y),
                            Enabled = !field.IsReadOnly
                        };
                        break;

                    case "radiobutton":
                        int radioButtonHeight = 30; 

                        inputControl = new FlowLayoutPanel
                        {
                            Width = 200,
                            Location = new Point(150, y),
                            AutoSize = false, 
                            FlowDirection = FlowDirection.TopDown,
                            Enabled = !field.IsReadOnly
                        };

                        int optionsCount = field.Options.Count;
                        int totalHeight = optionsCount * radioButtonHeight;

                        inputControl.Height = totalHeight;
                        radioBtnHTotal = totalHeight;

                        foreach (var option in field.Options)
                        {
                            var radioButton = new RadioButton
                            {
                                Text = option.Text,
                                Checked = option.Value == field.Value,
                                Enabled = !field.IsReadOnly
                            };
                            ((FlowLayoutPanel)inputControl).Controls.Add(radioButton);
                        }

                        break;
                }

                if (inputControl != null)
                {
                    inputControl.Tag = field.Label; 
                    _inputControls[field.Label] = inputControl;
                    Controls.Add(inputControl);
                    if(field.Type.ToLower() == "radiobutton")
                    {
                        y += 40 + radioBtnHTotal;
                    }
                    else
                    {
                        y += 40;
                    }

                }
            }

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Bottom; 
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft; 
            flowLayoutPanel.Padding = new Padding(10);
            flowLayoutPanel.Margin = new Padding(10); 
            flowLayoutPanel.WrapContents = false;

            var btnExit = new Button
            {
                Text = "Thoát",
                Width = 100,
                Location = new Point(50, y)
            };
            btnExit.Click += (s, e) => this.Close();

            var btnSave = new Button
            {
                Text = "Lưu",
                Width = 100,
                Location = new Point(50, y)
            };
            btnSave.Click += BtnSave_Click;

           
            flowLayoutPanel.Controls.Add(btnExit);
            flowLayoutPanel.Controls.Add(btnSave);

            Controls.Add(flowLayoutPanel);

            this.Height = y + 120;
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            var result = new Dictionary<string, string>();
            bool isValid = true;

            foreach (var field in _fields)
            {
                if (_inputControls.TryGetValue(field.Label, out var control))
                {
                    string value = control switch
                    {
                        TextBox textBox => textBox.Text,
                        DateTimePicker datePicker => datePicker.Value.ToString("yyyy-MM-dd"),
                        CheckBox checkBox => checkBox.Checked.ToString(),
                        ComboBox comboBox => comboBox.SelectedValue != null ? comboBox.SelectedValue.ToString() : string.Empty,
                        FlowLayoutPanel flowPanel =>
                            flowPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text ?? string.Empty,
                        _ => string.Empty
                    };

                    // Kiểm tra trường bắt buộc không được bỏ trống
                    if (field.IsRequired && string.IsNullOrWhiteSpace(value))
                    {
                        MessageBox.Show($"{field.Label} không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                        break;
                    }

                    // Kiểm tra nếu là số và không được nhỏ hơn 0
                    if (field.Type.ToLower() == "text" && decimal.TryParse(value, out var numberValue) && numberValue < 0)
                    {
                        MessageBox.Show($"{field.Label} không được nhỏ hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                        break;
                    }

                    result[field.Label] = value;
                }
            }
            if (isValid)
            {
                string display = string.Join(Environment.NewLine, result.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                MessageBox.Show(display, "Kết quả nhập");

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            
        }

    }
}
