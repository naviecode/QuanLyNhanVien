namespace Presentation.Forms.CustomControls
{
    public class CustomListView : ListView
    {
        private int currentPage = 1;  // Trang hiện tại
        private int itemsPerPage = 24; // Số mục mỗi trang
        private List<Dictionary<string, string>> allData = new List<Dictionary<string, string>>(); // Dữ liệu đầy đủ
        private int totalPages; // Tổng số trang

        public CustomListView()
        {
            this.View = View.Details; // Chế độ xem chi tiết
            this.FullRowSelect = true; // Chọn toàn bộ dòng
            this.GridLines = true; // Hiển thị đường kẻ
        }

        /// <summary>
        /// Thiết lập dữ liệu cho ListView và phân trang.
        /// </summary>
        /// <param name="data">Danh sách các bản ghi (Dictionary)</param>
        public void SetData(List<Dictionary<string, string>> data)
        {
            if (data == null || data.Count == 0)
                return;

            allData = data;
            totalPages = (int)Math.Ceiling((double)allData.Count / itemsPerPage); // Tính tổng số trang
            currentPage = 1; // Bắt đầu từ trang 1

            ShowPage(currentPage); // Hiển thị trang đầu tiên
        }

        /// <summary>
        /// Hiển thị dữ liệu của một trang cụ thể.
        /// </summary>
        private void ShowPage(int pageNumber)
        {
            this.Items.Clear(); // Xóa dữ liệu cũ
            this.Columns.Clear(); // Xóa cột cũ

            // Tạo cột dựa trên keys của bản ghi đầu tiên, bỏ cột "ID"
            var columns = allData[0].Keys;
            foreach (var column in columns)
            {
                if (column != "ID")
                {
                    this.Columns.Add(column, 120); // Mặc định rộng 120px
                }
            }

            // Tính toán các mục cần hiển thị cho trang này
            int startIndex = (pageNumber - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, allData.Count);

            var pageData = allData.GetRange(startIndex, endIndex - startIndex);

            // Tạo dòng dữ liệu
            foreach (var record in pageData)
            {
                var item = new ListViewItem();
                item.Tag = record["ID"]; // Lưu trữ ID vào Tag (để không hiển thị trên ListView)

                foreach (var column in columns)
                {
                    if (column != "ID") // Chỉ hiển thị cột khác "ID"
                    {
                        if (item.SubItems.Count == 1 && string.IsNullOrEmpty(item.Text))
                        {
                            item.Text = record[column]; // Cột đầu tiên
                        }
                        else
                        {
                            item.SubItems.Add(record[column]); // Các cột tiếp theo
                        }
                    }
                }
                this.Items.Add(item);
            }

            // Tự động điều chỉnh độ rộng cột phù hợp nội dung
            foreach (ColumnHeader column in this.Columns)
            {
                column.Width = -2; // AutoResizeColumn
            }
        }
        /// <summary>
        /// Di chuyển đến trang tiếp theo.
        /// </summary>
        public void NextPage()
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ShowPage(currentPage);
            }
        }
        /// <summary>
        /// Di chuyển đến trang trước đó.
        /// </summary>
        public void PreviousPage()
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowPage(currentPage);
            }
        }

        /// <summary>
        /// Di chuyển đến trang đầu tiên.
        /// </summary>
        public void FirstPage()
        {
            currentPage = 1;
            ShowPage(currentPage);
        }

        /// <summary>
        /// Di chuyển đến trang cuối cùng.
        /// </summary>
        public void LastPage()
        {
            currentPage = totalPages;
            ShowPage(currentPage);
        }

        /// <summary>
        /// Cập nhật thông tin trang hiện tại và tổng số trang.
        /// </summary>
        public string GetPageInfo()
        {
            return $"{currentPage} / {totalPages}";
        }
    }
}
