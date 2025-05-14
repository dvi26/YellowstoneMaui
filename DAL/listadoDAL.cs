using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class listadoDAL
    {
        /// <summary>
        /// Obtiene un listado de caballos de la BDD
        /// </summary>
        /// <returns></returns>
        public static List<clsCaballo> ObtenerCaballos()
        {

            SqlConnection miConexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();
            clsCaballo oCaballo;
            List<clsCaballo> listadoCaballos = new List<clsCaballo>();

            try
            {
                miConexion = clsConexionListado.getConexion();
                //miConexion.Open();
                miComando.CommandText = "SELECT * FROM caballos";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        
                        oCaballo = new clsCaballo();
                        oCaballo.IdCaballo = (int)miLector["IDCaballo"];

                        if (miLector["Nombre"] != DBNull.Value)
                        {
                            oCaballo.Nombre = (string)miLector["Nombre"];
                        }
                        if (miLector["IDRaza"] != DBNull.Value)
                        {
                            oCaballo.IdRaza = (int)miLector["IDRaza"];
                        }
                        listadoCaballos.Add(oCaballo);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }

            return listadoCaballos;
        }
        /// <summary>
        /// Funcion que devolvera una lista de razas de la BDD
        /// </summary>
        /// <returns></returns>
        public static List<clsRaza> ObtenerRazas()
        {
            SqlConnection miConexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();
            clsRaza oRaza;
            List<clsRaza> listadoRazas = new List<clsRaza>();

            try
            {
                miConexion = clsConexionListado.getConexion();
                miComando.CommandText = "SELECT * FROM Razas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        int idRaza = (int)miLector["IDRaza"];
                        oRaza = new clsRaza(idRaza, (string)miLector["Nombre"]);
                        listadoRazas.Add(oRaza);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }

            return listadoRazas;
        }
        /// <summary>
        /// Funcion que busca el caballo por raza en la BDD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsCaballo BuscarCaballoPorRaza(int id)
        {
            string connectionString = "server=davidser.database.windows.net;database=DavidDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
            clsCaballo oCaballo = null;

            using (SqlConnection miConexion = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Caballos WHERE IDRaza = @id";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                    try
                    {
                        miConexion.Open();

                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.Read())
                            {
                                {
                                    oCaballo = new clsCaballo();
                                    oCaballo.IdCaballo = (int)miLector["IDCaballo"];
                                    oCaballo.Nombre = (string)miLector["Nombre"];
                                    oCaballo.IdRaza = (int)miLector["IDRaza"];
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return oCaballo;
        }
        
    }
}

            
    




