using AccesoDatos.Helpers;
using AccesoDatos.Models;
using AccesoDatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccesoDatos.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrincipalView : ContentPage
	{
        HelperAutoescuelaSQLite helper;
        public PrincipalView ()
		{
            InitializeComponent();
            this.helper = new HelperAutoescuelaSQLite();
            this.botoninsertar.Clicked += Botoninsertar_Clicked;
            this.botonleer.Clicked += Botonleer_Clicked;
            this.botoncrear.Clicked += Botoncrear_Clicked;
            this.botonmodificar.Clicked += Botonmodificar_Clicked;
            this.botoneliminar.Clicked += Botoneliminar_Clicked;
        }

        private void Botoneliminar_Clicked(object sender, EventArgs e)
        {
            int numero = int.Parse(this.txtnumero.Text);
            Secciones oficina = helper.BuscarSeccion(numero);
            if (oficina != null)
            {
                this.helper.EliminarSeccion(oficina);
                this.lblmensaje.Text = "Sección eliminada";
            }
            else
            {
                this.lblmensaje.Text = "No se ha encontrado la Sección a eliminar.";
            }
        }

        private async void Botonmodificar_Clicked(object sender, EventArgs e)
        {
            ModificarSeccionView updateview = new ModificarSeccionView();
            SeccionesViewModel viewmodel = new SeccionesViewModel();
            int numero = int.Parse(this.txtnumero.Text);
            Secciones oficina = helper.BuscarSeccion(numero);
            viewmodel.SeccionesModel = oficina;
            updateview.BindingContext = viewmodel;
            await Navigation.PushModalAsync(updateview);
        }

        private async void Botoninsertar_Clicked(object sender, EventArgs e)
        {
            InsertarSeccionView insertarview = new InsertarSeccionView();
            await Navigation.PushModalAsync(insertarview);
        }

        private async void Botonleer_Clicked(object sender, EventArgs e)
        {
            ListaSeccionesView listaview = new ListaSeccionesView();
            await Navigation.PushModalAsync(listaview);
        }

        private void Botoncrear_Clicked(object sender, EventArgs e)
        {
            this.helper.CrearBBDD();
            this.lblmensaje.Text = "BBDD creada correctamente";
        }

    }
}