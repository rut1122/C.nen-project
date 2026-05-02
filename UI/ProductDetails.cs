using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class ProductDetails : Form
    {
        // תיקון: הסרת הסוגריים מ-Get אם מדובר ב-Property
        private BlApi.IBl bl = BlApi.Factory.Get;
        private BO.Product _currentProduct;

        public ProductDetails(BO.Product? product = null)
        {
            InitializeComponent();

            if (product != null)
            {
                _currentProduct = product;
                txtId.Text = _currentProduct.Id.ToString();
                txtId.ReadOnly = true;
                txtProductName.Text = _currentProduct.ProductName;
                txtPrice.Text = _currentProduct.Price.ToString();
                btnSave.Text = "עדכן";
            }
            else
            {
                _currentProduct = new BO.Product();
                btnSave.Text = "הוסף";
                txtId.ReadOnly = false;
            }
        }

        // וודאי שהוספת את האירוע הזה לכפתור השמירה ב-Design
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _currentProduct.ProductName = txtProductName.Text;
                _currentProduct.Price = double.Parse(txtPrice.Text);

                if (btnSave.Text == "הוסף")
                {
                    _currentProduct.Id = int.Parse(txtId.Text);
                    bl.Product.Create(_currentProduct);
                }
                else
                {
                    bl.Product.Update(_currentProduct);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}