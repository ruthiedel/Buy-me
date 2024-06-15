
namespace Buy_Me.Gui
{
    partial class FrmUsing
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtcodecard = new System.Windows.Forms.TextBox();
            this.lblpel = new System.Windows.Forms.Label();
            this.btnok = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtcodeb = new System.Windows.Forms.TextBox();
            this.txtsum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelkindofcard = new System.Windows.Forms.Panel();
            this.btnmultycard = new System.Windows.Forms.Button();
            this.btncard = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelkindofcard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.txtcodecard);
            this.panel1.Controls.Add(this.lblpel);
            this.panel1.Controls.Add(this.btnok);
            this.panel1.Location = new System.Drawing.Point(262, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 138);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtcodecard
            // 
            this.txtcodecard.Location = new System.Drawing.Point(20, 36);
            this.txtcodecard.Name = "txtcodecard";
            this.txtcodecard.Size = new System.Drawing.Size(100, 20);
            this.txtcodecard.TabIndex = 2;
            // 
            // lblpel
            // 
            this.lblpel.AutoSize = true;
            this.lblpel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblpel.Location = new System.Drawing.Point(126, 37);
            this.lblpel.Name = "lblpel";
            this.lblpel.Size = new System.Drawing.Size(106, 16);
            this.lblpel.TabIndex = 1;
            this.lblpel.Text = "הקש קוד כרטיס";
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(71, 97);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "!הקשתי";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtcodeb);
            this.panel2.Controls.Add(this.txtsum);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(222, 241);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 138);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtcodeb
            // 
            this.txtcodeb.Location = new System.Drawing.Point(101, 81);
            this.txtcodeb.Name = "txtcodeb";
            this.txtcodeb.Size = new System.Drawing.Size(100, 20);
            this.txtcodeb.TabIndex = 3;
            // 
            // txtsum
            // 
            this.txtsum.Location = new System.Drawing.Point(101, 41);
            this.txtsum.Name = "txtsum";
            this.txtsum.Size = new System.Drawing.Size(100, 20);
            this.txtsum.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "קוד בית עסק";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "סכום";
            // 
            // panelkindofcard
            // 
            this.panelkindofcard.BackColor = System.Drawing.Color.Black;
            this.panelkindofcard.BackgroundImage = global::Buy_Me.Properties.Resources.images__1_;
            this.panelkindofcard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelkindofcard.Controls.Add(this.btnmultycard);
            this.panelkindofcard.Controls.Add(this.btncard);
            this.panelkindofcard.Location = new System.Drawing.Point(280, 58);
            this.panelkindofcard.Name = "panelkindofcard";
            this.panelkindofcard.Size = new System.Drawing.Size(214, 102);
            this.panelkindofcard.TabIndex = 3;
            // 
            // btnmultycard
            // 
            this.btnmultycard.BackColor = System.Drawing.Color.Yellow;
            this.btnmultycard.Location = new System.Drawing.Point(16, 30);
            this.btnmultycard.Name = "btnmultycard";
            this.btnmultycard.Size = new System.Drawing.Size(84, 34);
            this.btnmultycard.TabIndex = 1;
            this.btnmultycard.Text = "קנייה במולטיכרד";
            this.btnmultycard.UseVisualStyleBackColor = false;
            this.btnmultycard.Click += new System.EventHandler(this.btnmultycard_Click);
            // 
            // btncard
            // 
            this.btncard.BackColor = System.Drawing.Color.Yellow;
            this.btncard.Location = new System.Drawing.Point(106, 29);
            this.btncard.Name = "btncard";
            this.btncard.Size = new System.Drawing.Size(83, 35);
            this.btncard.TabIndex = 0;
            this.btncard.Text = "קנייה מכרטיס";
            this.btncard.UseVisualStyleBackColor = false;
            this.btncard.Click += new System.EventHandler(this.btncard_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Black;
            this.btnback.ForeColor = System.Drawing.Color.Yellow;
            this.btnback.Location = new System.Drawing.Point(605, 12);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(137, 39);
            this.btnback.TabIndex = 56;
            this.btnback.Text = "חזרה לתפריט ראשי";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // FrmUsing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Buy_Me.Properties.Resources.הורדה__1_;
            this.ClientSize = new System.Drawing.Size(763, 411);
            this.Controls.Add(this.panelkindofcard);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmUsing";
            this.Text = "FrmUsing";
            this.Load += new System.EventHandler(this.FrmUsing_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelkindofcard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtcodecard;
        private System.Windows.Forms.Label lblpel;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtcodeb;
        private System.Windows.Forms.TextBox txtsum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelkindofcard;
        private System.Windows.Forms.Button btnmultycard;
        private System.Windows.Forms.Button btncard;
        private System.Windows.Forms.Button btnback;
    }
}