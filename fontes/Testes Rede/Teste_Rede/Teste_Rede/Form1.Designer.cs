namespace Teste_Rede
{
    partial class Form1
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
            this.txtMensagemEnviada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMensagemRecebida = new System.Windows.Forms.TextBox();
            this.numPorta = new System.Windows.Forms.NumericUpDown();
            this.btnEnviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMensagemEnviada
            // 
            this.txtMensagemEnviada.Location = new System.Drawing.Point(12, 29);
            this.txtMensagemEnviada.Multiline = true;
            this.txtMensagemEnviada.Name = "txtMensagemEnviada";
            this.txtMensagemEnviada.Size = new System.Drawing.Size(252, 72);
            this.txtMensagemEnviada.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mensagem Enviada:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Porta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mensagem Recebida:";
            // 
            // txtMensagemRecebida
            // 
            this.txtMensagemRecebida.Location = new System.Drawing.Point(12, 123);
            this.txtMensagemRecebida.Multiline = true;
            this.txtMensagemRecebida.Name = "txtMensagemRecebida";
            this.txtMensagemRecebida.Size = new System.Drawing.Size(252, 72);
            this.txtMensagemRecebida.TabIndex = 4;
            // 
            // numPorta
            // 
            this.numPorta.Location = new System.Drawing.Point(284, 30);
            this.numPorta.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPorta.Name = "numPorta";
            this.numPorta.Size = new System.Drawing.Size(58, 20);
            this.numPorta.TabIndex = 5;
            this.numPorta.Value = new decimal(new int[] {
            5500,
            0,
            0,
            0});
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(283, 56);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 208);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.numPorta);
            this.Controls.Add(this.txtMensagemRecebida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMensagemEnviada);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMensagemEnviada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMensagemRecebida;
        private System.Windows.Forms.NumericUpDown numPorta;
        private System.Windows.Forms.Button btnEnviar;
    }
}

