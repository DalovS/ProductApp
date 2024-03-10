using Business;
using Data.Data;
using Data.Model;
using System.Drawing;

namespace ProductApp
{
    public partial class ProductApp : Form
    {
        public ProductBusiness productBusiness = new ProductBusiness();
        private int editId = 0;
        public ProductApp()
        {
            InitializeComponent();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Name = txtName.Text;

            decimal decPrice ;
            string inputPrice = txtPrice.Text;
            if (decimal.TryParse(inputPrice, out decPrice))
            {
                product.Price = decPrice;
                productBusiness.Add(product);
                MessageBox.Show("Data is inputed!");
            }
            else
            {
                MessageBox.Show("Невалидна стойност за цена!");
            }
            int stock;
            string inputStock = txtStock.Text;
            if (int.TryParse(inputStock, out stock))
            {
                product.Stock = stock;
                productBusiness.Update(product);
                MessageBox.Show("Data is inputed!");
            }
            else
            {
                MessageBox.Show("Невалидна стойност за Количество!");
            }
   
            UpdateGrid();
            ClearTextBoxes();          
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product edited = new Product();
            edited.Id = editId;
            edited.Name = txtName.Text;
            decimal decPrice;
            string inputPrice = txtPrice.Text;
            if(decimal.TryParse(inputPrice,out decPrice))
            {
                edited.Price = decPrice;
                productBusiness.Update(edited);
                MessageBox.Show("Data is Updated!");
            }
            else
            {
                MessageBox.Show("Невалидна стойност за цена!");
            }
            int stock;
            string inputStock = txtStock.Text;
            if (int.TryParse(inputPrice, out stock))
            {
                edited.Stock = stock;
                productBusiness.Update(edited);
                MessageBox.Show("Data is Updated!");
            }
            else
            {
                MessageBox.Show("Невалидна стойност за Количество!");
            }
          
            UpdateGrid();
            ClearTextBoxes();         
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ProductApp_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ClearTextBoxes();
            btnUpdate.Enabled = false;
            btnDelete.Enabled=false;
        }
        private void UpdateGrid()
        {
            dataGridView1.DataSource = productBusiness.GetAll();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearTextBoxes()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";
        }
        private void UpdateTextBoxes(int id)
        {
            Product update = productBusiness.Get(id);
            txtName.Text = update.Name;
            txtPrice.Text = update.Price.ToString();
            txtStock.Text = update.Stock.ToString();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dataGridView1.SelectedRows[0].Cells;
            var id = int.Parse(item[0].Value.ToString());
            editId = id;
            UpdateTextBoxes(id);
            btnInsert.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = dataGridView1.SelectedRows[0].Cells;
            var id = int.Parse(item[0].Value.ToString());
            productBusiness.Delete(id);
            UpdateGrid();
            ClearTextBoxes();
            MessageBox.Show("Data is Deleted!");
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        
    }
}
