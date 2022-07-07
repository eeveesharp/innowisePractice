using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Shop.DAL.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
