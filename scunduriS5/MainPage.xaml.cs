﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace scunduriS5
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.17.35/Api/ws_uisrael/post.php";
        private HttpClient client = new HttpClient();

        private ObservableCollection<scunduriS5.Datos> post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await client.GetStringAsync(Url);
            List<scunduriS5.Datos> listPost = JsonConvert.DeserializeObject<List<scunduriS5.Datos>>(contenido);
            post = new ObservableCollection<scunduriS5.Datos>(listPost);
            lstEstudiantes.ItemsSource = post;
        }
    }
}
