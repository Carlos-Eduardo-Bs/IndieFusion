namespace IndieDesk
{
    partial class mdiUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiUser));
            panel1 = new Panel();
            lblSession = new Label();
            menuStrip1 = new MenuStrip();
            usuárioToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            tipoUsuárioToolStripMenuItem = new ToolStripMenuItem();
            tsmiListarType = new ToolStripMenuItem();
            controleTipoUsuarioToolStripMenuItem = new ToolStripMenuItem();
            tsmiSair = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(lblSession);
            panel1.Location = new Point(0, 444);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 99);
            panel1.TabIndex = 0;
            // 
            // lblSession
            // 
            lblSession.AutoSize = true;
            lblSession.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSession.ForeColor = SystemColors.ControlLightLight;
            lblSession.Location = new Point(3, 33);
            lblSession.Name = "lblSession";
            lblSession.Size = new Size(78, 32);
            lblSession.TabIndex = 0;
            lblSession.Text = "label1";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Black;
            menuStrip1.Items.AddRange(new ToolStripItem[] { usuárioToolStripMenuItem, tipoUsuárioToolStripMenuItem, tsmiSair });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // usuárioToolStripMenuItem
            // 
            usuárioToolStripMenuItem.BackColor = Color.Black;
            usuárioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem4 });
            usuárioToolStripMenuItem.ForeColor = Color.BlueViolet;
            usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            usuárioToolStripMenuItem.Size = new Size(59, 20);
            usuárioToolStripMenuItem.Text = "&Usuário";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.BackColor = Color.Black;
            toolStripMenuItem4.ForeColor = SystemColors.ControlLightLight;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(163, 22);
            toolStripMenuItem4.Text = "&Controle Usuario";
            toolStripMenuItem4.Click += testeToolStripMenuItem_Click;
            // 
            // tipoUsuárioToolStripMenuItem
            // 
            tipoUsuárioToolStripMenuItem.BackColor = Color.Black;
            tipoUsuárioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiListarType, controleTipoUsuarioToolStripMenuItem });
            tipoUsuárioToolStripMenuItem.ForeColor = Color.BlueViolet;
            tipoUsuárioToolStripMenuItem.Name = "tipoUsuárioToolStripMenuItem";
            tipoUsuárioToolStripMenuItem.Size = new Size(86, 20);
            tipoUsuárioToolStripMenuItem.Text = "&Tipo Usuário";
            // 
            // tsmiListarType
            // 
            tsmiListarType.BackColor = Color.Black;
            tsmiListarType.ForeColor = SystemColors.ControlLightLight;
            tsmiListarType.Name = "tsmiListarType";
            tsmiListarType.Size = new Size(190, 22);
            tsmiListarType.Text = "&Listar";
            tsmiListarType.Click += tsmiListarType_Click;
            // 
            // controleTipoUsuarioToolStripMenuItem
            // 
            controleTipoUsuarioToolStripMenuItem.BackColor = Color.Black;
            controleTipoUsuarioToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            controleTipoUsuarioToolStripMenuItem.Name = "controleTipoUsuarioToolStripMenuItem";
            controleTipoUsuarioToolStripMenuItem.Size = new Size(190, 22);
            controleTipoUsuarioToolStripMenuItem.Text = "&Controle Tipo Usuario";
            controleTipoUsuarioToolStripMenuItem.Click += controleTipoUsuarioToolStripMenuItem_Click;
            // 
            // tsmiSair
            // 
            tsmiSair.BackColor = Color.Black;
            tsmiSair.ForeColor = Color.BlueViolet;
            tsmiSair.Name = "tsmiSair";
            tsmiSair.Size = new Size(38, 20);
            tsmiSair.Text = "&Sair";
            tsmiSair.Click += tsmiSair_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(535, 210);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 108);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(383, 210);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(96, 108);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(227, 210);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(105, 108);
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // mdiUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(884, 541);
            ControlBox = false;
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "mdiUser";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Main";
            Load += mdiUser_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblSession;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem usuárioToolStripMenuItem;
        private ToolStripMenuItem tipoUsuárioToolStripMenuItem;
        private ToolStripMenuItem tsmiListarType;
        private ToolStripMenuItem tsmiSair;
        private ToolStripMenuItem testeToolStripMenuItem;
        private ToolStripMenuItem controleTipoUsuarioToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}