namespace BusinessLogic.IService
{
    public class ResponseDataDto<T>
    {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
        public ResponseDataDto(List<T> items, int totalItems)
        {
            this.TotalItems = totalItems;
            this.Items = items;
        }
    }
}
