namespace soft
{
    partial class AdminDashboard
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
            this.button1 = new System.Windows.Forms.Button();
            this.pnEditProfile = new System.Windows.Forms.Panel();
            this.btnupdateAccount = new System.Windows.Forms.Button();
            this.tbNewEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbnewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbnewUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateProduct = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.lbwelcome = new System.Windows.Forms.Label();
            this.pnCreateProduct = new System.Windows.Forms.Panel();
            this.lbfilePath = new System.Windows.Forms.Label();
            this.btnSavePdf = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbBusinessArea = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.tbProductSoftware = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnEditProfile.SuspendLayout();
            this.pnCreateProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(728, -5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnEditProfile
            // 
            this.pnEditProfile.Controls.Add(this.btnupdateAccount);
            this.pnEditProfile.Controls.Add(this.tbNewEmail);
            this.pnEditProfile.Controls.Add(this.label4);
            this.pnEditProfile.Controls.Add(this.tbnewPassword);
            this.pnEditProfile.Controls.Add(this.label3);
            this.pnEditProfile.Controls.Add(this.tbnewUserName);
            this.pnEditProfile.Controls.Add(this.label2);
            this.pnEditProfile.Location = new System.Drawing.Point(146, 73);
            this.pnEditProfile.Name = "pnEditProfile";
            this.pnEditProfile.Size = new System.Drawing.Size(657, 373);
            this.pnEditProfile.TabIndex = 1;
            // 
            // btnupdateAccount
            // 
            this.btnupdateAccount.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnupdateAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnupdateAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnupdateAccount.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdateAccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnupdateAccount.Location = new System.Drawing.Point(97, 243);
            this.btnupdateAccount.Name = "btnupdateAccount";
            this.btnupdateAccount.Size = new System.Drawing.Size(233, 44);
            this.btnupdateAccount.TabIndex = 6;
            this.btnupdateAccount.Text = "Update account";
            this.btnupdateAccount.UseVisualStyleBackColor = false;
            this.btnupdateAccount.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbNewEmail
            // 
            this.tbNewEmail.Location = new System.Drawing.Point(214, 187);
            this.tbNewEmail.Name = "tbNewEmail";
            this.tbNewEmail.Size = new System.Drawing.Size(292, 20);
            this.tbNewEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 39);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email:";
            // 
            // tbnewPassword
            // 
            this.tbnewPassword.Location = new System.Drawing.Point(214, 123);
            this.tbnewPassword.Name = "tbnewPassword";
            this.tbnewPassword.Size = new System.Drawing.Size(292, 20);
            this.tbnewPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // tbnewUserName
            // 
            this.tbnewUserName.Location = new System.Drawing.Point(214, 53);
            this.tbnewUserName.Name = "tbnewUserName";
            this.tbnewUserName.Size = new System.Drawing.Size(292, 20);
            this.tbnewUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username:";
            // 
            // btnCreateProduct
            // 
            this.btnCreateProduct.Location = new System.Drawing.Point(1, 118);
            this.btnCreateProduct.Name = "btnCreateProduct";
            this.btnCreateProduct.Size = new System.Drawing.Size(148, 40);
            this.btnCreateProduct.TabIndex = 2;
            this.btnCreateProduct.Text = "Add product";
            this.btnCreateProduct.UseVisualStyleBackColor = true;
            this.btnCreateProduct.Click += new System.EventHandler(this.btnCreateProduct_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Create new user";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1, 188);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 34);
            this.button4.TabIndex = 4;
            this.button4.Text = "update product";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1, 220);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 37);
            this.button5.TabIndex = 5;
            this.button5.Text = "Delete product";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(353, -2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "search";
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Location = new System.Drawing.Point(1, 86);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(148, 37);
            this.btnEditProfile.TabIndex = 8;
            this.btnEditProfile.Text = "Edit profile";
            this.btnEditProfile.UseVisualStyleBackColor = true;
            this.btnEditProfile.Click += new System.EventHandler(this.button6_Click);
            // 
            // lbwelcome
            // 
            this.lbwelcome.AutoSize = true;
            this.lbwelcome.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwelcome.Location = new System.Drawing.Point(140, 37);
            this.lbwelcome.Name = "lbwelcome";
            this.lbwelcome.Size = new System.Drawing.Size(145, 33);
            this.lbwelcome.TabIndex = 9;
            this.lbwelcome.Text = "WELCOME";
            // 
            // pnCreateProduct
            // 
            this.pnCreateProduct.Controls.Add(this.lbfilePath);
            this.pnCreateProduct.Controls.Add(this.btnSavePdf);
            this.pnCreateProduct.Controls.Add(this.label10);
            this.pnCreateProduct.Controls.Add(this.tbUrl);
            this.pnCreateProduct.Controls.Add(this.label9);
            this.pnCreateProduct.Controls.Add(this.tbBusinessArea);
            this.pnCreateProduct.Controls.Add(this.label8);
            this.pnCreateProduct.Controls.Add(this.rtbDescription);
            this.pnCreateProduct.Controls.Add(this.btnAddProduct);
            this.pnCreateProduct.Controls.Add(this.tbProductSoftware);
            this.pnCreateProduct.Controls.Add(this.label5);
            this.pnCreateProduct.Controls.Add(this.label6);
            this.pnCreateProduct.Controls.Add(this.tbProductName);
            this.pnCreateProduct.Controls.Add(this.label7);
            this.pnCreateProduct.Location = new System.Drawing.Point(146, 73);
            this.pnCreateProduct.Name = "pnCreateProduct";
            this.pnCreateProduct.Size = new System.Drawing.Size(657, 373);
            this.pnCreateProduct.TabIndex = 10;
            // 
            // lbfilePath
            // 
            this.lbfilePath.AutoSize = true;
            this.lbfilePath.Font = new System.Drawing.Font("Gabriola", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbfilePath.Location = new System.Drawing.Point(246, 146);
            this.lbfilePath.Name = "lbfilePath";
            this.lbfilePath.Size = new System.Drawing.Size(130, 28);
            this.lbfilePath.TabIndex = 15;
            this.lbfilePath.Text = "file path shows here...";
            // 
            // btnSavePdf
            // 
            this.btnSavePdf.Location = new System.Drawing.Point(165, 147);
            this.btnSavePdf.Name = "btnSavePdf";
            this.btnSavePdf.Size = new System.Drawing.Size(75, 23);
            this.btnSavePdf.TabIndex = 13;
            this.btnSavePdf.Text = "Attach pdf";
            this.btnSavePdf.UseVisualStyleBackColor = true;
            this.btnSavePdf.Click += new System.EventHandler(this.btnSavePdf_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 29);
            this.label10.TabIndex = 12;
            this.label10.Text = "Save pdf file";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(165, 115);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(292, 20);
            this.tbUrl.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 29);
            this.label9.TabIndex = 10;
            this.label9.Text = "URL";
            // 
            // tbBusinessArea
            // 
            this.tbBusinessArea.Location = new System.Drawing.Point(165, 80);
            this.tbBusinessArea.Name = "tbBusinessArea";
            this.tbBusinessArea.Size = new System.Drawing.Size(292, 20);
            this.tbBusinessArea.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 29);
            this.label8.TabIndex = 8;
            this.label8.Text = "Business area";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(165, 180);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(357, 96);
            this.rtbDescription.TabIndex = 7;
            this.rtbDescription.Text = "";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnAddProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddProduct.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddProduct.Location = new System.Drawing.Point(8, 302);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(233, 44);
            this.btnAddProduct.TabIndex = 6;
            this.btnAddProduct.Text = "Add product";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // tbProductSoftware
            // 
            this.tbProductSoftware.Location = new System.Drawing.Point(165, 45);
            this.tbProductSoftware.Name = "tbProductSoftware";
            this.tbProductSoftware.Size = new System.Drawing.Size(292, 20);
            this.tbProductSoftware.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Type of software";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Description";
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(165, 13);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(292, 20);
            this.tbProductName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.pnCreateProduct);
            this.Controls.Add(this.lbwelcome);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCreateProduct);
            this.Controls.Add(this.pnEditProfile);
            this.Controls.Add(this.button1);
            this.Name = "AdminDashboard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.pnEditProfile.ResumeLayout(false);
            this.pnEditProfile.PerformLayout();
            this.pnCreateProduct.ResumeLayout(false);
            this.pnCreateProduct.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnEditProfile;
        private System.Windows.Forms.Button btnCreateProduct;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Label lbwelcome;
        private System.Windows.Forms.TextBox tbnewUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNewEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbnewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnupdateAccount;
        private System.Windows.Forms.Panel pnCreateProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TextBox tbProductSoftware;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbBusinessArea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSavePdf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbfilePath;
    }
}