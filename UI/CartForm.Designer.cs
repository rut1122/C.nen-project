namespace UI
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvProduct = new DataGridView();
            dgvCart = new DataGridView();
            lblTotal = new Label();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            button3 = new Button();
            button4 = new Button();
            chkIsClubMember = new CheckBox();
            txtSearch = new TextBox();
            cmbCategory = new ComboBox();
            btnReset = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbCustomers = new ComboBox();
            lblCustomerStatus = new Label();
            btnCheckCustomer = new Button();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // dgvProduct
            // 
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.BackgroundColor = Color.White;
            dgvProduct.BorderStyle = BorderStyle.None;
            dgvProduct.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Location = new Point(815, 184);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.RowHeadersVisible = false;
            dgvProduct.RowHeadersWidth = 51;
            dgvProduct.Size = new Size(740, 299);
            dgvProduct.TabIndex = 0;
            dgvProduct.CellContentClick += dgvProduct_CellContentClick;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(51, 184);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(682, 299);
            dgvCart.TabIndex = 1;
            dgvCart.CellClick += dgvCart_CellClick;
            dgvCart.CellDoubleClick += dgvCart_CellDoubleClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(251, 545);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(212, 28);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "סה\"כ לתשלום: 0.00 ₪";
            // 
            // button1
            // 
            button1.Location = new Point(303, 622);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 3;
            button1.Text = "ביטול הזמנה";
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(251, 576);
            button2.Name = "button2";
            button2.Size = new Size(220, 40);
            button2.TabIndex = 4;
            button2.Text = "בצע תשלום והדפס קבלה";
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.Location = new Point(0, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 28);
            comboBox1.TabIndex = 0;
            // 
            // button3
            // 
            button3.Font = new Font("Snap ITC", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(387, 489);
            button3.Name = "button3";
            button3.Size = new Size(84, 35);
            button3.TabIndex = 5;
            button3.Text = "+";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnAddAmount_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Snap ITC", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(251, 489);
            button4.Name = "button4";
            button4.Size = new Size(84, 35);
            button4.TabIndex = 5;
            button4.Text = "-";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnRemoveAmount_Click;
            // 
            // chkIsClubMember
            // 
            chkIsClubMember.AutoSize = true;
            chkIsClubMember.CheckAlign = ContentAlignment.MiddleRight;
            chkIsClubMember.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkIsClubMember.Location = new Point(1212, 512);
            chkIsClubMember.Name = "chkIsClubMember";
            chkIsClubMember.Size = new Size(194, 42);
            chkIsClubMember.TabIndex = 6;
            chkIsClubMember.Text = "?לקוח מועדון";
            chkIsClubMember.UseVisualStyleBackColor = true;
            chkIsClubMember.CheckedChanged += chkIsClubMember_CheckedChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(1344, 136);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 7;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(1134, 133);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 8;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1036, 119);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(60, 50);
            btnReset.TabIndex = 9;
            btnReset.Text = "איפוס";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1336, 103);
            label1.Name = "label1";
            label1.Size = new Size(133, 27);
            label1.TabIndex = 10;
            label1.Text = "חיפוש חופשי";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1132, 103);
            label2.Name = "label2";
            label2.Size = new Size(153, 27);
            label2.TabIndex = 10;
            label2.Text = "חיפוש קטגוריה";
            label2.Click += label1_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Perpetua Titling MT", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(681, 15);
            label3.Name = "label3";
            label3.Size = new Size(281, 48);
            label3.TabIndex = 11;
            label3.Text = "הזמנה חדשה";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Agency FB", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkSalmon;
            label4.Location = new Point(308, 133);
            label4.Name = "label4";
            label4.Size = new Size(208, 36);
            label4.TabIndex = 12;
            label4.Text = "ההזמנה שלך";
            // 
            // cmbCustomers
            // 
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(1307, 60);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(151, 28);
            cmbCustomers.TabIndex = 13;
            cmbCustomers.Text = "?יש לי מועדון";
            cmbCustomers.SelectedIndexChanged += cmbCustomers_SelectedIndexChanged;
            // 
            // lblCustomerStatus
            // 
            lblCustomerStatus.AutoSize = true;
            lblCustomerStatus.Location = new Point(898, 63);
            lblCustomerStatus.Name = "lblCustomerStatus";
            lblCustomerStatus.Size = new Size(0, 20);
            lblCustomerStatus.TabIndex = 14;
            // 
            // btnCheckCustomer
            // 
            btnCheckCustomer.Location = new Point(1191, 60);
            btnCheckCustomer.Name = "btnCheckCustomer";
            btnCheckCustomer.Size = new Size(94, 29);
            btnCheckCustomer.TabIndex = 15;
            btnCheckCustomer.Text = "אישור";
            btnCheckCustomer.UseVisualStyleBackColor = true;
            btnCheckCustomer.Click += btnCheckCustomer_Click;
            // 
            // button5
            // 
            button5.Location = new Point(87, 55);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 16;
            button5.Text = "חזרה";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1077, 63);
            button6.Name = "button6";
            button6.Size = new Size(94, 25);
            button6.TabIndex = 17;
            button6.Text = "↺רענן";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // CartForm
            // 
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1555, 611);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(btnCheckCustomer);
            Controls.Add(lblCustomerStatus);
            Controls.Add(cmbCustomers);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnReset);
            Controls.Add(cmbCategory);
            Controls.Add(txtSearch);
            Controls.Add(chkIsClubMember);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(lblTotal);
            Controls.Add(button1);
            Controls.Add(dgvCart);
            Controls.Add(dgvProduct);
            Name = "CartForm";
            Text = "קופת מכירה";
            Load += CartForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private Button button3;
        private Button button4;
        private CheckBox chkIsClubMember;
        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private Button btnReset;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbCustomers;
        private Label lblCustomerStatus;
        private Button btnCheckCustomer;
        private Button button5;
        private Button button6;
    }
}