using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KBM_88
{
    public class VersionChecker
    {
        private const string VersionMetaUrl = @"https://raw.githubusercontent.com/galister/dcs-kbm/version-meta/version.json";
        public const string ReleasesUrl = @"https://github.com/galister/dcs-kbm/releases";

        public static async Task<Version> CheckVersion()
        {
            using var client = new HttpClient();
            using var resp = await client.GetAsync(VersionMetaUrl);

            resp.EnsureSuccessStatusCode();
            var contentStr = await resp.Content.ReadAsStringAsync();
            var meta = JsonConvert.DeserializeObject<VersionMeta>(contentStr);

            if (meta.versions.TryGetValue("stable", out var stableVerStr))
            {
                var stableVer = Version.Parse(stableVerStr);
                if (stableVer > Assembly.GetExecutingAssembly().GetName().Version)
                    return stableVer;
            }
            return null;
        }

        public class VersionMeta
        {
            public Dictionary<string, string> versions;
            public string updated;
        }
    }
}