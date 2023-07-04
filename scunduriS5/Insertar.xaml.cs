using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace scunduriS5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Insertar : ContentPage
	{
		public Insertar ()
		{
			InitializeComponent ();
		}

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
			try
			{
				WebClient cliente = new WebClient ();
                string Url = "http://192.168.17.35/Api/ws_uisrael/post.php";
				var parametros = new System.Collections.Specialized.NameValueCollection ();
				parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
				cliente.UploadValues(Url,"POST",parametros);
				DisplayAlert("ATENCION","Registro Ingresado correctamente","CERRAR");
				Navigation.PushAsync(new Page1());            }
			catch (Exception ex)
			{

				DisplayAlert("ERROR..!",ex.Message,"CERRAR");
			}

        }
    }
}