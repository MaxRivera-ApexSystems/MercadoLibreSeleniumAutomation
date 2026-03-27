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
            var json = File.ReadAllText(configPath);
            var doc = JsonDocument.Parse(json);

            return doc.RootElement.GetProperty("cookies").GetProperty("ssid").GetString();



        }
    }
}
