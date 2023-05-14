namespace TriangulareaUnuiPoligon
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Desenare = new System.Windows.Forms.Button();
            this.Triangulare = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(847, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            // 
            // Desenare
            // 
            this.Desenare.Location = new System.Drawing.Point(847, 169);
            this.Desenare.Name = "Desenare";
            this.Desenare.Size = new System.Drawing.Size(86, 27);
            this.Desenare.TabIndex = 1;
            this.Desenare.Text = "Desenare";
            this.Desenare.UseVisualStyleBackColor = true;
            this.Desenare.Click += new System.EventHandler(this.Desenare_Click);
            // 
            // Triangulare
            // 
            this.Triangulare.Location = new System.Drawing.Point(847, 229);
            this.Triangulare.Name = "Triangulare";
            this.Triangulare.Size = new System.Drawing.Size(100, 30);
            this.Triangulare.TabIndex = 2;
            this.Triangulare.Text = "Triangulare";
            this.Triangulare.UseVisualStyleBackColor = true;
            this.Triangulare.Click += new System.EventHandler(this.Triangulare_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(847, 292);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 27);
            this.button3.TabIndex = 3;
            this.button3.Text = "3-colorare";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(806, 608);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 628);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Triangulare);
            this.Controls.Add(this.Desenare);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Desenare;
        private System.Windows.Forms.Button Triangulare;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

