using AccesoDatos.Helpers;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AccesoDatos.ViewModels
{
    public class SeccionesViewModel : INotifyPropertyChanged
    {
        private HelperAutoescuelaSQLite helper;

        public SeccionesViewModel()
        {
            this.helper = new HelperAutoescuelaSQLite();
            if (this.SeccionesModel == null)
            {
                this.SeccionesModel = new Secciones();
            }
        }

        private Secciones _SeccionesModel;

        public Secciones SeccionesModel
        {
            get { return this._SeccionesModel; }
            set
            {
                this._SeccionesModel = value;
                OnPropertyChanged("SeccionesModel");
            }
        }

        public Command InsertarDato
        {
            get
            {
                return new Command(() => {
                    this.helper.InsertarSeccion(this.SeccionesModel);
                });
            }
        }

        public Command ModificarDato
        {
            get
            {
                return new Command(() => {
                    this.helper.ModificarSeccion(this.SeccionesModel);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
