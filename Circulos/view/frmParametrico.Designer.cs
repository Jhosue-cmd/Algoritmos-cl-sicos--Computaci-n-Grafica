namespace Algoritmo_de_lineas.Circulos.view
{
    partial class frmParametrico
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
            this.btnDibujar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxGrafico = new System.Windows.Forms.GroupBox();
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.txtYc = new System.Windows.Forms.TextBox();
            this.txtXc = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.lblYc = new System.Windows.Forms.Label();
            this.lblXc = new System.Windows.Forms.Label();
            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxGrafico.SuspendLayout();
            this.groupBoxDatos.SuspendLayout();
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
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.txtRadio);
            this.groupBoxDatos.Controls.Add(this.txtYc);
            this.groupBoxDatos.Controls.Add(this.txtXc);
            this.groupBoxDatos.Controls.Add(this.lblRadio);
            this.groupBoxDatos.Controls.Add(this.lblYc);
            this.groupBoxDatos.Controls.Add(this.lblXc);
            this.groupBoxDatos.Location = new System.Drawing.Point(19, 45);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Size = new System.Drawing.Size(302, 150);
            this.groupBoxDatos.TabIndex = 4;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Datos de la Circunferencia";
            // 
            // lblXc
            // 
            this.lblXc.AutoSize = true;
            this.lblXc.Location = new System.Drawing.Point(18, 35);
            this.lblXc.Name = "lblXc";
            this.lblXc.Size = new System.Drawing.Size(73, 16);
            this.lblXc.TabIndex = 0;
            this.lblXc.Text = "Centro X:";
            // 
            // lblYc
            // 
            this.lblYc.AutoSize = true;
            this.lblYc.Location = new System.Drawing.Point(18, 70);
            this.lblYc.Name = "lblYc";
            this.lblYc.Size = new System.Drawing.Size(74, 16);
            this.lblYc.TabIndex = 1;
            this.lblYc.Text = "Centro Y:";
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(18, 105);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(50, 16);
            this.lblRadio.TabIndex = 2;
            this.lblRadio.Text = "Radio:";
            // 
            // txtXc
            // 
            this.txtXc.Location = new System.Drawing.Point(120, 32);
            this.txtXc.Name = "txtXc";
            this.txtXc.Size = new System.Drawing.Size(150, 22);
            this.txtXc.TabIndex = 3;
            // 
            // txtYc
            // 
            this.txtYc.Location = new System.Drawing.Point(120, 67);
            this.txtYc.Name = "txtYc";
            this.txtYc.Size = new System.Drawing.Size(150, 22);
            this.txtYc.TabIndex = 4;
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(120, 102);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(150, 22);
            this.txtRadio.TabIndex = 5;
            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnBorrar);
            this.groupBoxAcciones.Controls.Add(this.btnDibujar);
            this.groupBoxAcciones.Location = new System.Drawing.Point(24, 220);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(296, 100);
            this.groupBoxAcciones.TabIndex = 5;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // 
            // frmParametrico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxDatos);
            this.Controls.Add(this.groupBoxGrafico);
            this.Name = "frmParametrico";
            this.Text = "Algoritmo Paramétrico - Circunferencia";
            this.Load += new System.EventHandler(this.frmParametrico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxGrafico.ResumeLayout(false);
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.groupBoxAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxGrafico;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.Label lblYc;
        private System.Windows.Forms.Label lblXc;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.TextBox txtYc;
        private System.Windows.Forms.TextBox txtXc;
        private System.Windows.Forms.GroupBox groupBoxAcciones;
    }
}