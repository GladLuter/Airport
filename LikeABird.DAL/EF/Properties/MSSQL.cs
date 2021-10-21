using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.EF.Properties {
    public class MSSQL {
        public string ConnectionStrings { get; set; }
        private static string GetConfigPath() {
            string FilePath = Directory.GetCurrentDirectory() + "\\MSSQL.json";
            return FilePath;
        }
        private static async Task<string> GetConfigAsync() {
            var dataStr = await File.ReadAllTextAsync(GetConfigPath());
            return dataStr;
        }
        public static MSSQL GetMSSQL() {
            return JsonConvert.DeserializeObject<MSSQL>(GetConfigAsync().Result);
        }
    }
}
