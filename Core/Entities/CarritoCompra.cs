using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CarritoCompra
    {
        public CarritoCompra()
        {

        }
        public CarritoCompra(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<CarritoItem> items { get; set; }  = new List<CarritoItem>();
    }
}
