using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification() 
        {
            AddInclude(p => p.Categoria);
            AddInclude(P => P.Marca);
        }

         public ProductoWithCategoriaAndMarcaSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(P => P.Marca);
        }
    }
}
