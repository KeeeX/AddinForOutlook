using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeeeXAddinOutlook2013_2016
{
    public partial class AttachmentList : Form
    {
        public string title { get; set; }
        public AttachmentList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productName = null;
            string price = null;
            string quantity = null;

            if (listView1.SelectedItems.Count > 0)
            {
                productName = listView1.SelectedItems[0].SubItems[0].Text;
                price = listView1.SelectedItems[0].SubItems[1].Text;
                quantity = listView1.SelectedItems[0].SubItems[2].Text;

                MessageBox.Show(productName + " , " + price + " , " + quantity, title);
            }
            else
                MessageBox.Show("Aucune sélection", title);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void AttachmentList_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("ProductName", 100);
            listView1.Columns.Add("Price", 70);
            listView1.Columns.Add("Quantity", 70);

            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm;

            //Add first item
            arr[0] = "product_1";
            arr[1] = "100";
            arr[2] = "10";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            //Add second item
            arr[0] = "product_2";
            arr[1] = "200";
            arr[2] = "20";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
        }
    }
}
