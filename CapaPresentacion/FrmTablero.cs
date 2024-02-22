using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmTablero : Form
    {
        public FrmTablero(Usuario objUsuario)
        {
            InitializeComponent();
            usuarioActual = objUsuario;
        }
        private static Usuario usuarioActual;
        private Form FormActivo = null;
        private void abrirFormHijo(Form formHijo)
        {
            if (FormActivo != null)
                FormActivo.Dispose();

            FormActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelFormHijos.Controls.Add(formHijo);
            panelFormHijos.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
            FormActivo.FormClosed += new FormClosedEventHandler(CierreForm);

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            colorActivoProductos.Visible = true;
            colorActivoUsuarios.Visible = false;
            colorActivoTablero.Visible = false;
            colorActivoCategorias.Visible = false;
            colorActivoBitacora.Visible = false;
            colorActivoRC.Visible = false;
            colorActivoProveedor.Visible = false;
            colorActivoDetalleCompra.Visible = false;
        }

        private void picCerrar_Click(object sender, EventArgs e)
        {
            ModalSalirDashboard mod = new ModalSalirDashboard();
            mod.PreviousForm = this; // Configurar la referencia al formulario anterior
            mod.ShowDialog();

        }

        private void btnTablero_Click(object sender, EventArgs e)
        {
            if(FormActivo != null)
            {
               FormActivo.Dispose();
            }
            colorActivoTablero.Visible = true;
            colorActivoProductos.Visible = false;
            colorActivoUsuarios.Visible = false;
            colorActivoCategorias.Visible = false;
            colorActivoBitacora.Visible = false;
            colorActivoProveedor.Visible = false;
            colorActivoRC.Visible = false;
            colorActivoDetalleCompra.Visible = false;
        }

        private void FrmTablero_Load(object sender, EventArgs e)
        {
            List<Oferta> listaOfertas = new CN_Oferta().Listar();
            List<Producto> listaProductos = new CN_Producto().Listar();
            List<Usuario> listaUsuarios = new CN_Usuario().Listar();
            List<Proveedor> listaProveedores = new CN_Proveedor().Listar(); 
            List<Categoria> listaCategorias = new CN_Categoria().Listar();
            List<Permiso> listaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);
            foreach (Button btn in panelMenu.Controls.OfType<Button>())
            {
                bool encontrado = listaPermisos.Any(m => m.NombreMenu == btn.Name);

                if (encontrado== false)
                {
                    btn.Visible= false;
                }
            }

            lblOfertas.Text= listaOfertas.Count.ToString();
            lblUsername.Text = usuarioActual.Username;
            lblCorreo.Text = usuarioActual.Correo;
            lblcantprod.Text = listaProductos.Count.ToString();
            lblempleados.Text = listaUsuarios.Count.ToString();
            lblproveedores.Text = listaProveedores.Count.ToString();
            lblCategorias.Text = listaCategorias.Count.ToString();

        }

        private void FrmTablero_ParentChanged(object sender, EventArgs e)
        {

        }

        private void panelFormHijos_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panelFormHijos_Enter(object sender, EventArgs e)
        {

        }
        private void CierreForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FrmProductos"] == null)
            {
                colorActivoProductos.Visible = false;
                colorActivoTablero.Visible = true;
            }
            if (Application.OpenForms["FrmCategorias"] == null)
            {
                colorActivoCategorias.Visible = false;
                colorActivoTablero.Visible = true;
            }
            if (Application.OpenForms["FrmCategorias"] == null)
            {
                colorActivoBitacora.Visible = false;
                colorActivoTablero.Visible = true;
            }


        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //abrirFormHijo(new FrmUsuarios());
            colorActivoProductos.Visible = false;
            colorActivoTablero.Visible = false;
            colorActivoCategorias.Visible = false;
            colorActivoUsuarios.Visible = true;
            colorActivoProveedor.Visible = false;
            colorActivoBitacora.Visible = false;
            colorActivoRC.Visible = false;
            colorActivoDetalleCompra.Visible = false;

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmCategorias());
            colorActivoProductos.Visible = false;
            colorActivoUsuarios.Visible = false;
            colorActivoTablero.Visible = false;
            colorActivoCategorias.Visible = true;
            colorActivoProveedor.Visible = false;
            colorActivoBitacora.Visible = false;
            colorActivoRC.Visible = false;
            colorActivoDetalleCompra.Visible = false;


        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmBitacora());
            colorActivoProductos.Visible = false;
            colorActivoUsuarios.Visible = false;
            colorActivoTablero.Visible = false;
            colorActivoCategorias.Visible = false;
            colorActivoProveedor.Visible = false;
            colorActivoBitacora.Visible = true;
            colorActivoRC.Visible = false;
            colorActivoDetalleCompra.Visible = false;

        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmProveedores());
            colorActivoProductos.Visible = false;
            colorActivoUsuarios.Visible = false;
            colorActivoTablero.Visible = false;
            colorActivoCategorias.Visible = false;
            colorActivoBitacora.Visible = false;
            colorActivoProveedor.Visible = true;
            colorActivoRC.Visible = false;
            colorActivoDetalleCompra.Visible = false;



        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmRegistrarCompra(usuarioActual));
            colorActivoProductos.Visible = false;
            colorActivoUsuarios.Visible = false;
            colorActivoTablero.Visible = false;
            colorActivoCategorias.Visible = false;
            colorActivoBitacora.Visible = false;
            colorActivoProveedor.Visible = false;
            colorActivoRC.Visible = true;
            colorActivoDetalleCompra.Visible = false;
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDetalleCompra_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmDetalleCompra());
            colorActivoDetalleCompra.Visible = true;
            colorActivoUsuarios.Visible = false;
            colorActivoTablero.Visible = false;
            colorActivoCategorias.Visible = false;
            colorActivoBitacora.Visible = false;
            colorActivoProveedor.Visible = true;
            colorActivoRC.Visible = false;
            colorActivoProveedor.Visible = false;
        }

        private void FrmTablero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                picCerrar_Click(sender, e);
            }
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmOfertas());
        }

        private void btnLegales_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmLegales());
        }

        private void btnOfertas_Productos_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmOfertas_Productos());

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmPedido(usuarioActual));

        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmDetallePedido());

        }
    }
}
