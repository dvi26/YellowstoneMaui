namespace ENT
{
    public class clsRaza
    {
        public int IdRaza { get; set; }
        public string Nombre { get; set; }

        public clsRaza(int idRaza, string nombre)
        {
            IdRaza = idRaza;
            Nombre = nombre;
        }
        public clsRaza() { }
    }
}
