using System.Globalization;
using System.Resources;

namespace Presentation.Forms.FormInput
{
    public partial class InputForm : Form
    {
        private object _entity;
        private List<InputField> _fields;
        private Dictionary<string, Control> _inputControls;
        private ResourceManager rm = new ResourceManager("Presentation.Resources.Languages", typeof(InputForm).Assembly);
        public InputForm(List<InputField> fields, object entity)
        {
            InitializeComponent();
            _fields = fields;
            _inputControls = new Dictionary<string, Control>();
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeDynamicInputs();
            _entity = entity;
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
                    lbl.Text = $"{rm.GetString(field.Label, CultureInfo.CurrentUICulture) ?? field.Label} *";
                    lbl.ForeColor = Color.Red;
                }
                else
                {
                    lbl.Text = rm.GetString(field.Label, CultureInfo.CurrentUICulture) ?? field.Label;
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
                            Location = new Point(150, y),
                            Enabled = !field.IsReadOnly
                        };

                        foreach (var option in field.Options)
                        {
                            ((ComboBox)inputControl).Items.Add(option);
                        }
                        ((ComboBox)inputControl).DisplayMember = "Text";
                        ((ComboBox)inputControl).ValueMember = "Value";
                        var selectedOption = field.Options.FirstOrDefault(o => o.Value == field.Value);

                        ((ComboBox)inputControl).SelectedIndex = field.Options.IndexOf(selectedOption);

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
                    if (field.Type.ToLower() == "combobox")
                    {
                    }
                    if (field.Type.ToLower() == "radiobutton")
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
                        ComboBox comboBox => comboBox.SelectedItem != null ? ((OptionItem)comboBox.SelectedItem).Value.ToString() : string.Empty,
                        FlowLayoutPanel flowPanel =>
                            flowPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text ?? string.Empty,
                        _ => string.Empty
                    };

                    if (field.IsRequired && string.IsNullOrWhiteSpace(value))
                    {
                        MessageBox.Show($"{rm.GetString(field.Label, CultureInfo.CurrentUICulture) ?? field.Label} không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                        break;
                    }

                    if (field.Type.ToLower() == "text" && decimal.TryParse(value, out var numberValue) && numberValue < 0)
                    {
                        MessageBox.Show($"{rm.GetString(field.Label, CultureInfo.CurrentUICulture) ?? field.Label} không được nhỏ hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                        break;
                    }

                    result[field.Label] = value;
                }
            }
            if (isValid)
            {
                var entity = ConvertDictionaryToObject(result);
                _entity = entity;
                //string display = string.Join(Environment.NewLine, result.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                //MessageBox.Show(display, "Kết quả nhập");

                this.DialogResult = DialogResult.OK;
                this.Close();

            }

        }
        private object ConvertDictionaryToObject(Dictionary<string, string> dictionary)
        {
            var entity = Activator.CreateInstance(_entity.GetType());
            foreach (var kvp in dictionary)
            {
                var property = entity.GetType().GetProperty(kvp.Key);
                if (property != null && property.CanWrite)
                {
                    object value = null;

                    if (!string.IsNullOrEmpty(kvp.Value))
                    {
                        var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        value = Convert.ChangeType(kvp.Value, propertyType);
                    }
                    else if (Nullable.GetUnderlyingType(property.PropertyType) == null && property.PropertyType.IsValueType)
                    {
                        value = Activator.CreateInstance(property.PropertyType);
                    }
                    property.SetValue(entity, value);
                }
            }
            return entity;
        }
        public object GetEntity()
        {
            return _entity;
        }

    }
}