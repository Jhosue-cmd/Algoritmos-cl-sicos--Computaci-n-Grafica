namespace Algoritmo_de_lineas.Recorte_de_Lineas.view
{
    partial class frmNichollLeeNicholl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxGrafico = new System.Windows.Forms.GroupBox();
            this.groupBoxVentana = new System.Windows.Forms.GroupBox();
            this.txtYMax = new System.Windows.Forms.TextBox();
            this.txtXMax = new System.Windows.Forms.TextBox();
            this.txtYMin = new System.Windows.Forms.TextBox();
            this.txtXMin = new System.Windows.Forms.TextBox();
            this.lblYMax = new System.Windows.Forms.Label();
            this.lblXMax = new System.Windows.Forms.Label();
            this.lblYMin = new System.Windows.Forms.Label();
            this.lblXMin = new System.Windows.Forms.Label();
            this.groupBoxLinea = new System.Windows.Forms.GroupBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.lblX1 = new System.Windows.Forms.Label();
            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.groupBoxResultado = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxGrafico.SuspendLayout();
            this.groupBoxVentana.SuspendLayout();
            this.groupBoxLinea.SuspendLayout();
            this.groupBoxAcciones.SuspendLayout();
            this.groupBoxResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxGrafico
            // 
            this.groupBoxGrafico.Controls.Add(this.pictureBox1);
            this.groupBoxGrafico.Location = new System.Drawing.Point(340, 12);
            this.groupBoxGrafico.Name = "groupBoxGrafico";
            this.groupBoxGrafico.Size = new System.Drawing.Size(530, 435);
            this.groupBoxGrafico.TabIndex = 1;
            this.groupBoxGrafico.TabStop = false;
            this.groupBoxGrafico.Text = "Área de Dibujo";
            // 
            // groupBoxVentana
            // 
            this.groupBoxVentana.Controls.Add(this.txtYMax);
            this.groupBoxVentana.Controls.Add(this.txtXMax);
            this.groupBoxVentana.Controls.Add(this.txtYMin);
            this.groupBoxVentana.Controls.Add(this.txtXMin);
            this.groupBoxVentana.Controls.Add(this.lblYMax);
            this.groupBoxVentana.Controls.Add(this.lblXMax);
            this.groupBoxVentana.Controls.Add(this.lblYMin);
            this.groupBoxVentana.Controls.Add(this.lblXMin);
            this.groupBoxVentana.Location = new System.Drawing.Point(12, 12);
            this.groupBoxVentana.Name = "groupBoxVentana";
            this.groupBoxVentana.Size = new System.Drawing.Size(310, 100);
            this.groupBoxVentana.TabIndex = 2;
            this.groupBoxVentana.TabStop = false;
            this.groupBoxVentana.Text = "Ventana de Recorte";
            // 
            // txtYMax
            // 
            this.txtYMax.Location = new System.Drawing.Point(220, 60);
            this.txtYMax.Name = "txtYMax";
            this.txtYMax.Size = new System.Drawing.Size(70, 22);
            this.txtYMax.TabIndex = 7;
            // 
            // txtXMax
            // 
            this.txtXMax.Location = new System.Drawing.Point(220, 28);
            this.txtXMax.Name = "txtXMax";
            this.txtXMax.Size = new System.Drawing.Size(70, 22);
            this.txtXMax.TabIndex = 6;
            // 
            // txtYMin
            // 
            this.txtYMin.Location = new System.Drawing.Point(70, 60);
            this.txtYMin.Name = "txtYMin";
            this.txtYMin.Size = new System.Drawing.Size(70, 22);
            this.txtYMin.TabIndex = 5;
            // 
            // txtXMin
            // 
            this.txtXMin.Location = new System.Drawing.Point(70, 28);
            this.txtXMin.Name = "txtXMin";
            this.txtXMin.Size = new System.Drawing.Size(70, 22);
            this.txtXMin.TabIndex = 4;
            // 
            // lblYMax
            // 
            this.lblYMax.AutoSize = true;
            this.lblYMax.Location = new System.Drawing.Point(160, 63);
            this.lblYMax.Name = "lblYMax";
            this.lblYMax.Size = new System.Drawing.Size(47, 16);
            this.lblYMax.TabIndex = 3;
            this.lblYMax.Text = "YMax:";
            // 
            // lblXMax
            // 
            this.lblXMax.AutoSize = true;
            this.lblXMax.Location = new System.Drawing.Point(160, 31);
            this.lblXMax.Name = "lblXMax";
            this.lblXMax.Size = new System.Drawing.Size(48, 16);
            this.lblXMax.TabIndex = 2;
            this.lblXMax.Text = "XMax:";
            // 
            // lblYMin
            // 
            this.lblYMin.AutoSize = true;
            this.lblYMin.Location = new System.Drawing.Point(15, 63);
            this.lblYMin.Name = "lblYMin";
            this.lblYMin.Size = new System.Drawing.Size(42, 16);
            this.lblYMin.TabIndex = 1;
            this.lblYMin.Text = "YMin:";
            // 
            // lblXMin
            // 
            this.lblXMin.AutoSize = true;
            this.lblXMin.Location = new System.Drawing.Point(15, 31);
            this.lblXMin.Name = "lblXMin";
            this.lblXMin.Size = new System.Drawing.Size(43, 16);
            this.lblXMin.TabIndex = 0;
            this.lblXMin.Text = "XMin:";
            // 
            // groupBoxLinea
            // 
            this.groupBoxLinea.Controls.Add(this.txtY2);
            this.groupBoxLinea.Controls.Add(this.txtX2);
            this.groupBoxLinea.Controls.Add(this.txtY1);
            this.groupBoxLinea.Controls.Add(this.txtX1);
            this.groupBoxLinea.Controls.Add(this.lblY2);
            this.groupBoxLinea.Controls.Add(this.lblX2);
            this.groupBoxLinea.Controls.Add(this.lblY1);
            this.groupBoxLinea.Controls.Add(this.lblX1);
            this.groupBoxLinea.Location = new System.Drawing.Point(12, 118);
            this.groupBoxLinea.Name = "groupBoxLinea";
            this.groupBoxLinea.Size = new System.Drawing.Size(310, 100);
            this.groupBoxLinea.TabIndex = 3;
            this.groupBoxLinea.TabStop = false;
            this.groupBoxLinea.Text = "Línea a Recortar";
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(220, 60);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(70, 22);
            this.txtY2.TabIndex = 7;
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(220, 28);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(70, 22);
            this.txtX2.TabIndex = 6;
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(70, 60);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(70, 22);
            this.txtY1.TabIndex = 5;
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(70, 28);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(70, 22);
            this.txtX1.TabIndex = 4;
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(175, 63);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(28, 16);
            this.lblY2.TabIndex = 3;
            this.lblY2.Text = "Y2:";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(175, 31);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(29, 16);
            this.lblX2.TabIndex = 2;
            this.lblX2.Text = "X2:";
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(15, 63);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(28, 16);
            this.lblY1.TabIndex = 1;
            this.lblY1.Text = "Y1:";
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(15, 31);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(29, 16);
            this.lblX1.TabIndex = 0;
            this.lblX1.Text = "X1:";
            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnBorrar);
            this.groupBoxAcciones.Controls.Add(this.btnRecortar);
            this.groupBoxAcciones.Location = new System.Drawing.Point(12, 224);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(310, 70);
            this.groupBoxAcciones.TabIndex = 4;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(165, 25);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(120, 35);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Location = new System.Drawing.Point(20, 25);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(120, 35);
            this.btnRecortar.TabIndex = 0;
            this.btnRecortar.Text = "Recortar";
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // groupBoxResultado
            // 
            this.groupBoxResultado.Controls.Add(this.txtResultado);
            this.groupBoxResultado.Location = new System.Drawing.Point(12, 300);
            this.groupBoxResultado.Name = "groupBoxResultado";
            this.groupBoxResultado.Size = new System.Drawing.Size(310, 160);
            this.groupBoxResultado.TabIndex = 5;
            this.groupBoxResultado.TabStop = false;
            this.groupBoxResultado.Text = "Resultado";
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Consolas", 8F);
            this.txtResultado.Location = new System.Drawing.Point(10, 22);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(290, 128);
            this.txtResultado.TabIndex = 0;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(12, 468);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(295, 16);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Listo. Ingrese los datos y presione Recortar.";
            // 
            // frmNichollLeeNicholl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 495);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.groupBoxResultado);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxLinea);
            this.Controls.Add(this.groupBoxVentana);
            this.Controls.Add(this.groupBoxGrafico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmNichollLeeNicholl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Nicholl-Lee-Nicholl - Recorte de Líneas";
            this.Load += new System.EventHandler(this.frmNichollLeeNicholl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxGrafico.ResumeLayout(false);
            this.groupBoxVentana.ResumeLayout(false);
            this.groupBoxVentana.PerformLayout();
            this.groupBoxLinea.ResumeLayout(false);
            this.groupBoxLinea.PerformLayout();
            this.groupBoxAcciones.ResumeLayout(false);
            this.groupBoxResultado.ResumeLayout(false);
            this.groupBoxResultado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxGrafico;
        private System.Windows.Forms.GroupBox groupBoxVentana;
        private System.Windows.Forms.TextBox txtYMax;
        private System.Windows.Forms.TextBox txtXMax;
        private System.Windows.Forms.TextBox txtYMin;
        private System.Windows.Forms.TextBox txtXMin;
        private System.Windows.Forms.Label lblYMax;
        private System.Windows.Forms.Label lblXMax;
        private System.Windows.Forms.Label lblYMin;
        private System.Windows.Forms.Label lblXMin;
        private System.Windows.Forms.GroupBox groupBoxLinea;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.GroupBox groupBoxAcciones;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.GroupBox groupBoxResultado;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblEstado;
    }
}