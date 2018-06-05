using AccesoDatos.Helpers;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace AccesoDatos.ViewModels
{
    public class ListaSeccionesViewModel : INotifyPropertyChanged
    {
        private HelperAutoescuelaSQLite helper;

        public ListaSeccionesViewModel()
        {
            this.helper = new HelperAutoescuelaSQLite();
            List<Secciones> lista = helper.GetSecciones();
            this.Secciones = new ObservableCollection<Secciones>(lista);
        }

        private ObservableCollection<Secciones> _Secciones;

        public ObservableCollection<Secciones> Secciones
        {
            get { return this._Secciones; }
            set
            {
                this._Secciones = value;
                OnPropertyChanged("Secciones");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
