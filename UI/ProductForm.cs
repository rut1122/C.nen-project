using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO;
using BL.BO;

namespace UI
{
    public partial class ProductForm : Form
    {
        // משתנה שיגיד לנו אם אנחנו במצב עדכון או הוספה
        bool isUpdate = false;
        BlApi.IBl bl = BlApi.Factory.Get;
        public ProductForm()
        {
            InitializeComponent();
        }
        public ProductForm(BO.Product productToUpdate) : this()
        {
            isUpdate = true; // סימן שאנחנו בעדכון

            // מילוי השדות בטופס בנתונים של המוצר שקיבלנו
            txtId.Text = productToUpdate.Id.ToString();
            txtId.Enabled = false; // אסור למשתמש לשנות ID בעדכון!
            txtProductName.Text = productToUpdate.ProductName;
            txtPrice.Text = productToUpdate.Price.ToString();
            txtAmount.Text = productToUpdate.Amount.ToString();
            cmbCategory.SelectedItem = productToUpdate.ProductCategory;

            btnAdd.Text = "עדכן מוצר"; // שינוי הטקסט על הכפתור
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

            cmbCategory.DataSource = Enum.GetValues(typeof(BL.BO.Category));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. יצירת האובייקט עם הנתונים מהמסך
                BO.Product p = new BO.Product()
                {
                    // אם אנחנו בעדכון - לוקחים את ה-ID האמיתי מהתיבה txtId.
                    // אם אנחנו בהוספה - שמים 1 זמני כדי לעבור את ה-BL.
                    Id = isUpdate ? int.Parse(txtId.Text) : 1,
                    ProductName = txtProductName.Text,
                    Price = double.Parse(txtPrice.Text),
                    Amount = int.Parse(txtAmount.Text),
                    ProductCategory = (Category)cmbCategory.SelectedItem
                };

                // 2. בדיקה: האם לבצע עדכון או הוספה?
                if (isUpdate)
                {
                    bl.Product.Update(p); // קריאה לעדכון ב-BL
                    MessageBox.Show("המוצר עודכן בהצלחה!");
                }
                else
                {
                    bl.Product.Create(p); // קריאה להוספה ב-BL
                    MessageBox.Show("המוצר נוסף בהצלחה!");
                }

                this.Close(); // סגירת הטופס בסיום
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה: " + ex.Message);
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
