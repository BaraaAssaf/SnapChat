using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class Order_Service : IOrder_service
    {
        private readonly IOrder_Repository iorder;
        public Order_Service(IOrder_Repository order)
        {
            this.iorder = order;
        }

        public List<orderForEachService> countOfService()
        {
            return iorder.countOfService();
        }

        public order_snapchat createorder(order_snapchat order)
        {
            return iorder.createorder(order);
        }
    }
}
