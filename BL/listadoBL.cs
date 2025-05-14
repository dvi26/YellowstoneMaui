using DAL;
using ENT;

namespace BL
{
    public class listadoBL
    {
        public static List<clsCaballo> ObtenerCaballos()
        {
            return listadoDAL.ObtenerCaballos();
        }
        public static List<clsRaza> ObtenerRazas()
        {
            return listadoDAL.ObtenerRazas();
        }



    }
}
