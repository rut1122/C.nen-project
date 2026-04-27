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
            btnAdmin = new Button();
            btnSales = new Button();
            SuspendLayout();
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(550, 219);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(155, 72);
            btnAdmin.TabIndex = 0;
            btnAdmin.Text = "כניסת מנהל";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += button1_Click;
            // 
            // btnSales
            // 
            btnSales.Location = new Point(352, 218);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(156, 73);
            btnSales.TabIndex = 1;
            btnSales.Text = "כניסת קופאי";
            btnSales.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 565);
            Controls.Add(btnSales);
            Controls.Add(btnAdmin);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdmin;
        private Button btnSales;
    }
}
