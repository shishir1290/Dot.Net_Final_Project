using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;

namespace BLL.Services
{
    public class OrderService
    {
        public static OrderDTO Create(OrderDTO order, int id)
        {

            order.BuyerId = id;
            order.Status = "Pending";

            var cfg = new MapperConfiguration(c => c.CreateMap<OrderDTO, Order>());
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Order>(order);

            var data = DataAccessFactory.OrderData().Create(mapped);

            var cfg2 = new MapperConfiguration(c => c.CreateMap<Order, OrderDTO>());
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<OrderDTO>(data);

            return mapped2;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/

        public static OrderDTO Get(int id)
        {
            var data = DataAccessFactory.OrderData().Read(id);

            var cfg = new MapperConfiguration(c => c.CreateMap<Order, OrderDTO>());
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);

            return mapped;
        }
    }
}
