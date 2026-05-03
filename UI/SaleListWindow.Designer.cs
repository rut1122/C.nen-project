namespace UI
{
    partial class SaleListWindow
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
            dgvSales = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // dgvSales
            // 
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(224, 243);
            dgvSales.Name = "dgvSales";
            dgvSales.RowHeadersWidth = 51;
            dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.Size = new Size(300, 188);
            dgvSales.TabIndex = 0;
            dgvSales.CellContentClick += dgvSales_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(643, 63);
            button1.Name = "button1";
            button1.Size = new Size(129, 29);
            button1.TabIndex = 1;
            button1.Text = "הוספת מבצע";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(643, 115);
            button2.Name = "button2";
            button2.Size = new Size(129, 29);
            button2.TabIndex = 2;
            button2.Text = "עדכון מבצע";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(643, 174);
            button3.Name = "button3";
            button3.Size = new Size(129, 29);
            button3.TabIndex = 3;
            button3.Text = "מחיקה";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // SaleListWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 597);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvSales);
            Name = "SaleListWindow";
            Text = "SaleListWindow";
            Load += SaleListWindow_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSales;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}