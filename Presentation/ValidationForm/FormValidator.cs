using System.Text.RegularExpressions;

namespace Presentation.ValidationForm
{
    public class FormValidator
    {
        public static bool ValidateForm(Control parent, out string errorMessage)
        {
            errorMessage = string.Empty;

            foreach (Control control in parent.Controls)
            {
                // Bỏ qua các control không cần kiểm tra
                if (control is TextBox textBox)
                {
                    // Kiểm tra bắt buộc nhập
                    if (textBox.Tag != null && textBox.Tag.ToString().Contains("required") && string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        errorMessage = $"{control.Name} không được để trống.";
                        textBox.Focus();
                        return false;
                    }

                    // Kiểm tra độ dài tối thiểu
                    if (textBox.Tag != null && textBox.Tag.ToString().Contains("minlength:"))
                    {
                        int minLength = int.Parse(GetTagValue(textBox.Tag.ToString(), "minlength:"));
                        if (textBox.Text.Length < minLength)
                        {
                            errorMessage = $"{control.Name} phải có ít nhất {minLength} ký tự.";
                            textBox.Focus();
                            return false;
                        }
                    }

                    // Kiểm tra kiểu email
                    if (textBox.Tag != null && textBox.Tag.ToString().Contains("email"))
                    {
                        if (!IsValidEmail(textBox.Text))
                        {
                            errorMessage = $"{control.Name} không đúng định dạng email.";
                            textBox.Focus();
                            return false;
                        }
                    }

                    // Kiểm tra kiểu số
                    if (textBox.Tag != null && textBox.Tag.ToString().Contains("number"))
                    {
                        if (!int.TryParse(textBox.Text, out _))
                        {
                            errorMessage = $"{control.Name} phải là số.";
                            textBox.Focus();
                            return false;
                        }
                    }
                }

                // Đệ quy kiểm tra các container bên trong (Panel, GroupBox,...)
                if (control.Controls.Count > 0)
                {
                    if (!ValidateForm(control, out errorMessage))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static string GetTagValue(string tag, string key)
        {
            string pattern = $@"{key}(\d+)";
            var match = Regex.Match(tag, pattern);
            return match.Success ? match.Groups[1].Value : "0";
        }

        private static bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
