using ApiMaui.Resources;
using BL;
using ENT;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Yellowstone.Models;

namespace Yellowstone.ViewModel
{
    public class clsUIViewModel : clsCaballoConRaza,INotifyPropertyChanged
    {
        #region Atributos
        private ObservableCollection<clsCaballoConRaza> listadoCompleto;
        private DelegateCommand guardarBtn;
        private int filasAfectadas;
        #endregion

        #region Propiedades

        public int FilasAfectadas
        {
            get { return filasAfectadas; }
            private set { filasAfectadas = value; NotifyPropertyChanged("FilasAfectadas"); }
        }
        public ObservableCollection<clsCaballoConRaza> ListadoCompleto
        {
            get { return listadoCompleto; }

        }

        public DelegateCommand GuardarBoton
        {
            get { return guardarBtn; }
        }
        #endregion

        #region Constructor
        public clsUIViewModel()
        {
            try
            {
                List<clsCaballo> caballos = listadoBL.ObtenerCaballos();
                ObservableCollection<clsRaza> listadoRazasAux = new ObservableCollection<clsRaza>(listadoBL.ObtenerRazas());
                listadoRazasAux.Insert(0, new clsRaza(0, "Seleccione una raza"));

                listadoCompleto = new ObservableCollection<clsCaballoConRaza>();
                _ = cargarListado(caballos, listadoRazasAux);
                guardarBtn = new DelegateCommand(GuardarCommandExecuted);
                //guardarBtn = new DelegateCommand(GuardarCommandExecuted, GuardarCommandCanExecute);
            }
            catch (SqlException e)
            {
                throw e;
            }       
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Funcion que se ejecutara al pulsar el boton guardar, llamara a editar caballos en la BDD y hara las comprobaciones necesarias
        /// </summary>
        private async void GuardarCommandExecuted()
        {
            FilasAfectadas = 0;

            try
            {
                foreach (clsCaballoConRaza caballo in listadoCompleto)
                {
                    int idCaballo = caballo.IdCaballo;
                    clsRaza razaSeleccionada = caballo.RazaSeleccionada;

                    if (razaSeleccionada != null)
                    {
                        try
                        {
                            if (razaSeleccionada.IdRaza != 0 && razaSeleccionada.IdRaza != caballo.IdRaza)
                            {
                                int filaAfectadaActual = ManejadoraCaballosBL.EditarCaballoBL(idCaballo, razaSeleccionada.IdRaza);

                                if (filaAfectadaActual > 0)
                                {
                                    caballo.IdRaza = razaSeleccionada.IdRaza;
                                    FilasAfectadas += filaAfectadaActual;
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            await App.Current.MainPage.DisplayAlert("Error", $"Error al actualizar el caballo con ID {idCaballo}: {ex.Message}", "Aceptar");
                        }
                    }
                }
                //NotifyPropertyChanged("FilasAfectadas");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error al guardar los cambios: {ex.Message}", "Aceptar");
            }
        }
        /// <summary>
        /// Carga el listado
        /// </summary>
        /// <param name="caballos"></param>
        /// <param name="listadoRazasAux"></param>
        /// <returns></returns>
        public async Task cargarListado(List<clsCaballo> caballos, ObservableCollection<clsRaza> listadoRazasAux)
        {
            
            foreach (var caballo in caballos)
            {
                listadoCompleto.Add(new clsCaballoConRaza(caballo, listadoRazasAux));
            }
        }

        /*Idea, no se donde llamar al raiseCanExeccuteChanged
        /// <summary>
        /// Comprueba si se puede o no ejecutar el boton
        /// </summary>
        /// <returns></returns>
        private bool GuardarCommandCanExecute()
        {
            if (listadoCompleto != null)
            {
                foreach (var caballo in listadoCompleto)
                {
                    if (caballo.RazaSeleccionada != null &&
                        caballo.RazaSeleccionada.IdRaza != 0 &&
                        caballo.RazaSeleccionada.IdRaza != caballo.IdRaza)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        */
        #endregion

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
