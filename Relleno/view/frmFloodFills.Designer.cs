namespace Algoritmo_de_lineas.Relleno.view
{
    partial class frmFloodFills
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxGrafico = new System.Windows.Forms.GroupBox();
            this.groupBoxForma = new System.Windows.Forms.GroupBox();
            this.cmbForma = new System.Windows.Forms.ComboBox();
            this.lblForma = new System.Windows.Forms.Label();
            this.groupBoxCirculo = new System.Windows.Forms.GroupBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.txtCentroY = new System.Windows.Forms.TextBox();
            this.txtCentroX = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.lblCentroY = new System.Windows.Forms.Label();
            this.lblCentroX = new System.Windows.Forms.Label();
            this.groupBoxRectangulo = new System.Windows.Forms.GroupBox();
            this.txtAlto = new System.Windows.Forms.TextBox();
            this.txtAncho = new System.Windows.Forms.TextBox();
            this.lblAlto = new System.Windows.Forms.Label();
            this.lblAncho = new System.Windows.Forms.Label();
            this.groupBoxPoligono = new System.Windows.Forms.GroupBox();
            this.chkDibujarConMouse = new System.Windows.Forms.CheckBox();
            this.lstVertices = new System.Windows.Forms.ListBox();
            this.btnAgregarVertice = new System.Windows.Forms.Button();
            this.txtVerticeY = new System.Windows.Forms.TextBox();
            this.txtVerticeX = new System.Windows.Forms.TextBox();
            this.lblVerticeY = new System.Windows.Forms.Label();
            this.lblVerticeX = new System.Windows.Forms.Label();
            this.groupBoxColores = new System.Windows.Forms.GroupBox();
            this.cmbColorBorde = new System.Windows.Forms.ComboBox();
            this.cmbColorRelleno = new System.Windows.Forms.ComboBox();
            this.lblColorBorde = new System.Windows.Forms.Label();
            this.lblColorRelleno = new System.Windows.Forms.Label();
            this.groupBoxConectividad = new System.Windows.Forms.GroupBox();
            this.cmbTipoConectividad = new System.Windows.Forms.ComboBox();
            this.lblTipoConectividad = new System.Windows.Forms.Label();
            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnRellenar = new System.Windows.Forms.Button();
            this.btnDibujarForma = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxGrafico.SuspendLayout();
            this.groupBoxForma.SuspendLayout();
            this.groupBoxCirculo.SuspendLayout();
            this.groupBoxRectangulo.SuspendLayout();
            this.groupBoxPoligono.SuspendLayout();
            this.groupBoxColores.SuspendLayout();
            this.groupBoxConectividad.SuspendLayout();
            this.groupBoxAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // groupBoxGrafico
            // 
            this.groupBoxGrafico.Controls.Add(this.pictureBox1);
            this.groupBoxGrafico.Location = new System.Drawing.Point(380, 12);
            this.groupBoxGrafico.Name = "groupBoxGrafico";
            this.groupBoxGrafico.Size = new System.Drawing.Size(530, 485);
            this.groupBoxGrafico.TabIndex = 1;
            this.groupBoxGrafico.TabStop = false;
            this.groupBoxGrafico.Text = "Área de Dibujo - Haga clic para seleccionar punto semilla";
            // 
            // groupBoxForma
            // 
            this.groupBoxForma.Controls.Add(this.cmbForma);
            this.groupBoxForma.Controls.Add(this.lblForma);
            this.groupBoxForma.Location = new System.Drawing.Point(12, 12);
            this.groupBoxForma.Name = "groupBoxForma";
            this.groupBoxForma.Size = new System.Drawing.Size(350, 55);
            this.groupBoxForma.TabIndex = 2;
            this.groupBoxForma.TabStop = false;
            this.groupBoxForma.Text = "Tipo de Forma";
            this.groupBoxForma.Enter += new System.EventHandler(this.groupBoxForma_Enter);
            // 
            // cmbForma
            // 
            this.cmbForma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbForma.FormattingEnabled = true;
            this.cmbForma.Items.AddRange(new object[] {
            "Círculo",
            "Rectángulo",
            "Polígono Manual"});
            this.cmbForma.Location = new System.Drawing.Point(80, 21);
            this.cmbForma.Name = "cmbForma";
            this.cmbForma.Size = new System.Drawing.Size(250, 24);
            this.cmbForma.TabIndex = 1;
            this.cmbForma.SelectedIndexChanged += new System.EventHandler(this.cmbForma_SelectedIndexChanged);
            // 
            // lblForma
            // 
            this.lblForma.AutoSize = true;
            this.lblForma.Location = new System.Drawing.Point(15, 24);
            this.lblForma.Name = "lblForma";
            this.lblForma.Size = new System.Drawing.Size(49, 16);
            this.lblForma.TabIndex = 0;
            this.lblForma.Text = "Forma:";
            // 
            // groupBoxCirculo
            // 
            this.groupBoxCirculo.Controls.Add(this.txtRadio);
            this.groupBoxCirculo.Controls.Add(this.txtCentroY);
            this.groupBoxCirculo.Controls.Add(this.txtCentroX);
            this.groupBoxCirculo.Controls.Add(this.lblRadio);
            this.groupBoxCirculo.Controls.Add(this.lblCentroY);
            this.groupBoxCirculo.Controls.Add(this.lblCentroX);
            this.groupBoxCirculo.Location = new System.Drawing.Point(12, 73);
            this.groupBoxCirculo.Name = "groupBoxCirculo";
            this.groupBoxCirculo.Size = new System.Drawing.Size(170, 120);
            this.groupBoxCirculo.TabIndex = 3;
            this.groupBoxCirculo.TabStop = false;
            this.groupBoxCirculo.Text = "Círculo";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(85, 85);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(70, 22);
            this.txtRadio.TabIndex = 5;
            // 
            // txtCentroY
            // 
            this.txtCentroY.Location = new System.Drawing.Point(85, 55);
            this.txtCentroY.Name = "txtCentroY";
            this.txtCentroY.Size = new System.Drawing.Size(70, 22);
            this.txtCentroY.TabIndex = 4;
            // 
            // txtCentroX
            // 
            this.txtCentroX.Location = new System.Drawing.Point(85, 25);
            this.txtCentroX.Name = "txtCentroX";
            this.txtCentroX.Size = new System.Drawing.Size(70, 22);
            this.txtCentroX.TabIndex = 3;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(15, 88);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(47, 16);
            this.lblRadio.TabIndex = 2;
            this.lblRadio.Text = "Radio:";
            // 
            // lblCentroY
            // 
            this.lblCentroY.AutoSize = true;
            this.lblCentroY.Location = new System.Drawing.Point(15, 58);
            this.lblCentroY.Name = "lblCentroY";
            this.lblCentroY.Size = new System.Drawing.Size(61, 16);
            this.lblCentroY.TabIndex = 1;
            this.lblCentroY.Text = "Centro Y:";
            // 
            // lblCentroX
            // 
            this.lblCentroX.AutoSize = true;
            this.lblCentroX.Location = new System.Drawing.Point(15, 28);
            this.lblCentroX.Name = "lblCentroX";
            this.lblCentroX.Size = new System.Drawing.Size(60, 16);
            this.lblCentroX.TabIndex = 0;
            this.lblCentroX.Text = "Centro X:";
            // 
            // groupBoxRectangulo
            // 
            this.groupBoxRectangulo.Controls.Add(this.txtAlto);
            this.groupBoxRectangulo.Controls.Add(this.txtAncho);
            this.groupBoxRectangulo.Controls.Add(this.lblAlto);
            this.groupBoxRectangulo.Controls.Add(this.lblAncho);
            this.groupBoxRectangulo.Enabled = false;
            this.groupBoxRectangulo.Location = new System.Drawing.Point(192, 73);
            this.groupBoxRectangulo.Name = "groupBoxRectangulo";
            this.groupBoxRectangulo.Size = new System.Drawing.Size(170, 120);
            this.groupBoxRectangulo.TabIndex = 4;
            this.groupBoxRectangulo.TabStop = false;
            this.groupBoxRectangulo.Text = "Rectángulo";
            // 
            // txtAlto
            // 
            this.txtAlto.Location = new System.Drawing.Point(70, 55);
            this.txtAlto.Name = "txtAlto";
            this.txtAlto.Size = new System.Drawing.Size(80, 22);
            this.txtAlto.TabIndex = 3;
            // 
            // txtAncho
            // 
            this.txtAncho.Location = new System.Drawing.Point(70, 25);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(80, 22);
            this.txtAncho.TabIndex = 2;
            // 
            // lblAlto
            // 
            this.lblAlto.AutoSize = true;
            this.lblAlto.Location = new System.Drawing.Point(15, 58);
            this.lblAlto.Name = "lblAlto";
            this.lblAlto.Size = new System.Drawing.Size(33, 16);
            this.lblAlto.TabIndex = 1;
            this.lblAlto.Text = "Alto:";
            // 
            // lblAncho
            // 
            this.lblAncho.AutoSize = true;
            this.lblAncho.Location = new System.Drawing.Point(15, 28);
            this.lblAncho.Name = "lblAncho";
            this.lblAncho.Size = new System.Drawing.Size(48, 16);
            this.lblAncho.TabIndex = 0;
            this.lblAncho.Text = "Ancho:";
            // 
            // groupBoxPoligono
            // 
            this.groupBoxPoligono.Controls.Add(this.chkDibujarConMouse);
            this.groupBoxPoligono.Controls.Add(this.lstVertices);
            this.groupBoxPoligono.Controls.Add(this.btnAgregarVertice);
            this.groupBoxPoligono.Controls.Add(this.txtVerticeY);
            this.groupBoxPoligono.Controls.Add(this.txtVerticeX);
            this.groupBoxPoligono.Controls.Add(this.lblVerticeY);
            this.groupBoxPoligono.Controls.Add(this.lblVerticeX);
            this.groupBoxPoligono.Enabled = false;
            this.groupBoxPoligono.Location = new System.Drawing.Point(12, 199);
            this.groupBoxPoligono.Name = "groupBoxPoligono";
            this.groupBoxPoligono.Size = new System.Drawing.Size(350, 130);
            this.groupBoxPoligono.TabIndex = 5;
            this.groupBoxPoligono.TabStop = false;
            this.groupBoxPoligono.Text = "Polígono Manual";
            // 
            // chkDibujarConMouse
            // 
            this.chkDibujarConMouse.AutoSize = true;
            this.chkDibujarConMouse.Location = new System.Drawing.Point(18, 100);
            this.chkDibujarConMouse.Name = "chkDibujarConMouse";
            this.chkDibujarConMouse.Size = new System.Drawing.Size(170, 20);
            this.chkDibujarConMouse.TabIndex = 6;
            this.chkDibujarConMouse.Text = "Agregar con clic mouse";
            this.chkDibujarConMouse.UseVisualStyleBackColor = true;
            // 
            // lstVertices
            // 
            this.lstVertices.FormattingEnabled = true;
            this.lstVertices.ItemHeight = 16;
            this.lstVertices.Location = new System.Drawing.Point(230, 20);
            this.lstVertices.Name = "lstVertices";
            this.lstVertices.Size = new System.Drawing.Size(105, 100);
            this.lstVertices.TabIndex = 5;
            // 
            // btnAgregarVertice
            // 
            this.btnAgregarVertice.Location = new System.Drawing.Point(18, 65);
            this.btnAgregarVertice.Name = "btnAgregarVertice";
            this.btnAgregarVertice.Size = new System.Drawing.Size(120, 30);
            this.btnAgregarVertice.TabIndex = 4;
            this.btnAgregarVertice.Text = "Agregar Vértice";
            this.btnAgregarVertice.UseVisualStyleBackColor = true;
            this.btnAgregarVertice.Click += new System.EventHandler(this.btnAgregarVertice_Click);
            // 
            // txtVerticeY
            // 
            this.txtVerticeY.Location = new System.Drawing.Point(165, 35);
            this.txtVerticeY.Name = "txtVerticeY";
            this.txtVerticeY.Size = new System.Drawing.Size(50, 22);
            this.txtVerticeY.TabIndex = 3;
            // 
            // txtVerticeX
            // 
            this.txtVerticeX.Location = new System.Drawing.Point(50, 35);
            this.txtVerticeX.Name = "txtVerticeX";
            this.txtVerticeX.Size = new System.Drawing.Size(50, 22);
            this.txtVerticeX.TabIndex = 2;
            // 
            // lblVerticeY
            // 
            this.lblVerticeY.AutoSize = true;
            this.lblVerticeY.Location = new System.Drawing.Point(130, 38);
            this.lblVerticeY.Name = "lblVerticeY";
            this.lblVerticeY.Size = new System.Drawing.Size(19, 16);
            this.lblVerticeY.TabIndex = 1;
            this.lblVerticeY.Text = "Y:";
            // 
            // lblVerticeX
            // 
            this.lblVerticeX.AutoSize = true;
            this.lblVerticeX.Location = new System.Drawing.Point(15, 38);
            this.lblVerticeX.Name = "lblVerticeX";
            this.lblVerticeX.Size = new System.Drawing.Size(18, 16);
            this.lblVerticeX.TabIndex = 0;
            this.lblVerticeX.Text = "X:";
            // 
            // groupBoxColores
            // 
            this.groupBoxColores.Controls.Add(this.cmbColorBorde);
            this.groupBoxColores.Controls.Add(this.cmbColorRelleno);
            this.groupBoxColores.Controls.Add(this.lblColorBorde);
            this.groupBoxColores.Controls.Add(this.lblColorRelleno);
            this.groupBoxColores.Location = new System.Drawing.Point(12, 335);
            this.groupBoxColores.Name = "groupBoxColores";
            this.groupBoxColores.Size = new System.Drawing.Size(350, 85);
            this.groupBoxColores.TabIndex = 6;
            this.groupBoxColores.TabStop = false;
            this.groupBoxColores.Text = "Colores";
            // 
            // cmbColorBorde
            // 
            this.cmbColorBorde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorBorde.FormattingEnabled = true;
            this.cmbColorBorde.Items.AddRange(new object[] {
            "Azul Claro",
            "Azul Oscuro",
            "Rojo",
            "Verde",
            "Naranja",
            "Púrpura",
            "Cian",
            "Magenta"});
            this.cmbColorBorde.Location = new System.Drawing.Point(120, 52);
            this.cmbColorBorde.Name = "cmbColorBorde";
            this.cmbColorBorde.Size = new System.Drawing.Size(210, 24);
            this.cmbColorBorde.TabIndex = 3;
            // 
            // cmbColorRelleno
            // 
            this.cmbColorRelleno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorRelleno.FormattingEnabled = true;
            this.cmbColorRelleno.Items.AddRange(new object[] {
            "Azul Claro",
            "Azul Oscuro",
            "Rojo",
            "Verde",
            "Naranja",
            "Púrpura",
            "Cian",
            "Magenta"});
            this.cmbColorRelleno.Location = new System.Drawing.Point(120, 22);
            this.cmbColorRelleno.Name = "cmbColorRelleno";
            this.cmbColorRelleno.Size = new System.Drawing.Size(210, 24);
            this.cmbColorRelleno.TabIndex = 2;
            // 
            // lblColorBorde
            // 
            this.lblColorBorde.AutoSize = true;
            this.lblColorBorde.Location = new System.Drawing.Point(15, 55);
            this.lblColorBorde.Name = "lblColorBorde";
            this.lblColorBorde.Size = new System.Drawing.Size(82, 16);
            this.lblColorBorde.TabIndex = 1;
            this.lblColorBorde.Text = "Color Borde:";
            // 
            // lblColorRelleno
            // 
            this.lblColorRelleno.AutoSize = true;
            this.lblColorRelleno.Location = new System.Drawing.Point(15, 25);
            this.lblColorRelleno.Name = "lblColorRelleno";
            this.lblColorRelleno.Size = new System.Drawing.Size(92, 16);
            this.lblColorRelleno.TabIndex = 0;
            this.lblColorRelleno.Text = "Color Relleno:";
            // 
            // groupBoxConectividad
            // 
            this.groupBoxConectividad.Controls.Add(this.cmbTipoConectividad);
            this.groupBoxConectividad.Controls.Add(this.lblTipoConectividad);
            this.groupBoxConectividad.Location = new System.Drawing.Point(12, 426);
            this.groupBoxConectividad.Name = "groupBoxConectividad";
            this.groupBoxConectividad.Size = new System.Drawing.Size(170, 55);
            this.groupBoxConectividad.TabIndex = 7;
            this.groupBoxConectividad.TabStop = false;
            this.groupBoxConectividad.Text = "Conectividad";
            // 
            // cmbTipoConectividad
            // 
            this.cmbTipoConectividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoConectividad.FormattingEnabled = true;
            this.cmbTipoConectividad.Items.AddRange(new object[] {
            "4-Conectividad",
            "8-Conectividad"});
            this.cmbTipoConectividad.Location = new System.Drawing.Point(55, 21);
            this.cmbTipoConectividad.Name = "cmbTipoConectividad";
            this.cmbTipoConectividad.Size = new System.Drawing.Size(105, 24);
            this.cmbTipoConectividad.TabIndex = 1;
            // 
            // lblTipoConectividad
            // 
            this.lblTipoConectividad.AutoSize = true;
            this.lblTipoConectividad.Location = new System.Drawing.Point(10, 24);
            this.lblTipoConectividad.Name = "lblTipoConectividad";
            this.lblTipoConectividad.Size = new System.Drawing.Size(38, 16);
            this.lblTipoConectividad.TabIndex = 0;
            this.lblTipoConectividad.Text = "Tipo:";
            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnBorrar);
            this.groupBoxAcciones.Controls.Add(this.btnRellenar);
            this.groupBoxAcciones.Controls.Add(this.btnDibujarForma);
            this.groupBoxAcciones.Location = new System.Drawing.Point(192, 426);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(170, 70);
            this.groupBoxAcciones.TabIndex = 8;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(115, 20);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(50, 40);
            this.btnBorrar.TabIndex = 2;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnRellenar
            // 
            this.btnRellenar.Location = new System.Drawing.Point(60, 20);
            this.btnRellenar.Name = "btnRellenar";
            this.btnRellenar.Size = new System.Drawing.Size(50, 40);
            this.btnRellenar.TabIndex = 1;
            this.btnRellenar.Text = "Rellenar";
            this.btnRellenar.UseVisualStyleBackColor = true;
            this.btnRellenar.Click += new System.EventHandler(this.btnRellenar_Click);
            // 
            // btnDibujarForma
            // 
            this.btnDibujarForma.Location = new System.Drawing.Point(6, 20);
            this.btnDibujarForma.Name = "btnDibujarForma";
            this.btnDibujarForma.Size = new System.Drawing.Size(50, 40);
            this.btnDibujarForma.TabIndex = 0;
            this.btnDibujarForma.Text = "Dibujar";
            this.btnDibujarForma.UseVisualStyleBackColor = true;
            this.btnDibujarForma.Click += new System.EventHandler(this.btnDibujarForma_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(380, 500);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(238, 16);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "Listo. Dibuje una forma para comenzar.";
            // 
            // frmFloodFills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 530);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxConectividad);
            this.Controls.Add(this.groupBoxColores);
            this.Controls.Add(this.groupBoxPoligono);
            this.Controls.Add(this.groupBoxRectangulo);
            this.Controls.Add(this.groupBoxCirculo);
            this.Controls.Add(this.groupBoxForma);
            this.Controls.Add(this.groupBoxGrafico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFloodFills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Flood Fill - Relleno por Semilla";
            this.Load += new System.EventHandler(this.frmFloodFills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxGrafico.ResumeLayout(false);
            this.groupBoxForma.ResumeLayout(false);
            this.groupBoxForma.PerformLayout();
            this.groupBoxCirculo.ResumeLayout(false);
            this.groupBoxCirculo.PerformLayout();
            this.groupBoxRectangulo.ResumeLayout(false);
            this.groupBoxRectangulo.PerformLayout();
            this.groupBoxPoligono.ResumeLayout(false);
            this.groupBoxPoligono.PerformLayout();
            this.groupBoxColores.ResumeLayout(false);
            this.groupBoxColores.PerformLayout();
            this.groupBoxConectividad.ResumeLayout(false);
            this.groupBoxConectividad.PerformLayout();
            this.groupBoxAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxGrafico;
        private System.Windows.Forms.GroupBox groupBoxForma;
        private System.Windows.Forms.ComboBox cmbForma;
        private System.Windows.Forms.Label lblForma;
        private System.Windows.Forms.GroupBox groupBoxCirculo;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.TextBox txtCentroY;
        private System.Windows.Forms.TextBox txtCentroX;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.Label lblCentroY;
        private System.Windows.Forms.Label lblCentroX;
        private System.Windows.Forms.GroupBox groupBoxRectangulo;
        private System.Windows.Forms.TextBox txtAlto;
        private System.Windows.Forms.TextBox txtAncho;
        private System.Windows.Forms.Label lblAlto;
        private System.Windows.Forms.Label lblAncho;
        private System.Windows.Forms.GroupBox groupBoxPoligono;
        private System.Windows.Forms.ListBox lstVertices;
        private System.Windows.Forms.Button btnAgregarVertice;
        private System.Windows.Forms.TextBox txtVerticeY;
        private System.Windows.Forms.TextBox txtVerticeX;
        private System.Windows.Forms.Label lblVerticeY;
        private System.Windows.Forms.Label lblVerticeX;
        private System.Windows.Forms.CheckBox chkDibujarConMouse;
        private System.Windows.Forms.GroupBox groupBoxColores;
        private System.Windows.Forms.ComboBox cmbColorBorde;
        private System.Windows.Forms.ComboBox cmbColorRelleno;
        private System.Windows.Forms.Label lblColorBorde;
        private System.Windows.Forms.Label lblColorRelleno;
        private System.Windows.Forms.GroupBox groupBoxConectividad;
        private System.Windows.Forms.ComboBox cmbTipoConectividad;
        private System.Windows.Forms.Label lblTipoConectividad;
        private System.Windows.Forms.GroupBox groupBoxAcciones;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnRellenar;
        private System.Windows.Forms.Button btnDibujarForma;
        private System.Windows.Forms.Label lblEstado;
    }
}