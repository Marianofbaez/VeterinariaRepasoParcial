using System.Data.SqlClient;
using VeterinariaRepasoParcial.Models;
namespace VeterinariaRepasoParcial.Datos

{
    public class BibliotecaDatos
    {
        private string conexionString = @"Data Source=DESKTOP-2ES64E3;Initial Catalog=VeterinariaProgramacionIII;Integrated Security=True";
        //public List<Mascota> ListarMascotas()
        public List<Mascota> ListarMascotas(int id)
        {
            List<Mascota> lista = new List<Mascota>();
            //todo lo que está dentro de using, al final automáticamente se cierra
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                //string query = "SELECT * FROM Mascotas ";
                string query = "SELECT Mascotas.Id as IdMascota, Mascotas.Nombre as NombreMascota, Mascotas.IdEspecie, Mascotas.Edad, Mascotas.NombreDuenio, Especies.Nombre as NombreEspecie FROM Mascotas INNER JOIN Especies ON Mascotas.IdEspecie = Especies.Id ";

                if (id > 0)
                {
                    query += $"WHERE Mascotas.Id = {id} ";
                }

                query += $"ORDER BY Mascotas.Nombre";

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


            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    string query = $"INSERT INTO Mascotas (nombre, IdEspecie, edad, nombreduenio) VALUES ('{mascota.Nombre}', {mascota.IdEspecie}, {mascota.Edad}, '{mascota.NombreDuenio}')";

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
        public string EditarMascota(Mascota mascota)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    string query = $"UPDATE Mascotas SET Nombre = '{mascota.Nombre}' , IdEspecie = '{mascota.IdEspecie}', edad = '{mascota.Edad}' , nombreduenio = '{mascota.NombreDuenio}' WHERE Id = '{mascota.Id}' ";
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

        public string BorrarMascota(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    string query = $"DELETE FROM Mascotas WHERE Id = {id}";
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
    }
}
