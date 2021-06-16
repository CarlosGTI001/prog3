using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class lista
    {
        private conect con = new conect();

        SqlDataReader read;
        SqlDataReader reada;
        DataTable tab = new DataTable();
        SqlCommand com = new SqlCommand();
        DataTable tab2 = new DataTable();
        SqlCommand com2 = new SqlCommand();

        public DataTable ShowList()
        {
            tab.Clear();
            com.Connection = con.OpenCon();
            com.CommandText = "VerEstudiante";
            com.CommandType = CommandType.StoredProcedure;
            read = com.ExecuteReader();
            tab.Load(read);
            con.CerrarConexion();
            return tab;
        }

        public void Insert(string matricula, string nombre, string apellido, int edad, string numeroTelefono, DateTime fechaNacimiento, string cursoId, string CursoNombre, string seccionId, string seccionNombre)
        {
            com.Connection = con.OpenCon();
            com.CommandText = "InsertarEstudiante";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@matricula", matricula);
            com.Parameters.AddWithValue("@nombre", nombre);
            com.Parameters.AddWithValue("@apellido", apellido);
            com.Parameters.AddWithValue("@numeroTelefono", numeroTelefono);
            com.Parameters.AddWithValue("@edad", edad);
            com.Parameters.AddWithValue("@fechadenacimiento", fechaNacimiento);
            com.Parameters.AddWithValue("@cursoId", cursoId);
            com.Parameters.AddWithValue("@cursoNombre", CursoNombre);
            com.Parameters.AddWithValue("@SeccionId", seccionId);
            com.Parameters.AddWithValue("@SeccioNombre", seccionNombre);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        public void Edit(string matricula, string nombre, string apellido, int edad, string numeroTelefono, DateTime fechaNacimiento, string cursoId, string CursoNombre, string seccionId, string seccionNombre)
        {
            com.Connection = con.OpenCon();
            com.CommandText = "EditarEstudiante";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@matricula", matricula);
            com.Parameters.AddWithValue("@nombre", nombre);
            com.Parameters.AddWithValue("@apellido", apellido);
            com.Parameters.AddWithValue("@numeroTelefono", numeroTelefono);
            com.Parameters.AddWithValue("@edad", edad);
            com.Parameters.AddWithValue("@fechadenacimiento", fechaNacimiento);
            com.Parameters.AddWithValue("@cursoId", cursoId);
            com.Parameters.AddWithValue("@cursoNombre", CursoNombre);
            com.Parameters.AddWithValue("@SeccionId", seccionId);
            com.Parameters.AddWithValue("@SeccioNombre", seccionNombre);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        public void Del(string matricula)
        {
            com.Connection = con.OpenCon();
            com.CommandText = "EliminarEstudiante";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@matricula", matricula);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        public string[] ShowMatricula()
        {
            com2.Connection = con.OpenCon();
            com2.CommandText = "VerMatricula";
            com2.CommandType = CommandType.StoredProcedure;
            reada = com.ExecuteReader();
            
            List<string> resultado = new List<string>();
            while (reada.Read())
            {
                resultado.Add(Convert.ToString(reada["matricula"]));
            }
            string[] arrays = resultado.ToArray();
            con.CerrarConexion();
            return arrays;
        }
    }
}
