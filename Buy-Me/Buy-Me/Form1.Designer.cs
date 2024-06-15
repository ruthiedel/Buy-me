namespace Buy_Me
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
            this.btnbusiness = new System.Windows.Forms.Button();
            this.btnusing = new System.Windows.Forms.Button();
            this.btnclient = new System.Windows.Forms.Button();
            this.btnpurchase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnbusiness
            // 
            this.btnbusiness.Location = new System.Drawing.Point(227, 93);
            this.btnbusiness.Name = "btnbusiness";
            this.btnbusiness.Size = new System.Drawing.Size(144, 84);
            this.btnbusiness.TabIndex = 4;
            this.btnbusiness.Text = "בית עסק";
            this.btnbusiness.UseVisualStyleBackColor = true;
            this.btnbusiness.Click += new System.EventHandler(this.btnbusiness_Click);
            // 
            // btnusing
            // 
            this.btnusing.Location = new System.Drawing.Point(29, 91);
            this.btnusing.Name = "btnusing";
            this.btnusing.Size = new System.Drawing.Size(145, 86);
            this.btnusing.TabIndex = 5;
            this.btnusing.Text = "שימוש בכרטיס";
            this.btnusing.UseVisualStyleBackColor = true;
            this.btnusing.Click += new System.EventHandler(this.btnusing_Click);
            // 
            // btnclient
            // 
            this.btnclient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclient.Location = new System.Drawing.Point(633, 93);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(155, 84);
            this.btnclient.TabIndex = 6;
            this.btnclient.Text = "לקוחות";
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // btnpurchase
            // 
            this.btnpurchase.BackColor = System.Drawing.Color.Transparent;
            this.btnpurchase.Location = new System.Drawing.Point(444, 94);
            this.btnpurchase.Name = "btnpurchase";
            this.btnpurchase.Size = new System.Drawing.Size(151, 83);
            this.btnpurchase.TabIndex = 7;
            this.btnpurchase.Text = "קנייה";
            this.btnpurchase.UseVisualStyleBackColor = false;
            this.btnpurchase.Click += new System.EventHandler(this.btnpurchase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Buy_Me.Properties.Resources.unnamed;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnpurchase);
            this.Controls.Add(this.btnclient);
            this.Controls.Add(this.btnusing);
            this.Controls.Add(this.btnbusiness);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnbusiness;
        private System.Windows.Forms.Button btnusing;
        private System.Windows.Forms.Button btnclient;
        private System.Windows.Forms.Button btnpurchase;
    }
}

