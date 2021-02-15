using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace KBM_88
{
    public class Settings
    {
        public static readonly string ConfigFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "DCS-KBM88.json"
            );
        
        public string SavedGamesFolder { get; set; }
        
        public Dictionary<string, string> DcsBinFolders { get; set; }
        public Dictionary<string, List<string>> AirframeSelections { get; set; }
        public Dictionary<string, List<string>> MapSelections { get; set; }
        public List<string> CommonSelections { get; set; }
        public string Airframe { get; set; }
        public string Map { get; set; }

        public static Settings Load()
        {
            try
            {
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(ConfigFile)).EnsureValid();
            }
            catch
            {
                return new Settings
                {
                    MapSelections = new Dictionary<string, List<string>>(),
                    AirframeSelections = new Dictionary<string, List<string>>(),
                    CommonSelections = new List<string>()
                };
            }
        }

        private Settings EnsureValid()
        {
            AirframeSelections ??= new Dictionary<string, List<string>>();
            MapSelections ??= new Dictionary<string, List<string>>();
            CommonSelections ??= new List<string>();
            return this;
        }

        public void Save()
        {
            File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}