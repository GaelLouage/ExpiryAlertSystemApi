using Infra.Dtos;
using Infra.Enums;
using Infra.Extensions;
using Infra.Helpers;
using Infra.Models;
using Infra.Services.Interfaces;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services.Classes
{
    public class PerishableProductService : IPerishableProductService
    {
        private readonly string _filePath;
        public PerishableProductService(string filePath)
        {
            _filePath = filePath;
        }
        public async Task<List<ExpiryAlertDto>> GetExpiryAlertsAsync(int daysThreshold = 7)
        {
            var expiryDtos = new List<ExpiryAlertDto>();
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("File not found!");
            }

            var products = await IOHelpers.ReadFileAsync(_filePath);

            products = products
                .OrderByDescending(x => x.ExpiryDate)
                .ToList();

            foreach (var product in products)
            {
                expiryDtos.GetExpiredProducts(product);

                expiryDtos.GetSoonExpiredProducts(daysThreshold,product);
            }
            return expiryDtos;
        }
    }
}
