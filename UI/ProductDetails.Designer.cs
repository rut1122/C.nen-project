namespace UI
{
    partial class ProductDetails
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
            txtId = new TextBox();
            txtProductName = new TextBox();
            txtPrice = new TextBox();
            btnSave = new Button();
            lblId = new Label();
            lblProductName = new Label();
            lblPrice = new Label();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(150, 30);
            txtId.Name = "txtId";
            txtId.Size = new Size(200, 27);
            txtId.TabIndex = 0;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(150, 70);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(200, 27);
            txtProductName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(150, 110);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 27);
            txtPrice.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 160);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "שמור";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click; // קישור לאירוע הלחיצה
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(30, 33);
            lblId.Name = "lblId";
            lblId.Size = new Size(27, 20);
            lblId.TabIndex = 4;
            lblId.Text = "ID:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(30, 73);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(78, 20);
            lblProductName.TabIndex = 5;
            lblProductName.Text = "שם מוצר:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(30, 113);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(45, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "מחיר:";
            // 
            // ProductDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 250);
            Controls.Add(lblPrice);
            Controls.Add(lblProductName);
            Controls.Add(lblId);
            Controls.Add(btnSave);
            Controls.Add(txtPrice);
            Controls.Add(txtProductName);
            Controls.Add(txtId);
            Name = "ProductDetails";
            Text = "פרטי מוצר";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // הצהרה על המשתנים (חייב להופיע כאן כדי שהקוד ב-ProductDetails.cs יכיר אותם)
        private TextBox txtId;
        private TextBox txtProductName;
        private TextBox txtPrice;
        private Button btnSave;
        private Label lblId;
        private Label lblProductName;
        private Label lblPrice;
    }
}