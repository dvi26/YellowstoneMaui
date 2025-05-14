using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ManejadoraCaballosBDD
    {
        /// <summary>
        /// Funcion que editara el caballo llamando a la BDD
        /// </summary>
        /// <param name="idCaballo"></param>
        /// <param name="idRaza"></param>
        /// <returns></returns>
        public static int EditarCaballo(int idCaballo, int idRaza)
        {
            //bool haEditado = false;
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@idCaballo", System.Data.SqlDbType.Int).Value = idCaballo;
            miComando.Parameters.Add("@idRaza", System.Data.SqlDbType.Int).Value = idRaza;

            try
            {
                miConexion = clsConexionListado.getConexion();
                //miConexion.Open();
                miComando.CommandText = "UPDATE Caballos SET IDRaza=@idRaza WHERE IDCaballo=@idCaballo;";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
                //haEditado = numeroFilasAfectadas > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }
            return numeroFilasAfectadas;
        }
    }
}
