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
    public partial class CustomerListForm : Form
    {
        BlApi.IBl bl = BlApi.Factory.Get;
        public CustomerListForm()
        {
            InitializeComponent();
        }
        private void RefreshGrid()
        {
            dgvCustomers.DataSource = bl.Customer.ReadAll().ToList();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // 1. פתיחת התפריט הראשי מחדש
            new frmManagerMenu().Show();

            // 2. סגירת המסך הנוכחי (הלקוחות)
            this.Close();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            // משיכת כל הלקוחות מהלוגיקה והצגתם בטבלה שקראנו לה dgvCustomers
            dgvCustomers.DataSource = bl.Customer.ReadAll().ToList();
        }

        private void txtSearchById_TextChanged(object sender, EventArgs e)
        {
            // אם התיבה ריקה - נציג את כל הלקוחות
            if (string.IsNullOrEmpty(txtSearchById.Text))
            {
                dgvCustomers.DataSource = bl.Customer.ReadAll().ToList();
            }
            else
            {
                // סינון: מציג רק לקוחות שתעודת הזהות שלהם מתחילה במה שהקלדנו
                // הערה: p.Id זה שדה תעודת הזהות ב-BO שלך
                var filtered = bl.Customer.ReadAll(p => p.Id.ToString().StartsWith(txtSearchById.Text));
                dgvCustomers.DataSource = filtered.ToList();
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm(); // פותח טופס ריק להוספה
            frm.ShowDialog();
            // אחרי שהטופס נסגר, כדאי לרענן את הטבלה כדי לראות את הלקוח החדש
            dgvCustomers.DataSource = bl.Customer.ReadAll().ToList();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            // במקום SelectedRows, נבדוק CurrentRow - זה תמיד מחזיר את השורה שהסמן עליה
            if (dgvCustomers.CurrentRow != null)
            {
                var selectedCustomer = (BO.Customer)dgvCustomers.CurrentRow.DataBoundItem;
                int customerId = selectedCustomer.Id;

                CustomerForm frm = new CustomerForm(customerId);
                frm.ShowDialog();

                RefreshGrid(); // ודאי שהוספת את הפונקציה הזו כפי שהסברתי קודם
            }
            else
            {
                MessageBox.Show("אנא בחרי לקוח מהרשימה לעדכון.");
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // 1. בדיקה האם נבחרה שורה
            if (dgvCustomers.CurrentRow != null)
            {
                // 2. חילוץ הלקוח וה-ID
                var selectedCustomer = (BO.Customer)dgvCustomers.CurrentRow.DataBoundItem;
                int customerId = selectedCustomer.Id;

                // 3. הוספת תיבת אישור (חשוב מאוד במחיקה!)
                var result = MessageBox.Show($"האם את בטוחה שברצונך למחוק את הלקוח {selectedCustomer.Name}?",
                                           "אישור מחיקה",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // 4. קריאה ל-BL לביצוע המחיקה
                        bl.Customer.Delete(customerId);

                        MessageBox.Show("הלקוח נמחק בהצלחה.");

                        // 5. ריענון הטבלה כדי שהלקוח ייעלם מהמסך
                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("לא ניתן למחוק את הלקוח: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("אנא בחרי לקוח מהרשימה למחיקה.");
            }
        }
    }
}
