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
    public partial class SaleListWindow : Form
    {
        BlApi.IBl bl = BlApi.Factory.Get;
        public SaleListWindow()
        {
            InitializeComponent();
            // יצירת מופע של ה-BL (כמו שעשית בלקוחות)
            BlApi.IBl bl = BlApi.Factory.Get;

            // הצגת הנתונים בטבלה
            dgvSales.DataSource = bl.Sale.ReadAll().ToList();
        }

        private void SaleListWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaleForm frm = new SaleForm();
            frm.ShowDialog();

            // ריענון הטבלה אחרי שהטופס נסגר
            dgvSales.DataSource = bl.Sale.ReadAll().ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. בדיקה שנבחרה שורה בטבלה
            if (dgvSales.SelectedRows.Count > 0)
            {
                // 2. שליפת ה-ID של המבצע מהשורה שנבחרה
                var selectedSale = (BO.Sale)dgvSales.SelectedRows[0].DataBoundItem;
                int saleId = selectedSale.Id;

                // 3. שאלת אישור מהמשתמש
                var result = MessageBox.Show($"האם את בטוחה שברצונך למחוק את מבצע מספר {saleId}?",
                                             "אישור מחיקה",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // 4. ביצוע המחיקה בפועל דרך ה-BL
                        bl.Sale.Delete(saleId);

                        // 5. ריענון הטבלה כדי שהשורה תיעלם מהעין
                        dgvSales.DataSource = bl.Sale.ReadAll().ToList();

                        MessageBox.Show("המבצע נמחק בהצלחה");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("שגיאה במחיקה: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("אנא בחרי שורה למחיקה מתוך הטבלה");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. בדיקה שנבחרה שורה בטבלה
            if (dgvSales.SelectedRows.Count > 0)
            {
                // 2. שליפת האובייקט מהשורה שנבחרה
                BO.Sale selectedSale = (BO.Sale)dgvSales.SelectedRows[0].DataBoundItem;

                // 3. פתיחת הטופס עם הבנאי החדש שיצרנו (זה שמקבל אובייקט)
                SaleForm frm = new SaleForm(selectedSale);
                frm.ShowDialog();

                // 4. ריענון הטבלה כשהטופס נסגר
                dgvSales.DataSource = bl.Sale.ReadAll().ToList();
            }
            else
            {
                MessageBox.Show("אנא בחרי שורה לעדכון מתוך הטבלה");
            }
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
