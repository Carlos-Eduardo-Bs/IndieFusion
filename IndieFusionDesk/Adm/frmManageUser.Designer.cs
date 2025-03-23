namespace IndieDesk.Adm
{
    partial class frmManageUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUser));
            btnFechar = new Button();
            txtFilter = new TextBox();
            btnClear = new Button();
            btnFilter = new Button();
            dgv1 = new DataGridView();
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtPassword = new TextBox();
            btnRecord = new Button();
            btnDelete = new Button();
            cbox1 = new ComboBox();
            txtData = new MaskedTextBox();
            lblData = new Label();
            label6 = new Label();
            txtNickName = new TextBox();
            a = new Label();
            btnCarregar = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Firebrick;
            btnFechar.FlatAppearance.BorderColor = Color.Maroon;
            btnFechar.FlatAppearance.BorderSize = 3;
            btnFechar.FlatAppearance.MouseDownBackColor = Color.Black;
            btnFechar.FlatAppearance.MouseOverBackColor = Color.Red;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.ForeColor = SystemColors.ControlLightLight;
            btnFechar.Location = new Point(706, 1);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(80, 30);
            btnFechar.TabIndex = 10;
            btnFechar.Text = "Close";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(227, 499);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(172, 23);
            txtFilter.TabIndex = 5;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.BlueViolet;
            btnClear.FlatAppearance.BorderColor = Color.Indigo;
            btnClear.FlatAppearance.BorderSize = 3;
            btnClear.FlatAppearance.MouseDownBackColor = Color.Black;
            btnClear.FlatAppearance.MouseOverBackColor = Color.DarkViolet;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = SystemColors.ControlLightLight;
            btnClear.Location = new Point(423, 511);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.BlueViolet;
            btnFilter.FlatAppearance.BorderColor = Color.Indigo;
            btnFilter.FlatAppearance.BorderSize = 3;
            btnFilter.FlatAppearance.MouseDownBackColor = Color.Black;
            btnFilter.FlatAppearance.MouseOverBackColor = Color.DarkViolet;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.ForeColor = SystemColors.ControlLightLight;
            btnFilter.Location = new Point(423, 475);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(100, 30);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // dgv1
            // 
            dgv1.BackgroundColor = Color.Black;
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv1.Location = new Point(2, 222);
            dgv1.Name = "dgv1";
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.Size = new Size(784, 234);
            dgv1.TabIndex = 5;
            dgv1.CellClick += dgv1_CellClick;


            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(30, 108);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 10;
            label1.Text = "id:";
            // 
            // txtId
            // 
            txtId.Location = new Point(30, 130);
            txtId.Name = "txtId";
            txtId.Size = new Size(38, 23);
            txtId.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(104, 74);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 10;
            label2.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(98, 96);
            txtName.Name = "txtName";
            txtName.Size = new Size(129, 23);
            txtName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(254, 74);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 10;
            label3.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(252, 96);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(129, 23);
            txtEmail.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(403, 74);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 10;
            label4.Text = "UserType:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(252, 129);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 10;
            label5.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(252, 151);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(129, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnRecord
            // 
            btnRecord.BackColor = Color.BlueViolet;
            btnRecord.FlatAppearance.BorderColor = Color.Indigo;
            btnRecord.FlatAppearance.BorderSize = 3;
            btnRecord.FlatAppearance.MouseDownBackColor = Color.Black;
            btnRecord.FlatAppearance.MouseOverBackColor = Color.DarkViolet;
            btnRecord.FlatStyle = FlatStyle.Flat;
            btnRecord.ForeColor = SystemColors.ControlLightLight;
            btnRecord.Location = new Point(529, 511);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(100, 30);
            btnRecord.TabIndex = 9;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = false;
            btnRecord.Click += btnRecord_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.FlatAppearance.BorderColor = Color.Maroon;
            btnDelete.FlatAppearance.BorderSize = 3;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.Black;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = SystemColors.ControlLightLight;
            btnDelete.Location = new Point(529, 475);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // cbox1
            // 
            cbox1.FormattingEnabled = true;
            cbox1.Location = new Point(403, 96);
            cbox1.Name = "cbox1";
            cbox1.RightToLeft = RightToLeft.No;
            cbox1.Size = new Size(129, 23);
            cbox1.TabIndex = 11;
            // 
            // txtData
            // 
            txtData.Location = new Point(403, 151);
            txtData.Mask = "00/00/0000";
            txtData.Name = "txtData";
            txtData.Size = new Size(129, 23);
            txtData.TabIndex = 19;
            txtData.ValidatingType = typeof(DateTime);
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.ForeColor = SystemColors.ControlLightLight;
            lblData.Location = new Point(30, 9);
            lblData.Name = "lblData";
            lblData.Size = new Size(0, 15);
            lblData.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(403, 130);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 17;
            label6.Text = "Data:";
            // 
            // txtNickName
            // 
            txtNickName.Location = new Point(100, 151);
            txtNickName.Name = "txtNickName";
            txtNickName.RightToLeft = RightToLeft.No;
            txtNickName.Size = new Size(127, 23);
            txtNickName.TabIndex = 21;
            // 
            // a
            // 
            a.AutoSize = true;
            a.BackColor = Color.Transparent;
            a.ForeColor = SystemColors.ControlLightLight;
            a.Location = new Point(100, 128);
            a.Name = "a";
            a.Size = new Size(66, 15);
            a.TabIndex = 20;
            a.Text = "NickName:";
            // 
            // btnCarregar
            // 
            btnCarregar.BackColor = Color.BlueViolet;
            btnCarregar.FlatAppearance.BorderColor = Color.Indigo;
            btnCarregar.FlatAppearance.BorderSize = 3;
            btnCarregar.FlatAppearance.MouseDownBackColor = Color.Black;
            btnCarregar.FlatAppearance.MouseOverBackColor = Color.DarkViolet;
            btnCarregar.FlatStyle = FlatStyle.Flat;
            btnCarregar.ForeColor = SystemColors.ControlLightLight;
            btnCarregar.Location = new Point(584, 180);
            btnCarregar.Name = "btnCarregar";
            btnCarregar.Size = new Size(75, 36);
            btnCarregar.TabIndex = 26;
            btnCarregar.Text = "Upload";
            btnCarregar.UseVisualStyleBackColor = false;
            btnCarregar.Click += btnCarregar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(558, 91);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 83);
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // frmManageUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(784, 561);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(btnCarregar);
            Controls.Add(txtNickName);
            Controls.Add(a);
            Controls.Add(txtData);
            Controls.Add(lblData);
            Controls.Add(label6);
            Controls.Add(cbox1);
            Controls.Add(btnDelete);
            Controls.Add(btnRecord);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(btnFechar);
            Controls.Add(txtFilter);
            Controls.Add(btnClear);
            Controls.Add(btnFilter);
            Controls.Add(dgv1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmManageUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageUser";
            Load += frmManageUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFechar;
        private TextBox txtFilter;
        private Button btnClear;
        private Button btnFilter;
        private DataGridView dgv1;
        private Label label1;
        private TextBox txtId;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private Label label5;
        private TextBox txtPassword;
        private Button btnRecord;
        private Button btnDelete;
        private ComboBox cbox1;
        private MaskedTextBox txtData;
        private Label lblData;
        private Label label6;
        private TextBox txtNickName;
        private Label a;
        private Button btnCarregar;
        private PictureBox pictureBox1;
    }
}