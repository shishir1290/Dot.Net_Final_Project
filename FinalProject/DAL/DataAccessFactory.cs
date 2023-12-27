using DAL.EF.Model;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Buyer, int, Buyer> BuyerData()
        {
            return new BuyerRepo();
        }

        public static IRepo<Products, int, Products> ProductData()
        {
            return new ProductRepo();
        }

        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }

        public static IAuth<Buyer> AuthData()
        {
            return new BuyerRepo();
        }
    }
}
