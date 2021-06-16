using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataLayer;

namespace BussinesLayer
{
    public class usrMgrBsn
    {
        admUsr adm = new admUsr();

        public bool login(string email, string password)
        {
            bool _u, _p, _r;
            string[] pwd = adm.ShowPsw();
            string[] eml = adm.ShowUsr();
            int longitudU = eml.Length, longitudC = pwd.Length;
            
            _u = false;
            _p = false;
        
            if (longitudU > 0)
            {  
                for (int i = 0; i < longitudU; i++)
                {
                    if (eml[i] == email)
                    {
                        _u = true;
                        goto exit1;
                    }
                    else
                    {
                        _u = false;
                    }
                }

            exit1:
                for (int i = 0; i < longitudC; i++)
                {
                    if (pwd[i] == password)
                    {
                        _p = true;
                        goto exit2;
                    }
                    else
                    {
                        _p = false;
                    }
                }
            exit2:; 
            }
            else
            {
                _p = false;
            }



            if (_u == true && _p == true)
            {
                _r = true;
            }
            else
            {
                _r = false;
            }

            return _r;
        }

        /*public bool verificarRoll(string id)
        {
            string result = adm.ShowRoll(id);
            if(result == "administrador")
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        /*public string getId(string correo)
        {
            return adm.ShowId(correo);
        }*/
    }
}
