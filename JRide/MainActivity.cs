using System;
using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using JRide;
using Android.Content;
using Newtonsoft.Json;

namespace JRide
{
    [Activity(Label = "JRide", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private AzureService azureService;

        EditText etUsuario;
        EditText etContrasena;
        Button btnEntrar;
        protected override void OnCreate(Bundle bundle)
        {
            azureService = new AzureService();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            base.OnCreate(bundle);

            btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
            etUsuario = FindViewById<EditText>(Resource.Id.etUsuario);
            etContrasena = FindViewById<EditText>(Resource.Id.etContrasena);

            btnEntrar.Click += BtnEntrar_Click;
        }
        private async void BtnEntrar_Click(object sender, EventArgs e)
        {
            await azureService.BuscarConductor(etUsuario.Text, etContrasena.Text);
            var intent = new Intent(this, typeof(SeleccionarCarro));
            if (azureService.conductores != null && azureService.conductores.Count > 0)
            {
                intent.PutExtra("ConductorData", JsonConvert.SerializeObject(azureService.conductores[0]));
            }
            this.StartActivity(intent);
            //this.Finish();
        }


        private void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
        }

        private void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}

