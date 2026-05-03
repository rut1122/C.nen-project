namespace UI
{
    partial class CustomerListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBack = new Button();
            dgvCustomers = new DataGridView();
            btnAddCustomer = new Button();
            btnUpdateCustomer = new Button();
            btnDeleteCustomer = new Button();
            Label = new Label();
            txtSearchById = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(84, 33);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 0;
            btnBack.Text = "חזרה";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(186, 186);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(300, 188);
            dgvCustomers.TabIndex = 1;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(605, 67);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(183, 29);
            btnAddCustomer.TabIndex = 2;
            btnAddCustomer.Text = "הוספת לקוח חדש";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(605, 123);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(183, 29);
            btnUpdateCustomer.TabIndex = 3;
            btnUpdateCustomer.Text = "עדכון פרטי לקוח";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(605, 175);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(179, 29);
            btnDeleteCustomer.TabIndex = 4;
            btnDeleteCustomer.Text = "מחיקת לקוח";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Location = new Point(390, 163);
            Label.Name = "Label";
            Label.Size = new Size(96, 20);
            Label.TabIndex = 5;
            Label.Text = "חיפוש לפי ת.ז";
            // 
            // txtSearchById
            // 
            txtSearchById.Location = new Point(250, 160);
            txtSearchById.Name = "txtSearchById";
            txtSearchById.Size = new Size(125, 27);
            txtSearchById.TabIndex = 6;
            txtSearchById.TextChanged += txtSearchById_TextChanged;
            // 
            // CustomerListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 611);
            Controls.Add(txtSearchById);
            Controls.Add(Label);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(btnAddCustomer);
            Controls.Add(dgvCustomers);
            Controls.Add(btnBack);
            Name = "CustomerListForm";
            Text = "CustomerListForm";
            Load += CustomerListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private DataGridView dgvCustomers;
        private Button btnAddCustomer;
        private Button btnUpdateCustomer;
        private Button btnDeleteCustomer;
        private Label Label;
        private TextBox txtSearchById;
    }
}