namespace ReconhecimentoFacialTest
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.camBox = new Emgu.CV.UI.ImageBox();
            this.btnDetec = new System.Windows.Forms.Button();
            this.btnCad = new System.Windows.Forms.Button();
            this.txtCad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.camBox)).BeginInit();
            this.SuspendLayout();
            // 
            // camBox
            // 
            this.camBox.Location = new System.Drawing.Point(25, 24);
            this.camBox.Name = "camBox";
            this.camBox.Size = new System.Drawing.Size(532, 559);
            this.camBox.TabIndex = 2;
            this.camBox.TabStop = false;
            // 
            // btnDetec
            // 
            this.btnDetec.BackColor = System.Drawing.Color.SeaShell;
            this.btnDetec.Location = new System.Drawing.Point(699, 140);
            this.btnDetec.Name = "btnDetec";
            this.btnDetec.Size = new System.Drawing.Size(244, 96);
            this.btnDetec.TabIndex = 3;
            this.btnDetec.Text = "Verificar ";
            this.btnDetec.UseVisualStyleBackColor = false;
            this.btnDetec.Click += new System.EventHandler(this.btnDetec_Click);
            // 
            // btnCad
            // 
            this.btnCad.BackColor = System.Drawing.Color.Honeydew;
            this.btnCad.Location = new System.Drawing.Point(608, 21);
            this.btnCad.Name = "btnCad";
            this.btnCad.Size = new System.Drawing.Size(161, 42);
            this.btnCad.TabIndex = 4;
            this.btnCad.Text = "Cadastrar pessoa";
            this.btnCad.UseVisualStyleBackColor = false;
            this.btnCad.Click += new System.EventHandler(this.btnCad_Click);
            // 
            // txtCad
            // 
            this.txtCad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCad.Location = new System.Drawing.Point(787, 29);
            this.txtCad.MaximumSize = new System.Drawing.Size(250, 90);
            this.txtCad.MinimumSize = new System.Drawing.Size(250, 25);
            this.txtCad.Name = "txtCad";
            this.txtCad.Size = new System.Drawing.Size(250, 24);
            this.txtCad.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1080, 603);
            this.Controls.Add(this.txtCad);
            this.Controls.Add(this.btnCad);
            this.Controls.Add(this.btnDetec);
            this.Controls.Add(this.camBox);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.camBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox camBox;
        private System.Windows.Forms.Button btnDetec;
        private System.Windows.Forms.Button btnCad;
        private System.Windows.Forms.TextBox txtCad;
    }
}

