namespace QTCC_Server
{
    partial class frPrincipal
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Teste",
            "01/01/1900 00:00",
            "1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Teste");
            this.grpContatos = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstUsuariosOnline = new System.Windows.Forms.ListView();
            this.lstUsuariosOnlineVistoPorUltimo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstUsuariosOnlineNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpUsuariosOnline = new System.Windows.Forms.GroupBox();
            this.lstContatos = new System.Windows.Forms.ListView();
            this.lstContatosUsuarioNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.timerUsuariosOnline = new System.Windows.Forms.Timer(this.components);
            this.timerContatosUsuario = new System.Windows.Forms.Timer(this.components);
            this.grpContatos.SuspendLayout();
            this.grpUsuariosOnline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpContatos
            // 
            this.grpContatos.Controls.Add(this.lstContatos);
            this.grpContatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpContatos.Location = new System.Drawing.Point(0, 0);
            this.grpContatos.Name = "grpContatos";
            this.grpContatos.Size = new System.Drawing.Size(237, 337);
            this.grpContatos.TabIndex = 2;
            this.grpContatos.TabStop = false;
            this.grpContatos.Text = "Lista de Contatos";
            this.grpContatos.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Configurar Conexão";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstUsuariosOnline
            // 
            this.lstUsuariosOnline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstUsuariosOnlineNome,
            this.lstUsuariosOnlineVistoPorUltimo});
            this.lstUsuariosOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUsuariosOnline.FullRowSelect = true;
            this.lstUsuariosOnline.HideSelection = false;
            listViewItem2.Tag = "Teste";
            this.lstUsuariosOnline.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lstUsuariosOnline.Location = new System.Drawing.Point(3, 16);
            this.lstUsuariosOnline.MultiSelect = false;
            this.lstUsuariosOnline.Name = "lstUsuariosOnline";
            this.lstUsuariosOnline.ShowItemToolTips = true;
            this.lstUsuariosOnline.Size = new System.Drawing.Size(232, 318);
            this.lstUsuariosOnline.TabIndex = 4;
            this.lstUsuariosOnline.UseCompatibleStateImageBehavior = false;
            this.lstUsuariosOnline.View = System.Windows.Forms.View.Details;
            this.lstUsuariosOnline.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // lstUsuariosOnlineVistoPorUltimo
            // 
            this.lstUsuariosOnlineVistoPorUltimo.Text = "Visto por Último";
            this.lstUsuariosOnlineVistoPorUltimo.Width = 100;
            // 
            // lstUsuariosOnlineNome
            // 
            this.lstUsuariosOnlineNome.Text = "Nome";
            this.lstUsuariosOnlineNome.Width = 115;
            // 
            // grpUsuariosOnline
            // 
            this.grpUsuariosOnline.Controls.Add(this.lstUsuariosOnline);
            this.grpUsuariosOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUsuariosOnline.Location = new System.Drawing.Point(0, 0);
            this.grpUsuariosOnline.Name = "grpUsuariosOnline";
            this.grpUsuariosOnline.Size = new System.Drawing.Size(238, 337);
            this.grpUsuariosOnline.TabIndex = 5;
            this.grpUsuariosOnline.TabStop = false;
            this.grpUsuariosOnline.Text = "Usuários Online";
            // 
            // lstContatos
            // 
            this.lstContatos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstContatosUsuarioNome});
            this.lstContatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContatos.FullRowSelect = true;
            this.lstContatos.HideSelection = false;
            listViewItem1.Tag = "Teste";
            this.lstContatos.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstContatos.Location = new System.Drawing.Point(3, 16);
            this.lstContatos.MultiSelect = false;
            this.lstContatos.Name = "lstContatos";
            this.lstContatos.Size = new System.Drawing.Size(231, 318);
            this.lstContatos.TabIndex = 5;
            this.lstContatos.UseCompatibleStateImageBehavior = false;
            this.lstContatos.View = System.Windows.Forms.View.Details;
            // 
            // lstContatosUsuarioNome
            // 
            this.lstContatosUsuarioNome.Text = "Nome";
            this.lstContatosUsuarioNome.Width = 200;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(93, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpUsuariosOnline);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpContatos);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(479, 337);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 6;
            // 
            // timerUsuariosOnline
            // 
            this.timerUsuariosOnline.Interval = 10000;
            this.timerUsuariosOnline.Tick += new System.EventHandler(this.timerUsuariosOnline_Tick);
            // 
            // timerContatosUsuario
            // 
            this.timerContatosUsuario.Interval = 10000;
            this.timerContatosUsuario.Tick += new System.EventHandler(this.timerContatosUsuario_Tick);
            // 
            // frPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QTCC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frPrincipal_Load);
            this.grpContatos.ResumeLayout(false);
            this.grpUsuariosOnline.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpContatos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lstUsuariosOnline;
        private System.Windows.Forms.ColumnHeader lstUsuariosOnlineVistoPorUltimo;
        private System.Windows.Forms.ColumnHeader lstUsuariosOnlineNome;
        private System.Windows.Forms.GroupBox grpUsuariosOnline;
        private System.Windows.Forms.ListView lstContatos;
        private System.Windows.Forms.ColumnHeader lstContatosUsuarioNome;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timerUsuariosOnline;
        private System.Windows.Forms.Timer timerContatosUsuario;
    }
}

