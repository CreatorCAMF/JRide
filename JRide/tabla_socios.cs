using Newtonsoft.Json;

namespace JRide
{
    public class tabla_socios
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
    }

    public class tabla_sociosWrapper : Java.Lang.Object
    {
        public tabla_sociosWrapper(tabla_socios socio)
        {
            tabla_socios = socio;
        }

        public tabla_socios tabla_socios { get; private set; }
    }
}