namespace Inventory_Management_Application
{
    partial class UserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(111)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.PasswordCheckBox);
            this.panel1.Controls.Add(this.ClearLabel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.PasswordTextBox);
            this.panel1.Controls.Add(this.UsernameTextBox);
            this.panel1.Controls.Add(this.LoginLabel);
            this.panel1.Location = new System.Drawing.Point(139, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 332);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(67, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // PasswordCheckBox
            // 
            this.PasswordCheckBox.AutoSize = true;
            this.PasswordCheckBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordCheckBox.ForeColor = System.Drawing.Color.SandyBrown;
            this.PasswordCheckBox.Location = new System.Drawing.Point(112, 267);
            this.PasswordCheckBox.Name = "PasswordCheckBox";
            this.PasswordCheckBox.Size = new System.Drawing.Size(123, 20);
            this.PasswordCheckBox.TabIndex = 5;
            this.PasswordCheckBox.Text = "Show Password";
            this.PasswordCheckBox.UseVisualStyleBackColor = true;
            this.PasswordCheckBox.CheckedChanged += new System.EventHandler(this.PasswordCheckBox_CheckedChanged);
            // 
            // ClearLabel
            // 
            this.ClearLabel.AutoSize = true;
            this.ClearLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLabel.ForeColor = System.Drawing.Color.SandyBrown;
            this.ClearLabel.Location = new System.Drawing.Point(36, 268);
            this.ClearLabel.Name = "ClearLabel";
            this.ClearLabel.Size = new System.Drawing.Size(43, 16);
            this.ClearLabel.TabIndex = 4;
            this.ClearLabel.Text = "Clear";
            this.ClearLabel.Click += new System.EventHandler(this.ClearLabel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(39, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(39, 167);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(172, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "Password";
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.ForeColor = System.Drawing.Color.Black;
            this.UsernameTextBox.Location = new System.Drawing.Point(39, 115);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(172, 20);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.Text = "Username";
            this.UsernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.ForeColor = System.Drawing.Color.White;
            this.LoginLabel.Location = new System.Drawing.Point(87, 15);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(66, 30);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Login";
            this.LoginLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(98, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inventory Management System";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(111)))), ((int)(((byte)(82)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 461);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(514, 10);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(111)))), ((int)(((byte)(82)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 10);
            this.panel2.TabIndex = 3;
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(514, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox PasswordCheckBox;
        private System.Windows.Forms.Label ClearLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
    }
}

