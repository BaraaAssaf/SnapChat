using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class OrderService_service : IOrderService_service
    {
        private readonly IOrderService_Repository orderService_;
        public OrderService_service(IOrderService_Repository orderService_)
        {
            this.orderService_ = orderService_;
        }




        public orderservice_snapchat createorderservice(orderservice_snapchat orderservice)
        {
            return orderService_.createorderservice(orderservice);
        }

        public List<SalesDTO> gettotalsalesbyservice()
        {
            return orderService_.gettotalsalesbyservice();
        }


    }
}