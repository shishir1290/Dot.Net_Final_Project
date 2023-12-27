using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey("Product")]
        public string Products { get; set; }

        public virtual ICollection<Products> Product { get; set; }
        public Category()
        {
            Product = new List<Products>();
        }
    }
}
