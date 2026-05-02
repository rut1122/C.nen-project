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
    public partial class frmManagerMenu : Form
    {
        public frmManagerMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. יצירת מופע (Object) של דף ניהול המוצרים
            ProductListForm frmProducts = new ProductListForm();

            // 2. הצגת הדף החדש
            frmProducts.Show();
            this.Hide();
            // 3. (אופציונלי) אם את רוצה לסגור או להסתיר את התפריט הנוכחי
            // this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // פתיחה של מסך הכניסה הראשי
            //Form1 loginMenu = new Form1();
            //loginMenu.Show();

            // סגירה סופית של התפריט הנוכחי
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. יצירת מופע (עותק) של המסך החדש שבנית
            CustomerListForm frm = new CustomerListForm();

            // 2. פקודה להציג את המסך על המסך
            frm.Show();

            // 3. הסתרת התפריט הנוכחי כדי שלא יפריע (או Close לסגירה)
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. יצירת מופע של חלון רשימת המבצעים
            SaleListWindow salesWindow = new SaleListWindow();

            // 2. פתיחת החלון
            salesWindow.ShowDialog();
        }
    }
}
