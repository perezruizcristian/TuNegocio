using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario Usuario_Actual;//creamos esta variable de tipo objeto Usuario para poder mostrar el nombre del usuario en el Menu
        private static IconMenuItem MenuActivo = null; //Esta variable de tipo objeto de icono para poder manejar y marcar cual de los iconos del Menu se clickeo
        private static Form formularioActivo= null; // Esta variable indica cual es el formulario que se va a estar mostrando en el Panel

        public Inicio(Usuario objUsu = null)// hacemos que el Usuario permita Nulon de esta manera no es necesario siempre Logearse
        {// y de esta manera podemos uniciar la depuracion directamente en el Inicio
            if(objUsu == null) 
            {
                Usuario_Actual = new Usuario()
                {
                    NombreCompleto = "Admin Predefinido",
                    IdUsuario = 1
                };
            }
            else
            {
                Usuario_Actual = objUsu;
            }

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermiso = new CN_Permiso().Listar(Usuario_Actual.IdUsuario);
            // este foreach lee cada uno de los items que hay dentro de la barra del menu 
            foreach (IconMenuItem iconMenu in menuOpciones.Items)
            { 
                // por cada uno de los items si es encontrado la variable sera True o false
                bool encontrado = ListaPermiso.Any(m => m.NombreMenu == iconMenu.Name);
                if (encontrado == false)
                { //si esta en falso no lo mostrara en la barra del menu 
                    iconMenu.Visible = false;
                }
            }

            lblusuario.Text = Usuario_Actual.NombreCompleto;
        }
        // este metodo recibe de parametros los iconos de el formulario los cuales fueron clickeados 
        // y tambien recibe el Formulario que tine q ser visualisado en el panel 
        private void AbrirFormulario(IconMenuItem menu , Form formulario)
        {
            // si se selecciono un menu funcionara 
            if (MenuActivo != null)
            {
                
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.BackColor = Color.SlateGray;
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }


        private void menuusuario_Click(object sender, EventArgs e)
        {
            // el menu que deseo mostrar cuando clikeo una opcion se cuarda en el objeto "sender" este es el primer parametro para mostrar 
            // el formulario y para que se pueda usar el objeto "sender" lo debemos convertir 
            // en este caso lo convertimos en IconMenuItem por que lo que queremos es marcar el menu seleccionado 
            //Y luego el parametro de el formulario que queremos mostrar es decir frmUsuarios
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios()) ;
        }

        private void subMenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmCategoria());
        }

        private void subMenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmProducto());

        }

        private void SubMenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmVentas());

        }

        private void subMenuVerDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmDetalleVenta());

        }

        private void subMenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmCompras());

        }

        private void subMenuVerDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmDetalleCompra());

        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes()) ;
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());

        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblusuario_Click(object sender, EventArgs e)
        {

        }
    }
}
