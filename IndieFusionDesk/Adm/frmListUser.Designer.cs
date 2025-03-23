namespace IndieDesk.Adm
{
    partial class frmListUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListUser));
            dgv1 = new DataGridView();
            btnFilter = new Button();
            btnClear = new Button();
            txtFilter = new TextBox();
            btnFechar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            SuspendLayout();
            // 
            // dgv1
            // 
            dgv1.BackgroundColor = Color.Black;
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv1.Location = new Point(0, 110);
            dgv1.Name = "dgv1";
            dgv1.Size = new Size(784, 361);
            dgv1.TabIndex = 0;
            dgv1.CellContentClick += dgv1_CellContentClick_1;
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
            btnFilter.Location = new Point(193, 489);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(150, 50);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
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
            btnClear.Location = new Point(423, 489);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 50);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtFilter
            // 
            txtFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilter.Location = new Point(295, 46);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(200, 29);
            txtFilter.TabIndex = 3;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Brown;
            btnFechar.FlatAppearance.BorderColor = Color.Maroon;
            btnFechar.FlatAppearance.BorderSize = 3;
            btnFechar.FlatAppearance.MouseDownBackColor = Color.Black;
            btnFechar.FlatAppearance.MouseOverBackColor = Color.Red;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.ForeColor = SystemColors.ControlLightLight;
            btnFechar.Location = new Point(698, 2);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(86, 36);
            btnFechar.TabIndex = 4;
            btnFechar.Text = "Close";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // frmListUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(784, 561);
            ControlBox = false;
            Controls.Add(btnFechar);
            Controls.Add(txtFilter);
            Controls.Add(btnClear);
            Controls.Add(btnFilter);
            Controls.Add(dgv1);
            Name = "frmListUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListUser";
            Load += frmListUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv1;
        private Button btnFilter;
        private Button btnClear;
        private TextBox txtFilter;
        private Button btnFechar;
    }
}