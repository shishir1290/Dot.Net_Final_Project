using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class OrderService
    {
        public static OrderDTO Create(OrderDTO order, int id)
        {
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            order.BuyerId = id;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDTO, Order>()
                    .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.ProductIds));
            });

            var mapper = new Mapper(cfg);
            var mappedOrder = mapper.Map<Order>(order);

            var data = DataAccessFactory.OrderData().Create(mappedOrder);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>()
                    .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.ProductIds));
            });

            var mapper2 = new Mapper(cfg2);
            var mappedOrderDTO = mapper2.Map<OrderDTO>(data);

            return mappedOrderDTO;
        }

        public static List<OrderDTO> GetByBuyerId(int buyerId)
        {
            var data = DataAccessFactory.OrderData().SearchByCategory(buyerId);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>()
                    .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.ProductIds));
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDTO>>(data);

            return mapped;
        }
    }
}
