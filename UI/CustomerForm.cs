namespace UI
{
    public partial class CustomerForm : Form
    {
        // גישה ללוגיקה
        BlApi.IBl bl = BlApi.Factory.Get;

        // משתנה שישמור לנו את הלקוח שאנחנו מעדכנים (אם יש כזה)
        BO.Customer currentCustomer;

        // בנאי להוספה (הכל ריק) - השארנו רק את זה עם התוכן
        public CustomerForm()
        {
            InitializeComponent();
            currentCustomer = null; // מסמן שאנחנו בהוספה
            btnConfirm.Text = "הוסף";
        }

        // בנאי לעדכון (ממלא פרטים קיימים)
        public CustomerForm(int id)
        {
            InitializeComponent();
            currentCustomer = bl.Customer.Read(id);

            txtId.Text = currentCustomer.Id.ToString();
            txtId.ReadOnly = true;
            txtName.Text = currentCustomer.Name;
            txtEmail.Text = currentCustomer.Email ??"";
            txtPhone.Text = currentCustomer.Phone.ToString();
            txtAddress.Text = currentCustomer.Address;

            btnConfirm.Text = "עדכן";
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. יצירת האובייקט מהנתונים בתיבות הטקסט
                BO.Customer customerToSave = new BO.Customer(
                    int.Parse(txtId.Text),
                    txtName.Text,
                    txtAddress.Text,
                    txtEmail.Text,
                    int.Parse(txtPhone.Text)
                );

                // 2. שמירה ב-BL
                if (currentCustomer == null) // מצב הוספה
                {
                    bl.Customer.Create(customerToSave);
                    MessageBox.Show("הלקוח נוסף בהצלחה!");
                }
                else // מצב עדכון
                {
                    bl.Customer.Update(customerToSave);
                    MessageBox.Show("פרטי הלקוח עודכנו בהצלחה!");
                }

                this.Close(); // סגירת הטופס
            }
            catch (Exception ex)
            {
                // זה החלק הכי חשוב - אם יש שגיאה, כאן היא תצוף
                MessageBox.Show("חלה שגיאה בשמירה: " + ex.Message);
            }
        }
    }
}