using EShop.Data.Context;
using EShop.Data.Entitiy;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace EShop.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            ComboBox.Items.Clear();
            using (ShopDbContext shopDbContext = new ShopDbContext())
            {

                dgv.DataSource = shopDbContext.Products.ToList();
                ComboBox.Items.AddRange(shopDbContext.Shops./*Select(p => p.Name).Distinct().*/ToArray());
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                using (ShopDbContext shopDbContext = new ShopDbContext())
                {
                    shopDbContext.Products.Add(addProductForm.Product);
                    shopDbContext.SaveChanges();
                    dgv.DataSource = shopDbContext.Products.ToList();
                }
            }
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            ComboBox.Items.Clear();
            AddShopForm addShopForm = new AddShopForm();
            if (addShopForm.ShowDialog() == DialogResult.OK)
            {
                using (ShopDbContext shopDbContext = new ShopDbContext())
                {
                    shopDbContext.Shops.Add(addShopForm.Shop);
                    shopDbContext.SaveChanges();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = (int)dgv.SelectedRows[0].Cells["ID"].Value;
            using (ShopDbContext shopDbContext = new ShopDbContext())
            {
                var productForEdit = shopDbContext.Products.SingleOrDefault(p => p.ID == id);
                AddProductForm addProductForm = new AddProductForm(productForEdit);
                if (addProductForm.ShowDialog() == DialogResult.OK)
                {
                    shopDbContext.Products.Add(productForEdit);
                    shopDbContext.Entry(productForEdit).State = EntityState.Modified;
                    shopDbContext.SaveChanges();
                    dgv.DataSource = shopDbContext.Products.ToList();
                }

            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var shop = ComboBox.SelectedItem as Shop;
            if (shop != null)
            {
                using (ShopDbContext shopDbContext = new ShopDbContext())
                {
                    var filtredShop = shopDbContext.Shops.SingleOrDefault(s => s.ID == shop.ID);
                    dgv.DataSource = shopDbContext.Products.Where(p => p.ShopId == filtredShop.ID).ToList();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComboBox.Items.Clear();
            using (ShopDbContext shopDbContext = new ShopDbContext())
            {

                dgv.DataSource = shopDbContext.Products.ToList();
                ComboBox.Items.AddRange(shopDbContext.Shops./*Select(p => p.Name).Distinct().*/ToArray());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = (int)dgv.SelectedRows[0].Cells["ID"].Value;
            using (ShopDbContext shopDbContext = new ShopDbContext())
            {
                var productForDelete = shopDbContext.Products.SingleOrDefault(p => p.ID == id);
                shopDbContext.Products.Remove(productForDelete);
                shopDbContext.SaveChanges();

                dgv.DataSource = shopDbContext.Products.ToList();
            }
        }
    }
}