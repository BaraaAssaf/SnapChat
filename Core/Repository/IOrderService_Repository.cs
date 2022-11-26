using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IOrderService_Repository
    {
        public orderservice_snapchat createorderservice(orderservice_snapchat orderservice);
        public List<SalesDTO> gettotalsalesbyservice();
    }
}
