namespace Algoritmo_de_lineas.Recorte_de_poligonos.view
{
    partial class frmVatti
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxGrafico = new System.Windows.Forms.GroupBox();
            this.groupBoxVentana = new System.Windows.Forms.GroupBox();
            this.cmbOperacion = new System.Windows.Forms.ComboBox();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.txtYMax = new System.Windows.Forms.TextBox();
            this.txtXMax = new System.Windows.Forms.TextBox();
            this.txtYMin = new System.Windows.Forms.TextBox();
            this.txtXMin = new System.Windows.Forms.TextBox();
            this.lblYMax = new System.Windows.Forms.Label();
            this.lblXMax = new System.Windows.Forms.Label();
            this.lblYMin = new System.Windows.Forms.Label();
            this.lblXMin = new System.Windows.Forms.Label();
            this.groupBoxPoligono = new System.Windows.Forms.GroupBox();
            this.chkDibujarConMouse = new System.Windows.Forms.CheckBox();
            this.btnPoligonoEjemplo = new System.Windows.Forms.Button();
            this.lstVertices = new System.Windows.Forms.ListBox();
            this.btnAgregarVertice = new System.Windows.Forms.Button();
            this.txtVerticeY = new System.Windows.Forms.TextBox();
            this.txtVerticeX = new System.Windows.Forms.TextBox();
            this.lblVerticeY = new System.Windows.Forms.Label();
            this.lblVerticeX = new System.Windows.Forms.Label();
            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.groupBoxResultado = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxGrafico.SuspendLayout();
            this.groupBoxVentana.SuspendLayout();
            this.groupBoxPoligono.SuspendLayout();
            this.groupBoxAcciones.SuspendLayout();
            this.groupBoxResultado.SuspendLayout();
            this.SuspendLayout();
            // pictureBox1
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // groupBoxGrafico
            this.groupBoxGrafico.Controls.Add(this.pictureBox1);
            this.groupBoxGrafico.Location = new System.Drawing.Point(340, 12);
            this.groupBoxGrafico.Name = "groupBoxGrafico";
            this.groupBoxGrafico.Size = new System.Drawing.Size(530, 435);
            this.groupBoxGrafico.TabIndex = 1;
            this.groupBoxGrafico.TabStop = false;
            this.groupBoxGrafico.Text = "Área de Dibujo - Operaciones Booleanas";
            // groupBoxVentana
            this.groupBoxVentana.Controls.Add(this.cmbOperacion);
            this.groupBoxVentana.Controls.Add(this.lblOperacion);
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
            this.groupBoxVentana.Text = "Ventana y Operación";
            // cmbOperacion
            this.cmbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperacion.Location = new System.Drawing.Point(220, 70);
            this.cmbOperacion.Name = "cmbOperacion";
            this.cmbOperacion.Size = new System.Drawing.Size(80, 24);
            this.cmbOperacion.TabIndex = 9;
            // lblOperacion
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Location = new System.Drawing.Point(150, 73);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(68, 16);
            this.lblOperacion.TabIndex = 8;
            this.lblOperacion.Text = "Operación:";
            // txtYMax
            this.txtYMax.Location = new System.Drawing.Point(220, 42);
            this.txtYMax.Name = "txtYMax";
            this.txtYMax.Size = new System.Drawing.Size(50, 22);
            this.txtYMax.TabIndex = 7;
            // txtXMax
            this.txtXMax.Location = new System.Drawing.Point(220, 17);
            this.txtXMax.Name = "txtXMax";
            this.txtXMax.Size = new System.Drawing.Size(50, 22);
            this.txtXMax.TabIndex = 6;
            // txtYMin
            this.txtYMin.Location = new System.Drawing.Point(70, 42);
            this.txtYMin.Name = "txtYMin";
            this.txtYMin.Size = new System.Drawing.Size(50, 22);
            this.txtYMin.TabIndex = 5;
            // txtXMin
            this.txtXMin.Location = new System.Drawing.Point(70, 17);
            this.txtXMin.Name = "txtXMin";
            this.txtXMin.Size = new System.Drawing.Size(50, 22);
            this.txtXMin.TabIndex = 4;
            // lblYMax
            this.lblYMax.AutoSize = true;
            this.lblYMax.Location = new System.Drawing.Point(160, 45);
            this.lblYMax.Name = "lblYMax";
            this.lblYMax.Size = new System.Drawing.Size(47, 16);
            this.lblYMax.TabIndex = 3;
            this.lblYMax.Text = "YMax:";
            // lblXMax
            this.lblXMax.AutoSize = true;
            this.lblXMax.Location = new System.Drawing.Point(160, 20);
            this.lblXMax.Name = "lblXMax";
            this.lblXMax.Size = new System.Drawing.Size(48, 16);
            this.lblXMax.TabIndex = 2;
            this.lblXMax.Text = "XMax:";
            // lblYMin
            this.lblYMin.AutoSize = true;
            this.lblYMin.Location = new System.Drawing.Point(15, 45);
            this.lblYMin.Name = "lblYMin";
            this.lblYMin.Size = new System.Drawing.Size(42, 16);
            this.lblYMin.TabIndex = 1;
            this.lblYMin.Text = "YMin:";
            // lblXMin
            this.lblXMin.AutoSize = true;
            this.lblXMin.Location = new System.Drawing.Point(15, 20);
            this.lblXMin.Name = "lblXMin";
            this.lblXMin.Size = new System.Drawing.Size(43, 16);
            this.lblXMin.TabIndex = 0;
            this.lblXMin.Text = "XMin:";
            // groupBoxPoligono
            this.groupBoxPoligono.Controls.Add(this.chkDibujarConMouse);
            this.groupBoxPoligono.Controls.Add(this.btnPoligonoEjemplo);
            this.groupBoxPoligono.Controls.Add(this.lstVertices);
            this.groupBoxPoligono.Controls.Add(this.btnAgregarVertice);
            this.groupBoxPoligono.Controls.Add(this.txtVerticeY);
            this.groupBoxPoligono.Controls.Add(this.txtVerticeX);
            this.groupBoxPoligono.Controls.Add(this.lblVerticeY);
            this.groupBoxPoligono.Controls.Add(this.lblVerticeX);
            this.groupBoxPoligono.Location = new System.Drawing.Point(12, 118);
            this.groupBoxPoligono.Name = "groupBoxPoligono";
            this.groupBoxPoligono.Size = new System.Drawing.Size(310, 150);
            this.groupBoxPoligono.TabIndex = 3;
            this.groupBoxPoligono.TabStop = false;
            this.groupBoxPoligono.Text = "Polígono Sujeto";
            // chkDibujarConMouse
            this.chkDibujarConMouse.AutoSize = true;
            this.chkDibujarConMouse.Checked = true;
            this.chkDibujarConMouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDibujarConMouse.Location = new System.Drawing.Point(18, 123);
            this.chkDibujarConMouse.Name = "chkDibujarConMouse";
            this.chkDibujarConMouse.Size = new System.Drawing.Size(165, 20);
            this.chkDibujarConMouse.TabIndex = 7;
            this.chkDibujarConMouse.Text = "Agregar con clic mouse";
            // btnPoligonoEjemplo
            this.btnPoligonoEjemplo.Location = new System.Drawing.Point(195, 120);
            this.btnPoligonoEjemplo.Name = "btnPoligonoEjemplo";
            this.btnPoligonoEjemplo.Size = new System.Drawing.Size(100, 25);
            this.btnPoligonoEjemplo.TabIndex = 6;
            this.btnPoligonoEjemplo.Text = "Ejemplo";
            this.btnPoligonoEjemplo.Click += new System.EventHandler(this.btnPoligonoEjemplo_Click);
            // lstVertices
            this.lstVertices.FormattingEnabled = true;
            this.lstVertices.ItemHeight = 16;
            this.lstVertices.Location = new System.Drawing.Point(155, 20);
            this.lstVertices.Name = "lstVertices";
            this.lstVertices.Size = new System.Drawing.Size(140, 84);
            this.lstVertices.TabIndex = 5;
            // btnAgregarVertice
            this.btnAgregarVertice.Location = new System.Drawing.Point(18, 75);
            this.btnAgregarVertice.Name = "btnAgregarVertice";
            this.btnAgregarVertice.Size = new System.Drawing.Size(120, 28);
            this.btnAgregarVertice.TabIndex = 4;
            this.btnAgregarVertice.Text = "Agregar Vértice";
            this.btnAgregarVertice.Click += new System.EventHandler(this.btnAgregarVertice_Click);
            // txtVerticeY
            this.txtVerticeY.Location = new System.Drawing.Point(50, 47);
            this.txtVerticeY.Name = "txtVerticeY";
            this.txtVerticeY.Size = new System.Drawing.Size(88, 22);
            this.txtVerticeY.TabIndex = 3;
            // txtVerticeX
            this.txtVerticeX.Location = new System.Drawing.Point(50, 20);
            this.txtVerticeX.Name = "txtVerticeX";
            this.txtVerticeX.Size = new System.Drawing.Size(88, 22);
            this.txtVerticeX.TabIndex = 2;
            // lblVerticeY
            this.lblVerticeY.AutoSize = true;
            this.lblVerticeY.Location = new System.Drawing.Point(15, 50);
            this.lblVerticeY.Name = "lblVerticeY";
            this.lblVerticeY.Size = new System.Drawing.Size(21, 16);
            this.lblVerticeY.TabIndex = 1;
            this.lblVerticeY.Text = "Y:";
            // lblVerticeX
            this.lblVerticeX.AutoSize = true;
            this.lblVerticeX.Location = new System.Drawing.Point(15, 23);
            this.lblVerticeX.Name = "lblVerticeX";
            this.lblVerticeX.Size = new System.Drawing.Size(22, 16);
            this.lblVerticeX.TabIndex = 0;
            this.lblVerticeX.Text = "X:";
            // groupBoxAcciones
            this.groupBoxAcciones.Controls.Add(this.btnBorrar);
            this.groupBoxAcciones.Controls.Add(this.btnRecortar);
            this.groupBoxAcciones.Location = new System.Drawing.Point(12, 274);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(310, 60);
            this.groupBoxAcciones.TabIndex = 4;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // btnBorrar
            this.btnBorrar.Location = new System.Drawing.Point(165, 22);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(120, 30);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // btnRecortar
            this.btnRecortar.Location = new System.Drawing.Point(20, 22);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(120, 30);
            this.btnRecortar.TabIndex = 0;
            this.btnRecortar.Text = "Recortar";
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // groupBoxResultado
            this.groupBoxResultado.Controls.Add(this.txtResultado);
            this.groupBoxResultado.Location = new System.Drawing.Point(12, 340);
            this.groupBoxResultado.Name = "groupBoxResultado";
            this.groupBoxResultado.Size = new System.Drawing.Size(310, 120);
            this.groupBoxResultado.TabIndex = 5;
            this.groupBoxResultado.TabStop = false;
            this.groupBoxResultado.Text = "Resultado";
            // txtResultado
            this.txtResultado.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.txtResultado.Location = new System.Drawing.Point(10, 20);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(290, 90);
            this.txtResultado.TabIndex = 0;
            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(12, 468);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(305, 16);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Listo. Agregue vértices para crear un polígono.";
            // frmVatti
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 495);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.groupBoxResultado);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxPoligono);
            this.Controls.Add(this.groupBoxVentana);
            this.Controls.Add(this.groupBoxGrafico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmVatti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Vatti - Recorte de Polígonos";
            this.Load += new System.EventHandler(this.frmVatti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxGrafico.ResumeLayout(false);
            this.groupBoxVentana.ResumeLayout(false);
            this.groupBoxVentana.PerformLayout();
            this.groupBoxPoligono.ResumeLayout(false);
            this.groupBoxPoligono.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbOperacion;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.TextBox txtYMax;
        private System.Windows.Forms.TextBox txtXMax;
        private System.Windows.Forms.TextBox txtYMin;
        private System.Windows.Forms.TextBox txtXMin;
        private System.Windows.Forms.Label lblYMax;
        private System.Windows.Forms.Label lblXMax;
        private System.Windows.Forms.Label lblYMin;
        private System.Windows.Forms.Label lblXMin;
        private System.Windows.Forms.GroupBox groupBoxPoligono;
        private System.Windows.Forms.CheckBox chkDibujarConMouse;
        private System.Windows.Forms.Button btnPoligonoEjemplo;
        private System.Windows.Forms.ListBox lstVertices;
        private System.Windows.Forms.Button btnAgregarVertice;
        private System.Windows.Forms.TextBox txtVerticeY;
        private System.Windows.Forms.TextBox txtVerticeX;
        private System.Windows.Forms.Label lblVerticeY;
        private System.Windows.Forms.Label lblVerticeX;
        private System.Windows.Forms.GroupBox groupBoxAcciones;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.GroupBox groupBoxResultado;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblEstado;
    }
}