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
    public partial class CursoCrud : Form
    {
        Add.carlosFWK wnMgr = new Add.carlosFWK();
        bsnCursos crud = new bsnCursos();
        MenuForm frm = new MenuForm();
        Login frmL = new Login();
        bool actualizarE = false;

        public CursoCrud()
        {
            InitializeComponent();
            actualizar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtIDCurso.Text) && !string.IsNullOrEmpty(txtNombreCurso.Text) && numCupo.Value != 0)
            {
                try
                {
                    crud.insertarCurso(txtIDCurso.Text, txtNombreCurso.Text, txtDescripcion.Text, int.Parse(numCupo.Value.ToString()));
                    actualizar();
                    limpiarTxt();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("El registro no se pudo ingresar\n"+ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("No deje los campos vacios.", "Alerta");
            }
        }

        private void closeLbl_Click(object sender, EventArgs e)
        {
            wnMgr.openForm(this, frm);
        }

        private void actualizar()
        {
            readDg.DataSource = crud.leerCurso();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (actualizarE == true)
            {
                try
                {
                    crud.actualizarCurso(txtIDCurso.Text, txtNombreCurso.Text, txtDescripcion.Text, int.Parse(numCupo.Value.ToString()));
                    actualizar();
                    EnabledBTN();
                    limpiarTxt();
                    txtIDCurso.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ha actualizado correctamente el registro, contacte a el Desarrollador del sistema\n" + ex.Message, "Error");
                } 
            }
            else
            {
                MessageBox.Show("No has seleccionado una celda para la actualizacion\nSeleccione una celda para continuar", "Alerta");
            }
        }

        private void btnogout_Click(object sender, EventArgs e)
        {
            wnMgr.openForm(this, frmL);
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (actualizarE == true)
            {
                try
                {
                    crud.eliminarCurso(txtIDCurso.Text);
                    actualizar();
                    actualizarE = false;
                    EnabledBTN();
                    limpiarTxt();
                    txtIDCurso.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ha eliminado correctamente el registro, contacte a el Desarrollador del sistema\n" + ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("No has seleccionado una celda para la operacion\nSeleccione una celda para continuar", "Alerta");
            }
        }

        private void readDg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDCurso.Enabled = false;
            wnMgr.habilitarButton(btnActualizar);
            wnMgr.habilitarButton(btnEliminar);
            wnMgr.inhabilitarButton(btnInsertar);

            txtIDCurso.Text = readDg.CurrentRow.Cells["CursoID"].Value.ToString();
            txtNombreCurso.Text = readDg.CurrentRow.Cells["CursoNombre"].Value.ToString();
            txtDescripcion.Text = readDg.CurrentRow.Cells["CursoDescripcion"].Value.ToString();
            actualizarE = true;
        }

        private void EnabledBTN(){
            wnMgr.habilitarButton(btnInsertar);
            wnMgr.inhabilitarButton(btnEliminar);
            wnMgr.inhabilitarButton(btnActualizar);
        }

        private void limpiarTxt()
        {
            txtDescripcion.Text = "";
            txtIDCurso.Text = "";
            txtNombreCurso.Text = "";
            numCupo.Value = 0;
        }
    }
}
