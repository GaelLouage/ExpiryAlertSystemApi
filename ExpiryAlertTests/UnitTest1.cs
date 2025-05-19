using Infra.Enums;
using Infra.Models;
using Newtonsoft.Json;

namespace ExpiryAlertTests
{
    public class Tests
    {
  
        [Test]
        public void Test1()
        {
            var ExpiryTreshold = DateTime.Now.AddDays(7);
            var readFile = File.ReadAllText("C:\\Users\\louag\\source\\repos\\ExpiryAlertSystemApi\\ExpiryAlertSystemApi\\products.json");
            var data = JsonConvert.DeserializeObject<List<PerishableProductEntity>>(readFile);
            // Assert
            var firstProduct = data.FirstOrDefault();
            Assert.Less(firstProduct.ExpiryDate, ExpiryTreshold, $"Status: {StatusType.Soon}");
        }
    }
}