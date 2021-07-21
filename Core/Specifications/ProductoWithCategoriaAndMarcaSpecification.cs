using Core.Entities;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification(ProductoSpecificationParams productoParams)
            : base(x =>
            (string.IsNullOrEmpty(productoParams.Search) || x.Nombre.Contains(productoParams.Search)) &&
            (!productoParams.Marca.HasValue || x.MarcaId == productoParams.Marca) &&
            (!productoParams.Categoria.HasValue || x.CategoriaId == productoParams.Categoria)
            )

        {
            AddInclude(p => p.Categoria);
            AddInclude(P => P.Marca);

            /*ApplyPaging(0 ,2) ==> desde la posición 0 toma 2 registros
             * http://localhost:20122/api/producto?pageIndex=1&pageSize=2
             */
            ApplyPaging(productoParams.PageSize * (productoParams.PageIndex - 1), productoParams.PageSize);

            if (!string.IsNullOrEmpty(productoParams.Sort))
            {
                switch (productoParams.Sort)
                {
                    case "NombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "NombreDesc":
                        AddOrderByDescending(p => p.Nombre);
                        break;
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDescending(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderByDescending(p => p.Descripcion);
                        break;
                    case "stockAsc":
                        AddOrderBy(p => p.Stock);
                        break;
                    case "stockDesc":
                        AddOrderByDescending(p => p.Stock);
                        break;
                    default:
                        AddOrderBy(p => p.Nombre);
                        break;
                }
            }
        }
        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(P => P.Marca);
        }
    }
}