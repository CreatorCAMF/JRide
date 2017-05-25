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
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace JRide
{

    public class AzureService
    {
        private MobileServiceClient client;
        private const string applicationURL = @"https://jride.azurewebsites.net";
        private IMobileServiceTable<tabla_socios> tablaSocios;
        private IMobileServiceTable<tabla_conductores> tablaConductores;
        private IMobileServiceTable<tabla_carros> tablaCarros;
        //private IMobileServiceTable<tabla_conductores_activos> tablaConductoresActivos;
        //private IMobileServiceTable<tabla_clientes> tablaClientes;
        //private IMobileServiceTable<tabla_viajes> tablaViajes;
        public List<tabla_socios> socios;
        public List<tabla_conductores> conductores;
        public List<tabla_carros> carros;
        public AzureService()
        {
            CurrentPlatform.Init();
            client = new MobileServiceClient(applicationURL);
            tablaSocios = client.GetTable<tabla_socios>();
            tablaConductores = client.GetTable<tabla_conductores>();
            tablaCarros = client.GetTable<tabla_carros>();
        }

        public async void AgregarSocio(tabla_socios socio)
        {
            await tablaSocios.InsertAsync(socio);
        }

        public async Task BuscarSocio(string mote, string contrasena)
        {
            try
            {
                socios = await tablaSocios.Where(socio => socio.mote == mote && socio.contrasena == contrasena).ToListAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }


        public async void AgregarConductor(tabla_conductores conductor)
        {
            await tablaConductores.InsertAsync(conductor);
        }

        public async Task BuscarConductor(string mote, string contrasena)
        {
            try
            {
                conductores = await tablaConductores.Where(conductor => conductor.mote == mote && conductor.contrasena == contrasena).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async void AgregarCarro(tabla_carros carro)
        {
            await tablaCarros.InsertAsync(carro);
        }

        public async Task BuscarCarros(string id)
        {
            try
            {
                carros = await tablaCarros.Where(carro => carro.socio == id).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task BuscarCarro(string id, string placas)
        {
            try
            {
                carros = await tablaCarros.Where(carro => carro.socio == id && carro.placas == placas).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}