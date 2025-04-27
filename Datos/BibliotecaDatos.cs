using System.Data.SqlClient;
using VeterinariaRepasoParcial.Models;
namespace VeterinariaRepasoParcial.Datos

{
    public class BibliotecaDatos
    {
        private string conexionString = @"Data Source=DESKTOP-2ES64E3;Initial Catalog=VeterinariaProgramacionIII;Integrated Security=True";
        public List<Mascota> ListarMascotas()
        {
            List<Mascota> lista = new List<Mascota>();
            //todo lo que está dentro de using, al final automáticamente se cierra
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                //string query = "SELECT * FROM Mascotas ";
                string query = "SELECT Mascotas.Id as IdMascota, Mascotas.Nombre as NombreMascota, Mascotas.IdEspecie, Mascotas.Edad, Mascotas.NombreDuenio, Especies.Nombre as NombreEspecie FROM Mascotas INNER JOIN Especies ON Mascotas.IdEspecie = Especies.Id ORDER BY Mascotas.Nombre";

                //if (id > 0)
                //{
                //    query += $"WHERE id = {id}";
                //}

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Mascota()
                    {
                        Id = (int)reader["IdMascota"],
                        Nombre = reader["NombreMascota"].ToString(),
                        IdEspecie = (int)reader["IdEspecie"],
                        Edad = (int)reader["Edad"],
                        NombreDuenio = reader["NombreDuenio"].ToString(),
                        Especie = new Especie()
                        {
                            Id = (int)reader["IdEspecie"],
                            Nombre = reader["NombreEspecie"].ToString()
                        }
                    });
                }
                return lista;
            }
        }
        //public List<Especie> ListarEspecies()
        //{
        //    List<Especie> lista = new List<Especie>();
        //    using (SqlConnection con = new SqlConnection(conexionString))
        //    {
        //        string query = "SELECT * FROM Especies ";

        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            lista.Add(new Especie()
        //            {
        //                Id = (int)reader["Id"],
        //                Nombre = reader["Nombre"].ToString()
        //            });
        //        }
        //    }
        //    return lista;
        //}

        public string CrearMascota(Mascota mascota)
        {
            //string query = $" INSERT INTO Mascotas (Nombre, Especie, Edad, NombreDuenio) VALUES ('{mascota.Nombre}', '{mascota.Especie}', '{mascota.Edad}', '{mascota.NombreDuenio}')";
            string query = $"INSERT INTO Mascotas (nombre, IdEspecie, edad, nombreduenio) VALUES ('{mascota.Nombre}', {mascota.IdEspecie}, {mascota.Edad}, '{mascota.NombreDuenio}')";


            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public List<Especie> ListarEspecies()
        {
            List<Especie> lista = new List<Especie>();
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "SELECT * FROM Especies ORDER BY Nombre";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Especie()
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
                return lista;
            }
        }
    }
}
