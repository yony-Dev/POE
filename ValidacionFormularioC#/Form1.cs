using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioPOE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z\s]*$" ))
            {
                MessageBox.Show("Por favor, ingrese solo letras y espacios en el nombre.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Text = string.Empty;
            }
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtEdad.Text, @"^\d*$"))
            {
                MessageBox.Show("Por favor, ingrese solo números en la edad.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdad.Text = string.Empty;
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string edadTexto = txtEdad.Text.Trim();
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(edadTexto))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (int.TryParse(edadTexto, out int edadNum))
            {
                if (edadNum >= 18 & edadNum <= 50)
                {
                    MessageBox.Show($"Bienvenido, {nombre}. Usted es mayor de edad.", "Acceso permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Acceso Denegado. {nombre} Usted es menor de edad.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una edad válida.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
