﻿
namespace Buy_Me.Gui
{
    partial class FrmSort
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
            this.components = new System.ComponentModel.Container();
            this.btnnew = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtteur = new System.Windows.Forms.TextBox();
            this.txtsort = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(379, 331);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(75, 30);
            this.btnnew.TabIndex = 5;
            this.btnnew.Text = "חדש";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.Color.White;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(483, 89);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(247, 180);
            this.dg.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.txtteur);
            this.panel1.Controls.Add(this.txtsort);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Location = new System.Drawing.Point(71, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 161);
            this.panel1.TabIndex = 3;
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(32, 121);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "בטל";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(147, 121);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "שמור";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtteur
            // 
            this.txtteur.Location = new System.Drawing.Point(43, 57);
            this.txtteur.Name = "txtteur";
            this.txtteur.Size = new System.Drawing.Size(113, 20);
            this.txtteur.TabIndex = 1;
            // 
            // txtsort
            // 
            this.txtsort.Location = new System.Drawing.Point(43, 25);
            this.txtsort.Name = "txtsort";
            this.txtsort.Size = new System.Drawing.Size(113, 20);
            this.txtsort.TabIndex = 1;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(173, 64);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(82, 13);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "תאור  קהל יעד";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(183, 25);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(72, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "קוד קהל יעד";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(702, 12);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(86, 29);
            this.btnback.TabIndex = 6;
            this.btnback.Text = "חזור";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // FrmSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Buy_Me.Properties.Resources.הורדה1;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnnew);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSort";
            this.Text = "קהל יעד";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSort_FormClosing);
            this.Load += new System.EventHandler(this.FrmSort_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtteur;
        private System.Windows.Forms.TextBox txtsort;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnback;
    }
}