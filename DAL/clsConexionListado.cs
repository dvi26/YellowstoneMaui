using Microsoft.Data.SqlClient;


namespace DAL
{

    public class clsConexionListado
    {
        /// <summary>
        /// Funcion estatica que devuelve una conexión abierta a la base de datos
        /// </summary>
        /// <returns></returns>
        public static SqlConnection getConexion()
        {
            SqlConnection miConexion = new SqlConnection();
            try
            {
                miConexion.ConnectionString = "server=davidser.database.windows.net;database=DavidDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
                miConexion.Open();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //miConexion.Close();
            }
            return miConexion;
        }
        /*
        public static SqlConnection cerrarConexion(ref SqlConnection conexion)
        {

        }*/


    }
}
