using Newtonsoft.Json;

namespace JRide
{
    public class tabla_conductores
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "mote")]
        public string mote { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string nombre { get; set; }

        [JsonProperty(PropertyName = "apellido_paterno")]
        public string apellido_paterno { get; set; }

        [JsonProperty(PropertyName = "apellido_materno")]
        public string apellido_materno { get; set; }

        [JsonProperty(PropertyName = "edad")]
        public int edad { get; set; }

        [JsonProperty(PropertyName = "contrasena")]
        public string contrasena { get; set; }

        [JsonProperty(PropertyName = "socio")]
        public string socio { get; set; }
    }

    public class tabla_conductoresWrapper : Java.Lang.Object
    {
        public tabla_conductoresWrapper(tabla_conductores conductor)
        {
            tabla_conductores = conductor;
        }

        public tabla_conductores tabla_conductores { get; private set; }
    }
}