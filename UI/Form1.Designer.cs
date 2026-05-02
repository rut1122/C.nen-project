namespace UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnAdmin = new Button();
            btnSales = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnAdmin
            // 
            btnAdmin.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnAdmin.FlatAppearance.MouseOverBackColor = Color.Pink;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Snap ITC", 16F, FontStyle.Bold);
            btnAdmin.Location = new Point(980, 452);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(278, 203);
            btnAdmin.TabIndex = 0;
            btnAdmin.Text = "לניהול המלאי";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += button1_Click;
            // 
            // btnSales
            // 
            btnSales.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnSales.FlatAppearance.MouseOverBackColor = Color.Pink;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Snap ITC", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSales.Location = new Point(583, 224);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(248, 203);
            btnSales.TabIndex = 1;
            btnSales.Text = "להשכרת שמלות";
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Snap ITC", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RosyBrown;
            label1.Location = new Point(559, 89);
            label1.Name = "label1";
            label1.Size = new Size(419, 57);
            label1.TabIndex = 2;
            label1.Text = "Dress Boutique";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1723, 920);
            Controls.Add(label1);
            Controls.Add(btnSales);
            Controls.Add(btnAdmin);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdmin;
        private Button btnSales;
        private Label label1;
    }
}
