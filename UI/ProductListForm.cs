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
    }
}
