
using DAL;

namespace BL
{
    public class ManejadoraCaballosBL
    {
        public static int EditarCaballoBL(int idCaballo, int idRaza)
        {
            return ManejadoraCaballosBDD.EditarCaballo(idCaballo, idRaza);
        }
    }
}
