namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// יצירת מופע חדש של מסך רשימת המוצרים
            //ProductListForm listForm = new ProductListForm();

            //// הצגת המסך
            //listForm.ShowDialog();
            // יצירת מופע של המסך החדש
            frmManagerMenu menu = new frmManagerMenu();
            // הצגת המסך
            menu.Show();
            // (אופציונלי) הסתרת המסך הנוכחי
            //this.Hide();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            // יצירת מופע חדש של מסך העגלה
            CartForm cart = new CartForm();

            // הצגת המסך
            cart.Show();

            // אופציונלי: אם את רוצה שהמסך הראשי ייעלם כשהעגלה נפתחת:
            // this.Hide(); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
