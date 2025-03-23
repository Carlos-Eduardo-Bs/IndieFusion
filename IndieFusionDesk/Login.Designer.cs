namespace IndieDesk
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            txtNickName = new TextBox();
            txtPassword = new TextBox();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblSession = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(1218, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 148);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.BlueViolet;
            btnSubmit.FlatAppearance.BorderColor = Color.Indigo;
            btnSubmit.FlatAppearance.BorderSize = 3;
            btnSubmit.FlatAppearance.MouseDownBackColor = Color.Black;
            btnSubmit.FlatAppearance.MouseOverBackColor = Color.DarkViolet;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = SystemColors.ControlLight;
            btnSubmit.Location = new Point(1132, 539);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(150, 50);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.BlueViolet;
            btnCancel.FlatAppearance.BorderColor = Color.Indigo;
            btnCancel.FlatAppearance.BorderSize = 3;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.Black;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.DarkViolet;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(1308, 539);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 50);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(1251, 342);
            label1.Name = "label1";
            label1.Size = new Size(86, 21);
            label1.TabIndex = 3;
            label1.Text = "NickName:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(1258, 405);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // txtNickName
            // 
            txtNickName.Font = new Font("Segoe UI", 12F);
            txtNickName.Location = new Point(1199, 372);
            txtNickName.Name = "txtNickName";
            txtNickName.Size = new Size(200, 29);
            txtNickName.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(1199, 440);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 29);
            txtPassword.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(402, 113);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(129, 158);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(280, 290);
            label3.Name = "label3";
            label3.Size = new Size(393, 86);
            label3.TabIndex = 8;
            label3.Text = "  Bem vindo ";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(421, 361);
            label4.Name = "label4";
            label4.Size = new Size(88, 86);
            label4.TabIndex = 8;
            label4.Text = " a";
            label4.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(289, 429);
            label5.Name = "label5";
            label5.Size = new Size(177, 86);
            label5.TabIndex = 8;
            label5.Text = "Indie";
            label5.Click += label3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.BlueViolet;
            label6.Location = new Point(452, 429);
            label6.Name = "label6";
            label6.Size = new Size(221, 86);
            label6.TabIndex = 8;
            label6.Text = "Fusion";
            label6.Click += label3_Click;
            // 
            // lblSession
            // 
            lblSession.AutoSize = true;
            lblSession.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSession.Location = new Point(1299, 474);
            lblSession.Name = "lblSession";
            lblSession.Size = new Size(0, 30);
            lblSession.TabIndex = 9;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1520, 757);
            ControlBox = false;
            Controls.Add(lblSession);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(txtPassword);
            Controls.Add(txtNickName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(pictureBox1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnSubmit;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private TextBox txtNickName;
        private TextBox txtPassword;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblSession;
    }
}