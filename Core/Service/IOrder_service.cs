using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IOrder_service
    {
        public order_snapchat createorder(order_snapchat order);
        public List<orderForEachService> countOfService();


    }

}
