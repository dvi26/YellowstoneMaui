using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ENT;

namespace Yellowstone.Models
{
    public class clsCaballoConRaza : clsCaballo
    {
        private ObservableCollection<clsRaza> listadoRazas;
        private clsRaza razaSeleccionada;

        public clsCaballoConRaza(clsCaballo caballo, ObservableCollection<clsRaza> listadoParam)
        {
            listadoRazas = listadoParam;
            IdCaballo = caballo.IdCaballo;
            Nombre = caballo.Nombre;
            IdRaza = caballo.IdRaza;
            RazaSeleccionada = listadoRazas.Where(x => x.IdRaza == IdRaza).FirstOrDefault();

        }
        public ObservableCollection<clsRaza> ListadoRazas
        {
            get { return listadoRazas; }

        }
        public clsRaza RazaSeleccionada
        {
            get { return razaSeleccionada; }
            set { razaSeleccionada = value; }
        }
        public clsCaballoConRaza()
        {

        }
        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
