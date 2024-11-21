using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms.Menus
{
    public partial class ViewTimeTable : Form
    {
        public ViewTimeTable()
        {
            InitializeComponent();
        }

        private void ViewTimeTable_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount = 8; 
            tableLayoutPanel1.RowCount = 6;    

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            AddCell("Phòng", 0, 0, true);
            AddCell("Thứ 2", 1, 0, true);
            AddCell("Thứ 3", 2, 0, true);
            AddCell("Thứ 4", 3, 0, true);
            AddCell("Thứ 5", 4, 0, true);
            AddCell("Thứ 6", 5, 0, true);
            AddCell("Thứ 7", 6, 0, true);
            AddCell("Chủ nhật", 7, 0, true);

            for (int i = 1; i <= 5; i++)
            {
                AddCell($"Thứ {i}", 0, i, false);
                AddCell("Lập trình hướng tượng \n Thời gian \n Giáo viên", 1, i, false);
                AddCell("", 2, i, false);
                AddCell("", 3, i, false);
                AddCell("", 4, i, false);
                AddCell("", 5, i, false);
                AddCell("", 6, i, false);
                AddCell("", 7, i, false);
            }
        }
        private void AddCell(string text, int column, int row, bool isHeader)
        {
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.None, 
                Dock = DockStyle.Fill
            };

            Label label = new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Margin = new Padding(0) 
            };
            panel.Controls.Add(label);

            tableLayoutPanel1.Controls.Add(panel, column, row);
        }

    }

}
