namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // יצירת מופע חדש של מסך רשימת המוצרים
            ProductListForm listForm = new ProductListForm();

            // הצגת המסך
            listForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
