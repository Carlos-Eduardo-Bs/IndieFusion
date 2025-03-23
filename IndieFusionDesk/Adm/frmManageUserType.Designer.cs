namespace IndieFusionDesk.Adm
{
    partial class frmManageUserType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUserType));
            lblData = new Label();
            btnDelete = new Button();
            btnRecord = new Button();
            txtDescription = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            btnFechar = new Button();
            btnClear = new Button();
            dgv1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            SuspendLayout();
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(627, 101);
            lblData.Name = "lblData";
            lblData.Size = new Size(0, 15);
            lblData.TabIndex = 40;
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
            btnDelete.Location = new Point(246, 328);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 30;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
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
            btnRecord.Location = new Point(246, 220);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(100, 30);
            btnRecord.TabIndex = 31;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = false;
            btnRecord.Click += btnRecord_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(83, 308);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(129, 23);
            txtDescription.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(112, 290);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 34;
            label2.Text = "Descricao:";
            // 
            // txtId
            // 
            txtId.Location = new Point(124, 251);
            txtId.Name = "txtId";
            txtId.Size = new Size(38, 23);
            txtId.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(133, 228);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 33;
            label1.Text = "id:";
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
            btnFechar.Location = new Point(705, 1);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(80, 30);
            btnFechar.TabIndex = 32;
            btnFechar.Text = "Close";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
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
            btnClear.Location = new Point(246, 275);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 29;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // dgv1
            // 
            dgv1.BackgroundColor = Color.Black;
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv1.Location = new Point(362, 119);
            dgv1.Name = "dgv1";
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.Size = new Size(410, 361);
            dgv1.TabIndex = 26;
            dgv1.CellContentClick += dgv1_CellContentClick;
            // 
            // frmManageUserType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(784, 561);
            Controls.Add(lblData);
            Controls.Add(btnDelete);
            Controls.Add(btnRecord);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(btnFechar);
            Controls.Add(btnClear);
            Controls.Add(dgv1);
            ForeColor = SystemColors.ControlLightLight;
            Name = "frmManageUserType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmManageUserType";
            Load += frmManageUserType_Load;
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNickName;
        private Label a;
        private MaskedTextBox txtData;
        private Label lblData;
        private Label label6;
        private ComboBox cbox1;
        private Button btnDelete;
        private Button btnRecord;
        private TextBox txtPassword;
        private Label label5;
        private Label label4;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtDescription;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Button btnFechar;
        private TextBox txtFilter;
        private Button btnClear;
        private Button btnFilter;
        private DataGridView dgv1;
    }
}