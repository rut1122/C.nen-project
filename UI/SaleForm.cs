//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace UI
//{
//    public partial class SaleForm : Form
//    {
//        BlApi.IBl bl = BlApi.Factory.Get;
//        public SaleForm()
//        {
//            InitializeComponent();
//        }
//        public SaleForm(BO.Sale sale) : this() // קורא קודם לבנאי הרגיל
//        {

//            // מילוי הפקדים בנתונים הקיימים
//            cmbProducts.SelectedValue = sale.ProductId;
//            txtSalePrice.Text = sale.SalePrice.ToString();
//            numRequiredAmount.Value = sale.RequiredAmount;
//            chkOnlyClub.Checked = sale.OnlyClub;
//            dtpStart.Value = sale.BeginSale;
//            dtpEnd.Value = sale.EndSale ?? DateTime.Now;

//            btnSave.Text = "עדכן"; // שינוי שם הכפתור לויזואליות
//        }

//        private void SaleForm_Load(object sender, EventArgs e)
//        {
//            // טעינת רשימת המוצרים מה-BL
//            var products = bl.Product.ReadAll().ToList();

//            cmbProducts.DataSource = products;
//            cmbProducts.DisplayMember = "Name"; // מה שהמשתמש רואה
//            cmbProducts.ValueMember = "Id";      // מה שבאמת נשמר מאחורי הקלעים
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                // 1. איסוף הנתונים מהטופס לאובייקט BO.Sale
//                BO.Sale newSale = new BO.Sale(
//                    id: 0, // ה-DAL ייצר ID אוטומטי
//                    productId: (int)cmbProducts.SelectedValue,
//                    requiredAmount: (int)numRequiredAmount.Value,
//                    salePrice: double.Parse(txtSalePrice.Text),
//                    onlyClub: chkOnlyClub.Checked,
//                    beginSale: dtpStart.Value,
//                    endSale: dtpEnd.Value
//                );

//                // 2. שליחה ל-BL ליצירה
//                bl.Sale.Create(newSale);

//                // 3. הודעת הצלחה וסגירה
//                MessageBox.Show("המבצע נשמר בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                this.Close();
//            }
//            catch (Exception ex)
//            {
//                // אם משהו לא תקין (למשל מחיר לא מספר), תקפץ הודעה
//                MessageBox.Show("שגיאה בשמירת המבצע: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//        }
//}
namespace UI
{
    public partial class SaleForm : Form
    {
        BlApi.IBl bl = BlApi.Factory.Get;

        // 1. הגדרת משתנה שישמור את המבצע הנוכחי (למקרה של עדכון)
        BO.Sale _currentSale = null;

        public SaleForm()
        {
            InitializeComponent();
        }

        public SaleForm(BO.Sale sale) : this()
        {
            // 2. שמירת המבצע שהתקבל לתוך המשתנה שהגדרנו
            _currentSale = sale;
            // אל תשימי פה cmbProducts.SelectedValue! זה גורם לשגיאה
            txtSalePrice.Text = sale.SalePrice.ToString();
            numRequiredAmount.Value = sale.RequiredAmount;
            chkOnlyClub.Checked = sale.OnlyClub;
            dtpStart.Value = sale.BeginSale;
            dtpEnd.Value = sale.EndSale ?? DateTime.Now;

            btnSave.Text = "עדכן";
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            var products = bl.Product.ReadAll().ToList();
            cmbProducts.DataSource = products;
            cmbProducts.DisplayMember = "Name";
            cmbProducts.ValueMember = "Id";
            // רק כאן, כשהרשימה כבר קיימת, נבחר את המוצר הנכון
            if (_currentSale != null)
            {
                cmbProducts.SelectedValue = _currentSale.ProductId;
            }

            // 3. אם אנחנו במצב עדכון, נבחר את המוצר הנכון עכשיו כשהרשימה מוכנה
            if (_currentSale != null)
            {
                cmbProducts.SelectedValue = _currentSale.ProductId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // איסוף הנתונים
                BO.Sale newSale = new BO.Sale(
                    id: _currentSale?.Id ?? 0, // אם יש מבצע קיים, נשתמש ב-ID שלו
                    productId: (int)cmbProducts.SelectedValue,
                    requiredAmount: (int)numRequiredAmount.Value,
                    salePrice: double.Parse(txtSalePrice.Text),
                    onlyClub: chkOnlyClub.Checked,
                    beginSale: dtpStart.Value,
                    endSale: dtpEnd.Value
                );

                // 4. בדיקה האם לבצע הוספה או עדכון
                if (_currentSale == null)
                {
                    bl.Sale.Create(newSale);
                    MessageBox.Show("המבצע נוסף בהצלחה!");
                }
                else
                {
                    bl.Sale.Update(newSale);
                    MessageBox.Show("המבצע עודכן בהצלחה!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בשמירת המבצע: " + ex.Message);
            }
        }
    }
}