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

        public static IRepo<Products, int, Products> ProductsData()
        {
            return new ProductsRepo();
        }

        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }

        public static IRepo<Sellers, int, Sellers> SellersData()
        {
            return new SellerRepo();
        }

        public static IAuth<Buyer> AuthData()
        {
            return new BuyerRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
               return new TokenRepo();
        }

        public static IRepo<Brand, int, Brand> BrandData()
        {
            return new BrandRepo();
        }

        public static IRepo<Category, int, Category> CategoryData()
        {
            return new CategoryRepo();
        }

        public static IRepo<Review, string, Review> ReviewData()
        {
            return new ReviewRepo();
        }
    }
}
