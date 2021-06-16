using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinesLayer;

namespace progCapas
{
    public partial class Form1 : Form
    {
        public bool test;
        string id, ida;
        bool actualizar = false;
        public Form1()
        {
            InitializeComponent();
        }
        Add.carlosFWK winMgr = new Add.carlosFWK();
        bsn cdb = new bsn();
        bsnSeccion seccBsn = new bsnSeccion();
        bsnCursos cursBsn = new bsnCursos();
        private void miniLbl_Click(object sender, EventArgs e)
        {
            winMgr.minimizar(this);
        }

        private void closeLbl_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            winMgr.openForm(this, menu);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbbxCurso.DataSource = cursBsn.MostrarIDCurso();
            readDg.DataSource = cdb.mostrarPersona();
            readDg.ClearSelection();
        }

        private void btnogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            winMgr.openForm(this, lg);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMatricula.Text) || !string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtApellido.Text) || !string.IsNullOrEmpty(txtEdad.Text))
                {
                    if(cdb.insertarPersona(txtMatricula.Text, txtName.Text, txtApellido.Text, int.Parse(txtEdad.Text), txtTelefono.Text, dtPFecha.Value, cbbxCurso.Text, cursBsn.leerCursoNombre(cbbxCurso.Text), cbbxSeccion.Text, seccBsn.obtenerSeccionNombreWhereId(cbbxSeccion.Text).ToString()))
                    {
                        readDg.DataSource = cdb.mostrarPersona();

                        limpiarTb();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un estudiante con esa matricula");
                    }

                   
                    }
                else
                {
                    MessageBox.Show("No deje ninguno de los campos obligatorios vacio", "Alerta");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo agregar el registro por:\n "+ex.ToString() + "\n Contacte al administrador del sistema.", "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(readDg.SelectedCells.ToString()))
            {
                try
                {
                    if (readDg.SelectedCells.Count > 0)
                    {
                        DialogResult resultado = MessageBox.Show("En realidad desea eliminar a la persona", "Alerta", MessageBoxButtons.YesNoCancel);
                        if (resultado == DialogResult.Yes)
                        {
                            id = readDg.CurrentRow.Cells["matricula"].Value.ToString();
                            cdb.eliminarPersona(id);
                            cdb.mostrarPersona();
                            limpiarTb();
                            winMgr.inhabilitarButton(btnActualizar);
                            winMgr.habilitarButton(btnInsertar);
                            winMgr.inhabilitarButton(btnEliminar);

                            txtMatricula.Enabled = true;
                        }
                        else
                        {
                             MessageBox.Show("No has seleccionado una fila", "Alerta");
                        }
                           
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se ha podido elimiar el registro por:\n" + ex.Message.ToString() + "\n Contacte al administrador del sistema.", "Error");
                }
            }
            else
            {
                MessageBox.Show("No has seleccionado una fila","Alerta");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (actualizar == true)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtMatricula.Text) || !string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtApellido.Text) || !string.IsNullOrEmpty(txtEdad.Text))
                    {
                        cdb.editarPersona(ida, txtName.Text, txtApellido.Text, int.Parse(txtEdad.Text), txtTelefono.Text, dtPFecha.Value, cbbxCurso.Text, cursBsn.leerCursoNombre(cbbxCurso.Text), cbbxSeccion.Text, seccBsn.obtenerSeccionNombreWhereId(cbbxSeccion.Text).ToString());
                        cdb.mostrarPersona();
                        limpiarTb();
                        winMgr.inhabilitarButton(btnActualizar);
                        winMgr.habilitarButton(btnInsertar);
                        winMgr.inhabilitarButton(btnEliminar);
                        txtMatricula.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No dejes ningun campo vacio", "Alerta");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar el registro por:\n"+ex.Message.ToString()+"\n Contacte al administrador del sistema.", "Error");
                }
                
            }
            else
            {
                MessageBox.Show("Selecciona una celda para modificar su registro", "Alerta");
            }
        }

       

        private void readDg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            winMgr.habilitarButton(btnActualizar);
            winMgr.habilitarButton(btnEliminar);
            ida = readDg.CurrentRow.Cells["matricula"].Value.ToString();
            txtMatricula.Text = ida;
            txtName.Text = readDg.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = readDg.CurrentRow.Cells["apellido"].Value.ToString();
            txtEdad.Text = readDg.CurrentRow.Cells["edad"].Value.ToString();
            txtTelefono.Text = readDg.CurrentRow.Cells["numeroTelefono"].Value.ToString();
            dtPFecha.Value = DateTime.Parse(readDg.CurrentRow.Cells["fechadenacimiento"].Value.ToString());
            cbbxSeccion.SelectedItem = readDg.CurrentRow.Cells["seccionid"].Value.ToString();
            cbbxCurso.SelectedItem = readDg.CurrentRow.Cells["cursoId"].Value.ToString();
            actualizar = true;
            txtMatricula.Enabled = false;
            winMgr.inhabilitarButton(btnInsertar);
        }

        private void cbbxCurso_SelectedValueChanged(object sender, EventArgs e)
        {
            cbbxSeccion.Text = "";
            cbbxSeccion.DataSource = seccBsn.obtenerSeccionID(cbbxCurso.Text);
        }

        private void limpiarTb()
        {
            winMgr.limpiarTextBox(txtName);
            winMgr.limpiarTextBox(txtApellido);
            winMgr.limpiarTextBox(txtTelefono);
            winMgr.limpiarTextBox(txtEdad);
        }
    }
}
