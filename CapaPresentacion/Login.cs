using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario ousuario = new CN_Usuario().Listar().Where(u=>u.Documento == txtDoc.Text && u.Clave== txtPass.Text).FirstOrDefault();
            //Acciones "Landa" nos pernite tomar acciones segun lo que nos retorne una lista 

            if (ousuario != null)
            {
                Inicio form = new Inicio(ousuario);
                form.Show();
                this.Hide();
                form.FormClosing += frm_cerrando; //si se cierra el formulario de inicio se abre automaticamente el de Login

            }
            else
            {
                MessageBox.Show("No se encontro el Usuario", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDoc.Text = "";
                txtPass.Text = "";
            }

        }
        private void frm_cerrando(object sender, EventArgs e)
        {
            this.Show();
            txtDoc.Text = "";
            txtPass.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
