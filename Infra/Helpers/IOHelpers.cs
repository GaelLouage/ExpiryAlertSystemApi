using Infra.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers
{
    public class IOHelpers
    {
        public static async Task<List<PerishableProductEntity>?> ReadFileAsync(string filePath)
        {
            var read = await File.ReadAllTextAsync(filePath);
            var products = JsonConvert.DeserializeObject<List<PerishableProductEntity>>(read);
            return products;
        }
    }
}
