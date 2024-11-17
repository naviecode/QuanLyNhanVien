namespace Presentation.Forms.FormInput
{
    public class InputField
    {
        public string Label { get; set; } 
        public string Type { get; set; } 
        public string Value { get; set; } 
        public bool IsRequired { get; set; }
        public bool IsReadOnly { get; set; }
        public List<OptionItem> Options { get; set; } 

        public InputField(string label, string type, string value = "", bool required = false, bool isReadOnly = false, List<OptionItem> options = null)
        {
            Label = label;
            Type = type;
            Value = value;
            IsRequired = required;
            Options = options ?? new List<OptionItem>();
            IsReadOnly = isReadOnly;
        }
    }

    public class OptionItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
