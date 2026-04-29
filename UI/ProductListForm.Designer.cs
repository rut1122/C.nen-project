using System.Windows.Forms;
namespace UI
{
    partial class ProductListForm
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
            dataGridView1 = new DataGridView();
            cmbCategoryFilter = new ComboBox();
            add = new Button();
            updeate = new Button();
            delete = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(39, 151);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(546, 285);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(453, 108);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(151, 28);
            cmbCategoryFilter.TabIndex = 1;
            cmbCategoryFilter.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // add
            // 
            add.Location = new Point(668, 212);
            add.Name = "add";
            add.Size = new Size(94, 29);
            add.TabIndex = 2;
            add.Text = "הוספה";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // updeate
            // 
            updeate.Location = new Point(668, 248);
            updeate.Name = "updeate";
            updeate.Size = new Size(94, 29);
            updeate.TabIndex = 3;
            updeate.Text = "עידכון";
            updeate.UseVisualStyleBackColor = true;
            updeate.Click += updeate_Click;
            // 
            // delete
            // 
            delete.Location = new Point(668, 283);
            delete.Name = "delete";
            delete.Size = new Size(94, 29);
            delete.TabIndex = 4;
            delete.Text = "מחיקה";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // button1
            // 
            button1.Location = new Point(53, 18);
            button1.Name = "button1";
            button1.Size = new Size(134, 29);
            button1.TabIndex = 5;
            button1.Text = "חזרה לתפריט";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ProductListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(delete);
            Controls.Add(updeate);
            Controls.Add(add);
            Controls.Add(cmbCategoryFilter);
            Controls.Add(dataGridView1);
            Name = "ProductListForm";
            Text = "רשימת מוצרים";
            Load += ProductListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox cmbCategoryFilter;
        private Button add;
        private Button updeate;
        private Button delete;
        private Button button1;
    }
}