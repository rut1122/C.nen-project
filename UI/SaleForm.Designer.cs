namespace UI
{
    partial class SaleForm
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
            cmbProducts = new ComboBox();
            txtSalePrice = new TextBox();
            numRequiredAmount = new NumericUpDown();
            chkOnlyClub = new CheckBox();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numRequiredAmount).BeginInit();
            SuspendLayout();
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(419, 32);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(151, 28);
            cmbProducts.TabIndex = 0;
            // 
            // txtSalePrice
            // 
            txtSalePrice.Location = new Point(435, 75);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(125, 27);
            txtSalePrice.TabIndex = 1;
            // 
            // numRequiredAmount
            // 
            numRequiredAmount.Location = new Point(419, 119);
            numRequiredAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRequiredAmount.Name = "numRequiredAmount";
            numRequiredAmount.Size = new Size(150, 27);
            numRequiredAmount.TabIndex = 2;
            numRequiredAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkOnlyClub
            // 
            chkOnlyClub.AutoSize = true;
            chkOnlyClub.Location = new Point(460, 170);
            chkOnlyClub.Name = "chkOnlyClub";
            chkOnlyClub.Size = new Size(100, 24);
            chkOnlyClub.TabIndex = 3;
            chkOnlyClub.Text = "חבר מועדון";
            chkOnlyClub.UseVisualStyleBackColor = true;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(320, 200);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 4;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(320, 245);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(250, 27);
            dtpEnd.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(282, 318);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "שמירה";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(634, 32);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 7;
            label1.Text = "בחר מוצר למבצע";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(662, 81);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 8;
            label2.Text = "מחיר מבצע";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(634, 126);
            label3.Name = "label3";
            label3.Size = new Size(145, 20);
            label3.TabIndex = 9;
            label3.Text = "כמות מינימלית לקניה";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(627, 212);
            label4.Name = "label4";
            label4.Size = new Size(139, 20);
            label4.TabIndex = 10;
            label4.Text = "תאריך תחילת מבצע";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(634, 250);
            label5.Name = "label5";
            label5.Size = new Size(123, 20);
            label5.TabIndex = 11;
            label5.Text = "תאריך סיום מבצע";
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(chkOnlyClub);
            Controls.Add(numRequiredAmount);
            Controls.Add(txtSalePrice);
            Controls.Add(cmbProducts);
            Name = "SaleForm";
            Text = "SaleForm";
            Load += SaleForm_Load;
            ((System.ComponentModel.ISupportInitialize)numRequiredAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbProducts;
        private TextBox txtSalePrice;
        private NumericUpDown numRequiredAmount;
        private CheckBox chkOnlyClub;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}