using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class OrderRepo : Repos, IRepo<Order, int, Order>
    {
        public Order Create(Order obj)
        {
            obj.OrderDate = DateTime.Now;
            obj.Status = "Pending";
            
            db.Orders.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Orders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        /*-------------------------------------------------------------------------------------*/

        

        /*-------------------------------------------------------------------------------------*/

        public List<Order> Read()
        {
            return db.Orders.ToList();
        }

        public Order Read(int id)
        {
            return db.Orders.FirstOrDefault(p => p.BuyerId == id);
        }


        public Order Update(Order obj, int id)
        {
            throw new NotImplementedException();
        }



        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

        public List<Order> SearchByCategory(int Id)
        {
            return db.Orders.Where(p => p.BuyerId == Id).ToList();
        }

        public List<Order> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Order> SearchByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public Order ReadToken(string tokenString)
        {
            throw new NotImplementedException();
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
