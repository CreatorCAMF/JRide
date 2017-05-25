using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;

namespace JRide
{
    [Activity(Label = "SeleccionarCarro")]
    public class SeleccionarCarro : Activity
    {
        private CarrosAdapter adaptador;
        private AzureService azureService;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            azureService = new AzureService();
            base.OnCreate(savedInstanceState);
            JObject Conductor = JObject.Parse(Intent.GetStringExtra("ConductorData"));
            tabla_conductores ConductorData = Conductor.ToObject<tabla_conductores>();
            await azureService.BuscarCarros(ConductorData.socio);

            

            // Create your application here
            SetContentView(Resource.Layout.SeleccionarCarro);

            adaptador = new CarrosAdapter(this, Resource.Layout.ItemCarro);
            ListView listaCarros = FindViewById<ListView>(Resource.Id.lvListaCarro);
            listaCarros.Adapter = adaptador;

            foreach (tabla_carros current in azureService.carros)
            {
                adaptador.Add(current);
            }


        }
    }
}