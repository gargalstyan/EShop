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
    public partial class AddShopForm : Form
    {
        Shop shop = new Shop();
        public Shop Shop { get { return shop; } } 
        public AddShopForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            shop.Name = txtName.Text;
            shop.Address = txtAddress.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
