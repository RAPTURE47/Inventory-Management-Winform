using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMangement
{
    public partial class Form1 : Form
    {
        DataTable inventory = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void InventoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InventoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SKUTextbox.Text = inventory.Rows[InventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                NameTextbox.Text = inventory.Rows[InventoryGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                PriceTextbox.Text = inventory.Rows[InventoryGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
                DescriptionTextbox.Text = inventory.Rows[InventoryGridView.CurrentCell.RowIndex].ItemArray[4].ToString();
                QuantityTextbox.Text = inventory.Rows[InventoryGridView.CurrentCell.RowIndex].ItemArray[5].ToString();

                String itemToLookFor = inventory.Rows[InventoryGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                CategoryBox.SelectedIndex = CategoryBox.Items.IndexOf(itemToLookFor);
            }
            catch (Exception err)
            {
                Console.WriteLine("There has been an error: " + err);
            }
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inventory.Columns.Add("SKU");
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Category");
            inventory.Columns.Add("Price");
            inventory.Columns.Add("Description");
            inventory.Columns.Add("Quantity");
            InventoryGridView.DataSource = inventory;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            SKUTextbox.Text = "";
            NameTextbox.Text = "";
            PriceTextbox.Text = "";
            DescriptionTextbox.Text = "";
            QuantityTextbox.Text = "";
            CategoryBox.SelectedIndex = -1;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Save all the values from our fields into variables
            String sku = SKUTextbox.Text;
            String name = NameTextbox.Text;
            String price = PriceTextbox.Text;
            String quantity = QuantityTextbox.Text;
            String description = DescriptionTextbox.Text;
            String category = (string)CategoryBox.SelectedItem;

            // Add these values to the datatable
            inventory.Rows.Add(sku, name, category, price, description, quantity);

            // Clear fields after save
            NewButton_Click(sender, e);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                inventory.Rows[InventoryGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error: " + err);
            }
        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
