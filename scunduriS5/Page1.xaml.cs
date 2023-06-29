using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace scunduriS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private const string Url = "http://192.168.17.35/Api/ws_uisrael/post.php";
        private HttpClient client = new HttpClient();

        private ObservableCollection<scunduriS5.Datos> post;
        public Page1()
        {
            InitializeComponent();
            obtener();
        }

        public async void obtener() {
            var contenido = await client.GetStringAsync(Url);
            List<scunduriS5.Datos> listPost = JsonConvert.DeserializeObject<List<scunduriS5.Datos>>(contenido);
            post = new ObservableCollection<scunduriS5.Datos>(listPost);
            lstEstudiantes.ItemsSource = post;
        }
    }
}