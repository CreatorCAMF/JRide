using Newtonsoft.Json;

namespace JRide
{
    public class tabla_carros
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "marca")]
        public string marca { get; set; }

        [JsonProperty(PropertyName = "modelo")]
        public string modelo { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string color { get; set; }

        [JsonProperty(PropertyName = "anio")]
        public int anio { get; set; }

        [JsonProperty(PropertyName = "socio")]
        public string socio { get; set; }

        [JsonProperty(PropertyName = "placas")]
        public string placas { get; set; }
    }

    public class tabla_carrosWrapper : Java.Lang.Object
    {
        public tabla_carrosWrapper(tabla_carros carro)
        {
            tabla_carros = carro;
        }

        public tabla_carros tabla_carros { get; private set; }
    }
}