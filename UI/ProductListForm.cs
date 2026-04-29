using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI
{
    public partial class ProductListForm : Form
    {
        BlApi.IBl bl = BlApi.Factory.Get;

        public ProductListForm()
        {
            InitializeComponent();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            // מילוי התיבה בערכי הקטגוריות מה-BO
            cmbCategoryFilter.DataSource = Enum.GetValues(typeof(BL.BO.Category));
            // איפוס הבחירה ההתחלתית כדי שהסינון לא יקפוץ מיד
            cmbCategoryFilter.SelectedIndex = -1;

            // יצירת מופע של שכבת הלוגיקה (בהתאם לשם שהגדרת בפרויקט)

            // משיכת כל המוצרים והצגתם בטבלה
            dataGridView1.DataSource = bl.Product.ReadAll().ToList();
        }

        private void add_Click(object sender, EventArgs e)
        {
            // פתיחת הטופס החדש שעיצבנו
            ProductForm f = new ProductForm();
            f.ShowDialog();

            // רענון הטבלה כדי לראות את המוצר החדש מיד
            var list = bl.Product.ReadAll();
            dataGridView1.DataSource = list.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updeate_Click(object sender, EventArgs e)
        {
            // 1. בדיקה: האם המשתמש בכלל בחר שורה בטבלה?
            if (dataGridView1.CurrentRow != null)
            {
                // 2. חילוץ האובייקט שנבחר מהטבלה
                BO.Product selectedProduct = (BO.Product)dataGridView1.CurrentRow.DataBoundItem;

                // 3. פתיחת הטופס עם הקונסטרקטור המיוחד לעדכון (זה שבנינו בשלב הקודם)
                ProductForm f = new ProductForm(selectedProduct);
                f.ShowDialog();

                // 4. רענון הטבלה אחרי שהטופס נסגר כדי לראות את השינויים
                dataGridView1.DataSource = bl.Product.ReadAll().ToList();
            }
            else
            {
                MessageBox.Show("אנא בחרי מוצר מהרשימה לעדכון");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            // פתיחה מחדש של מסך התפריט
            frmManagerMenu menu = new frmManagerMenu();
            menu.Show();
            this.Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                BO.Product selectedProduct = (BO.Product)dataGridView1.CurrentRow.DataBoundItem;

                var result = MessageBox.Show($"האם את בטוחה שברצונך למחוק את {selectedProduct.ProductName}?", "אישור מחיקה", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bl.Product.Delete(selectedProduct.Id);
                        // רענון הטבלה
                        dataGridView1.DataSource = bl.Product.ReadAll().ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // בדיקת הבטיחות - אם לא נבחר כלום, אל תעשה כלום ותצא מהפונקציה
            if (cmbCategoryFilter.SelectedItem == null)
            {
                return;
            }

            try
            {
                // רק אם הגענו לכאן, סימן שיש ערך נבחר
                var selectedCategory = (BL.BO.Category)cmbCategoryFilter.SelectedItem;
                var filteredList = bl.Product.ReadAll(p => p.ProductCategory == selectedCategory);
                dataGridView1.DataSource = filteredList.ToList();
            }
            catch (Exception ex)
            {
                // תמיד כדאי לעטוף ב-try-catch כדי שהתוכנית לא תקרוס עם הודעה כזו
                MessageBox.Show("חלה שגיאה בסינון: " + ex.Message);
            }
        }
    }
}
