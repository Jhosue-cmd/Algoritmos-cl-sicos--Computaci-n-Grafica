namespace Algoritmo_de_lineas
{
    partial class frmHome
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAlgoritmos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLineas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDDA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBresenham = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXiaolin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCirculos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCircunferencia = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBresenhamModificado = new System.Windows.Forms.ToolStripMenuItem();
            this.menuParametrico = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRelleno = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScanLineFill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFloodFill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatternFill = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRecorte = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCohenSutherland = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLiangBarsky = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNichollLeeNicholl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRecortePoligonos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSutherlandHodgman = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWeilerAtherton = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVatti = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentana = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCascada = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCerrarTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAlgoritmos,
            this.menuVentana,
            this.menuAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAlgoritmos
            // 
            this.menuAlgoritmos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLineas,
            this.toolStripSeparator1,
            this.menuCirculos,
            this.toolStripSeparator4,
            this.menuRelleno,
            this.toolStripSeparator5,
            this.menuRecorte,
            this.toolStripSeparator6,
            this.menuRecortePoligonos});
            this.menuAlgoritmos.Name = "menuAlgoritmos";
            this.menuAlgoritmos.Size = new System.Drawing.Size(97, 24);
            this.menuAlgoritmos.Text = "&Algoritmos";
            // 
            // menuLineas
            // 
            this.menuLineas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDDA,
            this.menuBresenham,
            this.menuXiaolin});
            this.menuLineas.Name = "menuLineas";
            this.menuLineas.Size = new System.Drawing.Size(230, 26);
            this.menuLineas.Text = "📏 Líneas";
            // 
            // menuDDA
            // 
            this.menuDDA.Name = "menuDDA";
            this.menuDDA.Size = new System.Drawing.Size(190, 26);
            this.menuDDA.Text = "🔵 DDA";
            this.menuDDA.Click += new System.EventHandler(this.menuDDA_Click);
            // 
            // menuBresenham
            // 
            this.menuBresenham.Name = "menuBresenham";
            this.menuBresenham.Size = new System.Drawing.Size(190, 26);
            this.menuBresenham.Text = "🟢 Bresenham";
            this.menuBresenham.Click += new System.EventHandler(this.menuBresenham_Click);
            // 
            // menuXiaolin
            // 
            this.menuXiaolin.Name = "menuXiaolin";
            this.menuXiaolin.Size = new System.Drawing.Size(190, 26);
            this.menuXiaolin.Text = "🟣 Xiaolin Wu";
            this.menuXiaolin.Click += new System.EventHandler(this.menuXiaolin_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // menuCirculos
            // 
            this.menuCirculos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCircunferencia,
            this.menuBresenhamModificado,
            this.menuParametrico});
            this.menuCirculos.Name = "menuCirculos";
            this.menuCirculos.Size = new System.Drawing.Size(230, 26);
            this.menuCirculos.Text = "⭕ Círculos";
            // 
            // menuCircunferencia
            // 
            this.menuCircunferencia.Name = "menuCircunferencia";
            this.menuCircunferencia.Size = new System.Drawing.Size(250, 26);
            this.menuCircunferencia.Text = "🔵 Punto Medio";
            this.menuCircunferencia.Click += new System.EventHandler(this.menuCircunferencia_Click);
            // 
            // menuBresenhamModificado
            // 
            this.menuBresenhamModificado.Name = "menuBresenhamModificado";
            this.menuBresenhamModificado.Size = new System.Drawing.Size(250, 26);
            this.menuBresenhamModificado.Text = "🟢 Bresenham Modificado";
            this.menuBresenhamModificado.Click += new System.EventHandler(this.menuBresenhamModificado_Click);
            // 
            // menuParametrico
            // 
            this.menuParametrico.Name = "menuParametrico";
            this.menuParametrico.Size = new System.Drawing.Size(250, 26);
            this.menuParametrico.Text = "🟠 Paramétrico";
            this.menuParametrico.Click += new System.EventHandler(this.menuParametrico_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(227, 6);
            // 
            // menuRelleno
            // 
            this.menuRelleno.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuScanLineFill,
            this.menuFloodFill,
            this.menuPatternFill});
            this.menuRelleno.Name = "menuRelleno";
            this.menuRelleno.Size = new System.Drawing.Size(230, 26);
            this.menuRelleno.Text = "🎨 Relleno";
            // 
            // menuScanLineFill
            // 
            this.menuScanLineFill.Name = "menuScanLineFill";
            this.menuScanLineFill.Size = new System.Drawing.Size(190, 26);
            this.menuScanLineFill.Text = "🔵 Scan-Line Fill";
            this.menuScanLineFill.Click += new System.EventHandler(this.menuScanLineFill_Click);
            // 
            // menuFloodFill
            // 
            this.menuFloodFill.Name = "menuFloodFill";
            this.menuFloodFill.Size = new System.Drawing.Size(190, 26);
            this.menuFloodFill.Text = "🟢 Flood Fill";
            this.menuFloodFill.Click += new System.EventHandler(this.menuFloodFill_Click);
            // 
            // menuPatternFill
            // 
            this.menuPatternFill.Name = "menuPatternFill";
            this.menuPatternFill.Size = new System.Drawing.Size(190, 26);
            this.menuPatternFill.Text = "🟣 Pattern Fill";
            this.menuPatternFill.Click += new System.EventHandler(this.menuPatternFill_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(227, 6);
            // 
            // menuRecorte
            // 
            this.menuRecorte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCohenSutherland,
            this.menuLiangBarsky,
            this.menuNichollLeeNicholl});
            this.menuRecorte.Name = "menuRecorte";
            this.menuRecorte.Size = new System.Drawing.Size(230, 26);
            this.menuRecorte.Text = "✂️ Recorte de Líneas";
            // 
            // menuCohenSutherland
            // 
            this.menuCohenSutherland.Name = "menuCohenSutherland";
            this.menuCohenSutherland.Size = new System.Drawing.Size(230, 26);
            this.menuCohenSutherland.Text = "🔵 Cohen-Sutherland";
            this.menuCohenSutherland.Click += new System.EventHandler(this.menuCohenSutherland_Click);
            // 
            // menuLiangBarsky
            // 
            this.menuLiangBarsky.Name = "menuLiangBarsky";
            this.menuLiangBarsky.Size = new System.Drawing.Size(230, 26);
            this.menuLiangBarsky.Text = "🟢 Liang-Barsky";
            this.menuLiangBarsky.Click += new System.EventHandler(this.menuLiangBarsky_Click);
            // 
            // menuNichollLeeNicholl
            // 
            this.menuNichollLeeNicholl.Name = "menuNichollLeeNicholl";
            this.menuNichollLeeNicholl.Size = new System.Drawing.Size(230, 26);
            this.menuNichollLeeNicholl.Text = "🟣 Nicholl-Lee-Nicholl";
            this.menuNichollLeeNicholl.Click += new System.EventHandler(this.menuNichollLeeNicholl_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(227, 6);
            // 
            // menuRecortePoligonos
            // 
            this.menuRecortePoligonos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSutherlandHodgman,
            this.menuWeilerAtherton,
            this.menuVatti});
            this.menuRecortePoligonos.Name = "menuRecortePoligonos";
            this.menuRecortePoligonos.Size = new System.Drawing.Size(230, 26);
            this.menuRecortePoligonos.Text = "🔷 Recorte de Polígonos";
            // 
            // menuSutherlandHodgman
            // 
            this.menuSutherlandHodgman.Name = "menuSutherlandHodgman";
            this.menuSutherlandHodgman.Size = new System.Drawing.Size(230, 26);
            this.menuSutherlandHodgman.Text = "🔵 Sutherland-Hodgman";
            this.menuSutherlandHodgman.Click += new System.EventHandler(this.menuSutherlandHodgman_Click);
            // 
            // menuWeilerAtherton
            // 
            this.menuWeilerAtherton.Name = "menuWeilerAtherton";
            this.menuWeilerAtherton.Size = new System.Drawing.Size(230, 26);
            this.menuWeilerAtherton.Text = "🟢 Weiler-Atherton";
            this.menuWeilerAtherton.Click += new System.EventHandler(this.menuWeilerAtherton_Click);
            // 
            // menuVatti
            // 
            this.menuVatti.Name = "menuVatti";
            this.menuVatti.Size = new System.Drawing.Size(230, 26);
            this.menuVatti.Text = "🟣 Vatti";
            this.menuVatti.Click += new System.EventHandler(this.menuVatti_Click);
            // 
            // menuVentana
            // 
            this.menuVentana.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCascada,
            this.menuHorizontal,
            this.menuVertical,
            this.toolStripSeparator2,
            this.menuCerrarTodo});
            this.menuVentana.Name = "menuVentana";
            this.menuVentana.Size = new System.Drawing.Size(76, 24);
            this.menuVentana.Text = "&Ventana";
            // 
            // menuCascada
            // 
            this.menuCascada.Name = "menuCascada";
            this.menuCascada.Size = new System.Drawing.Size(222, 26);
            this.menuCascada.Text = "Cascada";
            this.menuCascada.Click += new System.EventHandler(this.menuCascada_Click);
            // 
            // menuHorizontal
            // 
            this.menuHorizontal.Name = "menuHorizontal";
            this.menuHorizontal.Size = new System.Drawing.Size(222, 26);
            this.menuHorizontal.Text = "Mosaico Horizontal";
            this.menuHorizontal.Click += new System.EventHandler(this.menuHorizontal_Click);
            // 
            // menuVertical
            // 
            this.menuVertical.Name = "menuVertical";
            this.menuVertical.Size = new System.Drawing.Size(222, 26);
            this.menuVertical.Text = "Mosaico Vertical";
            this.menuVertical.Click += new System.EventHandler(this.menuVertical_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(219, 6);
            // 
            // menuCerrarTodo
            // 
            this.menuCerrarTodo.Name = "menuCerrarTodo";
            this.menuCerrarTodo.Size = new System.Drawing.Size(222, 26);
            this.menuCerrarTodo.Text = "Cerrar Todo";
            this.menuCerrarTodo.Click += new System.EventHandler(this.menuCerrarTodo_Click);
            // 
            // menuAyuda
            // 
            this.menuAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAcercaDe,
            this.toolStripSeparator3,
            this.menuSalir});
            this.menuAyuda.Name = "menuAyuda";
            this.menuAyuda.Size = new System.Drawing.Size(65, 24);
            this.menuAyuda.Text = "A&yuda";
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(167, 26);
            this.menuAcercaDe.Text = "Acerca de...";
            this.menuAcercaDe.Click += new System.EventHandler(this.menuAcercaDe_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(167, 26);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmos de Computación Gráfica - Sistema Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAlgoritmos;
        private System.Windows.Forms.ToolStripMenuItem menuLineas;
        private System.Windows.Forms.ToolStripMenuItem menuDDA;
        private System.Windows.Forms.ToolStripMenuItem menuBresenham;
        private System.Windows.Forms.ToolStripMenuItem menuXiaolin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuCirculos;
        private System.Windows.Forms.ToolStripMenuItem menuCircunferencia;
        private System.Windows.Forms.ToolStripMenuItem menuBresenhamModificado;
        private System.Windows.Forms.ToolStripMenuItem menuParametrico;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuRelleno;
        private System.Windows.Forms.ToolStripMenuItem menuScanLineFill;
        private System.Windows.Forms.ToolStripMenuItem menuFloodFill;
        private System.Windows.Forms.ToolStripMenuItem menuPatternFill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuRecorte;
        private System.Windows.Forms.ToolStripMenuItem menuCohenSutherland;
        private System.Windows.Forms.ToolStripMenuItem menuLiangBarsky;
        private System.Windows.Forms.ToolStripMenuItem menuNichollLeeNicholl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuRecortePoligonos;
        private System.Windows.Forms.ToolStripMenuItem menuSutherlandHodgman;
        private System.Windows.Forms.ToolStripMenuItem menuWeilerAtherton;
        private System.Windows.Forms.ToolStripMenuItem menuVatti;
        private System.Windows.Forms.ToolStripMenuItem menuVentana;
        private System.Windows.Forms.ToolStripMenuItem menuCascada;
        private System.Windows.Forms.ToolStripMenuItem menuHorizontal;
        private System.Windows.Forms.ToolStripMenuItem menuVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuCerrarTodo;
        private System.Windows.Forms.ToolStripMenuItem menuAyuda;
        private System.Windows.Forms.ToolStripMenuItem menuAcercaDe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
    }
}