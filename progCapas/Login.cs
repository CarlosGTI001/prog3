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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Add.carlosFWK winMgr = new Add.carlosFWK();
        usrMgrBsn login = new usrMgrBsn();
        
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            winMgr.minimizar(this);
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            winMgr.cerrar();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(login.login(txtUsr.Text, txtPsw.Text))
            {
                MenuForm frm = new MenuForm();
                /*if (login.verificarRoll(login.getId(txtUsr.Text)))
                {
                    frm.test = true;
                }
                else
                {
                    frm.test = false;
                }*/
                winMgr.openForm(this, frm);

            }
            else
            {
                MessageBox.Show("Datos ingresados de manera incorrecta o aun no estas registrado: \n\n Contacta al administrador del sistema.", "Alerta");
            }
        }
    }
}
