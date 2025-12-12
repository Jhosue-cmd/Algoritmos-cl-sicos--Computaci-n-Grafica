namespace Algoritmo_de_lineas
{
    partial class frmDDA
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
            this.btnDibujar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxGrafico = new System.Windows.Forms.GroupBox();
            this.groupBoxPuntos = new System.Windows.Forms.GroupBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.lblX1 = new System.Windows.Forms.Label();
            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnPaso = new System.Windows.Forms.Button();
            this.btnSimular = new System.Windows.Forms.Button();
            this.groupBoxResultado = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxGrafico.SuspendLayout();
            this.groupBoxPuntos.SuspendLayout();
            this.groupBoxAcciones.SuspendLayout();
            this.groupBoxResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDibujar
            // 
            this.btnDibujar.Location = new System.Drawing.Point(15, 25);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(85, 32);
            this.btnDibujar.TabIndex = 0;
            this.btnDibujar.Text = "Dibujar";
            this.btnDibujar.UseVisualStyleBackColor = true;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(15, 63);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(85, 32);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 400);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxGrafico
            // 
            this.groupBoxGrafico.Controls.Add(this.pictureBox1);
            this.groupBoxGrafico.Location = new System.Drawing.Point(340, 12);
            this.groupBoxGrafico.Name = "groupBoxGrafico";
            this.groupBoxGrafico.Size = new System.Drawing.Size(480, 435);
            this.groupBoxGrafico.TabIndex = 3;
            this.groupBoxGrafico.TabStop = false;
            this.groupBoxGrafico.Text = "Gráfico - Simulación DDA";
            // 
            // groupBoxPuntos
            // 
            this.groupBoxPuntos.Controls.Add(this.txtY2);
            this.groupBoxPuntos.Controls.Add(this.txtX2);
            this.groupBoxPuntos.Controls.Add(this.txtY1);
            this.groupBoxPuntos.Controls.Add(this.txtX1);
            this.groupBoxPuntos.Controls.Add(this.lblY2);
            this.groupBoxPuntos.Controls.Add(this.lblX2);
            this.groupBoxPuntos.Controls.Add(this.lblY1);
            this.groupBoxPuntos.Controls.Add(this.lblX1);
            this.groupBoxPuntos.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPuntos.Name = "groupBoxPuntos";
            this.groupBoxPuntos.Size = new System.Drawing.Size(310, 90);
            this.groupBoxPuntos.TabIndex = 4;
            this.groupBoxPuntos.TabStop = false;
            this.groupBoxPuntos.Text = "Coordenadas";
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(190, 55);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(100, 22);
            this.txtY2.TabIndex = 7;
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(46, 55);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(100, 22);
            this.txtX2.TabIndex = 6;
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(190, 25);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(100, 22);
            this.txtY1.TabIndex = 5;
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(46, 25);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(100, 22);
            this.txtX1.TabIndex = 4;
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(160, 58);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(26, 16);
            this.lblY2.TabIndex = 3;
            this.lblY2.Text = "Y2:";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(15, 58);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(25, 16);
            this.lblX2.TabIndex = 2;
            this.lblX2.Text = "X2:";
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(160, 28);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(26, 16);
            this.lblY1.TabIndex = 1;
            this.lblY1.Text = "Y1:";
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(15, 28);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(25, 16);
            this.lblX1.TabIndex = 0;
            this.lblX1.Text = "X1:";
            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnDetener);
            this.groupBoxAcciones.Controls.Add(this.btnPaso);
            this.groupBoxAcciones.Controls.Add(this.btnSimular);
            this.groupBoxAcciones.Controls.Add(this.btnBorrar);
            this.groupBoxAcciones.Controls.Add(this.btnDibujar);
            this.groupBoxAcciones.Location = new System.Drawing.Point(12, 108);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(310, 105);
            this.groupBoxAcciones.TabIndex = 5;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.LightCoral;
            this.btnDetener.Enabled = false;
            this.btnDetener.Location = new System.Drawing.Point(205, 25);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(85, 70);
            this.btnDetener.TabIndex = 4;
            this.btnDetener.Text = " Detener";
            this.btnDetener.UseVisualStyleBackColor = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnPaso
            // 
            this.btnPaso.BackColor = System.Drawing.Color.LightBlue;
            this.btnPaso.Enabled = false;
            this.btnPaso.Location = new System.Drawing.Point(110, 63);
            this.btnPaso.Name = "btnPaso";
            this.btnPaso.Size = new System.Drawing.Size(85, 32);
            this.btnPaso.TabIndex = 3;
            this.btnPaso.Text = " Paso";
            this.btnPaso.UseVisualStyleBackColor = false;
            this.btnPaso.Click += new System.EventHandler(this.btnPaso_Click);
            // 
            // btnSimular
            // 
            this.btnSimular.BackColor = System.Drawing.Color.LightGreen;
            this.btnSimular.Location = new System.Drawing.Point(110, 25);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(85, 32);
            this.btnSimular.TabIndex = 2;
            this.btnSimular.Text = "Simular";
            this.btnSimular.UseVisualStyleBackColor = false;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // groupBoxResultado
            // 
            this.groupBoxResultado.Controls.Add(this.txtResultado);
            this.groupBoxResultado.Location = new System.Drawing.Point(12, 219);
            this.groupBoxResultado.Name = "groupBoxResultado";
            this.groupBoxResultado.Size = new System.Drawing.Size(310, 228);
            this.groupBoxResultado.TabIndex = 6;
            this.groupBoxResultado.TabStop = false;
            this.groupBoxResultado.Text = "Información del Paso";
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtResultado.Location = new System.Drawing.Point(10, 22);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(290, 195);
            this.txtResultado.TabIndex = 0;
            // 
            // frmDDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.groupBoxResultado);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxPuntos);
            this.Controls.Add(this.groupBoxGrafico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDDA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo DDA - Simulación Paso a Paso";
            this.Load += new System.EventHandler(this.frmDDA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxGrafico.ResumeLayout(false);
            this.groupBoxPuntos.ResumeLayout(false);
            this.groupBoxPuntos.PerformLayout();
            this.groupBoxAcciones.ResumeLayout(false);
            this.groupBoxResultado.ResumeLayout(false);
            this.groupBoxResultado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxGrafico;
        private System.Windows.Forms.GroupBox groupBoxPuntos;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.GroupBox groupBoxAcciones;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.Button btnPaso;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.GroupBox groupBoxResultado;
        private System.Windows.Forms.TextBox txtResultado;
    }
}

