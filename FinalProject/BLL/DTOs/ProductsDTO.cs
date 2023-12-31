﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.DTOs
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public int CategoryId { get; set; }

       public int BrandId { get; set; }

        public int SellerId { get; set; }
    }
}
