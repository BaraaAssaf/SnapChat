using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IOrder_Repository
    {
        public order_snapchat createorder(order_snapchat order);
        public List<orderForEachService> countOfService();
        


    }
}






