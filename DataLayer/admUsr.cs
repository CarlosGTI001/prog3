using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class admUsr
    {
        SqlDataReader read;
        SqlDataReader reada;
        SqlCommand com = new SqlCommand();
        SqlCommand com2 = new SqlCommand();

        private conect con = new conect();
        public string[] ShowUsr()
        {
            com2.Connection = con.OpenCon();
            com2.CommandText = "VerCorreo";
            com2.CommandType = CommandType.StoredProcedure;
            reada = com2.ExecuteReader();

            List<string> resultadoUsr = new List<string>();

            while (reada.Read())
            {
                resultadoUsr.Add((string)reada["correoElectronico"]);
            }
            string[] arrays = resultadoUsr.ToArray();

            con.CerrarConexion();
            return arrays;
        }
        
        /*public string ShowRoll(string id)
        {
            com2.Connection = con.OpenCon();
            com2.CommandText = "MostrarRoll";
            com2.Parameters.AddWithValue("@id", id);
            com2.CommandType = CommandType.StoredProcedure;
            reada = com2.ExecuteReader();

            List<string> resultadoUsr = new List<string>();

           
            string String = resultadoUsr.ToString();

            con.CerrarConexion();
            return String;
        }*/

        public string[] ShowPsw()
        {
            com2.Connection = con.OpenCon();
            com2.CommandText = "VerContrasenia";
            com2.CommandType = CommandType.StoredProcedure;
            read = com2.ExecuteReader();

            List<string> resultadoUsr = new List<string>();

            while (read.Read())
            {
                resultadoUsr.Add((string)read["contrasenia"]);
            }
            string[] arrays = resultadoUsr.ToArray();

            con.CerrarConexion();
            return arrays;
        }

        /*public string ShowId(string correo)
        {
            com2.Connection = con.OpenCon();
            com2.CommandText = "MostrarIdUs";
            com2.Parameters.AddWithValue("@user", correo);
            com2.CommandType = CommandType.StoredProcedure;
            reada = com2.ExecuteReader();

            List<string> resultadoUsr = new List<string>();

            string String = resultadoUsr.ToString();

            con.CerrarConexion();
            return String;
        }*/
    }
}