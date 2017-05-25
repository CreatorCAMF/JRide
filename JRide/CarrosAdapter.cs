
using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using System;

namespace JRide
{
    public class CarrosAdapter : BaseAdapter<tabla_carros>
    {
        Activity activity;
        int layoutResourceId;
        List<tabla_carros> carros = new List<tabla_carros>();




        public CarrosAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        //Returns the view for a specific carro on the list
        public override View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            TextView tvPlacas;
            TextView tvDescripcion;
            Button btnSeleccionar;
            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);
                btnSeleccionar = row.FindViewById<Button>(Resource.Id.btnCarroSeleccionado);

                btnSeleccionar.Click +=  (sender, e) =>
                {
                    var cbSender = sender as Button;
                    if (cbSender != null && cbSender.Tag is tabla_carrosWrapper)
                    {
                        Console.WriteLine((cbSender.Tag as tabla_carrosWrapper).tabla_carros.placas);
                    }
                };
              
            }
            else
            {
                btnSeleccionar = row.FindViewById<Button>(Resource.Id.btnCarroSeleccionado);
            }

            tvPlacas = row.FindViewById<TextView>(Resource.Id.tvPlacas);
            tvDescripcion = row.FindViewById<TextView>(Resource.Id.tvDescripcionCarro);
            tvPlacas.Text = currentItem.placas;
            tvDescripcion.Text = currentItem.marca + " " + currentItem.modelo + " " + currentItem.anio + " " + currentItem.color;

            btnSeleccionar.Tag = new tabla_carrosWrapper(currentItem);

            return row;
        }

        public void Add(tabla_carros carro)
        {
            carros.Add(carro);
            NotifyDataSetChanged();
        }

        public void Clear()
        {
            carros.Clear();
            NotifyDataSetChanged();
        }

        public void Remove(tabla_carros carro)
        {
            carros.Remove(carro);
            NotifyDataSetChanged();
        }







        #region implemented abstract members of BaseAdapter

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get
            {
                return carros.Count;
            }
        }

        public override tabla_carros this[int position]
        {
            get
            {
                return carros[position];
            }
        }

        #endregion
    }
}