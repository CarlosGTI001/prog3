using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace progCapas
{
    public partial class MenuForm : Form
    {
        Add.carlosFWK winMgr = new Add.carlosFWK(); 
        seccion seccionn = new seccion();
        public MenuForm()
        {
            InitializeComponent();
        }

        private void minLbl_Click(object sender, EventArgs e)
        {
            winMgr.minimizar(this);
        }

        private void ExitLbl_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            winMgr.openForm(this, frm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CursoCrud frm = new CursoCrud();
            winMgr.openForm(this, frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SeccionCrud frm = new SeccionCrud();
            winMgr.openForm(this, frm);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            winMgr.openForm(this, lgn);
        }
    }
}
