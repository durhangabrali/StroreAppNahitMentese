using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;


namespace DesktopUI
{
    public partial class Form1 : Form
    {
        //Burada ProductManager'ın ve CategoryManager'ın Constructor'ı üzerinden nesne enjeksiyonu yapılır
        ProductManager productManager = new ProductManager(new InMemoryProductDal());
        CategoryManager categoryManager = new CategoryManager(new InMemoryCategoryDal());

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productManager.GetAll();

            cbxKategoriler.DataSource = categoryManager.GetAll();
            cbxKategoriler.DisplayMember = "CategoryName";
            cbxKategoriler.ValueMember = "CategoryId";
        }      

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();

            product.ProductId = Guid.NewGuid();
            product.ProductName = txtProductName.Text;
            product.ProductDescription = txtDescription.Text;
            product.UnitsInStock = Convert.ToInt16(txtUnitsInStock.Text);
            product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            product.CategoryId = Convert.ToInt16(cbxKategoriler.SelectedValue);

            productManager.Add(product);

            MessageBox.Show("Ürün eklendi");
            txtProductName.Clear();
            txtDescription.Clear();
            txtUnitsInStock.Clear();
            txtUnitPrice.Clear();
          

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = productManager.GetAll();
        }
    }
}
