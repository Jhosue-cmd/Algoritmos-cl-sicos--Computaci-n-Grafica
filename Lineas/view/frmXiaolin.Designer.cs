namespace Algoritmo_de_lineas
{
    partial class frmXiaolin
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxGrafico.SuspendLayout();
            this.groupBoxPuntos.SuspendLayout();
            this.groupBoxAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDibujar
            // 
            this.btnDibujar.Location = new System.Drawing.Point(31, 30);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(100, 35);
            this.btnDibujar.TabIndex = 0;
            this.btnDibujar.Text = "Dibujar";
            this.btnDibujar.UseVisualStyleBackColor = true;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(158, 30);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 35);
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
            this.pictureBox1.Size = new System.Drawing.Size(411, 377);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxGrafico
            // 
            this.groupBoxGrafico.Controls.Add(this.pictureBox1);
            this.groupBoxGrafico.Location = new System.Drawing.Point(364, 17);
            this.groupBoxGrafico.Name = "groupBoxGrafico";
            this.groupBoxGrafico.Size = new System.Drawing.Size(426, 410);
            this.groupBoxGrafico.TabIndex = 3;
            this.groupBoxGrafico.TabStop = false;
            this.groupBoxGrafico.Text = "Gráfico";
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
            this.groupBoxPuntos.Location = new System.Drawing.Point(19, 45);
            this.groupBoxPuntos.Name = "groupBoxPuntos";
            this.groupBoxPuntos.Size = new System.Drawing.Size(302, 130);
            this.groupBoxPuntos.TabIndex = 4;
            this.groupBoxPuntos.TabStop = false;
            this.groupBoxPuntos.Text = "Puntos";
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(18, 31);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(22, 16);
            this.lblX1.TabIndex = 0;
            this.lblX1.Text = "X1";
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(160, 31);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(23, 16);
            this.lblY1.TabIndex = 1;
            this.lblY1.Text = "Y1";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(18, 98);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(22, 16);
            this.lblX2.TabIndex = 2;
            this.lblX2.Text = "X2";
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(160, 98);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(23, 16);
            this.lblY2.TabIndex = 3;
            this.lblY2.Text = "Y2";
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(46, 28);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(100, 22);
            this.txtX1.TabIndex = 4;
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(189, 28);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(100, 22);
            this.txtY1.TabIndex = 5;
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(46, 92);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(100, 22);
            this.txtX2.TabIndex = 6;
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(189, 92);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(100, 22);
            this.txtY2.TabIndex = 7;
            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnBorrar);
            this.groupBoxAcciones.Controls.Add(this.btnDibujar);
            this.groupBoxAcciones.Location = new System.Drawing.Point(24, 205);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(296, 100);
            this.groupBoxAcciones.TabIndex = 5;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // 
            // frmXiaolin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxPuntos);
            this.Controls.Add(this.groupBoxGrafico);
            this.Name = "frmXiaolin";
            this.Text = "Algoritmo de Xiaolin Wu - Trazado de Líneas (Anti-aliasing)";
            this.Load += new System.EventHandler(this.frmXiaolin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxGrafico.ResumeLayout(false);
            this.groupBoxPuntos.ResumeLayout(false);
            this.groupBoxPuntos.PerformLayout();
            this.groupBoxAcciones.ResumeLayout(false);
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
    }
}
