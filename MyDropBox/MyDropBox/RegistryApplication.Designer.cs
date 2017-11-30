namespace MyDropBox
{
    partial class RegistryApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.birthDate = new System.Windows.Forms.DateTimePicker();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordConfirm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.registry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(107, 29);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(154, 20);
            this.name.TabIndex = 1;
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(107, 66);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(154, 20);
            this.surname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surname";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(107, 102);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(154, 20);
            this.login.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Birth date";
            // 
            // birthDate
            // 
            this.birthDate.Location = new System.Drawing.Point(107, 209);
            this.birthDate.Name = "birthDate";
            this.birthDate.Size = new System.Drawing.Size(154, 20);
            this.birthDate.TabIndex = 7;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(107, 138);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(154, 20);
            this.password.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password";
            // 
            // passwordConfirm
            // 
            this.passwordConfirm.Location = new System.Drawing.Point(107, 174);
            this.passwordConfirm.Name = "passwordConfirm";
            this.passwordConfirm.PasswordChar = '*';
            this.passwordConfirm.Size = new System.Drawing.Size(154, 20);
            this.passwordConfirm.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Confirm password";
            // 
            // registry
            // 
            this.registry.Location = new System.Drawing.Point(107, 240);
            this.registry.Name = "registry";
            this.registry.Size = new System.Drawing.Size(84, 24);
            this.registry.TabIndex = 12;
            this.registry.Text = "Registry";
            this.registry.UseVisualStyleBackColor = true;
            this.registry.Click += new System.EventHandler(this.registry_Click);
            // 
            // RegistryApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 276);
            this.Controls.Add(this.registry);
            this.Controls.Add(this.passwordConfirm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.birthDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistryApplication";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistryApplication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker birthDate;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordConfirm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button registry;
    }
}