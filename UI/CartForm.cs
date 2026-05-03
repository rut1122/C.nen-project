using BL.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class CartForm : Form
    {
        readonly BlApi.IBl bl = BlApi.Factory.Get;
        BO.Order currentOrder = new BO.Order { Products = new List<BL.BO.ProductInOrder>() };

        public CartForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        //איתחול הדף
        private void CartForm_Load(object sender, EventArgs e)
        {
            try
            {
                var products = bl.Product.ReadAll().ToList();
                dgvProduct.DataSource = products;

                if (dgvProduct.Columns.Contains("clmCheck"))
                    dgvProduct.Columns.Remove("clmCheck");

                DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
                checkCol.Name = "clmCheck";
                checkCol.HeaderText = "בחר פריט";
                checkCol.Width = 60;
                checkCol.TrueValue = true;
                checkCol.FalseValue = false;
                dgvProduct.Columns.Insert(0, checkCol);

                // --- עמודת פרטים (העין) ---
                if (dgvProduct.Columns.Contains("clmDetails"))
                    dgvProduct.Columns.Remove("clmDetails");

                DataGridViewButtonColumn btnDetails = new DataGridViewButtonColumn();
                btnDetails.Name = "clmDetails";
                btnDetails.HeaderText = "פרטים";
                btnDetails.Width = 40;
                btnDetails.Text = "👁";
                btnDetails.UseColumnTextForButtonValue = true;
                dgvProduct.Columns.Insert(1, btnDetails);

                // שאר הגדרות העיצוב
                dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProduct.AllowUserToAddRows = false;

                // טעינת הקטגוריות מה-Enum
                cmbCategory.DataSource = Enum.GetValues(typeof(DO.Category));

                // מניעת בחירה אוטומטית בפריט הראשון (כדי שיוצגו כל המוצרים בהתחלה)
                cmbCategory.SelectedIndex = -1;

                LoadCustomersToCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הטופס: " + ex.Message);
            }
        }

        //ריענון העגלה בכל פעם שיש צורך
        private void RefreshCartGrid()
        {
            // שמירת מיקום הסמן בטבלה
            int? selectedId = null;
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.DataBoundItem is BL.BO.ProductInOrder current)
            {
                selectedId = current.Id;
            }

            dgvCart.DataSource = null;
            if (currentOrder.Products != null)
            {
                dgvCart.DataSource = currentOrder.Products.ToList();

                if (dgvCart.Columns["Id"] != null) dgvCart.Columns["Id"].Visible = false;
                dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // החזרת הסימון לשורה שהייתה נבחרת
                if (selectedId != null)
                {
                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        if (row.DataBoundItem is BL.BO.ProductInOrder item && item.Id == selectedId)
                        {
                            row.Selected = true;
                            var firstVisible = dgvCart.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Visible);
                            if (firstVisible != null) dgvCart.CurrentCell = row.Cells[firstVisible.Index];
                            break;
                        }
                    }
                }
            }
            lblTotal.Text = $"סה\"כ לתשלום: {currentOrder.FinalPrice:N2} ₪";
            UpdateProductCheckboxes();
        }

        // כפתור איפוס סל
        private void button1_Click(object sender, EventArgs e)
        {
            currentOrder = new BO.Order { Products = new List<BL.BO.ProductInOrder>() };
            RefreshCartGrid();
        }

        // ביצוע תשלום והדפסת קבלה
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentOrder.Products == null || !currentOrder.Products.Any())
            {
                MessageBox.Show("הסל ריק! אי אפשר לבצע תשלום.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bl.Order.DoOrder(currentOrder);

                string receipt = "======= קבלה =======\n\n";
                receipt += $"תאריך: {DateTime.Now:dd/MM/yyyy HH:mm}\n";
                receipt += "----------------------------------------------\n";

                foreach (var item in currentOrder.Products)
                {
                    receipt += $"{item.Name.PadRight(20)} | {item.Amount} יח' | {item.FinalPrice:N2} ₪\n";
                }

                receipt += "----------------------------------------------\n";
                receipt += $"סה\"כ לתשלום: {currentOrder.FinalPrice:N2} ₪\n\n";
                receipt += "תודה שקנית אצלנו!";

                MessageBox.Show(receipt, "התשלום בוצע בהצלחה!");

                currentOrder = new BO.Order { Products = new List<BL.BO.ProductInOrder>() };
                RefreshCartGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("תקלה בביצוע התשלום: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCart.Rows[e.RowIndex].DataBoundItem is BL.BO.ProductInOrder selectedItem)
            {
                try
                {
                    int newAmount = selectedItem.Amount - 1;
                    if (newAmount <= 0)
                        currentOrder.Products.Remove(selectedItem);
                    else
                        bl.Order.AddPoductToOrder(selectedItem.Id, newAmount, currentOrder);

                    bl.Order.CalcTotalPrice(currentOrder);
                    RefreshCartGrid();
                }
                catch (Exception ex) { MessageBox.Show("שגיאה בעדכון: " + ex.Message); }
            }
        }
        //כפתור פלוס
        private void btnAddAmount_Click(object sender, EventArgs e)
        {
            if (currentOrder.Products == null || !currentOrder.Products.Any()) return;

            BL.BO.ProductInOrder productToUpdate = dgvCart.CurrentRow?.DataBoundItem as BL.BO.ProductInOrder ?? currentOrder.Products.First();

            try
            {
                // המרת BO.ProductInOrder ל-BO.Product לצורך פונקציית העזר
                var prod = bl.Product.Read(productToUpdate.Id);
                AddProductToCart(prod);
                bl.Order.CalcTotalPrice(currentOrder);
                RefreshCartGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //כפתור מינוס
        //כפתור מינוס משופר - עובד גם ללא בחירת שורה
        private void btnRemoveAmount_Click(object sender, EventArgs e)
        {
            // 1. בדיקה אם הסל בכלל ריק
            if (currentOrder.Products == null || !currentOrder.Products.Any())
            {
                return;
            }

            try
            {
                // 2. זיהוי המוצר לעדכון: אם נבחרה שורה - ניקח אותה. אם לא - ניקח את המוצר הראשון בסל
                BL.BO.ProductInOrder productToUpdate = dgvCart.CurrentRow?.DataBoundItem as BL.BO.ProductInOrder
                                                       ?? currentOrder.Products.First();

                // 3. חיפוש האובייקט האמיתי ברשימה (כדי למנוע בעיות Reference)
                var actualItem = currentOrder.Products.FirstOrDefault(p => p.Id == productToUpdate.Id);

                if (actualItem != null)
                {
                    if (actualItem.Amount <= 1)
                    {
                        // אם הכמות היא 1, המינוס מסיר את המוצר לגמרי
                        currentOrder.Products.Remove(actualItem);
                    }
                    else
                    {
                        bl.Order.AddPoductToOrder(actualItem.Id, actualItem.Amount - 1, currentOrder);
                    }

                    bl.Order.CalcTotalPrice(currentOrder);
                    RefreshCartGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעדכון הכמות: " + ex.Message);
            }
        }

        //פונקציית סינון משולבת (ID+קטגוריה)
        private void ApplyFilters()
        {
            try
            {
                // שליפת כל המוצרים מהשכבה הלוגית
                var allProducts = bl.Product.ReadAll();

                // 1. סינון לפי קטגוריה (מתוך ה-ComboBox)
                if (cmbCategory.SelectedItem != null && cmbCategory.SelectedIndex != -1)
                {
                    var selectedCategory = (BL.BO.Category)cmbCategory.SelectedItem;
                    allProducts = allProducts.Where(p => p.ProductCategory == selectedCategory);
                }

                // 2. סינון לפי טקסט חופשי (ID, שם, מחיר או קטגוריה כטקסט)
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    string search = txtSearch.Text.Trim().ToLower();

                    allProducts = allProducts.Where(p =>
                        p.Id.ToString().Contains(search) ||
                        (p.ProductName != null && p.ProductName.ToLower().Contains(search)) ||
                        p.Price.ToString().Contains(search) ||
                        (p.ProductCategory.ToString().ToLower().Contains(search))
                    );
                }

                // עדכון ה-DataSource של הטבלה
                dgvProduct.DataSource = allProducts.ToList();

                // שמירה על עיצוב הטבלה והסתרת עמודות טכניות
                if (dgvProduct.Columns.Contains("InCart"))
                    dgvProduct.Columns["InCart"].Visible = false;
            }
            catch (Exception ex)
            {
                // הצגת הודעה שקטה במקרה של שגיאה
                MessageBox.Show("שגיאה בביצוע החיפוש: " + ex.Message, "עדכון", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        // פונקציה להצגת פרטי מוצר
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedProduct = dgvProduct.Rows[e.RowIndex].DataBoundItem as BO.Product;
                if (selectedProduct == null) return;

                // בדיקה לפי אינדקס העמודה (0)
                if (e.ColumnIndex == 0)
                {
                    string info = "======= פרטי מוצר =======\n\n";
                    info += $"קוד: {selectedProduct.Id}\n";
                    info += $"שם: {selectedProduct.ProductName}\n";
                    info += $"מחיר: {selectedProduct.Price:N2} ₪\n";
                    info += $"קטגוריה: {selectedProduct.ProductCategory}\n";
                    info += "\n==========================";

                    // שינוי ל-None כדי שלא יופיע שום אייקון, או ל-Information לאייקון כחול עדין
                    MessageBox.Show(info, "פרטי מוצר", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    AddProductToCart(selectedProduct);
                }
            }
        }
        //פונקציה שמוסיפה מוצר לעגלה עי סימון הצקליסט
        private void AddProductToCart(BO.Product product)
        {
            if (currentOrder.Products == null)
            {
                currentOrder.Products = new List<BL.BO.ProductInOrder>();
            }

            var existingItem = currentOrder.Products.FirstOrDefault(p => p.Id == product.Id);

            if (existingItem != null)
            {
                bl.Order.AddPoductToOrder(product.Id, existingItem.Amount + 1, currentOrder);
            }
            else
            {
                // שימוש בבנאי (Constructor) לפי הסדר המדויק שמופיע בשגיאה:
                // (int id, string name, double basePrice, int amount, List<SaleInProduct> saleList, double finalPrice)
                var newItem = new BL.BO.ProductInOrder(
                    product.Id,
                    product.ProductName,
                    product.Price,
                    1,
                    new List<BL.BO.SaleInProduct>(),
                    product.Price
                );

                currentOrder.Products.Add(newItem);
                bl.Order.CalcTotalPrice(currentOrder);
            }

            RefreshCartGrid();
        }
        //טעינת כל הלקולחות לתוך הCOMBOBOX
        private void LoadCustomersToCombo()
        {
            try
            {
                // שליפת כל הלקוחות מה-BL
                // הערה: וודא שיש לך פונקציה ב-BL שמחזירה רשימת לקוחות מלאה
                var customerList = bl.Customer.ReadAll().ToList();

                // קישור הנתונים לקומבובוקס
                cmbCustomers.DataSource = customerList;

                // מה המשתמש יראה (שם הלקוח)
                cmbCustomers.DisplayMember = "Name";

                // מה הערך שייצג את הבחירה (מספר הזיהוי)
                cmbCustomers.ValueMember = "Id";

                // הגדרות סינון והשלמה אוטומטית
                cmbCustomers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCustomers.AutoCompleteSource = AutoCompleteSource.ListItems;

                // אופציונלי: התחלה ללא בחירה ראשונית
                cmbCustomers.SelectedIndex = -1;
                lblCustomerStatus.Text = ""; // איפוס הטקסט של הסטטוס
                                             // ניקוי כללי
                this.BackgroundImage = null;
                this.BackColor = Color.FromArgb(245, 245, 245); // אפור בהיר מאוד ונעים

                // עיצוב טבלת מוצרים
                dgvProduct.BackgroundColor = Color.White;
                dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvProduct.EnableHeadersVisualStyles = false;

                // עיצוב טבלת עגלה
                dgvCart.BackgroundColor = Color.White;
                dgvCart.GridColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בטעינת רשימת לקוחות: {ex.Message}");
            }
        }

        // פונקציות זמניות כדי לפתור את שגיאות ה-Designer
        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void dgvProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }

        //אחרי שבוחרים מוצר מוסיפה לעגלה
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // בדיקה שלוחצים על שורה תקינה (לא כותרת)
            if (e.RowIndex < 0) return;

            DataGridViewRow currentRow = dgvProduct.Rows[e.RowIndex];

            // 1. טיפול בלחיצה על עמודת "פרטים" (העין) - ללא צליל שגיאה
            if (dgvProduct.Columns[e.ColumnIndex].Name == "clmDetails")
            {
                var selectedProduct = currentRow.DataBoundItem as BO.Product;
                if (selectedProduct != null)
                {
                    string info = "======= פרטי מוצר =======\n\n";
                    info += $"קוד: {selectedProduct.Id}\n";
                    info += $"שם: {selectedProduct.ProductName}\n";
                    info += $"מחיר: {selectedProduct.Price:N2} ₪\n";
                    info += $"קטגוריה: {selectedProduct.ProductCategory}\n";
                    info += "\n==========================";

                    // שימוש ב-MessageBoxIcon.None מבטל את צליל ה"שגיאה" ששמעת קודם
                    MessageBox.Show(info, "פרטי מוצר", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                return;
            }

            // 2. טיפול בעמודת "בחר פריט" (תיבת הסימון V)
            if (dgvProduct.Columns[e.ColumnIndex].Name == "clmCheck")
            {
                var product = currentRow.DataBoundItem as BO.Product;
                if (product == null) return;

                // סיום עריכה כדי שהערך החדש של הצ'קבוקס ייקלט מיד
                dgvProduct.EndEdit();

                bool isChecked = currentRow.Cells["clmCheck"].Value != null && (bool)currentRow.Cells["clmCheck"].Value;

                if (isChecked)
                {
                    AddProductToCart(product);
                }
                else
                {
                    var itemToRemove = currentOrder.Products.FirstOrDefault(p => p.Id == product.Id);
                    if (itemToRemove != null)
                    {
                        currentOrder.Products.Remove(itemToRemove);
                        bl.Order.CalcTotalPrice(currentOrder);
                        RefreshCartGrid();
                    }
                }
            }
        }

        //עדכון טבלת המוצרים למשל אחרי שעושים מינוס למוצר- ירד הוי במוצרים
        private void UpdateProductCheckboxes()
        {
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                var product = row.DataBoundItem as BO.Product;
                if (product != null)
                {
                    bool existsInCart = currentOrder.Products.Any(p => p.Id == product.Id);

                    // שימוש בשם העמודה שהגדרנו למעלה
                    row.Cells["clmCheck"].Value = existsInCart;
                }
            }
        }
        //חיפוש לקוח מועדון
        private void chkIsClubMember_CheckedChanged(object sender, EventArgs e)
        {
            // עדכון המודל בהתאם לסימון
            currentOrder.IsClubMember = chkIsClubMember.Checked;

            // הרצת חישוב מחירים מחדש לכל המוצרים בסל
            try
            {
                foreach (var item in currentOrder.Products)
                {
                    // קריאה לפונקציה ב-BL שמחשבת מבצעים
                    bl.Order.SearchSaleForProduct(item, currentOrder.IsClubMember);
                    bl.Order.CalcTotalPriceForProduct(item);
                }
                bl.Order.CalcTotalPrice(currentOrder);
                RefreshCartGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters(); // מפעיל את הסינון המשולב
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters(); // מפעיל את הסינון המשולב
        }
        //כפתור  שמנקה את הסינון
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            cmbCategory.SelectedItem = null;
            ApplyFilters(); // יציג שוב את כל המוצרים
        }

        //פונקצי הלחיפוש הלקוח בפועל
        private void btnCheckCustomer_Click(object sender, EventArgs e)
        {
            string input = cmbCustomers.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("נא להזין שם או מספר זיהוי לחיפוש.", "חיפוש לקוח");
                return;
            }

            var customerList = cmbCustomers.DataSource as List<BO.Customer>;
            var foundCustomer = customerList?.FirstOrDefault(c =>
                c.Id.ToString() == input ||
                c.Name.Contains(input, StringComparison.OrdinalIgnoreCase));

            if (foundCustomer != null)
            {
                // לקוח קיים נמצא
                cmbCustomers.SelectedItem = foundCustomer;
                lblCustomerStatus.Text = $"לקוח נמצא: {foundCustomer.Name}";
                lblCustomerStatus.ForeColor = Color.Green;

                // סימון אוטומטי כחבר מועדון
                chkIsClubMember.Checked = true;
                currentOrder.IsClubMember = true;
            }
            else
            {
                var result = MessageBox.Show($"הלקוח '{input}' לא נמצא. האם תרצה להוסיף אותו כעת למועדון?",
                                             "לקוח חדש", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CustomerForm frm = new CustomerForm();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // כאן אנחנו מרעננים את הטופס
                        button6_Click(sender, e);

                        // לאחר הריענון, אנחנו מוודאים שהצ'קבוקס מסומן
                        chkIsClubMember.Checked = true;
                        currentOrder.IsClubMember = true;

                        MessageBox.Show("הלקוח נוסף וסומן כחבר מועדון.", "אישור", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
            }
        }

        //פונקציה לבחירת לקוח מתוך הרשימה
        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // בדיקה שנבחר אובייקט תקין מתוך הרשימה
            if (cmbCustomers.SelectedItem is BO.Customer selectedCustomer)
            {
                // עדכון פרטי הלקוח בהזמנה הנוכחית
                currentOrder.IsClubMember = true; // או הלוגיקה שלך לזיהוי חבר מועדון

                // עדכון הממשק בהתאם לבחירה
                lblCustomerStatus.Text = $"לקוח נבחר: {selectedCustomer.Name}";
                lblCustomerStatus.ForeColor = Color.Green;

                // רענון המחירים בעגלה (בהנחה שהפונקציה הזו קיימת אצלך)
                //RefreshOrderWithDiscounts();
            }
        }
        ////פונקציה ל
        //private void RefreshOrderWithDiscounts()
        //{
        //    // כאן תכניס את הלוגיקה שלך לעדכון מחירים ב-UI
        //    // לדוגמה:
        //    if (currentOrder.Products != null)
        //    {
        //        // קריאה ל-BL לעדכון מחירים לפי סטטוס חבר מועדון
        //        // ... 
        //    }
        //}

        //פונקציה להוספת לקוח חדש למועדון
        private void HandleNewCustomer(string id)
        {
            var result = MessageBox.Show("הלקוח לא נמצא. האם ברצונך להוסיף לקוח חדש?",
                         "לקוח חדש", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // פתיחת טופס לקוח - חובה להשתמש ב-new
                CustomerForm frm = new CustomerForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // אחרי הרישום, מנסים לבדוק שוב
                    btnCheckCustomer_Click(null, null);
                }
            }
        }
        //ריענון הדף לאחר הוספת לקוח למועדון
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            CartForm cf = new CartForm();
            cf.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // פתיחה של מסך הכניסה הראשי
            //Form1 loginMenu = new Form1();
            //loginMenu.Show();

            // סגירה סופית של התפריט הנוכחי
            this.Close();
        }
    }
}