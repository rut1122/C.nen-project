namespace UI
{
    partial class frmManagerMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagerMenu));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.MistyRose;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(864, 192);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(195, 128);
            button1.TabIndex = 0;
            button1.Text = " מוצרים      👗 ";
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.MistyRose;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Tahoma", 16.2F, FontStyle.Bold);
            button2.ForeColor = Color.IndianRed;
            button2.Location = new Point(864, 497);
            button2.Name = "button2";
            button2.Size = new Size(195, 128);
            button2.TabIndex = 1;
            button2.Text = "   לקוחות  👩";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.MistyRose;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Tahoma", 16.2F, FontStyle.Bold);
            button3.ForeColor = Color.IndianRed;
            button3.Location = new Point(864, 343);
            button3.Name = "button3";
            button3.Size = new Size(195, 128);
            button3.TabIndex = 2;
            button3.Text = "מבצעים    📆";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Tahoma", 16.2F, FontStyle.Bold);
            button4.ForeColor = Color.IndianRed;
            button4.Location = new Point(79, 30);
            button4.Name = "button4";
            button4.Size = new Size(140, 96);
            button4.TabIndex = 3;
            button4.Text = "חזרה";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // frmManagerMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1475, 871);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "frmManagerMenu";
            Text = "frmManagerMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}