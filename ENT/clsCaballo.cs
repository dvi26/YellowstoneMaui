namespace ENT
{
    public class clsCaballo
    {
        public int IdCaballo { get; set; }
        public string Nombre { get; set; }
        public int IdRaza { get; set; }

        public clsCaballo(int idCaballo, string nombre, int idRaza)
        {
            Nombre = nombre;
            IdCaballo = idCaballo;
            IdRaza = idRaza;
        }
        public clsCaballo() { }
    }
}
