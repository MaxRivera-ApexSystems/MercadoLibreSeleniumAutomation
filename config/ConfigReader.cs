using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ManualToSdetMercadoLibre.config
{
    public static class ConfigReader
    {
        private static readonly string configPath = "config/config.json";

        public static string GetSsid()
        {
            //Este comentario se puede considerar como solo un extra:
            //El documento busca un "config\config.json" aunque en el proyecto el archivo es llamado "config\testconfig.json"
            //y, al menos en mi caso, no es agregado durante el build.
            //Haciendo las adecuaciones necesarias funciona bien.
            var json = File.ReadAllText(configPath);
            var doc = JsonDocument.Parse(json);

            return doc.RootElement.GetProperty("cookies").GetProperty("ssid").GetString();



        }
    }
}
