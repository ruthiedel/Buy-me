
namespace Buy_Me.Gui
{
    partial class FrmSelection
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
            this.btnsum = new System.Windows.Forms.Button();
            this.btnsort = new System.Windows.Forms.Button();
            this.btnsubject = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnsum
            // 
            this.btnsum.Location = new System.Drawing.Point(400, 149);
            this.btnsum.Name = "btnsum";
            this.btnsum.Size = new System.Drawing.Size(131, 59);
            this.btnsum.TabIndex = 6;
            this.btnsum.Text = "סכומים";
            this.btnsum.UseVisualStyleBackColor = true;
            this.btnsum.Click += new System.EventHandler(this.btnsum_Click);
            // 
            // btnsort
            // 
            this.btnsort.Location = new System.Drawing.Point(228, 146);
            this.btnsort.Name = "btnsort";
            this.btnsort.Size = new System.Drawing.Size(130, 62);
            this.btnsort.TabIndex = 5;
            this.btnsort.Text = "קהלי יעד";
            this.btnsort.UseVisualStyleBackColor = true;
            this.btnsort.Click += new System.EventHandler(this.btnsort_Click);
            // 
            // btnsubject
            // 
            this.btnsubject.Location = new System.Drawing.Point(28, 146);
            this.btnsubject.Name = "btnsubject";
            this.btnsubject.Size = new System.Drawing.Size(130, 59);
            this.btnsubject.TabIndex = 4;
            this.btnsubject.Text = "תחומים";
            this.btnsubject.UseVisualStyleBackColor = true;
            this.btnsubject.Click += new System.EventHandler(this.btnsubject_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(42, 23);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(83, 31);
            this.btnback.TabIndex = 8;
            this.btnback.Text = "חזור";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // FrmSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Buy_Me.Properties.Resources.unnamed;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(567, 326);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnsum);
            this.Controls.Add(this.btnsort);
            this.Controls.Add(this.btnsubject);
            this.Name = "FrmSelection";
            this.Text = "תפריט קטגוריות";
            this.Load += new System.EventHandler(this.FrmSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnsum;
        private System.Windows.Forms.Button btnsort;
        private System.Windows.Forms.Button btnsubject;
        private System.Windows.Forms.Button btnback;
    }
}