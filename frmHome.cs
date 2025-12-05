using System;
using System.Windows.Forms;
using Algoritmo_de_lineas.Circulos.view;

namespace Algoritmo_de_lineas
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            // Configuración inicial
        }

        // Métodos para abrir formularios hijos MDI
        private void AbrirFormularioHijo(Form hijo)
        {
            // Cerrar cualquier formulario hijo abierto del mismo tipo
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == hijo.GetType())
                {
                    frm.Activate();
                    return;
                }
            }

            // Configurar como hijo MDI
            hijo.MdiParent = this;
            hijo.WindowState = FormWindowState.Maximized;
            hijo.Show();
        }

        // Eventos del menú - Algoritmos de Líneas
        private void menuDDA_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmDDA());
        }

        private void menuBresenham_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmBresenham());
        }

        private void menuXiaolin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmXiaolin());
        }

        // Eventos del menú - Circunferencias
        private void menuCircunferencia_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmCircuferenciacs());
        }

        private void menuBresenhamModificado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmBresenhamModificado());
        }

        private void menuParametrico_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmParametrico());
        }

        // Eventos del menú - Ventana
        private void menuCascada_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void menuHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuCerrarTodo_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        // Evento del menú - Salir
        private void menuSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir de la aplicación?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Evento del menú - Acerca de
        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Algoritmos de Computación Gráfica\n\n" +
                "━━━ ALGORITMOS DE LÍNEAS ━━━\n" +
                "• DDA (Digital Differential Analyzer)\n" +
                "• Bresenham\n" +
                "• Xiaolin Wu (Anti-aliasing)\n\n" +
                "━━━ ALGORITMOS DE CÍRCULOS ━━━\n" +
                "• Punto Medio (8 octantes)\n" +
                "• Bresenham Modificado (8 octantes)\n" +
                "• Paramétrico (ecuaciones trigonométricas)\n\n" +
                "━━━ INFORMACIÓN ━━━\n" +
                "Desarrollado para: Computación Gráfica\n" +
                "Framework: .NET Framework 4.8\n" +
                "Año: 2025",
                "Acerca de - Algoritmos Gráficos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
