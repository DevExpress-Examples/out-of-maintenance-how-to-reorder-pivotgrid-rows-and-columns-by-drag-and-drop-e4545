using DevExpress.XtraPivotGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pivot_Reorder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ReorderHelper helper;
        private static DataTable CreatePivotTable(int RowCount)
        {
            Random rnd = new Random();

            DataTable tbl = new DataTable();
            tbl.Columns.Add("ID", typeof(int)).Unique = true;
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("GroupL1", typeof(string));
            tbl.Columns.Add("GroupL2", typeof(string));
            tbl.Columns.Add("Value", typeof(decimal));
            tbl.Columns.Add("Date", typeof(DateTime));

            tbl.PrimaryKey = new DataColumn[] { tbl.Columns["ID"] };
            for (int i = 0; i < RowCount; i++)
            {
                DataRow row = tbl.Rows.Add(new object[] { i, String.Format("Name{0}", i % 27),String.Format("1 Level Group{0}", i % 3),String.Format("2 Level Group{0}", i % 9), rnd.Next(50), DateTime.Now.AddDays(rnd.Next(-300,300)) });

            }
            return tbl;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pivotGridControl1.DataSource = CreatePivotTable(1000);
            helper =new ReorderHelper(pivotGridControl1);
            helper.AllowChangeColumnGroup = true;
            helper.AllowChangeRowGroup = true;
            helper.AllowDragColumn = true;
            helper.AllowDragRow = true;
        }

        private void checkEdit3_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            helper.AllowChangeRowGroup = checkEdit3.Checked;
        }

        private void checkEdit7_CheckedChanged(object sender, EventArgs e)
        {
            helper.AllowDragColumn = checkEdit7.Checked;
        }

        private void checkEdit6_CheckedChanged(object sender, EventArgs e)
        {
            helper.AllowDragRow = checkEdit6.Checked;
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            helper.AllowChangeColumnGroup = checkEdit5.Checked;
        }


    }
}
