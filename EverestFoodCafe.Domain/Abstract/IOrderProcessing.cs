using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EverestFoodCafe.Domain.Entities;

namespace EverestFoodCafe.Domain.Abstract
{
  public  interface IOrderProcessing
  {
      void ProcessOrder(Cart cart, ShippingDetails shippingDetails );
  }
}
