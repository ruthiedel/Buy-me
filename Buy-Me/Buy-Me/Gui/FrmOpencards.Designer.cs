
namespace Buy_Me.Gui
{
    partial class FrmOpencards
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
            this.dgcards = new System.Windows.Forms.DataGridView();
            this.btnadd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncancle = new System.Windows.Forms.Button();
            this.btndone = new System.Windows.Forms.Button();
            this.txtsum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblresidence = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgcards)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcards
            // 
            this.dgcards.BackgroundColor = System.Drawing.Color.White;
            this.dgcards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcards.Location = new System.Drawing.Point(421, 60);
            this.dgcards.Name = "dgcards";
            this.dgcards.Size = new System.Drawing.Size(506, 251);
            this.dgcards.TabIndex = 0;
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.White;
            this.btnadd.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(586, 317);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(176, 60);
            this.btnadd.TabIndex = 1;
            this.btnadd.Text = "הוספה לכרטיס";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btncancle);
            this.panel1.Controls.Add(this.btndone);
            this.panel1.Controls.Add(this.txtsum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblresidence);
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(343, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 306);
            this.panel1.TabIndex = 2;
            // 
            // btncancle
            // 
            this.btncancle.BackColor = System.Drawing.Color.Orange;
            this.btncancle.Location = new System.Drawing.Point(12, 275);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(85, 25);
            this.btncancle.TabIndex = 5;
            this.btncancle.Text = "ביטול";
            this.btncancle.UseVisualStyleBackColor = false;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // btndone
            // 
            this.btndone.BackColor = System.Drawing.Color.Orange;
            this.btndone.Location = new System.Drawing.Point(108, 275);
            this.btndone.Name = "btndone";
            this.btndone.Size = new System.Drawing.Size(85, 25);
            this.btndone.TabIndex = 5;
            this.btndone.Text = "אישור קנייה";
            this.btndone.UseVisualStyleBackColor = false;
            this.btndone.Click += new System.EventHandler(this.btndone_Click);
            // 
            // txtsum
            // 
            this.txtsum.BackColor = System.Drawing.Color.Orange;
            this.txtsum.Location = new System.Drawing.Point(23, 230);
            this.txtsum.Name = "txtsum";
            this.txtsum.Size = new System.Drawing.Size(93, 20);
            this.txtsum.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = ":סכום להוספה";
            // 
            // lblresidence
            // 
            this.lblresidence.AutoSize = true;
            this.lblresidence.Location = new System.Drawing.Point(91, 202);
            this.lblresidence.Name = "lblresidence";
            this.lblresidence.Size = new System.Drawing.Size(35, 13);
            this.lblresidence.TabIndex = 2;
            this.lblresidence.Text = "label2";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(91, 179);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(35, 13);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 125);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.White;
            this.btnback.Location = new System.Drawing.Point(870, 16);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(106, 21);
            this.btnback.TabIndex = 3;
            this.btnback.Text = "חזרה";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // FrmOpencards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Buy_Me.Properties.Resources.הורדה1;
            this.ClientSize = new System.Drawing.Size(1004, 516);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.dgcards);
            this.Name = "FrmOpencards";
            this.Text = "FrmOpencards";
            this.Load += new System.EventHandler(this.FrmOpencards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcards)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgcards;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.Button btndone;
        private System.Windows.Forms.TextBox txtsum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblresidence;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnback;
    }
}