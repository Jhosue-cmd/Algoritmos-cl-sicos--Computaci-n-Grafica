namespace Algoritmo_de_lineas.Relleno.view
{
    partial class frmScan_LineFill
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
            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnRellenar = new System.Windows.Forms.Button();
            this.groupBoxColores = new System.Windows.Forms.GroupBox();
            this.cmbColorBorde = new System.Windows.Forms.ComboBox();
            this.cmbColorRelleno = new System.Windows.Forms.ComboBox();
            this.lblColorBorde = new System.Windows.Forms.Label();
            this.lblColorRelleno = new System.Windows.Forms.Label();
            this.groupBoxOpciones = new System.Windows.Forms.GroupBox();
            this.chkDibujarConMouse = new System.Windows.Forms.CheckBox();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxGrafico.SuspendLayout();
            this.groupBoxDatos.SuspendLayout();
            this.groupBoxAcciones.SuspendLayout();
            this.groupBoxColores.SuspendLayout();
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
            this.groupBoxGrafico.Location = new System.Drawing.Point(340, 12);
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
            this.groupBoxDatos.Size = new System.Drawing.Size(310, 220);
            this.groupBoxDatos.TabIndex = 2;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Vértices del Polígono";
            // 
            // btnQuitarVertice
            // 
            this.btnQuitarVertice.Location = new System.Drawing.Point(200, 180);
            this.btnQuitarVertice.Name = "btnQuitarVertice";
            this.btnQuitarVertice.Size = new System.Drawing.Size(95, 30);
            this.btnQuitarVertice.TabIndex = 7;
            this.btnQuitarVertice.Text = "Quitar Último";
            this.btnQuitarVertice.UseVisualStyleBackColor = true;
            this.btnQuitarVertice.Click += new System.EventHandler(this.btnQuitarVertice_Click);
            // 
            // lstVertices
            // 
            this.lstVertices.FormattingEnabled = true;
            this.lstVertices.ItemHeight = 16;
            this.lstVertices.Location = new System.Drawing.Point(200, 45);
            this.lstVertices.Name = "lstVertices";
            this.lstVertices.Size = new System.Drawing.Size(95, 132);
            this.lstVertices.TabIndex = 6;
            // 
            // lblVertices
            // 
            this.lblVertices.AutoSize = true;
            this.lblVertices.Location = new System.Drawing.Point(197, 25);
            this.lblVertices.Name = "lblVertices";
            this.lblVertices.Size = new System.Drawing.Size(60, 16);
            this.lblVertices.TabIndex = 5;
            this.lblVertices.Text = "Vértices:";
            // 
            // btnAgregarVertice
            // 
            this.btnAgregarVertice.Location = new System.Drawing.Point(20, 100);
            this.btnAgregarVertice.Name = "btnAgregarVertice";
            this.btnAgregarVertice.Size = new System.Drawing.Size(150, 35);
            this.btnAgregarVertice.TabIndex = 4;
            this.btnAgregarVertice.Text = "Agregar Vértice";
            this.btnAgregarVertice.UseVisualStyleBackColor = true;
            this.btnAgregarVertice.Click += new System.EventHandler(this.btnAgregarVertice_Click);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(60, 60);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(110, 22);
            this.txtY.TabIndex = 3;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(60, 30);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(110, 22);
            this.txtX.TabIndex = 2;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(20, 63);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(21, 16);
            this.lblY.TabIndex = 1;
            this.lblY.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(20, 33);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(21, 16);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "X:";
            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnBorrar);
            this.groupBoxAcciones.Controls.Add(this.btnRellenar);
            this.groupBoxAcciones.Location = new System.Drawing.Point(12, 380);
            this.groupBoxAcciones.Name = "groupBoxAcciones";
            this.groupBoxAcciones.Size = new System.Drawing.Size(310, 80);
            this.groupBoxAcciones.TabIndex = 3;
            this.groupBoxAcciones.TabStop = false;
            this.groupBoxAcciones.Text = "Acciones";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(165, 30);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(120, 35);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar Todo";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnRellenar
            // 
            this.btnRellenar.Location = new System.Drawing.Point(20, 30);
            this.btnRellenar.Name = "btnRellenar";
            this.btnRellenar.Size = new System.Drawing.Size(120, 35);
            this.btnRellenar.TabIndex = 0;
            this.btnRellenar.Text = "Rellenar";
            this.btnRellenar.UseVisualStyleBackColor = true;
            this.btnRellenar.Click += new System.EventHandler(this.btnRellenar_Click);
            // 
            // groupBoxColores
            // 
            this.groupBoxColores.Controls.Add(this.cmbColorBorde);
            this.groupBoxColores.Controls.Add(this.cmbColorRelleno);
            this.groupBoxColores.Controls.Add(this.lblColorBorde);
            this.groupBoxColores.Controls.Add(this.lblColorRelleno);
            this.groupBoxColores.Location = new System.Drawing.Point(12, 238);
            this.groupBoxColores.Name = "groupBoxColores";
            this.groupBoxColores.Size = new System.Drawing.Size(310, 90);
            this.groupBoxColores.TabIndex = 4;
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
            this.cmbColorBorde.Location = new System.Drawing.Point(120, 55);
            this.cmbColorBorde.Name = "cmbColorBorde";
            this.cmbColorBorde.Size = new System.Drawing.Size(170, 24);
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
            this.cmbColorRelleno.Location = new System.Drawing.Point(120, 25);
            this.cmbColorRelleno.Name = "cmbColorRelleno";
            this.cmbColorRelleno.Size = new System.Drawing.Size(170, 24);
            this.cmbColorRelleno.TabIndex = 2;
            // 
            // lblColorBorde
            // 
            this.lblColorBorde.AutoSize = true;
            this.lblColorBorde.Location = new System.Drawing.Point(20, 58);
            this.lblColorBorde.Name = "lblColorBorde";
            this.lblColorBorde.Size = new System.Drawing.Size(84, 16);
            this.lblColorBorde.TabIndex = 1;
            this.lblColorBorde.Text = "Color Borde:";
            // 
            // lblColorRelleno
            // 
            this.lblColorRelleno.AutoSize = true;
            this.lblColorRelleno.Location = new System.Drawing.Point(20, 28);
            this.lblColorRelleno.Name = "lblColorRelleno";
            this.lblColorRelleno.Size = new System.Drawing.Size(93, 16);
            this.lblColorRelleno.TabIndex = 0;
            this.lblColorRelleno.Text = "Color Relleno:";
            // 
            // groupBoxOpciones
            // 
            this.groupBoxOpciones.Controls.Add(this.chkDibujarConMouse);
            this.groupBoxOpciones.Location = new System.Drawing.Point(12, 334);
            this.groupBoxOpciones.Name = "groupBoxOpciones";
            this.groupBoxOpciones.Size = new System.Drawing.Size(310, 45);
            this.groupBoxOpciones.TabIndex = 5;
            this.groupBoxOpciones.TabStop = false;
            this.groupBoxOpciones.Text = "Opciones";
            // 
            // chkDibujarConMouse
            // 
            this.chkDibujarConMouse.AutoSize = true;
            this.chkDibujarConMouse.Location = new System.Drawing.Point(20, 18);
            this.chkDibujarConMouse.Name = "chkDibujarConMouse";
            this.chkDibujarConMouse.Size = new System.Drawing.Size(214, 20);
            this.chkDibujarConMouse.TabIndex = 0;
            this.chkDibujarConMouse.Text = "Dibujar vértices con clic del mouse";
            this.chkDibujarConMouse.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(12, 472);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(270, 16);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Listo. Agregue vértices para crear un polígono.";
            // 
            // frmScan_LineFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.groupBoxOpciones);
            this.Controls.Add(this.groupBoxColores);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxDatos);
            this.Controls.Add(this.groupBoxGrafico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmScan_LineFill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Scan-Line Fill - Relleno de Polígonos";
            this.Load += new System.EventHandler(this.frmScan_LineFill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxGrafico.ResumeLayout(false);
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.groupBoxAcciones.ResumeLayout(false);
            this.groupBoxColores.ResumeLayout(false);
            this.groupBoxColores.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxAcciones;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnRellenar;
        private System.Windows.Forms.GroupBox groupBoxColores;
        private System.Windows.Forms.ComboBox cmbColorBorde;
        private System.Windows.Forms.ComboBox cmbColorRelleno;
        private System.Windows.Forms.Label lblColorBorde;
        private System.Windows.Forms.Label lblColorRelleno;
        private System.Windows.Forms.GroupBox groupBoxOpciones;
        private System.Windows.Forms.CheckBox chkDibujarConMouse;
        private System.Windows.Forms.Label lblEstado;
    }
}