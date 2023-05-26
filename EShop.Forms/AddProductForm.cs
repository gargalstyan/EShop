using EShop.Data.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShop.Forms
{
    public partial class AddProductForm : Form
    {
        Product product = new Product();
        public Product Product { get { return product; } }
        public AddProductForm()
        {
            InitializeComponent();
        }
        public AddProductForm(Product product) :this()
        {
            this.product = product;
            txtName.Text= product.Name;
            txtCount.Text = product.Count.ToString();
            txtShopId.Text = product.ShopId.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            product.Name = txtName.Text;
            product.Count = int.Parse(txtCount.Text);
            product.ShopId = int.TryParse(txtShopId.Text, out int result) ? result : (int?)null;
            this.DialogResult = DialogResult.OK;
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAddShop_Click(object sender, EventArgs e)
        {
            AddShopForm addShopForm = new AddShopForm();
            if (addShopForm.ShowDialog() == DialogResult.OK)
            {
                product.Shop = addShopForm.Shop;
            }
        }
    }
}
