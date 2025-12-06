namespace Algoritmo_de_lineas.Relleno.view
{
    partial class frmPatternFill
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
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.btnQuitarVertice = new System.Windows.Forms.Button();
            this.lstVertices = new System.Windows.Forms.ListBox();
            this.lblVertices = new System.Windows.Forms.Label();
            this.btnAgregarVertice = new System.Windows.Forms.Button();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.groupBoxPatron = new System.Windows.Forms.GroupBox();
            this.pnlVistaPrevia = new System.Windows.Forms.Panel();
            this.lblVistaPrevia = new System.Windows.Forms.Label();
            this.numTamanoPatron = new System.Windows.Forms.NumericUpDown();
            this.lblTamano = new System.Windows.Forms.Label();
            this.cmbPatron = new System.Windows.Forms.ComboBox();
            this.lblPatron = new System.Windows.Forms.Label();
            this.groupBoxColores = new System.Windows.Forms.GroupBox();
            this.chkFondoTransparente = new System.Windows.Forms.CheckBox();
            this.cmbColorBorde = new System.Windows.Forms.ComboBox();
            this.cmbColorFondo = new System.Windows.Forms.ComboBox();
            this.cmbColorPatron = new System.Windows.Forms.ComboBox();
            this.lblColorBorde = new System.Windows.Forms.Label();
            this.lblColorFondo = new System.Windows.Forms.Label();
            this.lblColorPatron = new System.Windows.Forms.Label();
            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnRellenar = new System.Windows.Forms.Button();
            this.groupBoxOpciones = new System.Windows.Forms.GroupBox();
            this.chkDibujarConMouse = new System.Windows.Forms.CheckBox();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxGrafico.SuspendLayout();
            this.groupBoxDatos.SuspendLayout();
            this.groupBoxPatron.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTamanoPatron)).BeginInit();
            this.groupBoxColores.SuspendLayout();
            this.groupBoxAcciones.SuspendLayout();
            this.groupBoxOpciones.SuspendLayout();
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
            this.groupBoxGrafico.Text = "Área de Dibujo";
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.btnQuitarVertice);
            this.groupBoxDatos.Controls.Add(this.lstVertices);
            this.groupBoxDatos.Controls.Add(this.lblVertices);
            this.groupBoxDatos.Controls.Add(this.btnAgregarVertice);
            this.groupBoxDatos.Controls.Add(this.txtY);
            this.groupBoxDatos.Controls.Add(this.txtX);
            this.groupBoxDatos.Controls.Add(this.lblY);
            this.groupBoxDatos.Controls.Add(this.lblX);
            this.groupBoxDatos.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Size = new System.Drawing.Size(350, 150);
            this.groupBoxDatos.TabIndex = 2;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Vértices del Polígono";
            // 
            // btnQuitarVertice
            // 
            this.btnQuitarVertice.Location = new System.Drawing.Point(230, 110);
            this.btnQuitarVertice.Name = "btnQuitarVertice";
            this.btnQuitarVertice.Size = new System.Drawing.Size(105, 30);
            this.btnQuitarVertice.TabIndex = 7;
            this.btnQuitarVertice.Text = "Quitar Último";
            this.btnQuitarVertice.UseVisualStyleBackColor = true;
            this.btnQuitarVertice.Click += new System.EventHandler(this.btnQuitarVertice_Click);
            // 
            // lstVertices
            // 
            this.lstVertices.FormattingEnabled = true;
            this.lstVertices.ItemHeight = 16;
            this.lstVertices.Location = new System.Drawing.Point(230, 40);
            this.lstVertices.Name = "lstVertices";
            this.lstVertices.Size = new System.Drawing.Size(105, 68);
            this.lstVertices.TabIndex = 6;
            // 
            // lblVertices
            // 
            this.lblVertices.AutoSize = true;
            this.lblVertices.Location = new System.Drawing.Point(227, 21);
            this.lblVertices.Name = "lblVertices";
            this.lblVertices.Size = new System.Drawing.Size(60, 16);
            this.lblVertices.TabIndex = 5;
            this.lblVertices.Text = "Vértices:";
            // 
            // btnAgregarVertice
            // 
            this.btnAgregarVertice.Location = new System.Drawing.Point(20, 95);
            this.btnAgregarVertice.Name = "btnAgregarVertice";
            this.btnAgregarVertice.Size = new System.Drawing.Size(180, 35);
            this.btnAgregarVertice.TabIndex = 4;
            this.btnAgregarVertice.Text = "Agregar Vértice";
            this.btnAgregarVertice.UseVisualStyleBackColor = true;
            this.btnAgregarVertice.Click += new System.EventHandler(this.btnAgregarVertice_Click);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(60, 58);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(140, 22);
            this.txtY.TabIndex = 3;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(60, 28);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(140, 22);
            this.txtX.TabIndex = 2;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(20, 61);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(21, 16);
            this.lblY.TabIndex = 1;
            this.lblY.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(20, 31);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(21, 16);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "X:";
            // 
            // groupBoxPatron
            // 
            this.groupBoxPatron.Controls.Add(this.pnlVistaPrevia);
            this.groupBoxPatron.Controls.Add(this.lblVistaPrevia);
            this.groupBoxPatron.Controls.Add(this.numTamanoPatron);
            this.groupBoxPatron.Controls.Add(this.lblTamano);
            this.groupBoxPatron.Controls.Add(this.cmbPatron);
            this.groupBoxPatron.Controls.Add(this.lblPatron);
            this.groupBoxPatron.Location = new System.Drawing.Point(12, 168);
            this.groupBoxPatron.Name = "groupBoxPatron";
            this.groupBoxPatron.Size = new System.Drawing.Size(350, 130);
            this.groupBoxPatron.TabIndex = 3;
            this.groupBoxPatron.TabStop = false;
            this.groupBoxPatron.Text = "Configuración del Patrón";
            // 
            // pnlVistaPrevia
            // 
            this.pnlVistaPrevia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVistaPrevia.Location = new System.Drawing.Point(230, 40);
            this.pnlVistaPrevia.Name = "pnlVistaPrevia";
            this.pnlVistaPrevia.Size = new System.Drawing.Size(105, 80);
            this.pnlVistaPrevia.TabIndex = 5;
            // 
            // lblVistaPrevia
            // 
            this.lblVistaPrevia.AutoSize = true;
            this.lblVistaPrevia.Location = new System.Drawing.Point(227, 21);
            this.lblVistaPrevia.Name = "lblVistaPrevia";
            this.lblVistaPrevia.Size = new System.Drawing.Size(82, 16);
            this.lblVistaPrevia.TabIndex = 4;
            this.lblVistaPrevia.Text = "Vista Previa:";
            // 
            // numTamanoPatron
            // 
            this.numTamanoPatron.Location = new System.Drawing.Point(120, 60);
            this.numTamanoPatron.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTamanoPatron.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTamanoPatron.Name = "numTamanoPatron";
            this.numTamanoPatron.Size = new System.Drawing.Size(80, 22);
            this.numTamanoPatron.TabIndex = 3;
            this.numTamanoPatron.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numTamanoPatron.ValueChanged += new System.EventHandler(this.numTamanoPatron_ValueChanged);
            // 
            // lblTamano
            // 
            this.lblTamano.AutoSize = true;
            this.lblTamano.Location = new System.Drawing.Point(20, 62);
            this.lblTamano.Name = "lblTamano";
            this.lblTamano.Size = new System.Drawing.Size(95, 16);
            this.lblTamano.TabIndex = 2;
            this.lblTamano.Text = "Tamaño (1-50):";
            // 
            // cmbPatron
            // 
            this.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatron.FormattingEnabled = true;
            this.cmbPatron.Location = new System.Drawing.Point(80, 25);
            this.cmbPatron.Name = "cmbPatron";
            this.cmbPatron.Size = new System.Drawing.Size(140, 24);
            this.cmbPatron.TabIndex = 1;
            this.cmbPatron.SelectedIndexChanged += new System.EventHandler(this.cmbPatron_SelectedIndexChanged);
            // 
            // lblPatron
            // 
            this.lblPatron.AutoSize = true;
            this.lblPatron.Location = new System.Drawing.Point(20, 28);
            this.lblPatron.Name = "lblPatron";
            this.lblPatron.Size = new System.Drawing.Size(51, 16);
            this.lblPatron.TabIndex = 0;
            this.lblPatron.Text = "Patrón:";
            // 
            // groupBoxColores
            // 
            this.groupBoxColores.Controls.Add(this.chkFondoTransparente);
            this.groupBoxColores.Controls.Add(this.cmbColorBorde);
            this.groupBoxColores.Controls.Add(this.cmbColorFondo);
            this.groupBoxColores.Controls.Add(this.cmbColorPatron);
            this.groupBoxColores.Controls.Add(this.lblColorBorde);
            this.groupBoxColores.Controls.Add(this.lblColorFondo);
            this.groupBoxColores.Controls.Add(this.lblColorPatron);
            this.groupBoxColores.Location = new System.Drawing.Point(12, 304);
            this.groupBoxColores.Name = "groupBoxColores";
            this.groupBoxColores.Size = new System.Drawing.Size(350, 130);
            this.groupBoxColores.TabIndex = 4;
            this.groupBoxColores.TabStop = false;
            this.groupBoxColores.Text = "Colores";
            // 
            // chkFondoTransparente
            // 
            this.chkFondoTransparente.AutoSize = true;
            this.chkFondoTransparente.Location = new System.Drawing.Point(210, 58);
            this.chkFondoTransparente.Name = "chkFondoTransparente";
            this.chkFondoTransparente.Size = new System.Drawing.Size(117, 20);
            this.chkFondoTransparente.TabIndex = 6;
            this.chkFondoTransparente.Text = "Sin fondo sólido";
            this.chkFondoTransparente.UseVisualStyleBackColor = true;
            this.chkFondoTransparente.CheckedChanged += new System.EventHandler(this.chkFondoTransparente_CheckedChanged);
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
            "Magenta",
            "Amarillo",
            "Blanco"});
            this.cmbColorBorde.Location = new System.Drawing.Point(100, 88);
            this.cmbColorBorde.Name = "cmbColorBorde";
            this.cmbColorBorde.Size = new System.Drawing.Size(100, 24);
            this.cmbColorBorde.TabIndex = 5;
            // 
            // cmbColorFondo
            // 
            this.cmbColorFondo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorFondo.FormattingEnabled = true;
            this.cmbColorFondo.Items.AddRange(new object[] {
            "Azul Claro",
            "Azul Oscuro",
            "Rojo",
            "Verde",
            "Naranja",
            "Púrpura",
            "Cian",
            "Magenta",
            "Amarillo",
            "Blanco"});
            this.cmbColorFondo.Location = new System.Drawing.Point(100, 55);
            this.cmbColorFondo.Name = "cmbColorFondo";
            this.cmbColorFondo.Size = new System.Drawing.Size(100, 24);
            this.cmbColorFondo.TabIndex = 4;
            this.cmbColorFondo.SelectedIndexChanged += new System.EventHandler(this.cmbColorFondo_SelectedIndexChanged);
            // 
            // cmbColorPatron
            // 
            this.cmbColorPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorPatron.FormattingEnabled = true;
            this.cmbColorPatron.Items.AddRange(new object[] {
            "Azul Claro",
            "Azul Oscuro",
            "Rojo",
            "Verde",
            "Naranja",
            "Púrpura",
            "Cian",
            "Magenta",
            "Amarillo",
            "Blanco"});
            this.cmbColorPatron.Location = new System.Drawing.Point(100, 22);
            this.cmbColorPatron.Name = "cmbColorPatron";
            this.cmbColorPatron.Size = new System.Drawing.Size(100, 24);
            this.cmbColorPatron.TabIndex = 3;
            this.cmbColorPatron.SelectedIndexChanged += new System.EventHandler(this.cmbColorPatron_SelectedIndexChanged);
            // 
            // lblColorBorde
            // 
            this.lblColorBorde.AutoSize = true;
            this.lblColorBorde.Location = new System.Drawing.Point(20, 91);
            this.lblColorBorde.Name = "lblColorBorde";
            this.lblColorBorde.Size = new System.Drawing.Size(50, 16);
            this.lblColorBorde.TabIndex = 2;
            this.lblColorBorde.Text = "Borde:";
            // 
            // lblColorFondo
            // 
            this.lblColorFondo.AutoSize = true;
            this.lblColorFondo.Location = new System.Drawing.Point(20, 58);
            this.lblColorFondo.Name = "lblColorFondo";
            this.lblColorFondo.Size = new System.Drawing.Size(50, 16);
            this.lblColorFondo.TabIndex = 1;
            this.lblColorFondo.Text = "Fondo:";
            // 
            // lblColorPatron
            // 
            this.lblColorPatron.AutoSize = true;
            this.lblColorPatron.Location = new System.Drawing.Point(20, 25);
            this.lblColorPatron.Name = "lblColorPatron";
            this.lblColorPatron.Size = new System.Drawing.Size(51, 16);
            this.lblColorPatron.TabIndex = 0;
            this.lblColorPatron.Text = "Patrón:";
            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnBorrar);
            this.groupBoxAcciones.Controls.Add(this.btnRellenar);
            this.groupBoxAcciones.Location = new System.Drawing.Point(192, 440);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(170, 70);
            this.groupBoxAcciones.TabIndex = 5;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(90, 25);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(70, 35);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnRellenar
            // 
            this.btnRellenar.Location = new System.Drawing.Point(10, 25);
            this.btnRellenar.Name = "btnRellenar";
            this.btnRellenar.Size = new System.Drawing.Size(70, 35);
            this.btnRellenar.TabIndex = 0;
            this.btnRellenar.Text = "Rellenar";
            this.btnRellenar.UseVisualStyleBackColor = true;
            this.btnRellenar.Click += new System.EventHandler(this.btnRellenar_Click);
            // 
            // groupBoxOpciones
            // 
            this.groupBoxOpciones.Controls.Add(this.chkDibujarConMouse);
            this.groupBoxOpciones.Location = new System.Drawing.Point(12, 440);
            this.groupBoxOpciones.Name = "groupBoxOpciones";
            this.groupBoxOpciones.Size = new System.Drawing.Size(170, 70);
            this.groupBoxOpciones.TabIndex = 6;
            this.groupBoxOpciones.TabStop = false;
            this.groupBoxOpciones.Text = "Opciones";
            // 
            // chkDibujarConMouse
            // 
            this.chkDibujarConMouse.AutoSize = true;
            this.chkDibujarConMouse.Location = new System.Drawing.Point(15, 25);
            this.chkDibujarConMouse.Name = "chkDibujarConMouse";
            this.chkDibujarConMouse.Size = new System.Drawing.Size(138, 36);
            this.chkDibujarConMouse.TabIndex = 0;
            this.chkDibujarConMouse.Text = "Dibujar vértices\r\ncon clic del mouse";
            this.chkDibujarConMouse.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(380, 503);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(270, 16);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Listo. Agregue vértices para crear un polígono.";
            // 
            // frmPatternFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 530);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.groupBoxOpciones);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxColores);
            this.Controls.Add(this.groupBoxPatron);
            this.Controls.Add(this.groupBoxDatos);
            this.Controls.Add(this.groupBoxGrafico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPatternFill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Pattern Fill - Relleno con Patrones";
            this.Load += new System.EventHandler(this.frmPatternFill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxGrafico.ResumeLayout(false);
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.groupBoxPatron.ResumeLayout(false);
            this.groupBoxPatron.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTamanoPatron)).EndInit();
            this.groupBoxColores.ResumeLayout(false);
            this.groupBoxColores.PerformLayout();
            this.groupBoxAcciones.ResumeLayout(false);
            this.groupBoxOpciones.ResumeLayout(false);
            this.groupBoxOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxGrafico;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnAgregarVertice;
        private System.Windows.Forms.ListBox lstVertices;
        private System.Windows.Forms.Label lblVertices;
        private System.Windows.Forms.Button btnQuitarVertice;
        private System.Windows.Forms.GroupBox groupBoxPatron;
        private System.Windows.Forms.ComboBox cmbPatron;
        private System.Windows.Forms.Label lblPatron;
        private System.Windows.Forms.NumericUpDown numTamanoPatron;
        private System.Windows.Forms.Label lblTamano;
        private System.Windows.Forms.Panel pnlVistaPrevia;
        private System.Windows.Forms.Label lblVistaPrevia;
        private System.Windows.Forms.GroupBox groupBoxColores;
        private System.Windows.Forms.ComboBox cmbColorBorde;
        private System.Windows.Forms.ComboBox cmbColorFondo;
        private System.Windows.Forms.ComboBox cmbColorPatron;
        private System.Windows.Forms.Label lblColorBorde;
        private System.Windows.Forms.Label lblColorFondo;
        private System.Windows.Forms.Label lblColorPatron;
        private System.Windows.Forms.CheckBox chkFondoTransparente;
        private System.Windows.Forms.GroupBox groupBoxAcciones;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnRellenar;
        private System.Windows.Forms.GroupBox groupBoxOpciones;
        private System.Windows.Forms.CheckBox chkDibujarConMouse;
        private System.Windows.Forms.Label lblEstado;
    }
}