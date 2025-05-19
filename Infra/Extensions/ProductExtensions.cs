using Infra.Dtos;
using Infra.Enums;
using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Extensions
{
    public static class ProductExtensions
    {
        public static void GetSoonExpiredProducts(this List<ExpiryAlertDto> expiryDtos, int daysThreshold, PerishableProductEntity product)
        {
            if (product.ExpiryDate <= DateTime.Now.AddDays(daysThreshold))
            {
                expiryDtos.Add(new ExpiryAlertDto
                {
                    ProductName = product.Name,
                    Status = StatusType.Soon
                });
            }
        }

        public static void GetExpiredProducts(this List<ExpiryAlertDto> expiryDtos, PerishableProductEntity product)
        {
            if (product.ExpiryDate < DateTime.Now)
            {
                expiryDtos.Add(new ExpiryAlertDto
                {
                    ProductName = product.Name,
                    Status = StatusType.Expired
                });
            }
        }
    }
}
