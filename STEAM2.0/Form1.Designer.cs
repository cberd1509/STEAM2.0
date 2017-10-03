namespace STEAM2._0
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeloAnalíticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marxYLanghenheimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mandiYVolekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bobergLantzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPrincipal = new System.Windows.Forms.TabControl();
            this.gontijoYAzisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 341);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(653, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(188, 17);
            this.toolStripStatusLabel1.Text = "Steam 2.0 Cargado Correctamente";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(653, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStrip1_ItemAdded);
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeloAnalíticoToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // modeloAnalíticoToolStripMenuItem
            // 
            this.modeloAnalíticoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marxYLanghenheimToolStripMenuItem,
            this.mandiYVolekToolStripMenuItem,
            this.bobergLantzToolStripMenuItem,
            this.gontijoYAzisToolStripMenuItem});
            this.modeloAnalíticoToolStripMenuItem.Name = "modeloAnalíticoToolStripMenuItem";
            this.modeloAnalíticoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.modeloAnalíticoToolStripMenuItem.Text = "Modelo Analítico";
            // 
            // marxYLanghenheimToolStripMenuItem
            // 
            this.marxYLanghenheimToolStripMenuItem.Name = "marxYLanghenheimToolStripMenuItem";
            this.marxYLanghenheimToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.marxYLanghenheimToolStripMenuItem.Text = "Marx y Langhenheim";
            this.marxYLanghenheimToolStripMenuItem.Click += new System.EventHandler(this.marxYLanghenheimToolStripMenuItem_Click);
            // 
            // mandiYVolekToolStripMenuItem
            // 
            this.mandiYVolekToolStripMenuItem.Name = "mandiYVolekToolStripMenuItem";
            this.mandiYVolekToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.mandiYVolekToolStripMenuItem.Text = "Mandl y Volek";
            this.mandiYVolekToolStripMenuItem.Click += new System.EventHandler(this.mandiYVolekToolStripMenuItem_Click);
            // 
            // bobergLantzToolStripMenuItem
            // 
            this.bobergLantzToolStripMenuItem.Name = "bobergLantzToolStripMenuItem";
            this.bobergLantzToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.bobergLantzToolStripMenuItem.Text = "Boberg y Lantz";
            this.bobergLantzToolStripMenuItem.Click += new System.EventHandler(this.bobergLantzToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 24);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.SelectedIndex = 0;
            this.panelPrincipal.Size = new System.Drawing.Size(703, 329);
            this.panelPrincipal.TabIndex = 2;
            // 
            // gontijoYAzisToolStripMenuItem
            // 
            this.gontijoYAzisToolStripMenuItem.Name = "gontijoYAzisToolStripMenuItem";
            this.gontijoYAzisToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gontijoYAzisToolStripMenuItem.Text = "Gontijo y Azis";
            this.gontijoYAzisToolStripMenuItem.Click += new System.EventHandler(this.gontijoYAzisToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 363);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Steam 2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MdiChildActivate += new System.EventHandler(this.Form1_MdiChildActivate);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabControl panelPrincipal;
        private System.Windows.Forms.ToolStripMenuItem modeloAnalíticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marxYLanghenheimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mandiYVolekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bobergLantzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gontijoYAzisToolStripMenuItem;
    }
}

