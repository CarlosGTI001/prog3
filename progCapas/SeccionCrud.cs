using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer;

namespace progCapas
{
    public partial class SeccionCrud : Form
    {
        bsnCursos curse = new bsnCursos();
        bsnSeccion seccion = new bsnSeccion();
        Add.carlosFWK wnMgr = new Add.carlosFWK();
        bool actualizar = true;

        public SeccionCrud()
        {
            InitializeComponent();
            cbxCurso.DataSource = curse.MostrarIDCurso();
            cbxCurso2.DataSource = curse.MostrarIDCurso();
            verDatos();   
        }

        private void SeccionCrud_Load(object sender, EventArgs e)
        {

        }

        private void btnogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            wnMgr.openForm(this, lg);
        }

        private void closeLbl_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            wnMgr.openForm(this, menu);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtMaestro.Text) && cbxCurso.Text != "" && cbxSeccion.Text != "" && numEdadMax.Value != 0)
            {
                try
                {
                    seccion.insertarSeccion(cbxCurso.Text + cbxSeccion.Text, txtDescripcion.Text + " " + cbxSeccion.Text, txtMaestro.Text, 0, int.Parse(numEdadMax.Value.ToString()), dtPFecha.Value);
                    verDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ha podido agregar el registro por: " + ex.Message + ".\nLLame al administrador del sistema.", "Error");
                }
            }
            else
            {
                MessageBox.Show("No deje ningun campo obligatorio vacio", "Alerta - Campos Vacios");
            }      
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (actualizar)
            {
                try
                {
                    seccion.actualizarSeccion(cbxCurso.Text + cbxSeccion.Text, txtDescripcion.Text + " " + cbxSeccion.Text, txtMaestro.Text, int.Parse(numCantidad.Value.ToString()), int.Parse(numEdadMax.Value.ToString()), dtPFecha.Value);
                    activar();
                    verDatos();
                    actualizar = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se ha podido actualizar el registro por:"+ex.Message+".\nContacte a el desarrollador del sistema", "Error");
                }
            }
            else
            {
                MessageBox.Show("No has seleccionado una celda para actualizar un registro.");
            }
        }



        private void verDatos()
        {
            readDg.DataSource = seccion.leerSeccion();
        }

        private void readDg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string text = readDg.CurrentRow.Cells["SeccionID"].Value.ToString(), curso, seccion;
            char[] textS = text.ToArray();
            curso = "" + textS[0] + textS[1] + text[2] + "";
            seccion = "" + textS[3] + "";
            cbxCurso.SelectedItem = curso;
            cbxSeccion.SelectedItem = seccion;
            txtMaestro.Text = readDg.CurrentRow.Cells["SeccionMaestro"].Value.ToString();
            txtDescripcion.Text = readDg.CurrentRow.Cells["SeccionNombre"].Value.ToString();
            dtPFecha.Value = DateTime.Parse(readDg.CurrentRow.Cells["SeccionAñoCurso"].Value.ToString());
            numCantidad.Value = decimal.Parse(readDg.CurrentRow.Cells["SeccionCantidadEs"].Value.ToString());
            numEdadMax.Value = decimal.Parse(readDg.CurrentRow.Cells["EdadMaxima"].Value.ToString());
            wnMgr.inhabilitarButton(btnInsertar);
            wnMgr.habilitarButton(btnActualizar);
            wnMgr.habilitarButton(btnEliminar);
            actualizar = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (actualizar)
            {
                try
                {
                    seccion.eliminarSeccion(cbxCurso.Text + cbxSeccion.Text);
                    verDatos();
                    actualizar = false;
                    activar();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("El registro no se ha podido eliminar por:"+ex.Message+".\nContacte al desarrollador del sistema", "Error");
                }
                
            }
        }

        private void activar()
        {
                cbxSeccion.Enabled = true;
                cbxSeccion.Enabled = true;
                wnMgr.habilitarButton(btnInsertar);
                wnMgr.inhabilitarButton(btnActualizar);
                wnMgr.inhabilitarButton(btnEliminar);
        }

        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            readDg.DataSource = seccion.filtrarSeccion(cbxCurso2.Text);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            verDatos();
        }
    }
}
