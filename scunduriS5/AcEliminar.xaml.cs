using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace scunduriS5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AcEliminar : ContentPage
	{
		public AcEliminar (Datos datos)
		{
			InitializeComponent ();
            txtCodigo.Text = datos.codigo.ToString ();
            txtNombre.Text = datos.nombre.ToString ();
            txtApellido.Text = datos.apellido.ToString ();
            txtEdad.Text = datos.edad.ToString ();

		}

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string edad = txtEdad.Text;

                string url = "http://192.168.17.35/Api/ws_uisrael/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad;

                // Crea la solicitud HTTP con el método PUT
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "PUT";

                // Envía la solicitud y obtén la respuesta
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Lee la respuesta si es necesario
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = reader.ReadToEnd();
                }

                DisplayAlert("ATENCION", "Registro actualizado correctamente", "CERRAR");
                Navigation.PushAsync(new Page1());
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR..!", ex.Message, "CERRAR");
            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigo.Text;
                string url = "http://192.168.17.35/Api/ws_uisrael/post.php?codigo=" + codigo;

                // Crea la solicitud HTTP con el método PUT
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "DELETE";

                // Envía la solicitud y obtén la respuesta
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Lee la respuesta si es necesario
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    //respuesta
                    string responseText = reader.ReadToEnd();
                   
                }

                DisplayAlert("ATENCION", "Registro Eliminado correctamente", "CERRAR");
                Navigation.PushAsync(new Page1());
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR..!", ex.Message, "CERRAR");
            }
        }
    }
}